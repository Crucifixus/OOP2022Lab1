using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2022Lab1
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            initializeTextBoxes();
            InitializeComponent();
            initializeControls();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //wtf is this????? can I delete it???
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            if (lbl_help.Text == "")
            {
                lbl_help.Text = "Для того щоб порахувати що ви хочете, введіть вирази у клітинки і нажміть \"Значення\".\nКоли ви побачили що хотіли, можете нажати на \"Вирази\" і можете знову вводити вирази.\nРобота тільки з цілими числами, дозволені операції: + - * / ^ div(a, b) mod(a, b) inc(a) dec(a).";
            }
            else
            {
                lbl_help.Text = "";
            }
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            if (btn_сalc.Text == "Значення")
            {
                for (int i = 0; i < 100; ++i)
                {
                    CellPair currentPair = CellPairs[i / 10, i % 10];
                    currentPair.tiedCell.formula = currentPair.box.Text;
                }
                for (int i = 0; i < 100; ++i)
                {
                    //error processing and output may be cringe
                    CellPair currentPair = CellPairs[i / 10, i % 10];
                    CellValue temp = currentPair.tiedCell.calculate();
                    var val = temp as NumberValue;
                    if (val != null)
                    {
                        currentPair.box.Text = val.number.ToString();
                    }
                    else
                    {
                        var err = temp as ErrorValue;
                        if (err == null)
                        {
                            currentPair.box.Text = "NULL";
                        }
                        else
                        {
                            switch (err.code)
                            {
                                case ErrorValue.ErrorCode.OVERFLOW:
                                    currentPair.box.Text = "OVERFLOW";
                                    break;
                                case ErrorValue.ErrorCode.TYPE:
                                    currentPair.box.Text = "TYPE ERROR BUT HOW TF";
                                    break;
                                case ErrorValue.ErrorCode.REF_CYCLE:
                                    currentPair.box.Text = "REFERENCE CYCLE";
                                    break;
                                case ErrorValue.ErrorCode.DIV0:
                                    currentPair.box.Text = "DIVIDING BY 0";
                                    break;
                                case ErrorValue.ErrorCode.EMPTY:
                                    currentPair.box.Text = "EMPTY";
                                    break;
                                case ErrorValue.ErrorCode.VALUE:
                                    currentPair.box.Text = "VALUE ERROR (STRING)";
                                    break;
                                case ErrorValue.ErrorCode.PARENTHESES:
                                    currentPair.box.Text = "INCORRECT PARENTHESES";
                                    break;
                            }
                        }
                    }
                }
                btn_сalc.Text = "Вирази";
            }
            else
            {
                for (int i = 0; i < 100; ++i)
                {
                    var currentPair = CellPairs[i / 10, i % 10];
                    currentPair.tiedCell.formula = "";
                    currentPair.tiedCell.state = Cell.CalculationProgress.PENDING;
                    currentPair.tiedCell.value = new ErrorValue(ErrorValue.ErrorCode.EMPTY);
                    currentPair.box.Text = "";
                }
                btn_сalc.Text = "Значення";
            }
        }
    }
}
