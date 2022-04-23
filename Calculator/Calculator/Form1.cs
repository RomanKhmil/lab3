using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Calculator
{
    public partial class FormCalc : Form
    {
        public FormCalc()
        {
            InitializeComponent();
        }

        private double tempNumber = 0;
        private string errorMessage = "";

        

        

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                textBoxExpression.Text += ((Button)sender).Text;

            }
        }

        private void CloseByEsc(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                buttonCalc_Click(null, null);
            }
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if (textBoxExpression.Text.Length == 0) return;

            AnalaizerClass.AnalaizerClass analyzer = new AnalaizerClass.AnalaizerClass(textBoxExpression.Text);
            try
            {
                string res = analyzer.Estimate();
                textBoxResult.Text = res;
            }
            catch (Exception exception)
            {
                errorMessage = analyzer.lastError == "" ? exception.Message : analyzer.lastError;
                textBoxResult.Text = errorMessage;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text = "";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            String expr = textBoxExpression.Text;
            if (expr.Length > 0)
            {
                if (expr.EndsWith("mod"))
                {
                    textBoxExpression.Text = expr.Remove(expr.Length - 3);
                }
                else
                {
                    textBoxExpression.Text = expr.Remove(expr.Length - 1);
                }
            }
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text = textBoxExpression.Text + tempNumber.ToString();
        }

        private void buttonMpluss_Click(object sender, EventArgs e)
        {
            double number;
            if (Double.TryParse(textBoxResult.Text, out number))
            {
                tempNumber = tempNumber + Convert.ToDouble(textBoxResult.Text);
            }
            else
            {
                textBoxResult.Text = "Cannot be converted to a number";
            }
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            tempNumber = 0;
        }


        private void buttonUnar_Click(object sender, EventArgs e)
        {
            string expression = textBoxExpression.Text;
            if (expression == "") return;
            if (expression.StartsWith("m1*(") &&
                expression.EndsWith(")"))
            {
                expression = expression.Remove(0, 4);
                expression = expression.Remove(expression.Length - 1);
                textBoxExpression.Text = expression;
                return;
            }
            expression = "m1*(" + expression + ")";
            textBoxExpression.Text = expression;
        }
    }
}
