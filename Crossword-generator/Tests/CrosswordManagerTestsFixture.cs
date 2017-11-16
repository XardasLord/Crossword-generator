using System;
using System.IO;

namespace Tests
{
    public class CrosswordManagerTestsFixture
    {
        public string FilePath { get; private set; }
        private string currentDirPath;

        public CrosswordManagerTestsFixture()
        {
            currentDirPath = Path.GetDirectoryName(new Uri(typeof(CrosswordManagerTests).Assembly.CodeBase).LocalPath);
        }

        public void SetFakePath()
        {
            FilePath = Path.Combine(currentDirPath, @"Resources\NonExistingFile.txt");
        }

        public void SetRealPath()
        {
            FilePath = Path.Combine(currentDirPath, @"Resources\DictionaryWordList.txt");
        }
    }
}
