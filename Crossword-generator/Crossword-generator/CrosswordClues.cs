using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crossword_generator
{
    public partial class CrosswordClues : Form
    {
        CrosswordElement[] _clues;

        public CrosswordClues(CrosswordElement[] elements)
        {
            _clues = elements;

            InitializeComponent();

            ClearList();
            CreateColumns();
            CreateList();
        }

        private void ClearList()
        {
            listOfClues.Clear();
        }

        private void CreateColumns()
        {
            listOfClues.Columns.Add("Number");
            listOfClues.Columns.Add("Clue");
        }

        private void CreateList()
        {
            var counter = 1;

            foreach(CrosswordElement element in _clues)
            {
                string[] clue = { counter.ToString(), element.Word.Description };
                var item = new ListViewItem(clue);

                listOfClues.Items.Add(item);

                counter++;
            }

        }

        public void HighlightTheClue(int number)
        {
            foreach (ListViewItem item in listOfClues.Items)
            {
                item.ForeColor = DefaultForeColor;
                item.BackColor = DefaultBackColor;
                item.Font = new Font(item.Font, FontStyle.Regular);
            }

            if (number > listOfClues.Items.Count - 1)
                return;

            listOfClues.Items[number].ForeColor = Color.Green;
            listOfClues.Items[number].BackColor = Color.Yellow;
            listOfClues.Items[number].Font = new Font(listOfClues.Items[number].Font, FontStyle.Bold);
        }
    }
}
