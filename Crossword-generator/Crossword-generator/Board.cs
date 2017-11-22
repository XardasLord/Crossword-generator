using System;

namespace Crossword_generator
{
    public class Board
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public char[,] BoardArea { get; private set; }
        public CrosswordElement[] Elements { get; private set; }

        public Board(int rows, int columns, CrosswordElement[] crosswordElements)
        {
            if (rows < 0 || columns < 0)
                throw new ArgumentException($"Given rows or columns are negative. Rows: {rows}, columns: {columns}.");

            Rows = rows;
            Columns = columns;
            Elements = crosswordElements;

            BoardArea = new char[Rows, Columns];

            FillBoardArea();
        }

        private void FillBoardArea()
        {
            foreach(var element in Elements)
                foreach(var coordInfo in element.CoordinatesInfo)
                    BoardArea[coordInfo.Coordinates.X, coordInfo.Coordinates.Y] = coordInfo.Letter;
        }
    }
}
