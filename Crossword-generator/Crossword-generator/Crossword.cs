using System.IO;
using System.Windows.Forms;

namespace Crossword_generator
{
    public partial class Crossword : Form
    {
        private CrosswordManager crosswordManager;
        private string pathToWorldList = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\DictionaryWordList.txt";

        public Crossword()
        {
            crosswordManager = new CrosswordManager();
            crosswordManager.LoadWords(pathToWorldList);

            InitializeComponent();
        }
    }
}
