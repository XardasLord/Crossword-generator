using NUnit.Framework;
using FluentAssertions;
using Crossword_generator;
using System;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class CrosswordManagerTests
    {
        [Test]
        public void load_words_from_non_existing_file_should_throw_an_exception()
        {
            _fixture.SetFakePath();

            Action result = () => { act(); };

            result.ShouldThrowExactly<FileNotFoundException>();
        }

        [Test]
        public void load_words_from_correct_file_should_return_lists_of_word()
        {
            _fixture.SetRealPath();

            var result = act();

            result.Words.Count.Should().BeGreaterThan(0);
        }

        public CrosswordManager act()
        {
            var crosswordManager = new CrosswordManager();
            crosswordManager.LoadWords(_fixture.FilePath);

            return crosswordManager;
        }

        [SetUp]
        public void Init()
        {
            _fixture = new CrosswordManagerTestsFixture();
        }
        
        private CrosswordManagerTestsFixture _fixture;
    }
}
