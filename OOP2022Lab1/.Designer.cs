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
            this.lbl_help = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
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
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_help.Location = new System.Drawing.Point(17, 400);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.Size = new System.Drawing.Size(0, 25);
            this.lbl_help.TabIndex = 3;
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_clear.Location = new System.Drawing.Point(1315, 550);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(149, 38);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "Очистити";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_about
            // 
            this.btn_about.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_about.Location = new System.Drawing.Point(274, 553);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(148, 35);
            this.btn_about.TabIndex = 5;
            this.btn_about.Text = "Про програму";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1550, 600);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lbl_help);
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
            this.rows_num = new System.Windows.Forms.TextBox[10];
            this.cols_num = new System.Windows.Forms.TextBox[10];
            this.SuspendLayout();
            this.CellPairs = new CellPair[10, 10];
            for (uint row = 0; row < 10; row++)
            {
                this.rows_num[row] = new System.Windows.Forms.TextBox();
                this.rows_num[row].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.rows_num[row].Location = new System.Drawing.Point(0, 35 + 35 * (int)row);
                this.rows_num[row].Name = "Row";
                this.rows_num[row].Enabled = false;
                this.rows_num[row].ReadOnly = true;
                this.rows_num[row].Size = new System.Drawing.Size(50, 35);
                this.rows_num[row].TabIndex = 0;
                this.rows_num[row].Text = row.ToString();
            }
            for (uint col = 0; col < 10; col++)
            {
                this.cols_num[col] = new System.Windows.Forms.TextBox();
                this.cols_num[col].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.cols_num[col].Location = new System.Drawing.Point(50 + 150 * (int)col, 0);
                this.cols_num[col].Name = "Col";
                this.cols_num[col].Enabled = false;
                this.cols_num[col].ReadOnly = true;
                this.cols_num[col].Size = new System.Drawing.Size(150, 35);
                this.cols_num[col].TabIndex = 0;
                this.cols_num[col].Text = ((char)(col + 'A')).ToString();
            }
            for (uint row = 0; row < 10; row++)
            {
                for (uint col = 0; col < 10; col++)
                {
                    this.textBoxes[row, col] = new System.Windows.Forms.TextBox();
                    this.textBoxes[row, col].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    this.textBoxes[row, col].Location = new System.Drawing.Point(50 + 150 * (int)col, 35 + 35 * (int)row);
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
            for (int i = 0; i < 10; i++)
            {
                this.Controls.Add(this.rows_num[i]);
                this.Controls.Add(this.cols_num[i]);
            }
        }
        private CellPair[,] CellPairs;
        private System.Windows.Forms.TextBox[,] textBoxes;
        private System.Windows.Forms.Button btn_сalc;
        private System.Windows.Forms.Label lbl_help;
        private System.Windows.Forms.Button btn_help;
        private System.Windows.Forms.TextBox[] rows_num;
        private System.Windows.Forms.TextBox[] cols_num;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_about;
    }
}

