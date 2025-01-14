using System.Text.Json;
using System.IO;

namespace P3C8;

public class CurrentAccount
{
    public static decimal Balance;
    
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

    public static decimal DisposalMoneyToCurrentAccount(decimal amount, string json)
    {
        decimal newAccountBalance;
        
        try
        {
            string jsonContent = File.ReadAllText(json);
            using JsonDocument accounts = JsonDocument.Parse(jsonContent);
            JsonElement root = accounts.RootElement;

            if (root.TryGetProperty("currentAccountBalance", out JsonElement balanceElement) &&
                balanceElement.TryGetDecimal(out decimal balance))
            {
                newAccountBalance = balance + amount;
                Dictionary<string, object> updatedJson = new Dictionary<string, object>();
                foreach (JsonProperty property in root.EnumerateObject())
                {
                    if (property.Name == "currentAccountBalance")
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
    
    public static decimal WithdrawMoneyFromCurrentAccount(decimal amount, string json)
    {
        decimal newAccountBalance;
        
        try
        {
            string jsonContent = File.ReadAllText(json);
            using JsonDocument accounts = JsonDocument.Parse(jsonContent);
            JsonElement root = accounts.RootElement;

            if (root.TryGetProperty("currentAccountBalance", out JsonElement balanceElement) &&
                balanceElement.TryGetDecimal(out decimal balance))
            {
                newAccountBalance = balance - amount;
                Dictionary<string, object> updatedJson = new Dictionary<string, object>();
                foreach (JsonProperty property in root.EnumerateObject())
                {
                    if (property.Name == "currentAccountBalance" && newAccountBalance >= 0)
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