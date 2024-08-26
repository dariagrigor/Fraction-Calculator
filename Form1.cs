using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab13GUI_Grigorovich__Daria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.KeyPress += textBox_KeyPress;
            textBox2.KeyPress += textBox_KeyPress;
            textBox3.KeyPress += textBox_KeyPress;
            textBox4.KeyPress += textBox_KeyPress;

            radioButton1.CheckedChanged += radioButton_CheckedChanged;
            radioButton2.CheckedChanged += radioButton_CheckedChanged;
            radioButton3.CheckedChanged += radioButton_CheckedChanged;
            radioButton4.CheckedChanged += radioButton_CheckedChanged;

            //Tab indexes
            textBox1.TabIndex = 0;
            textBox2.TabIndex = 1;
            radioButton3.TabIndex = 2;
            radioButton1.TabIndex = 3;
            radioButton2.TabIndex = 4;
            radioButton4.TabIndex = 5;
            textBox3.TabIndex = 6;
            textBox4.TabIndex = 7;
            button1.TabIndex = 8;
            //Stop for disabled textboxes
            textBox5.TabStop = false;
            textBox6.TabStop = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                string operation = radioButton.Text;

                DoCalculation();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DoCalculation();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoCalculation()
        {
            // Radio buttons to choose the calculation
            string operation = "";
            if (radioButton1.Checked)
            {
                operation = "+";
            }
            else if (radioButton2.Checked)
            {
                operation = "-";
            }
            else if (radioButton3.Checked)
            {
                operation = "*";
            }
            else if (radioButton4.Checked)
            {
                operation = "/";
            }
            else
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                return;
            }

            if (int.TryParse(textBox1.Text, out int numerator1) &&
                int.TryParse(textBox2.Text, out int denominator1) &&
                int.TryParse(textBox3.Text, out int numerator2) &&
                int.TryParse(textBox4.Text, out int denominator2))
            {
                Fraction fraction1 = new Fraction(numerator1, denominator1);
                Fraction fraction2 = new Fraction(numerator2, denominator2);
                Fraction result = null;

                switch (operation)
                {
                    case "+":
                        result = fraction1 + fraction2;
                        break;
                    case "-":
                        result = fraction1 - fraction2;
                        break;
                    case "*":
                        result = fraction1 * fraction2;
                        break;
                    case "/":
                        if (denominator2 != 0)
                        {
                            result = fraction1 / fraction2;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero.");
                            return;
                        }
                        break;
                }

                if (result != null)
                {
                    textBox5.Text = result.Top.ToString();
                    textBox6.Text = result.Bottom.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid fractions.");
            }
        }
    }
}
