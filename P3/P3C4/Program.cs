namespace P3C4
{
    class Program
    {
        public static void Main()
        {
            // TODO : exécuter les méthodes de test pour les deux méthodes de la classe Program.cs
            Test.TestCinqPlusTreizeEgalDixHuit();
            Test.TestQuatorzeMoinsHuitEgalSix();
            
            // TODO : afficher le resultat de ces deux méthodes ici
            int a = 5;
            int b = 7;
            int c = Addition(a, b);
            Console.WriteLine($"Somme de {a} + {b} = {c}");

            int x = 15;
            int y = 3;
            int z = Addition(x, y);
            Console.WriteLine($"Différence de {x} - {y} = {z}");
            
        }

        // TODO : créer deux méthodes
        public static int Addition(int premier, int second)
        {
            return premier + second;
        }

        public static int Soustraction(int premier, int second)
        {
            return premier - second;
        }
    }
}