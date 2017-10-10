using System.Collections.Generic;

namespace Crossword_generator
{
    public class CrosswordManager
    {
        public List<Word> Words { get; private set; }

        public void LoadWords()
        {
            Words = new List<Word>();
        }
    }
}
