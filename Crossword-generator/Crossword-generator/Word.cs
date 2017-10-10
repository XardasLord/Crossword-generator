namespace Crossword_generator
{
    public class Word
    {
        public string Description { get; private set; }
        public string Value { get; private set; }

        public Word(string description, string value)
        {
            Description = description;
            Value = value;
        }
    }
}
