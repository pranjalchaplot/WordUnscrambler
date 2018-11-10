using System;
using System.Collections.Generic;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFileName = "wordlist.txt";

        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;

            do
            {
                Console.WriteLine("Enter the option - F for File and M for Manual");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "M":
                        Console.WriteLine("Enter scrambled words file name: ");
                        ExecuteScrambledWordsFileScenario();
                        break;
                    case "F":
                        Console.WriteLine("Enter scrambled words manually: ");
                        ExecuteScrambledWordsManually();
                        break;
                    default:
                        Console.WriteLine("Option was not recognized.");
                        break;
                }

                var continueDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueDecision = Console.ReadLine() ?? string.Empty;

                } while (
                    !continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                    !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);
        }

        private static void ExecuteScrambledWordsManually()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsFileScenario()
        {
            var filename = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine("No matches have been found.");
            }
        }
    }
}
