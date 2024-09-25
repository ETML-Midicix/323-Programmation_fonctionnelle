using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };
            Dictionary<char, double> letterPcPairs = new Dictionary<char, double>()
            { 
                { 'a', 7.11 },
                { 'b', 1.14 },
                { 'c', 3.18 },
                { 'd', 3.67 },
                { 'e', 12.10 },
                { 'f', 1.11 },
                { 'g', 1.23 },
                { 'h', 1.11 },
                { 'i', 6.59 },
                { 'j', 0.34 },
                { 'k', 0.29 },
                { 'l', 4.96 },
                { 'm', 2.62 },
                { 'n', 6.39 },
                { 'o', 5.02 },
                { 'p', 2.49 },
                { 'q', 0.65 },
                { 'r', 6.07 },
                { 's', 6.51 },
                { 't', 5.92 },
                { 'u', 4.49 },
                { 'v', 1.11 },
                { 'w', 0.17 },
                { 'x', 0.38 },
                { 'y', 0.46 },
                { 'z', 0.15 }
            };

            Console.WriteLine("EX1");

            //o instead of x
            words
                .Where(w => !w
                .Contains("o"))
                .ToList()
                .ForEach(w1 => Console
                .Write($"{w1}, "));

            Console.WriteLine();

            //6 instead of 4
            words.Where(w => w.Length >= 6).ToList().ForEach(w1 => Console.Write($"{w1}, "));
            Console.WriteLine();

            //AVG
            words.Where(w => w.Length == words.Average(w1 => w1.Length)).ToList().ForEach(w1 => Console.Write($"{w1}, "));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("EX2");

            //EPSILON
            //words.Where(w => w.Where(l => letterPcPairs[l] >= 0.5 && letterPcPairs[l] <= 0.95)).ToList().ForEach(w1 => Console.Write($"{w1}, "));
            Console.WriteLine(Parse(letterPcPairs, words[0]));
            Console.WriteLine(Parse2(letterPcPairs, words[0]));


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("EX3");

            List<Movie> frenchMovies = new List<Movie>() {
            new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
            new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
            new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
            new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
            new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
            new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
            new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
            };

            frenchMovies.Where(m => !(m.Genre.ToLower() == "comédie" || m.Genre.ToLower() == "drame")).ToList().ForEach(x => Console.Write($"{x.Title}, "));
            Console.WriteLine();
            frenchMovies.Where(m => (m.Rating < 7)).ToList().ForEach(x => Console.Write($"{x.Title}, "));
            Console.WriteLine();
            frenchMovies.Where(m => (m.Year < 2000)).ToList().ForEach(x => Console.Write($"{x.Title}, "));
            Console.WriteLine();
            frenchMovies.Where(m => !(m.LanguageOptions.Contains("Français"))).ToList().ForEach(x => Console.Write($"{x.Title}, "));
            Console.WriteLine();
            frenchMovies.Where(m => !(m.StreamingPlatforms.Contains("Netflix"))).ToList().ForEach(x => Console.Write($"{x.Title}, "));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("EX3 - CUMUL");

            frenchMovies
                .Where(m => !(m.Genre.ToLower() == "comédie" || m.Genre.ToLower() == "drame"))
                .Where(m => (m.Rating < 7))
                .Where(m => (m.Year < 2000))
                .Where(m => !(m.LanguageOptions.Contains("Français")))
                .Where(m => !(m.StreamingPlatforms.Contains("Netflix")))
                .ToList().ForEach(x => Console.Write($"{x.Title}, "));


            Console.Clear();
            Console.WriteLine("EX4 - Dynamique");

            Console.WriteLine();

            AskForFilter1(frenchMovies).ForEach(x => Console.Write($"{x.Title}, "));

            Console.Read();
        }


        static List<Movie> AskForFilter1(List<Movie> movieList)
        {
            bool check = true;
            List<string> filterList = new List<string>();
            while (check)
            {
                Console.WriteLine("Choose your exclusion option (empty string to confirm choice: ");
                Console.WriteLine("1) Comédie");
                Console.WriteLine("2) Science-Fiction");
                Console.WriteLine("3) Drame");
                Console.WriteLine("4) Thriller");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        if (!filterList.Contains("Comédie")) { filterList.Add("Comédie"); };
                        break;
                    case "2":
                        if (!filterList.Contains("Science-Fiction")) { filterList.Add("Science-Fiction"); };
                        break;
                    case "3":
                        if (!filterList.Contains("Drame")) { filterList.Add("Drame"); };
                        break;
                    case "4":
                        if (!filterList.Contains("Thriller")) { filterList.Add("Thriller"); };
                        break;
                    case "":
                        check = false;
                        break;
                    default:
                        break;
                }
            }
            foreach (string filter in filterList) 
            {
                movieList = movieList.Where(m => m.Genre != filter).ToList();
            }
            return movieList;
        }


        //BAD WAY
        static double Parse(Dictionary<char, double> letterPcPairs, string word)
        {
            double epsilon = 0;
            foreach (var letter in word)
            {
                switch (word.Count(l => l == letter))
                {
                    case 1:
                        //if (letterPcPairs[letter]/100 >= 0.5 && letterPcPairs[letter]/100 <= 0.95)
                        epsilon += letterPcPairs[letter] / 100;

                        break;
                    case int n when n > 1:
                        //if (letterPcPairs[letter] * n / 100 >= 0.5 && letterPcPairs[letter] * n / 100 <= 0.95)
                        epsilon += letterPcPairs[letter] / n / 100;
                        break;
                }
            }
            return epsilon;
        }

        //NICE WAY
        static string Parse2(Dictionary<char, double> letterPcPairs, string word)
        {
            //double epsilon = word
            //    .ToList()
            //    .Select(l => l * word.Count(l1 => l1 == l) / 100).Average();
            double epsilon = word
                .ToList()
                .Select(l => l / word.Count(l1 => l1 == l) / 100).Average();
            Console.WriteLine(epsilon);
            //return epsilon;
            return "non";
        }
    }
}
