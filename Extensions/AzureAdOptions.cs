namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// This class is where the users data is stored after he logs in
    /// </summary>
    public class AzureAdOptions
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Instance { get; set; }

        public string Domain { get; set; }

        public string TenantId { get; set; }

        public string CallbackPath { get; set; }
    }
}
