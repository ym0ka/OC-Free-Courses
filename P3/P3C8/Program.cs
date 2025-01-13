using System;
using System.Text.Json;
using System.IO;

namespace P3C8
{
    public class Program
    {
        public const string AccountPath = "account.json";
        
        public static void Main()
        {
            Console.WriteLine("Bienvenue sur MyBank.\nAppuyez sur Entrée pour continuer.");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Vous n'avez pas appuyé sur Entrée, le programme se termine.");
                return;
            }

            Console.WriteLine("Veuillez sélectionner une option ci-dessous :\n[I] Voir les informations sur le titulaire du compte\n[CS] Compte courant - Consulter le solde\n[CD] Compte courant - Déposer des fonds\n[CR] Compte courant - Retirer des fonds\n[ES] Compte épargne - Consulter le solde\n[ED] Compte épargne - Déposer des fonds\n[ER] Compte épargne - Retirer des fonds\n[X] Quitter");

            List<string> menuOptions = new List<string> { "I", "CS", "CD", "CR", "ES", "ED", "ER", "X" };
            
            //On crée ici une boucle infinie pour garder l'utilisateur dans le menu jusqu'à ce qu'il quitte explicitement ou fasse un choix correct.
            while (true)
            {
                //Pour éviter le cas où l'utilisateur ne met pas de majuscule en entrant les lettres dans la console, on fait un ToUpper().
                string userMenuChoice = Console.ReadLine().Trim().ToUpper();
                if (!menuOptions.Contains(userMenuChoice))
                {
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                    continue;
                }
                
                //Si le choix est valide, on précharge toutes les informations de lecture du compte pour ne plus avoir à le faire dans chaque case du switch.
                decimal currentUserBalance = CurrentAccount.GetCurrentAccountBalance(AccountPath);
                decimal savingsUserBalance = SavingsAccount.GetSavingsAccountBalance(AccountPath);
                string userFirstname = GetUserAccountFirstname(AccountPath);
                string userLastname = GetUserAccountLastname(AccountPath);

                switch (userMenuChoice)
                {
                    case "I":
                        Console.WriteLine($"Bonjour {userFirstname} {userLastname} !");
                        Console.WriteLine($"Vous possédez actuellement {currentUserBalance}€ sur votre compte courant.");
                        Console.WriteLine($"Vous possédez actuellement {savingsUserBalance}€ sur votre compte courant.");
                        break;
                    case "CS":
                        Console.WriteLine($"Vous possédez actuellement {currentUserBalance}€ sur votre compte courant.");
                        break;
                    case "CD":
                        //TODO : Prompt value à déposer, confirmer la valeur + mettre le fichier à jour
                        Console.WriteLine("CD");
                        break;
                    case "CR":
                        //TODO : Prompt value à retirer, confirmer la valeur + mettre le fichier à jour
                        Console.WriteLine("CR");
                        break;
                    case "ES":
                        Console.WriteLine($"Vous possédez actuellement {savingsUserBalance}€ sur votre compte courant.");
                        break;
                    case "ED":
                        //TODO : Prompt value à déposer, confirmer la valeur + mettre le fichier à jour
                        Console.WriteLine("ED");
                        break;
                    case "ER":
                        //TODO : Prompt value à retirer, confirmer la valeur + mettre le fichier à jour
                        Console.WriteLine("ER");
                        break;
                    case "X":
                        //TODO : Quitter le programme
                        Console.WriteLine("X");
                        return;
                }
            }
        }

        public static string GetUserAccountFirstname(string json)
        {
            try
            {
                string jsonContent = File.ReadAllText(json);
                using JsonDocument accounts = JsonDocument.Parse(jsonContent);
                JsonElement root = accounts.RootElement;

                return root.GetProperty("firstname").GetString();
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException();
            }
        }
        
        public static string GetUserAccountLastname(string json)
        {
            try
            {
                string jsonContent = File.ReadAllText(json);
                using JsonDocument accounts = JsonDocument.Parse(jsonContent);
                JsonElement root = accounts.RootElement;

                return root.GetProperty("lastname").GetString();
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
