using System.Collections.Generic;

namespace OOP2022Lab1
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_сalc = new System.Windows.Forms.Button();
            this.btn_help = new System.Windows.Forms.Button();
            this.lbl_calc = new System.Windows.Forms.Label();
            this.lbl_help = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_сalc
            // 
            this.btn_сalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_сalc.Location = new System.Drawing.Point(1100, 550);
            this.btn_сalc.Name = "btn_сalc";
            this.btn_сalc.Size = new System.Drawing.Size(150, 40);
            this.btn_сalc.TabIndex = 0;
            this.btn_сalc.Text = "Значення";
            this.btn_сalc.UseVisualStyleBackColor = true;
            this.btn_сalc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // btn_help
            // 
            this.btn_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_help.Location = new System.Drawing.Point(13, 553);
            this.btn_help.Name = "btn_help";
            this.btn_help.Size = new System.Drawing.Size(111, 37);
            this.btn_help.TabIndex = 1;
            this.btn_help.Text = "Допомога";
            this.btn_help.UseVisualStyleBackColor = true;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // lbl_calc
            // 
            this.lbl_calc.AutoSize = true;
            this.lbl_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_calc.Location = new System.Drawing.Point(1100, 500);
            this.lbl_calc.Name = "lbl_calc";
            this.lbl_calc.Size = new System.Drawing.Size(0, 25);
            this.lbl_calc.TabIndex = 2;
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_help.Location = new System.Drawing.Point(17, 430);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.Size = new System.Drawing.Size(0, 25);
            this.lbl_help.TabIndex = 3;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 600);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.lbl_calc);
            this.Controls.Add(this.btn_help);
            this.Controls.Add(this.btn_сalc);
            this.Name = "Form";
            this.Text = "Spreadsheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        //this.textBox1.ReadOnly = true;
        #endregion
        private void initializeTextBoxes()
        {
            this.textBoxes = new System.Windows.Forms.TextBox[10, 10];
            this.SuspendLayout();
            this.CellPairs = new CellPair[10, 10];
            for (uint row = 0; row < 10; row++)
            {
                for (uint col = 0; col < 10; col++)
                {
                    this.textBoxes[row, col] = new System.Windows.Forms.TextBox();
                    this.textBoxes[row, col].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    this.textBoxes[row, col].Location = new System.Drawing.Point(1 + 150 * (int)col, 1 + 35 * (int)row);
                    this.textBoxes[row, col].Name = "textBoxes";
                    this.textBoxes[row, col].Size = new System.Drawing.Size(150, 35);
                    this.textBoxes[row, col].TabIndex = 0;
                    this.CellPairs[row, col] = new CellPair();
                    this.CellPairs[row, col].box = textBoxes[row, col];
                    this.CellPairs[row, col].tiedCell = Table.getCell(row, col);
                }
            }
        }

        private void initializeControls()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.Controls.Add(this.textBoxes[i, j]);
                }
            }
        }

        private CellPair[,] CellPairs;
        private System.Windows.Forms.TextBox[,] textBoxes;
        private System.Windows.Forms.Button btn_сalc;
        private System.Windows.Forms.Label lbl_calc;
        private System.Windows.Forms.Label lbl_help;
        private System.Windows.Forms.Button btn_help;
    }
}

