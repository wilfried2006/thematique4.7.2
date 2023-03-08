using System;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace LamyThematique.Domain.Helpers
{
    public static class AzureHelper
    {
        public static string GetSecretValue(string keyVaultUrl, string secretName)
        {
            var options = new SecretClientOptions()
            {
                Retry = { Delay = TimeSpan.FromSeconds(2), MaxDelay = TimeSpan.FromSeconds(16), MaxRetries = 5, Mode = RetryMode.Exponential }
            };

            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential(), options);

            KeyVaultSecret devSecret = client.GetSecret(secretName);

            return devSecret.Value;
        }
    }
}
