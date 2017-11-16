namespace Tests
{
    public class BoardTestsFixture
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public BoardTestsFixture() { }

        public void SetNegativeDimensions()
        {
            Rows = -10;
            Columns = -10;
        }

        public void SetNormalDimensions()
        {
            Rows = 10;
            Columns = 10;
        }
    }
}
