namespace SudokuSolver_CSP
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.BtSolve = new System.Windows.Forms.Button();
            this.BtReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.AllowUserToDeleteRows = false;
            this.DataTable.AllowUserToResizeColumns = false;
            this.DataTable.AllowUserToResizeRows = false;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataTable.Location = new System.Drawing.Point(12, 12);
            this.DataTable.Name = "DataTable";
            this.DataTable.RowHeadersVisible = false;
            this.DataTable.Size = new System.Drawing.Size(453, 453);
            this.DataTable.TabIndex = 0;
            // 
            // BtSolve
            // 
            this.BtSolve.Location = new System.Drawing.Point(471, 67);
            this.BtSolve.Name = "BtSolve";
            this.BtSolve.Size = new System.Drawing.Size(152, 49);
            this.BtSolve.TabIndex = 1;
            this.BtSolve.Text = "Solve";
            this.BtSolve.UseVisualStyleBackColor = true;
            this.BtSolve.Click += new System.EventHandler(this.BtSolve_Click);
            // 
            // BtReset
            // 
            this.BtReset.Location = new System.Drawing.Point(471, 12);
            this.BtReset.Name = "BtReset";
            this.BtReset.Size = new System.Drawing.Size(152, 49);
            this.BtReset.TabIndex = 2;
            this.BtReset.Text = "Reset";
            this.BtReset.UseVisualStyleBackColor = true;
            this.BtReset.Click += new System.EventHandler(this.BtReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 472);
            this.Controls.Add(this.BtReset);
            this.Controls.Add(this.BtSolve);
            this.Controls.Add(this.DataTable);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Button BtSolve;
        private System.Windows.Forms.Button BtReset;
    }
}

