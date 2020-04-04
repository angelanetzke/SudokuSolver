using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver {
	internal class Set {
		private List<Square> squares;

		internal Set() {
			squares = new List<Square>();
		}

		internal void Add(Square s) {
			squares.Add(s);
		}

		internal int[] GetValuesAsArray() {
			int[] valuesArray = new int[Sudoku.SIZE];
			for (int i = 0; i < squares.Count; i++) {
				valuesArray[i] = squares.ElementAt<Square>(i).GetValue();
			}
			return valuesArray;
		}

		internal bool Process() {
			// Set has already been completely solved. Return false to indicate no change.			
			if (squares.Count(s => s.IsSolved()) == squares.Count()) {
				return false;
			}
			else {
				bool madeChange = false;
				foreach (Square s in squares) {
					if (s.GetValue() > 0) {
						if (EliminateFromAll(s.GetValue())) {
							madeChange = true;
						}
					}
				}
				return madeChange;
			}			
		}

		private bool EliminateFromAll(int value) {
			bool madeChange = false;
			foreach (Square s in squares) {
				if (s.Eliminate(value)) {
					madeChange = true;
				}
			}
			return madeChange;
		}

		// Checks if Set contains valid solution
		internal bool IsValid() {
			bool isValid = true;
			for (int i = 1; i <= Sudoku.SIZE; i++) {
				if (squares.Count(s => s.GetValue() == i) != 1) {
					isValid = false;
				}
			}
			return isValid;
		}
	}
}
