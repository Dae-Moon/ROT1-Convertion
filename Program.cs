using System;

namespace ROT1_Converter
{
    class Program
    {
        static Alphabets currentAlphabet;
        
        static char GetSymbol(char symbol, bool reverse = false)
        {
            var symbols = AlphabetData.GetAlphabetSymbols(currentAlphabet);
            if (symbols == null)
                return symbol;

            var idx = symbols.IndexOf(char.ToLower(symbol));
            if (idx < 0)
                return symbol;
            idx += reverse ? -1 : 1;

            if (idx < 0)
                idx += symbols.Count;
            else if (idx > symbols.Count)
                idx -= symbols.Count;

            return char.IsLower(symbol) ? symbols[idx] : char.ToUpper(symbols[idx]);
        }

        static string Convert(string text, bool reverse = false)
        {
            string result = "";
            foreach (var symbol in text)
                result += GetSymbol(symbol, reverse);
            return result;
        }



        static void Main()
        {
            void Restart(string text)
            {
                if (!string.IsNullOrEmpty(text))
                    Console.WriteLine(text);
                Console.Write("\nPress any key for restart...");
                Console.ReadKey(true);
            }

        restart:
            Console.Clear();

            Console.Write("Select your alphabet : ");
            currentAlphabet = AlphabetData.GetAlphabet(Console.ReadLine());

            if (currentAlphabet == Alphabets.None)
            {
                Restart("Alphabet not found.");
                goto restart;
            }

            Console.Write("Enter your type convertion '1/0' : ");

            if (!uint.TryParse(Console.ReadLine(), out uint ui) || (ui < 0 || ui > 1))
            {
                Restart("Type not recognized.");
                goto restart;
            }

            Console.Write("Enter your text : ");
            Console.WriteLine($"Result : {Convert(Console.ReadLine(), ui == 0)}");

            Console.Write("Press Enter key for exit..");
            if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                goto restart;
        }
    }
}
