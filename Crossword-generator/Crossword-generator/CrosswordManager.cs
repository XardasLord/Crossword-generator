using System;
using System.Collections.Generic;
using System.IO;

namespace Crossword_generator
{
    public class CrosswordManager
    {
        public List<Word> Words { get; private set; }
        private Board board;

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
            board = null;

            switch (crosswordInformation.Type)
            {
                case CrosswordType.Simple:
                    GenerateSimpleCrossword(crosswordInformation);
                    break;
                case CrosswordType.SecondType:
                    GenerateSecondTypeCrossword(crosswordInformation);
                    break;
                case CrosswordType.ThirdType:
                    GenerateThirdTypeCrossword(crosswordInformation);
                    break;
                default:
                    throw new Exception("Given crossword type to generate is invalid.");
            }

            return board;
        }

        private void GenerateSimpleCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate simple crossword based on a given CrosswordInformation
        }

        private void GenerateSecondTypeCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate second type crossword based on a given CrosswordInformation
        }

        private void GenerateThirdTypeCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate third type crossword based on a given CrosswordInformation
        }
    }
}
