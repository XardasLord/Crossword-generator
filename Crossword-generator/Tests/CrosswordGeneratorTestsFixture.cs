using Crossword_generator;

namespace Tests
{
    public class CrosswordGeneratorTestsFixture
    {
        public readonly string Password = "RandomPasswordText";
        private CrosswordType _type;

        public void SetSimpleCrosswordType()
        {
            _type = CrosswordType.Simple;
        }

        public void SetSecordTypeCrosswordType()
        {
            _type = CrosswordType.Medium;
        }

        public void SetThirdTypeCrosswordType()
        {
            _type = CrosswordType.Panoramic;
        }

        public CrosswordInformation CreateCrosswordInformation()
        {
            return new CrosswordInformation(Password, _type);
        }
    }
}
