using System.IO;
using System.Windows.Forms;

namespace Crossword_generator
{
    public partial class Crossword : Form
    {
        private CrosswordManager crosswordManager;
        private Board board;
        private CrosswordInformation crosswordInformation;
        private string pathToWorldList = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\DictionaryWordList.txt";

        public Crossword()
        {
            crosswordManager = new CrosswordManager();
            crosswordManager.LoadWords(pathToWorldList);

            InitializeComponent();
        }

        private void DrawBoard()
        {
            for (var i = 0; i < board.Columns; i++)
                dgvBoard.Columns.Add(new DataGridViewTextBoxColumn());

            dgvBoard.Rows.Add(board.Rows);

            foreach (DataGridViewColumn column in dgvBoard.Columns)
                column.Width = dgvBoard.Width / dgvBoard.Columns.Count;

            foreach (DataGridViewRow row in dgvBoard.Rows)
                row.Height = dgvBoard.Height / dgvBoard.Rows.Count;
        }

        private void btnGenerateCrossword_Click(object sender, System.EventArgs e)
        {
            var dialog = new GenerateCrossword();
            dialog.ShowDialog();

            crosswordInformation = dialog.crosswordInformation;

            board = crosswordManager.GenerateCrossword(crosswordInformation);
        }
    }
}
