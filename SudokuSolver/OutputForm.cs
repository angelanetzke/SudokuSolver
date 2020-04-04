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
	public partial class OutputForm : Form {
		public OutputForm() {
			InitializeComponent();
		}

		public OutputForm(int[] values) {
			InitializeComponent();
			foreach(Control c in this.Controls) {
				if (c is Label) {
					Label thisLabel =  c as Label;
					int index = int.Parse(thisLabel.Name.Split('_')[1]);
					thisLabel.Text = values[index].ToString();
				}
			}
		}
	}
}
