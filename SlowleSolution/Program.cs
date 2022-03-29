using System;
using System.Collections.Generic;
using System.Linq;

namespace SlowleSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int numberOfLettersinWord = 5;

            bool playNextRound = true;

            while (playNextRound)
            {
                string[] lines = System.IO.File.ReadAllLines(@"../../../Documents/nerdle_slowlist_true.txt");
                var newLines = lines.ToList();

                Console.WriteLine("Wpisz odpowiednie litery których pozycji jesteś pewien. Jeśli na danej pozycji nie jesteś pewien litery - wpisz '0'");
                for (int i = 0; i < numberOfLettersinWord; i++)
                {
                    Console.WriteLine("Wpisz literę na pozycji {0}", i + 1);

                    var letter = Console.ReadLine();
                    int parsed;

                    if (!Int32.TryParse(letter, out parsed))
                    {
                        var capitalizedLetter = letter.ToUpper()[0];
                        var newLines2 = newLines.Where(x => x[i] == capitalizedLetter).ToList();
                        newLines = newLines2;
                    }
                }

                Console.WriteLine("Wpisz ciągiem litery, które występują w słowie, ale nie jesteś pewien ich położenia. Jeśli nie ma takich liter - wpisz '0'");
                var presentLetters = Console.ReadLine();
                if (presentLetters != "0")
                {
                    var linesWitLetters = new List<string>();
                    foreach (char letter in presentLetters.ToUpper())
                    {
                        linesWitLetters = newLines.Where(x => x.Contains(letter)).ToList();
                        newLines = linesWitLetters;
                    }
                }

                Console.WriteLine("Wpisz ciągiem litery, które NIE występują w słowie.");
                var absentLetters = Console.ReadLine();

                var linesWithouLetters = new List<string>();
                foreach (char letter in absentLetters.ToUpper())
                {
                    linesWithouLetters = newLines.Where(x => !x.Contains(letter)).ToList();
                    newLines = linesWithouLetters;
                }

                Console.WriteLine("Możliwe słowo:");
                if(newLines.Count > 0)
                {
                    foreach (string line in newLines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Nie występuje żadne słowo z powyższymi założeniami");
                }
                

                Console.WriteLine("Y - kolejna runda");
                playNextRound = Console.ReadLine() == "y" ? true : false;
            }
        }
    }
}
