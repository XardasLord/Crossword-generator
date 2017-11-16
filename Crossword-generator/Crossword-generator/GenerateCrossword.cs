using System;
using System.Windows.Forms;

namespace Crossword_generator
{
    public partial class GenerateCrossword : Form
    {
        public CrosswordInformation crosswordInformation { get; private set; }

        public GenerateCrossword()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text.Length < 3)
            {
                MessageBox.Show("Password has to contains at least 3 characters.", "Invalid password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var type = GetCrosswordType();
            crosswordInformation = new CrosswordInformation(txtPassword.Text, CrosswordType.Simple);

            DialogResult = DialogResult.OK;
        }

        private CrosswordType GetCrosswordType()
        {
            var type = CrosswordType.Simple;

            if (rbtSimpleCrossword.Checked)
                type = CrosswordType.Simple;

            return type;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
