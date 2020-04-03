using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver {
	internal class Square {
		private bool[] isPossible;

		internal Square(int value) {
			isPossible = new bool[Sudoku.SIZE];
			for (int i = 0; i < isPossible.Count(); i++) {
				if (value == 0) {
					isPossible[i] = true;
				}
				else {
					if (value == i + 1) {
						isPossible[i] = true;
					}
					else {
						isPossible[i] = false;
					}
				}
			}
		}

		// Returns true if there is only one possiblity.
		internal bool IsSolved() {
			return (isPossible.Count(b => b == true) == 1);
		}

		// Returns true if and only if there is a change is the possible values.
		internal bool Eliminate(int value) {
			int index = value - 1;
			// Value has already been eliminated.
			if (!isPossible[index]) {
				return false;
			}
			//Value is only one possible
			else if (IsSolved()) {
				return false;
			}
			// Eliminate value.
			else {
				isPossible[index] = false;
				return true;
			}
		}

		/* If there is only one possible value, returns that value. Otherwise,
		 * returns 0
		 */
		internal int GetValue() {
			if (isPossible.Count(b => b == true) > 1) {
				return 0;
			}
			else {
				int index = Array.IndexOf(isPossible, true);
				return index + 1;
			}
		}

		override
		public string ToString() {
			return GetValue().ToString();
		}
	}
}
