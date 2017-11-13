namespace Crossword_generator
{
    public class Board
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public char[,] BoardArea { get; private set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            BoardArea = new char[Rows, Columns];
        }

        //TODO: Board has to know if word fits to crossword and how it fits (horizontal/vertical and the coordinates).
    }
}
