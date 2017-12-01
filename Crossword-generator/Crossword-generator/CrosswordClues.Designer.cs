namespace Crossword_generator
{
    partial class CrosswordClues
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
            this.listOfClues = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listOfClues
            // 
            this.listOfClues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOfClues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listOfClues.GridLines = true;
            this.listOfClues.Location = new System.Drawing.Point(0, 0);
            this.listOfClues.Name = "listOfClues";
            this.listOfClues.Size = new System.Drawing.Size(400, 600);
            this.listOfClues.TabIndex = 0;
            this.listOfClues.UseCompatibleStateImageBehavior = false;
            this.listOfClues.View = System.Windows.Forms.View.Details;
            // 
            // CrosswordClues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.listOfClues);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrosswordClues";
            this.ShowIcon = false;
            this.Text = "Clues for the crossword";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listOfClues;
    }
}