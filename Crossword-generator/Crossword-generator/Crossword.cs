using System.Windows.Forms;

namespace Crossword_generator
{
    public partial class Crossword : Form
    {
        private CrosswordManager crosswordManager;

        public Crossword()
        {
            crosswordManager = new CrosswordManager();
            crosswordManager.LoadWords();

            InitializeComponent();
        }
    }
}
