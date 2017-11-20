using NUnit.Framework;
using FluentAssertions;
using Crossword_generator;
using System;

namespace Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void set_negative_rows_or_columns_should_throw_an_exception()
        {
            _fixture.SetNegativeDimensions();

            Action result = () => { act(); };

            result.ShouldThrowExactly<ArgumentException>();
        }

        [Test]
        public void set_normal_number_of_rows_and_columns_should_create_array_with_these_dimensions()
        {
            _fixture.SetNormalDimensions();

            var result = act();

            result.Rows.ShouldBeEquivalentTo(_fixture.Rows);
            result.Columns.ShouldBeEquivalentTo(_fixture.Columns);
            result.BoardArea.Length.ShouldBeEquivalentTo(_fixture.Rows * _fixture.Columns);
        }

        public Board act()
        {
            return new Board(_fixture.Rows, _fixture.Columns);
        }

        [SetUp]
        public void Init()
        {
            _fixture = new BoardTestsFixture();
        }

        private BoardTestsFixture _fixture;
    }
}
