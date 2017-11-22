using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

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
            var elements = GetElementsForCrossword(crosswordInformation);

            MoveElementsOffsetForSimpleCrossword(ref elements);

            var rows = crosswordInformation.Password.Length;
            var columns = GetNumberOfColumns(elements);

            if (columns > rows)
                rows = columns;

            _board = new Board(rows, columns, elements);
        }

        private void GenerateSecondTypeCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate medium crossword based on a given CrosswordInformation
        }

        private void GenerateThirdTypeCrossword(CrosswordInformation crosswordInformation)
        {
            //TODO: Generate panoramic crossword based on a given CrosswordInformation
        }

        private CrosswordElement[] GetElementsForCrossword(CrosswordInformation crosswordInformation)
        {
            var elements = new List<CrosswordElement>();

            switch (crosswordInformation.Type)
            {
                case CrosswordType.Simple:
                    GetElementsForSimpleCrossword(crosswordInformation.Password, ref elements);
                    break;
                case CrosswordType.Medium:
                    GetElementsForSecondTypeCrossword(crosswordInformation.Password, ref elements);
                    break;
                case CrosswordType.Panoramic:
                    GetElementsForThirdTypeCrossword(crosswordInformation.Password, ref elements);
                    break;
                default:
                    throw new Exception("Given crossword type to generate is invalid.");
            }

            return elements.ToArray();
        }

        private void GetElementsForSimpleCrossword(string password, ref List<CrosswordElement> elements)
        {
            var random = new Random();

            foreach (var letter in password.ToCharArray())
            {
                var word = Words.Select(w => w)
                    .Where(w => w.Characters.Contains(letter))
                    .OrderBy(w => random.Next())
                    .FirstOrDefault();

                if(word == null)
                    throw new Exception($"The given password can not be placed in a crossword. Letter: '{letter}' doesn't exist in our database.");

                var coordinatesInfo = CreateCoordinatesInfoForSimpleCrossword(elements, word, letter);

                elements.Add(new CrosswordElement(coordinatesInfo, word));
            }
        }

        private void GetElementsForSecondTypeCrossword(string password, ref List<CrosswordElement> elements)
        {
            //TODO: Get random words to fit the medium crossword
        }

        private void GetElementsForThirdTypeCrossword(string password, ref List<CrosswordElement> elements)
        {
            //TODO: Get random words to fit the panoramic crossword
        }

        private CoordinateInfo[] CreateCoordinatesInfoForSimpleCrossword(List<CrosswordElement> elements, Word wordToPlace, char passwordLetter)
        {
            CoordinateInfo previousCoordPassword = null;

            if(elements.Count > 0)
            {
                previousCoordPassword = elements[elements.Count - 1].CoordinatesInfo
                    .Select(c => c)
                    .Where(c => c.IsPasswordLetter)
                    .FirstOrDefault();
            }

            if(previousCoordPassword == null)
                return CreateFirstCoordinatesInfoForSimpleCrossword(wordToPlace, passwordLetter);
            else
                return CreateNextCoordinatesInfoForSimpleCrossword(previousCoordPassword.Coordinates, wordToPlace, passwordLetter);
        }

        private CoordinateInfo[] CreateFirstCoordinatesInfoForSimpleCrossword(Word wordToPlace, char passwordLetter)
        {
            var coordinatesInfo = new List<CoordinateInfo>();
            var passLetterWasSet = false;

            for (var i = 0; i < wordToPlace.Value.Length; i++)
            {
                var letter = wordToPlace.Value[i];
                var isPasswordLetter = false;

                if (!passLetterWasSet && passwordLetter.Equals(letter))
                {
                    isPasswordLetter = true;
                    passLetterWasSet = true;
                }

                var coordInfo = new CoordinateInfo(new Point(0, i), letter, isPasswordLetter);

                coordinatesInfo.Add(coordInfo);
            }

            return coordinatesInfo.ToArray();
        }

        private CoordinateInfo[] CreateNextCoordinatesInfoForSimpleCrossword(Point previousCoordPassword, Word wordToPlace, char passwordLetter)
        {
            var coordinatesInfo = new List<CoordinateInfo>();
            var currentCoordPassword = new Point();
            var currentLetterCountPassword = 0;

            for (var i = 0; i < wordToPlace.Value.Length; i++)
            {
                var letter = wordToPlace.Value[i];

                if (passwordLetter.Equals(letter))
                {
                    currentCoordPassword = new Point(previousCoordPassword.X + 1, i);
                    currentLetterCountPassword = i;
                    break;
                }
            }

            // TODO: What about minus coord after calculating the password position??? How to handle it???
            // TODO: Maybe calculate it as it is now and after all elements check the most negative value and move ALL coords of that value to set this max negative to 0???
            var fakeCounter = 0;
            var passLetterWasSet = false;
            var startY = previousCoordPassword.Y - currentCoordPassword.Y;
            for(var i = startY; i < wordToPlace.Value.Length + startY; i++)
            {
                var letter = wordToPlace.Value[fakeCounter];
                var isPasswordLetter = false;

                if (!passLetterWasSet && fakeCounter == currentLetterCountPassword)
                {
                    isPasswordLetter = true;
                    passLetterWasSet = true;
                }

                var coordInfo = new CoordinateInfo(new Point(previousCoordPassword.X + 1, i), letter, isPasswordLetter);

                coordinatesInfo.Add(coordInfo);

                fakeCounter++;
            }

            return coordinatesInfo.ToArray();
        }

        private void MoveElementsOffsetForSimpleCrossword(ref CrosswordElement[] elements)
        {
            var offset = Math.Abs(elements.SelectMany(x => x.CoordinatesInfo).Min(x => x.Coordinates.Y));

            foreach(var element in elements)
                foreach(var coordInfo in element.CoordinatesInfo)
                    coordInfo.Coordinates = new Point(coordInfo.Coordinates.X, coordInfo.Coordinates.Y + offset);
        }

        private int GetNumberOfColumns(CrosswordElement[] elements)
        {
            return elements.SelectMany(x => x.CoordinatesInfo).Max(x => x.Coordinates.Y) + 1;
        }
    }
}
