using System;
using System.Configuration;

namespace AzStorage.Utilities
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AzureStorage"]?.ConnectionString ?? string.Empty;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("AzureStorage ConnectionString not provided");
            }

            var resetUtil = new BlobReset(connectionString);
            
            // resets all blobs in all containers found in your storage account
            resetUtil.ResetAllContainers(); 

            // or reset all blobs in container named `playlists`
            //resetUtil.ResetBlobs("playlists");
        }
    }
}
