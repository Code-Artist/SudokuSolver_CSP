# SudokuSolver_CSP
## About CSP
A constraint search does not refer to any specific search algorithm but to a layer of complexity added to existing algorithms that limit the possible solution set. A Constraint Search Problem (CSP) is an Artificial Intelligence Algorithm defined by a set of variables and a set of constraints where each variable has a non empty domain of possible values. Each domain in variable is evaluated with defined constraints.

## CSP Sudoku Solver
C# Sudoku Solver is an example implementation using CSP search algorithm. The code is optimized to solve 9 x 9 sudoku in 1ms.

![Sudoku_Solver](https://github.com/Code-Artist/SudokuSolver_CSP/assets/1674648/ec653748-5ea3-470b-a0dc-3a4f7147b790)

### Forward Checking
A define flag FORWARD_CHECKING in code is used to enable / disable forward checking to eliminate domains in variables which does not comply with defined constraints.

### Animation
To visualize search algorithm execution, subscribe to CellValueChanged event in MainForm constructor to show value change on each iteration. Disable this line to get maximum performance of the algorithm.

### Reference
[Constraint Satisfaction Problems (CSP) in Artificial Intelligence](https://github.com/Code-Artist/SudokuSolver_CSP/new/main?readme=1)
