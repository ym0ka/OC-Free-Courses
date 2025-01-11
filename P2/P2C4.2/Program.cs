
using P2C4._2;

List<int> temperaturesEnregistreDegresCelcius = new List<int>();

// remplir la liste à partir des valeurs fournies comme arguments en ligne de commande
foreach (string stringRepresentationTemperature in args)
{
    int temperature = int.Parse(stringRepresentationTemperature);
    temperaturesEnregistreDegresCelcius.Add(temperature);
}

// Attention aux listes vides
if (temperaturesEnregistreDegresCelcius.Count == 0)
{
    Console.WriteLine("Impossible de calculer la moyenne avec une liste vide !");
}
else
{
    // Calculer et afficher la température moyenne
    int temperatureMoyenne = MathSimple.CalculMoyenne(temperaturesEnregistreDegresCelcius);
    Console.WriteLine("La température moyenne est " + temperatureMoyenne);
}

//dotnet run > Impossible de calculer la moyenne avec une liste vide !
//dotnet run 8 6 9 > La température moyenne est 7
//dotnet run 8 6 huit 2 > Unhandled exception. System.FormatException: The input string 'huit' was not in a correct format.

