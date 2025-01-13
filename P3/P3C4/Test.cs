namespace P3C4;

public class Test
{
    // TODO : créer deux méthodes de test correspondant à la méthode Test en respectant la convention de nommage appropriée
    public static void TestCinqPlusTreizeEgalDixHuit()
    {
        Console.WriteLine("Test de somme 5 + 13 :");
        int testAddition = Program.Addition(5, 13);
        Console.WriteLine(testAddition);
    }
    
    public static void TestQuatorzeMoinsHuitEgalSix()
    {
        Console.WriteLine("Test de somme 14 - 8 :");
        int testSoustraction = Program.Soustraction(14, 8);
        Console.WriteLine(testSoustraction);
    }
}
