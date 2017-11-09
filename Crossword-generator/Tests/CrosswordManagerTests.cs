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
        private CrosswordManager crosswordManager;
        private string fakePath;
        private string realPath;

        [SetUp]
        public void Init()
        {
            crosswordManager = new CrosswordManager();
            var currentDirPath = Path.GetDirectoryName(new Uri(typeof(CrosswordManagerTests).Assembly.CodeBase).LocalPath);
            fakePath = Path.Combine(currentDirPath, @"Resources\NonExistingFile.txt");
            realPath = Path.Combine(currentDirPath, @"Resources\DictionaryWordList.txt");
        }

        [Test]
        public void load_words_from_non_existing_file_should_throw_an_exception()
        {
            Action result = () => { crosswordManager.LoadWords(fakePath); };

            result.ShouldThrowExactly<FileNotFoundException>();
        }

        [Test]
        public void load_words_from_correct_file_should_return_lists_of_word()
        {
            crosswordManager.LoadWords(realPath);

            crosswordManager.Words.Count.Should().BeGreaterThan(0);
        }
    }
}
