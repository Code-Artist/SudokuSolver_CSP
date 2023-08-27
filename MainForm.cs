using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; 

//Sudoku solver using CSP (Constraint Satisfaction Problems) Algorithm.

namespace SudokuSolver_CSP
{
    public partial class MainForm : Form
    {
        private int SudokuSize = 9;
        private SudokuSolver Solver;

        public MainForm()
        {
            InitializeComponent();
            Solver = new SudokuSolver(SudokuSize);
            Solver.CellValueChanged += Solver_CellValueChanged;
            GeneratePuzzle();
        }

        private void Solver_CellValueChanged(object sender, SudokuCellEventArgs e)
        {
            DataTable.Rows[e.Cell.Y].Cells[e.Cell.X].Value = e.Cell.Value;
            Application.DoEvents();
            //Thread.Sleep(1);
        }

        private void InitTable()
        {
            DataTable.Columns.Clear();
            DataTable.Rows.Clear();

            for (int x = 0; x < SudokuSize; x++)
            {
                DataGridViewColumn ptrCol = DataTable.Columns[DataTable.Columns.Add("col" + x, x.ToString())];
                ptrCol.Width = 50;
            }

            for (int y = 0; y < SudokuSize; y++)
            {
                DataGridViewRow ptrRow = DataTable.Rows[DataTable.Rows.Add()];
                ptrRow.Height = 50;
            }
        }

        private void GeneratePuzzle()
        {
            InitTable();
            SetValue(0, 0, 5);
            SetValue(0, 1, 3);
            SetValue(0, 4, 7);

            SetValue(1, 0, 6);
            SetValue(1, 3, 1);
            SetValue(1, 4, 9);
            SetValue(1, 5, 5);

            SetValue(2, 1, 9);
            SetValue(2, 2, 8);
            SetValue(2, 7, 6);

            SetValue(3, 0, 8);
            SetValue(3, 4, 6);
            SetValue(3, 8, 3);

            SetValue(4, 0, 4);
            SetValue(4, 3, 8);
            SetValue(4, 5, 3);
            SetValue(4, 8, 1);

            SetValue(5, 0, 7);
            SetValue(5, 4, 2);
            SetValue(5, 8, 6);

            SetValue(6, 1, 6);
            SetValue(6, 6, 2);
            SetValue(6, 7, 8);

            SetValue(7, 3, 4);
            SetValue(7, 4, 1);
            SetValue(7, 5, 9);
            SetValue(7, 8, 5);

            SetValue(8, 4, 8);
            SetValue(8, 6, 7);

            Solver.LoadPuzzle(DataTable);
        }

        private void SetValue(int row, int col, int value)
        {
            DataTable.Rows[row].Cells[col].Value = value;
        }

        private void BtSolve_Click(object sender, EventArgs e)
        {
            if (Solver.Solve())
            {
                foreach (SudokuCell c in Solver.Cells)
                    DataTable.Rows[c.Y].Cells[c.X].Value = c.Value;
            }
            else MessageBox.Show("No Solution!");
        }



        private void BtReset_Click(object sender, EventArgs e)
        {
            GeneratePuzzle();
        }
    }
}
