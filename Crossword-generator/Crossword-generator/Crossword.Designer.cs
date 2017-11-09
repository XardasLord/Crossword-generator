namespace Crossword_generator
{
    partial class Crossword
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
            this.dgvBoard = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBoard
            // 
            this.dgvBoard.AllowUserToAddRows = false;
            this.dgvBoard.AllowUserToDeleteRows = false;
            this.dgvBoard.AllowUserToResizeColumns = false;
            this.dgvBoard.AllowUserToResizeRows = false;
            this.dgvBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoard.ColumnHeadersVisible = false;
            this.dgvBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoard.Location = new System.Drawing.Point(0, 0);
            this.dgvBoard.MultiSelect = false;
            this.dgvBoard.Name = "dgvBoard";
            this.dgvBoard.ReadOnly = true;
            this.dgvBoard.RowHeadersVisible = false;
            this.dgvBoard.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dgvBoard.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvBoard.Size = new System.Drawing.Size(584, 561);
            this.dgvBoard.TabIndex = 0;
            // 
            // Crossword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.dgvBoard);
            this.Name = "Crossword";
            this.ShowIcon = false;
            this.Text = "Crossword generator";
            this.Shown += new System.EventHandler(this.Crossword_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBoard;
    }
}

