namespace Crossword_generator
{
    public class CrosswordElement
    {
        public CoordinateInfo[] CoordinatesInfo { get; private set; }
        public Word Word { get; private set; }
        public bool IsVertical { get; private set; }


        public CrosswordElement(CoordinateInfo[] coodrinatesInfo, Word word, bool isVertical)
        {
            CoordinatesInfo = coodrinatesInfo;
            Word = word;
            IsVertical = isVertical;
        }
    }
}
