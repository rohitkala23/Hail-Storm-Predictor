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
    public partial class CalculatorApp : Form
    {
        Double ResultValue = 0;
        String OperationPerformed = "";
        bool isOperationPerformed = false;   
        public CalculatorApp()
        {
            InitializeComponent();
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            if ((TxtBox.Text == "0") || isOperationPerformed)
                TxtBox.Clear();
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!TxtBox.Text.Contains(".") )
                    TxtBox.Text = TxtBox.Text + button.Text;
            }else
            TxtBox.Text = TxtBox.Text + button.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (ResultValue != 0)
            {
                EqualsBtn.PerformClick();
                OperationPerformed = button.Text;
                LabelCurrentOperation.Text = ResultValue + " " + OperationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                OperationPerformed = button.Text;
                ResultValue = Double.Parse(TxtBox.Text);
                LabelCurrentOperation.Text = ResultValue + " " + OperationPerformed;
                isOperationPerformed = true;
            }
        }

        private void ClrEntryBtn_Click(object sender, EventArgs e)
        {
            TxtBox.Text= "0";
        }

        private void ClrBtn_Click(object sender, EventArgs e)
        {
            TxtBox.Text = "0";
            ResultValue = 0;
        }

        private void EqualsBtn_Click(object sender, EventArgs e)
        {
            switch(OperationPerformed)
            {
                case "+":
                    TxtBox.Text = (ResultValue + Double.Parse(TxtBox.Text)).ToString();
                    break;
                case "-":
                    TxtBox.Text = (ResultValue - Double.Parse(TxtBox.Text)).ToString();
                    break;
                case "*":
                    TxtBox.Text = (ResultValue * Double.Parse(TxtBox.Text)).ToString();
                    break;
                case "/":
                    TxtBox.Text = (ResultValue / Double.Parse(TxtBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            ResultValue= Double.Parse(TxtBox.Text);
            LabelCurrentOperation.Text = "";
        }
    }
}
