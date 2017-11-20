using NUnit.Framework;
using FluentAssertions;
using Crossword_generator;

namespace Tests
{
    public class CrosswordGeneratorTests
    {
        [Test]
        public void generating_simple_crossword_type_should_create_board_with_number_of_column_equals_to_password_length()
        {
            _fixture.SetSimpleCrosswordType();

            var result = act();

            result.Columns.ShouldBeEquivalentTo(_fixture.Password.Length - 1);
        }

        public Board act()
        {
            var crosswordInformation = _fixture.CreateCrosswordInformation();

            return new CrosswordManager().GenerateCrossword(crosswordInformation);
        }

        [SetUp]
        public void Init()
        {
            _fixture = new CrosswordGeneratorTestsFixture();
        }

        private CrosswordGeneratorTestsFixture _fixture;
    }
}
