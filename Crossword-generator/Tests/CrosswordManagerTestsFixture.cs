using System;
using System.IO;

namespace Tests
{
    public class CrosswordManagerTestsFixture
    {
        public string FilePath { get; private set; }
        private string _currentDirPath;

        public CrosswordManagerTestsFixture()
        {
            _currentDirPath = Path.GetDirectoryName(new Uri(typeof(CrosswordManagerTests).Assembly.CodeBase).LocalPath);
        }

        public void SetFakePath()
        {
            FilePath = Path.Combine(_currentDirPath, @"Resources\NonExistingFile.txt");
        }

        public void SetRealPath()
        {
            FilePath = Path.Combine(_currentDirPath, @"Resources\DictionaryWordList.txt");
        }
    }
}
