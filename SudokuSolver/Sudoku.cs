using System;
using System.Collections.Generic;

namespace SudokuSolver {
	public class Sudoku {
		internal static readonly int SIZE = 9;
		private static readonly int SIZE_SQRT = 3;
		private readonly Set[] rows;
		private readonly Set[] columns;
		private readonly Set[] regions;

		public Sudoku(int[] values) {
			rows = new Set[SIZE];
			for (int i = 0; i < SIZE; i++) {
				rows[i] = new Set();
			}
			columns = new Set[SIZE];
			for (int i = 0; i < SIZE; i++) {
				columns[i] = new Set();
			}
			regions = new Set[SIZE];
			for (int i = 0; i < SIZE; i++) {
				regions[i] = new Set();
			}
			for (int i = 0; i < values.Length; i++) {
				Square newSquare = new Square(values[i]);
				rows[GetRow(i)].Add(newSquare);
				columns[GetColumn(i)].Add(newSquare);
				regions[GetRegion(i)].Add(newSquare);
			}
			Solve();
		}

		private int GetRow(int index) {
			return index / SIZE;
		}

		private int GetColumn(int index) {
			return index % SIZE;
		}

		private int GetRegion(int index) {
			return SIZE_SQRT * (GetRow(index) / SIZE_SQRT) + GetColumn(index) / SIZE_SQRT;
		}

		private void Solve() {
			DisplayPuzzle(); //For testing. Delete.
			bool keepSolving = true;
			while(keepSolving) {
				keepSolving = false;
				foreach (Set s in rows) {
					if (s.Process()) {
						keepSolving = true;
					}
				}
				foreach (Set s in columns) {
					if (s.Process()) {
						keepSolving = true;
					}
				}
				foreach (Set s in regions) {
					if (s.Process()) {
						keepSolving = true;
					}
				}
			}
			DisplayPuzzle(); //For testing. Delete.
		}

		private void DisplayPuzzle() {
			foreach (Set s in rows) {
				foreach (int i in s.GetValuesAsArray()) {
					System.Diagnostics.Debug.Write($"{i} ");
				}
				System.Diagnostics.Debug.WriteLine("");
			}
			if (IsValid()) {
				System.Diagnostics.Debug.WriteLine("Solved");
			}
			else {
				System.Diagnostics.Debug.WriteLine("Not Solved");
			}
		}

		private bool IsValid() {
			bool isValid = true;
			foreach (Set s in rows) {
				if (!s.IsValid()) {
					isValid = false;
				}
			}
			foreach (Set s in columns) {
				if (!s.IsValid()) {
					isValid = false;
				}
			}
			foreach (Set s in regions) {
				if (!s.IsValid()) {
					isValid = false;
				}
			}
			return isValid;
		}
	}
}