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

		/* Eliminate values that have already been filled in from other Squares in Set.
		 * Returns true if a change has been made (indicating that the program should
		 * continue to solve). Returns false if no change has been made (indicating
		 * that the program should terminate).
		 */ 
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

		/* Removes the given value as a possiblity from each Square
		 * in the Set (unless Square is already solved or value has
		 * already beeen eliminated from that Square.
		 */
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
