namespace Crossword_generator
{
    public class CrosswordElement
    {
        public CoordinateInfo[] CoordinatesInfo { get; private set; }
        public Word Word { get; private set; }
        public WordDirection Direction { get; private set; }


        public CrosswordElement(CoordinateInfo[] coodrinatesInfo, Word word, WordDirection direction = WordDirection.Horizontal)
        {
            CoordinatesInfo = coodrinatesInfo;
            Word = word;
            Direction = direction;
        }
    }
}
