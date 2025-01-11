﻿using P2C4._1;

// Le programme affiche la température moyenne à partir des valeurs fournies comme arguments en ligne de commande

List<int> temperaturesEnregistreDegresCelcius = new List<int>();

// Remplir la liste à partir des valeurs fournies comme arguments en ligne de commande
foreach (string stringRepresentationTemperature in args)
{
    int temperature = int.Parse(stringRepresentationTemperature);
    temperaturesEnregistreDegresCelcius.Add(temperature);
}

// Calculer et afficher la température moyenne
int temperatureMoyenne = MathSimple.CalculMoyenne(temperaturesEnregistreDegresCelcius);
Console.WriteLine("La température moyenne est " + temperatureMoyenne);

//dotnet run 4 7 9 16 > La température moyenne est 9
//dotnet run 4 7 > La température moyenne est 5