using System;
using System.Collections.Generic;
using System.IO;

namespace Crossword_generator
{
    public class CrosswordManager : IWordLoader, ICrosswordGenerator
    {
        public List<Word> Words { get; private set; }
        private Board _board;

        public CrosswordManager()
        {
            Words = new List<Word>();
        }

        public void LoadWords(string filePath = "")
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var words = line.Split(new string[] { ";" }, StringSplitOptions.None);
                    
                    for(var i = 0; i < words.Length - 1; i += 2)
                        Words.Add(new Word(words[i], words[i + 1]));
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException($"File not found: {e.FileName}");
            }
            catch (Exception e)
            {
                throw new Exception($"Exception has occured while loading the file with lists of word. {e.Message}");
            }
        }

        public Board GenerateCrossword(CrosswordInformation crosswordInformation)
        {
            _board = null;

            switch (crosswordInformation.Type)
            {
                case CrosswordType.Simple:
                    GenerateSimpleCrossword(crosswordInformation);
                    break;
                case CrosswordType.Medium:
                    GenerateSecondTypeCrossword(crosswordInformation);
                    break;
                case CrosswordType.Panoramic:
                    GenerateThirdTypeCrossword(crosswordInformation);
                    break;
                default:
                    throw new Exception("Given crossword type to generate is invalid.");
            }

            return _board;
        }

        private void GenerateSimpleCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate simple crossword based on a given CrosswordInformation
            var columns = crosswordInformation.Password.Length;
            var words = GetWordsForCrossword(crosswordInformation);
        }

        private void GenerateSecondTypeCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate medium crossword based on a given CrosswordInformation
        }

        private void GenerateThirdTypeCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate panoramic crossword based on a given CrosswordInformation
        }

        private List<Word> GetWordsForCrossword(CrosswordInformation crosswordInformation)
        {
            var words = new List<Word>();

            switch (crosswordInformation.Type)
            {
                case CrosswordType.Simple:
                    GetWordsForSimpleCrossword(crosswordInformation.Password, ref words);
                    break;
                case CrosswordType.Medium:
                    GetWordsForSecondTypeCrossword(crosswordInformation.Password, ref words);
                    break;
                case CrosswordType.Panoramic:
                    GetWordsForThirdTypeCrossword(crosswordInformation.Password, ref words);
                    break;
                default:
                    throw new Exception("Given crossword type to generate is invalid.");
            }

            return words;
        }

        private void GetWordsForSimpleCrossword(string password, ref List<Word> words)
        {
            //TODO: Get random words to fit the simple crossword
        }

        private void GetWordsForSecondTypeCrossword(string password, ref List<Word> words)
        {
            //TODO: Get random words to fit the medium crossword
        }

        private void GetWordsForThirdTypeCrossword(string password, ref List<Word> words)
        {
            //TODO: Get random words to fit the panoramic crossword
        }
    }
}
