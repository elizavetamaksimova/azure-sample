using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AzurePlayArea.Data.DataAccess
{
    public class QueueStorageDataAccess
    {
        private const string ConnectionStringSettingName = "StorageConnectionString";
        private const string QueueName = "products";

        public void AddMessage(string messageContent)
        {
            CloudQueue queue = GetQueueReference();
            CloudQueueMessage message = new CloudQueueMessage(messageContent);

            queue.AddMessage(message);
        }

        public CloudQueue GetQueueReference()
        {
            string connectionString = CloudConfigurationManager.GetSetting(ConnectionStringSettingName);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(QueueName);

            queue.CreateIfNotExists();

            return queue;
        } 
    }
}
