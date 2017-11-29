using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

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
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            _crosswordInformation = dialog.crosswordInformation;

            try
            {
                _board = _crosswordManager.GenerateCrossword(_crosswordInformation);

                DrawBoard();
                PrepareCellStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Problem with generating crossword", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBoard_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dgvBoard_KeyPress);

            e.Control.KeyPress += new KeyPressEventHandler(dgvBoard_KeyPress);
        }

        private void dgvBoard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvBoard.CurrentCell == null || dgvBoard.CurrentCell.Tag == null || dgvBoard.CurrentCell.Tag.ToString() == string.Empty)
                return;

            dgvBoard.CurrentCell.Value = e.KeyChar;

            FocusNextCell();
        }

        private void DrawBoard()
        {
            dgvBoard.Columns.Clear();
            dgvBoard.Rows.Clear();

            for (var i = 0; i < _board.Columns; i++)
                dgvBoard.Columns.Add(new DataGridViewTextBoxColumn());

            dgvBoard.Rows.Add(_board.Rows);

            foreach (DataGridViewColumn column in dgvBoard.Columns)
                column.Width = dgvBoard.Width / dgvBoard.Columns.Count;

            foreach (DataGridViewRow row in dgvBoard.Rows)
                row.Height = dgvBoard.Height / dgvBoard.Rows.Count;
        }

        private void PrepareCellStyles()
        {
            dgvBoard.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (var row = 0; row < _board.Rows; row++)
            {
                for(var col = 0; col < _board.Columns; col++)
                {
                    if(_board.BoardArea[row, col] == '\0')
                        SetEmptyField(col, row);
                    else
                        SetLetterField(col, row);
                }
            }
        }

        private void SetEmptyField(int column, int row)
        {
            dgvBoard[column, row].Style.BackColor = System.Drawing.Color.Black;
            dgvBoard[column, row].Style.SelectionBackColor = System.Drawing.Color.Black;
            dgvBoard[column, row].ReadOnly = true;
        }

        private void SetLetterField(int column, int row)
        {
            //dgvBoard[column, row].Value = _board.BoardArea[row, column];
            dgvBoard[column, row].Tag = _board.BoardArea[row, column];
            dgvBoard[column, row].Style.BackColor = Color.White;
            dgvBoard[column, row].Style.Font = new Font("Arial", 20F, GraphicsUnit.Pixel);
            dgvBoard[column, row].ReadOnly = false;

            if(CheckIfPasswordField(column, row))
                dgvBoard[column, row].Style.BackColor = Color.Yellow;
        }

        private bool CheckIfPasswordField(int column, int row)
        {
            var isPasswordField = false;

            var allCoordinates = _board.Elements.SelectMany(x => x.CoordinatesInfo)
                .ToArray();

            var passwordCoordinate = allCoordinates.Select(x => x)
                .Where(x => x.Coordinates.X == row && x.Coordinates.Y == column && x.IsPasswordLetter == true)
                .FirstOrDefault();

            if (passwordCoordinate != null)
                isPasswordField = true;

            return isPasswordField;
        }

        private void FocusNextCell()
        {
            var column = dgvBoard.CurrentCell.ColumnIndex;
            var row = dgvBoard.CurrentCell.RowIndex;


        }
    }
}
