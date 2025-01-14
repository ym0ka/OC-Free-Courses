using System;
using System.Text.Json;
using System.IO;

namespace P3C8
{
    public class Program
    {
        private const string AccountPath = "./account.json";
        
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
                        Console.WriteLine("Quel montant souhaitez-vous déposer ? ");
                        string userAmountToDeposit = null;
                        while (string.IsNullOrWhiteSpace(userAmountToDeposit) || !decimal.TryParse(userAmountToDeposit, out _) || decimal.Parse(userAmountToDeposit) < 0)
                        {
                            userAmountToDeposit = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(userAmountToDeposit))
                            {
                                Console.WriteLine("Merci d'entrer une valeur non nulle.");
                            }
                            
                            if (decimal.TryParse(userAmountToDeposit, out _))
                            {
                                Console.WriteLine("Merci d'entrer un chiffre.");
                            }
                            
                            if (decimal.Parse(userAmountToDeposit) < 0)
                            {
                                Console.WriteLine("Merci d'entrer un chiffre supérieur à 0.");
                            }
                        }
                        decimal userAccountBalanceAfterDeposit = CurrentAccount.DisposalMoneyToCurrentAccount(decimal.Parse(userAmountToDeposit), AccountPath);
                        Console.WriteLine($"Vous avez déposé {userAmountToDeposit}€ sur votre compte courant. !\nVous possédez désormais {userAccountBalanceAfterDeposit}€ !");
                        //TODO : Prompt value à retirer, confirmer la valeur + mettre le fichier à jour
                        Console.WriteLine("CR");
                        break;
                    case "CR":
                        Console.WriteLine("Quel montant souhaitez-vous retirer ? ");
                        string userAmountToWithdraw = null;
                        while (string.IsNullOrWhiteSpace(userAmountToWithdraw) || !decimal.TryParse(userAmountToWithdraw, out _) || decimal.Parse(userAmountToWithdraw) < 0)
                        {
                            userAmountToWithdraw = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(userAmountToWithdraw))
                            {
                                Console.WriteLine("Merci d'entrer une valeur non nulle.");
                            }
                            
                            if (decimal.TryParse(userAmountToWithdraw, out _))
                            {
                                Console.WriteLine("Merci d'entrer un chiffre.");
                            }
                            
                            if (decimal.Parse(userAmountToWithdraw) < 0)
                            {
                                Console.WriteLine("Merci d'entrer un chiffre supérieur à 0.");
                            }
                        }
                        decimal userAccountBalanceAfterWithdraw = CurrentAccount.WithdrawMoneyFromCurrentAccount(decimal.Parse(userAmountToWithdraw), AccountPath);
                        Console.WriteLine($"Vous avez retiré {userAmountToWithdraw}€ de votre compte courant. !\nVous possédez désormais {userAccountBalanceAfterWithdraw}€ !");
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

        private static string GetUserAccountFirstname(string json)
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
        
        private static string GetUserAccountLastname(string json)
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
