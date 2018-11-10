using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
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

                var continueWordUnscrambleDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueWordUnscrambleDecision = Console.ReadLine() ?? string.Empty;
                } while (
                    !continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                    !continueWordUnscrambleDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = continueWordUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);
        }

        private static void ExecuteScrambledWordsManually()
        {
            //throw new NotImplementedException();
        }

        private static void ExecuteScrambledWordsFileScenario()
        {
            //throw new NotImplementedException();
        }
    }
}
