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
    
    public static decimal DisposalMoneyToSavingsAccount(decimal amount, string json)
    {
        decimal newAccountBalance;
        
        try
        {
            string jsonContent = File.ReadAllText(json);
            using JsonDocument accounts = JsonDocument.Parse(jsonContent);
            JsonElement root = accounts.RootElement;

            if (root.TryGetProperty("savingsAccountBalance", out JsonElement balanceElement) &&
                balanceElement.TryGetDecimal(out decimal balance))
            {
                newAccountBalance = balance + amount;
                Dictionary<string, object> updatedJson = new Dictionary<string, object>();
                foreach (JsonProperty property in root.EnumerateObject())
                {
                    if (property.Name == "savingsAccountBalance")
                    {
                        updatedJson[property.Name] = newAccountBalance;
                    }
                    else
                    {
                        updatedJson[property.Name] = property.Value.Clone();
                    }
                }
                
                string updatedJsonString = JsonSerializer.Serialize(updatedJson, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(json, updatedJsonString);
                return newAccountBalance;
            }
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
    
    public static decimal WithdrawMoneyFromSavingsAccount(decimal amount, string json)
    {
        decimal newAccountBalance;
        
        try
        {
            string jsonContent = File.ReadAllText(json);
            using JsonDocument accounts = JsonDocument.Parse(jsonContent);
            JsonElement root = accounts.RootElement;

            if (root.TryGetProperty("savingsAccountBalance", out JsonElement balanceElement) &&
                balanceElement.TryGetDecimal(out decimal balance))
            {
                newAccountBalance = balance - amount;
                Dictionary<string, object> updatedJson = new Dictionary<string, object>();
                foreach (JsonProperty property in root.EnumerateObject())
                {
                    if (property.Name == "savingsAccountBalance" && newAccountBalance >= 0)
                    {
                        updatedJson[property.Name] = newAccountBalance;
                    }
                    else
                    {
                        Console.WriteLine("Impossible de retirer plus d'argent que vous ne possédez !");
                        updatedJson[property.Name] = property.Value.Clone();
                    }
                }
                
                string updatedJsonString = JsonSerializer.Serialize(updatedJson, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(json, updatedJsonString);
                return newAccountBalance;
            }
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