using System.Drawing;

namespace Crossword_generator
{
    public class CoordinateInfo
    {
        public Point Coordinates { get; set; }
        public char Letter { get; private set; }
        public bool IsPasswordLetter { get; private set; }

        public CoordinateInfo(Point coodrinates, char letter, bool isPasswordLetter)
        {
            Coordinates = coodrinates;
            Letter = letter;
            IsPasswordLetter = isPasswordLetter;
        }
    }
}
