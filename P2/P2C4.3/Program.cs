using P2C4._3;

try
{
    List<int> temperaturesEnregistreDegresCelcius = new List<int>();

    // remplir la liste à partir des valeurs fournies comme arguments en ligne de commande
    foreach (string stringRepresentationTemperature in args)
    {
        int temperature = int.Parse(stringRepresentationTemperature);
        temperaturesEnregistreDegresCelcius.Add(temperature);
    }

    // Calculer et afficher la température moyenne
    int moyenneTemperature = MathSimple.CalculMoyenne(temperaturesEnregistreDegresCelcius);
    Console.WriteLine("La température moyenne est " + moyenneTemperature);
}
catch (DivideByZeroException e)
{
    Console.WriteLine("Il est impossible de diviser par 0. Un minimum d'arguments est attendu.");
}
catch (FormatException e)
{
    Console.WriteLine("Le format des valeurs entrées est incorrect. Attendu : nombres entiers.")
}

//AVANT DE MODIFIER LE SCRIPT
//dotnet run > Unhandled exception. System.DivideByZeroException: Attempted to divide by zero.
// Le script crash car sans argument donnés, il essaie tout de même de diviser par 0, ce qui est impossible.

//dotnet run 3 9 4 > La température moyenne est 5
//Une valeur entière est retournée car on utilise une liste et des variables en int, qui ne permettent pas les décimales.

//APRES MODIFICATION
//dotnet run > Il est impossible de diviser par 0.
//Le script ne crash pas et précise que l'utilisateur ne peut pas diviser par 0 (ou ne fournir aucun argument)

//dotnet run 3 neuf 4 > Le format des valeurs entrées est incorrect. Attendu : nombres entiers.
//Le script ne crash pas et précise qu'on attend des nombres donnés au bon format.
