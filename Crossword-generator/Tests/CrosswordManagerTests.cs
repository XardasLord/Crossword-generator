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
            fixture.SetFakePath();

            Action result = () => { act(); };

            result.ShouldThrowExactly<FileNotFoundException>();
        }

        [Test]
        public void load_words_from_correct_file_should_return_lists_of_word()
        {
            fixture.SetRealPath();

            var result = act();

            result.Words.Count.Should().BeGreaterThan(0);
        }

        public CrosswordManager act()
        {
            var crosswordManager = new CrosswordManager();
            crosswordManager.LoadWords(fixture.FilePath);

            return crosswordManager;
        }

        [SetUp]
        public void Init()
        {
            fixture = new CrosswordManagerTestsFixture();
        }
        
        private CrosswordManagerTestsFixture fixture;
    }
}
