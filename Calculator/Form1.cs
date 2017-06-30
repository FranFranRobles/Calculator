using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private char[] mathTokens = { '+', '-', '*', '/', '^', '%', '.' }; //P-E-MD-AS

        public Form1()
        {
            InitializeComponent();

        }

        private void equal_Click(object sender, EventArgs e)
        {
            Calculate calc = new Calculate();
            calc.parse(display.Text);
            display.Text = calc.evaluate().ToString();
        }

        private void Modulus_Click(object sender, EventArgs e)
        {
            if ((display.Text.Count() > 0) && (Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1))
            {
                display.Text += "%";
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            display.Text = "";
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            display.Text = display.Text.Substring(0, display.Text.Count() - 1);
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += "+";
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += "-";
            }
        }
        private void divide_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += "/";
            }
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += "*";
            }
        }

        private void one_Click(object sender, EventArgs e)
        {
            display.Text += "1";
        }

        private void two_Click(object sender, EventArgs e)
        {
            display.Text += "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            display.Text += "3";
        }
        private void four_Click(object sender, EventArgs e)
        {
            display.Text += "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            display.Text += "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            display.Text += "6";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            display.Text += "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            display.Text += "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            display.Text += "9";
        }
        private void zero_Click(object sender, EventArgs e)
        {
            display.Text += "0";
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += ".";
            }
        }

        private void openPrnt_Click(object sender, EventArgs e)
        {
            display.Text += "(";
        }

        private void closePrnt_Click(object sender, EventArgs e)
        {
            display.Text += ")";
        }

        private void square_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += "^2";
            }
        }

        private void squareRoot_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += "^.5";
            }
        }

        private void toThePowerOf_Click(object sender, EventArgs e)
        {
            if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
            {
                display.Text += "^";
            }
        }

        private void pi_Click(object sender, EventArgs e)
        {
            display.Text += "p";
        }

        private void log_Click(object sender, EventArgs e)
        {
            display.Text += "L";
        }

        private void calcKeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    display.Text += "0";
                    break;
                case Keys.D0:
                    display.Text += "0";
                    break;
                case Keys.NumPad1:
                    display.Text += "1";
                    break;
                case Keys.D1:
                    display.Text += "1";
                    break;
                case Keys.NumPad2:
                    display.Text += "2";
                    break;
                case Keys.D2:
                    display.Text += "2";
                    break;
                case Keys.NumPad3:
                    display.Text += "3";
                    break;
                case Keys.D3:
                    display.Text += "3";
                    break;
                case Keys.NumPad4:
                    display.Text += "4";
                    break;
                case Keys.D4:
                    display.Text += "4";
                    break;
                case Keys.NumPad5:
                    display.Text += "5";
                    break;
                case Keys.D5:
                    display.Text += "5";
                    break;
                case Keys.NumPad6:
                    display.Text += "6";
                    break;
                case Keys.D6:
                    display.Text += "6";
                    break;
                case Keys.NumPad7:
                    display.Text += "7";
                    break;
                case Keys.D7:
                    display.Text += "7";
                    break;
                case Keys.NumPad8:
                    display.Text += "8";
                    break;
                case Keys.D8:
                    display.Text += "8";
                    break;
                case Keys.NumPad9:
                    display.Text += "9";
                    break;
                case Keys.D9:
                    display.Text += "9";
                    break;
                case Keys.Add:
                    if ((display.Text.Count() > 0) && (Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1))
                    {
                        display.Text += "+";
                    }
                    break;
                case Keys.Subtract:
                    if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
                    {
                        display.Text += "-";
                    }
                    break;
                case Keys.Multiply:
                    if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
                    {
                        display.Text += "*";
                    }
                    break;
                case Keys.Divide:
                    if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
                    {
                        display.Text += "/";
                    }
                    break;
                case Keys.OemBackslash:
                    if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
                    {
                        display.Text += "^";
                    }
                    break;
                case Keys.L:
                    display.Text += "l";
                    break;
                case Keys.Decimal:
                    if (display.Text.Count() > 0 && Array.IndexOf(mathTokens, display.Text[display.Text.Count() - 1]) == -1)
                    {
                        display.Text += ".";
                    }
                    break;
                case Keys.Enter:
                    Calculate calc = new Calculate();
                    calc.parse(display.Text);
                    display.Text = calc.evaluate().ToString();
                    break;
                case Keys.E:
                    display.Text += "e";
                    break;
                case Keys.P:
                    display.Text += "p";
                    break;
                case Keys.Delete:
                    display.Text = "";
                    break;
                case Keys.Back:
                    if (display.Text.Count() > 0)
                    {
                        display.Text = display.Text.Substring(0, display.Text.Count() - 1);
                    }
                    break;
                default:
                    break;
            }
            e.Handled = true;
        }
        private void natLogClick(object sender, EventArgs e)
        {
            display.Text += "l";
        }
        private void natNumE(object sender, EventArgs e)
        {
            display.Text += "e";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
