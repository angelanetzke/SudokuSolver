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
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		/* Create array from values entered into form. Assign a value of 0 for
		 * values that have not been assigned. */
		private void submitButton_Click(object sender, EventArgs e) {
			int[] values = new int[81];
			foreach (Control parentControl in this.Controls) {
				if (parentControl is GroupBox) {
					foreach (Control childControl in parentControl.Controls) {
						if (childControl is ComboBox) {
							ComboBox thisComboBox = childControl as ComboBox;
							int index = int.Parse(thisComboBox.Name.Split('_')[1]);
							int thisValue;
							bool isNumber = int.TryParse(thisComboBox.Text, out thisValue);
					        if (!isNumber) {
								thisValue = 0;
							}
							values[index] = thisValue;
						}
					}					
				}
			}
			Sudoku puzzle = new Sudoku(values);
		}
	}
}
