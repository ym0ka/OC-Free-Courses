using System.Text.Json;
using System.IO;

namespace P3C8;

public class SavingsAccount
{
    public decimal Balance;
    
    public SavingsAccount(decimal balance)
    {
        if (balance < 0)
        {
            throw new ArgumentException("Le découvert n'est pas autorisé sur ce compte.");
        }
        
        Balance = balance;
    }

    public static decimal GetSavingsAccountBalance(string json)
    {
        try
        {
            string jsonContent = File.ReadAllText(json);
            using JsonDocument accounts = JsonDocument.Parse(jsonContent);
            JsonElement root = accounts.RootElement;

            if (root.TryGetProperty("savingsAccountBalance", out JsonElement balanceElement) &&
                balanceElement.TryGetDecimal(out decimal balance))
            {
                return balance;
            }
            else
            {
                throw new KeyNotFoundException(
                    "Impossible de trouver la ligne 'savingsAccountBalance' dans le document.");
            }
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Le fichier JSON fourni n'est pas valide.", ex);
        }
    }
}