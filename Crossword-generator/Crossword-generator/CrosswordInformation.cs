namespace Crossword_generator
{
    public class CrosswordInformation
    {
        public string Password { get; private set; }
        public CrosswordType Type { get; private set; }

        public enum CrosswordType
        {
            Simple,
            SecondType,
            ThirdType
        }

        public CrosswordInformation(string password, CrosswordType type)
        {
            Password = password.ToLower();
            Type = type;
        }
    }
}
