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
            var crosswordManager = new CrosswordManager();
            var path = @"C:/test.txt";

            Action result = () => { crosswordManager.LoadWords(path); };

            result.ShouldThrowExactly<FileNotFoundException>();
        }
    }
}
