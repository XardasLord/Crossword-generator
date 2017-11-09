using System.IO;
using System.Windows.Forms;

namespace Crossword_generator
{
    public partial class Crossword : Form
    {
        private CrosswordManager crosswordManager;
        private Board board;
        private string pathToWorldList = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\DictionaryWordList.txt";

        public Crossword()
        {
            crosswordManager = new CrosswordManager();
            crosswordManager.LoadWords(pathToWorldList);

            //TODO: Initialize just for test
            board = new Board(10,10);

            InitializeComponent();
        }

        //TODO: Draw board just for test to see if it draws correctly depends on rows and columns on the 'board' object
        private void Crossword_Shown(object sender, System.EventArgs e)
        {
            for (var i = 0; i < board.Columns; i++)
                dgvBoard.Columns.Add(new DataGridViewTextBoxColumn());
            
            dgvBoard.Rows.Add(board.Rows);

            foreach (DataGridViewColumn column in dgvBoard.Columns)
                column.Width = dgvBoard.Width / dgvBoard.Columns.Count;

            foreach (DataGridViewRow row in dgvBoard.Rows)
                row.Height = dgvBoard.Height / dgvBoard.Rows.Count;
        }
    }
}
