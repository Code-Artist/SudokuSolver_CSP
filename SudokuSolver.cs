using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//#define OPTIMIZE_VAR

namespace SudokuSolver_CSP
{
    internal class SudokuCell
    {
        public SudokuCell(int x, int y) : this(x, y, 0) { }
        public SudokuCell(int x, int y, int value)
        {
            X = x; Y = y; Value = value;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
    }

    /// <summary>
    /// Possible Values for each non empty cells
    /// </summary>
    internal class Variable
    {
        public Variable(int x, int y) { X = x; Y = y; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<int> Values = Enumerable.Range(1, 9).ToList();
    }

    /// <summary>
    /// Constraints for possible puzzle solution
    /// </summary>
    internal class Constraint
    {
        public Constraint(int x, int y) { X = x; Y = y; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<SudokuCell> Cells = new List<SudokuCell>();
    }

    internal class SudokuCellEventArgs : EventArgs
    {
        public SudokuCell Cell;
    }

    internal class SudokuSolver
    {
        public int Size { get; private set; }
        public List<SudokuCell> Cells { get; set; } = new List<SudokuCell>();
        public List<Variable> Variables = new List<Variable>();
        public List<Constraint> Constraints = new List<Constraint>();

        public event EventHandler<SudokuCellEventArgs> CellValueChanged;

        public int SolvedCells { get => Cells.Where(c => c.Value != 0).Count(); }

        public SudokuSolver(int size) { Size = size; }

        public void LoadPuzzle(DataGridView table)
        {
            Cells.Clear();
            foreach (DataGridViewRow r in table.Rows)
            {
                foreach (DataGridViewCell c in r.Cells)
                {
                    int v = 0;
                    if (c.Value != null) v = Convert.ToInt16(c.Value);
                    Cells.Add(new SudokuCell(c.ColumnIndex, c.RowIndex, v));
                }
            }
            InitConstraints();
        }

        public bool Solve()
        {
            InitVariables();

            DateTime tNow = DateTime.Now;
            bool status = BackTrack(0);
            Trace.WriteLine("Solved in " + (DateTime.Now - tNow).TotalMilliseconds + " ms");
            return status;
        }

        private bool BackTrack(int index)
        {
            Variable ptrVar = GetNextVariable(index++);
            if (ptrVar == null) return true;

            Constraint ptrConstraint = Constraints.First(c => c.X == ptrVar.X && c.Y == ptrVar.Y);
            if (ptrVar == null) return false;
            SudokuCell ptrCell = Cells.First(c => c.X == ptrVar.X && c.Y == ptrVar.Y);
            foreach (int v in ptrVar.Values)
            {
                if (EvaluateConstraint(ptrVar, ptrConstraint, v))
                {
                    ptrCell.Value = v;
                    CellValueChanged?.Invoke(this, new SudokuCellEventArgs() { Cell = ptrCell });
                    if (BackTrack(index)) 
                        return true;
                    ptrCell.Value = 0;
                }
            }
            return false;
        }

        private Variable GetNextVariable(int index)
        {
            if (index == Variables.Count) return null;
            return Variables[index];
        }

        private void InitVariables()
        {
            //ToDo: Init variable exclude values exists in Constraint. How much will gain?
            Variables.Clear();
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (Cells.First(c => c.X == x && c.Y == y).Value == 0)
                    {
                        Variable v = new Variable(x, y);
                        Variables.Add(v);
#if OPTIMIZE_VAR
                        //Another 5ms if without this.
                        Constraint c = Constraints.First(r => r.X == v.X && r.Y == v.Y);
                        for(int n=0; n < v.Values.Count; n++)
                        {
                            if (!EvaluateConstraint(v, c, v.Values[n]))
                                v.Values.RemoveAt(n--);
                        }
#endif
                    }
                }
            }
            Variables = Variables.OrderBy(s => s.Values.Count).ToList();
        }

        /// <summary>
        /// Initialize constraint for each cell. 
        /// Execute once puzzle table changed.
        /// </summary>
        private void InitConstraints()
        {
            Constraints.Clear();
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Constraint s = new Constraint(x, y);
                    SudokuCell c = Cells.First(n => n.X == x && n.Y == y);
                    s.Cells.AddRange(Cells.Where(r => r.X == x)); //Row Constraint
                    s.Cells.AddRange(Cells.Where(r => r.Y == y)); //Column Constraint

                    //Section Constraint
                    int startX = x / 3 * 3;
                    int startY = y / 3 * 3;

                    for (int i = startX; i < startX + 3; i++)
                    {
                        for (int j = startY; j < startY + 3; j++)
                        {
                            s.Cells.Add(Cells.First(l => l.X == i && l.Y == j));
                        }
                    }

                    s.Cells = s.Cells.Distinct().ToList();
                    s.Cells.Remove(c);
                    if (s.Cells.Count != 20) throw new Exception("Invalid Constraints!");
                    Constraints.Add(s);
                }
            }
        }

        /// <summary>
        /// Evaluate Constraint, return false if value exists.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="r"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool EvaluateConstraint(Variable v, Constraint r, int value)
        {
            foreach (SudokuCell c in r.Cells)
            {
                if (c.Value == value) return false;
            }

            return true;
        }
    }
}
