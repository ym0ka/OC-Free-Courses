using System.Text.Json;
using System.IO;

namespace P3C8;

public class CurrentAccount
{
    public decimal Balance;
    
    public CurrentAccount(decimal balance)
    {
        if (balance < 0)
        {
            throw new ArgumentException("Le découvert n'est pas autorisé sur ce compte.");
        }
        
        Balance = balance;
    }

    public static decimal GetCurrentAccountBalance(string json)
    {
        try
        {
            string jsonContent = File.ReadAllText(json);
            using JsonDocument accounts = JsonDocument.Parse(jsonContent);
            JsonElement root = accounts.RootElement;

            if (root.TryGetProperty("currentAccountBalance", out JsonElement balanceElement) &&
                balanceElement.TryGetDecimal(out decimal balance))
            {
                return balance;
            }
            else
            {
                throw new KeyNotFoundException(
                    "Impossible de trouver la ligne 'currentAccountBalance' dans le document.");
            }
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Le fichier JSON fourni n'est pas valide.", ex);
        }
    }
}