//TODO : Créer une boucle for et while qui affiche à 5 reprises la phrase, « Je m'amuse comme un fou ! ».
using System;

namespace Boucles
{
    
    public class Boucles
    {
        public static void Main(string[] args)
        {
            AmusonsNous();
        }

        public static void AmusonsNous()
        {
            // for (int i = 0; i < 5; i++)
            // {
            //     Console.WriteLine("Je m'amuse comme un fou !");
            // }
            
            int i = 0;
            while (i < 5)
            {
                i++;
                if (i != 4)
                {
                    Console.WriteLine("Je m'amuse comme un fou !");
                }
            }
        }
    }

}