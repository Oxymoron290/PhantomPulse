using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Threading.Tasks;

namespace AzureKeyVaultApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Do you want to authenticate using Managed Identity (yes/no)?");
            var useManagedIdentity = Console.ReadLine()?.ToLower() == "yes";

            Console.WriteLine("Enter the Key Vault URL:");
            var keyVaultUrl = Console.ReadLine();

            SecretClient client;
            
            if (useManagedIdentity)
            {
                client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            }
            else
            {
                Console.WriteLine("Enter the client ID:");
                var clientId = Console.ReadLine();

                Console.WriteLine("Enter the client secret:");
                var clientSecret = Console.ReadLine();

                Console.WriteLine("Enter the tenant ID:");
                var tenantId = Console.ReadLine();

                client = new SecretClient(new Uri(keyVaultUrl), new ClientSecretCredential(tenantId, clientId, clientSecret));
            }

            Console.WriteLine("Fetching secrets...");
            var response = client.GetPropertiesOfSecretsAsync();

            await foreach (var secret in response)
            {
                Console.WriteLine(secret.Name);
            }

            Console.WriteLine("Enter the name of the secret you want to retrieve:");
            var secretName = Console.ReadLine();

            var retrievedSecret = await client.GetSecretAsync(secretName);

            Console.WriteLine($"The value of the secret is: {retrievedSecret.Value.Value}");
        }
    }
}
