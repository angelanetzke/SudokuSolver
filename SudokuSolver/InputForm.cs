using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver {
	public partial class InputForm : Form {
		public InputForm() {
			InitializeComponent();
		}

		/* Create array from values entered into form. Assign a value of 0 for
		 * values that have not been assigned. */
		private void submitButton_Click(object sender, EventArgs e) {
			int[] values = new int[81];
			foreach (Control c in this.Controls) {
				if (c is ComboBox) {
					ComboBox thisComboBox = c as ComboBox;
					int index = int.Parse(thisComboBox.Name.Split('_')[1]);
					bool isNumber = int.TryParse(thisComboBox.Text, out int thisValue);
					if (!isNumber) {
						thisValue = 0;
					}
					values[index] = thisValue;
				}
			}
			Sudoku puzzle = new Sudoku(values);
			if (puzzle.IsValid()) {
				label1.Text = "Solved!";
				label1.ForeColor = Color.Green;
				OutputForm outputForm = new OutputForm(puzzle.GetSolution());
				outputForm.Show();
			}
			else {
				label1.Text = "Invalid puzzle. Check inputs.";
				label1.ForeColor = Color.Red;
			}
			
		}
	}
}
