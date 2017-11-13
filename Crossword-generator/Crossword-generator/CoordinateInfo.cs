using System.Drawing;

namespace Crossword_generator
{
    public class CoordinateInfo
    {
        public Point Coordinates { get; private set; }
        public char Letter { get; private set; }

        public CoordinateInfo(Point coodrinates, char letter)
        {
            Coordinates = coodrinates;
            Letter = letter;
        }
    }
}
