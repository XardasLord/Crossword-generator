using System.IO;
using System.Windows.Forms;

namespace Crossword_generator
{
    public partial class Crossword : Form
    {
        private CrosswordManager _crosswordManager;
        private Board _board;
        private CrosswordInformation _crosswordInformation;
        private string _pathToWorldList = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\DictionaryWordList.txt";

        public Crossword()
        {
            _crosswordManager = new CrosswordManager();
            _crosswordManager.LoadWords(_pathToWorldList);

            InitializeComponent();
        }

        private void btnGenerateCrossword_Click(object sender, System.EventArgs e)
        {
            var dialog = new GenerateCrossword();
            dialog.ShowDialog();

            _crosswordInformation = dialog.crosswordInformation;

            _board = _crosswordManager.GenerateCrossword(_crosswordInformation);

            DrawBoard();
            FillLetters();
        }

        private void DrawBoard()
        {
            for (var i = 0; i < _board.Columns; i++)
                dgvBoard.Columns.Add(new DataGridViewTextBoxColumn());

            dgvBoard.Rows.Add(_board.Rows);

            foreach (DataGridViewColumn column in dgvBoard.Columns)
                column.Width = dgvBoard.Width / dgvBoard.Columns.Count;

            foreach (DataGridViewRow row in dgvBoard.Rows)
                row.Height = dgvBoard.Height / dgvBoard.Rows.Count;
        }

        private void FillLetters()
        {
            for(var row = 0; row < _board.Rows; row++)
            {
                for(var col = 0; col < _board.Columns; col++)
                {
                    dgvBoard[col, row].Value = _board.BoardArea[row, col];
                    dgvBoard[col, row].Style.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}
