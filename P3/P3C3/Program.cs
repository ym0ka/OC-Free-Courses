namespace P3C3
{
    class Program
    {
        public static void Main()
        {
            int x = 1;
            int y = 2;
            MessageAddition();
            int z = CalculAddition(x, y);
            MessageResultat(z);
            
            int i = 3;
            int j = 4;
            MessageAddition();
            int k = CalculAddition(i, j);
            MessageResultat(k);
            
            int var1 = 5;
            int var2 = 6;
            MessageAddition();
            int var3 = CalculAddition(var1, var2);
            MessageResultat(var3);
        }

        public static void MessageAddition()
        {
            Console.WriteLine("Essayons une addition !");
        }

        public static int CalculAddition(int premier, int second)
        {
            return premier + second;
        }

        public static void MessageResultat(int resultat)
        {
            Console.WriteLine($"La somme est de {resultat}");
        }
        
    }
}

// int x = 1;
// int y = 2;
// int z = x + y;
// Console.WriteLine("La somme est de " + z);
//
// Console.WriteLine("Essayons une addition !");
// int i = 3;
// int j = 4;
// int k = i + j;
// Console.WriteLine("La somme est de " + k);
//
// Console.WriteLine("Essayons une addition !");
// int var1 = 5;
// int var2 = 6;
// int var3 = var1 + var2;
// Console.WriteLine("La somme est de " + var3);