﻿namespace Immutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4 players
            List<Player> players = new List<Player>()
            {
                new Player("Joe", 32),
                new Player("Jack", 30),
                new Player("William", 37),
                new Player("Averell", 25)
            };

            // Initialize search
            Player elder = players.First();
            int biggestAge = elder.Age;
            Dictionary<string, int> elderList = new Dictionary<string, int>();
            elderList.Add(elder.Name, biggestAge);

            // search
            foreach (Player p in players)
            {
                if (p.Age > elderList.Last().Value) // memorize new elder
                {
                    elderList.Add(p.Name, p.Age);
                }
            }

            Console.WriteLine($"Le plus agé est {elderList.Last().Key} qui a {elderList.Last().Value} ans");

            Console.ReadKey();
        }
        public class Player
        {
            private readonly string _name;
            private readonly int _age;

            public Player(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public string Name => _name;

            public int Age => _age;
        }
    }
}
