namespace extension
{
    public static class Ext
    {
        /// Corps de la fonction à compléter
        public static int ReadInt(this string prompt)
        {
            int result;
            string entry;
            do
            {
                Console.Clear();
                Console.Write(prompt);
                entry = Console.ReadLine();
            } while (!int.TryParse(entry, out result));
            return result;
        }
        public static string Write(this string prompt, System.ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(prompt);
            Console.ResetColor();
            return "";
        }
        public static int ToIntSafe(this string prompt, int parameter = 0)
        {
            return int.TryParse(prompt, out int nb) ? nb : parameter;
        }
        public static string RandomString(this Random rdm, int parameter)
        {
            string s = "";
            Random r = new Random();
            for (int i = 0; i < parameter; i++)
            {
                string c = Convert.ToString(Convert.ToChar(r.Next(65, 65 + 26)));
                s += r.Next(2) == 1 ? c : c.ToLower();
            }
            return s;
        }
        public static bool RandomBool(this Random rdm)
        {
            return rdm.Next(2) == 1 ? true : false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        //Entrées
        int year = "Année de naissance: ".ReadInt();
            $"Vous avez {DateTime.Now.Year - year} ans".Write(ConsoleColor.Green);

            // Conversions
            string input = "123";
            int number = input.ToIntSafe();
            Console.WriteLine($"Nombre converti : {number}");
            Console.WriteLine($"Pas un nombre, valeur par défaut : {"notANumber".ToIntSafe()}");
            Console.WriteLine($"Pas un nombre, valeur par défaut spécifique : {"notANumber".ToIntSafe(-1)}");

            //Random
            var random = new Random();
            string randomStr = random.RandomString(8);
            Console.WriteLine($"Chaîne aléatoire : {randomStr}");
            bool randomBool = random.RandomBool();
            Console.WriteLine($"Booléen aléatoire: {randomBool}");
        }
    }
}
