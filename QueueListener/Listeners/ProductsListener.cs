using System;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using QueueListener.Helpers;
using QueueListener.Helpers.Models;
using QueueListener.Models;

namespace QueueListener.Listeners
{
    public class ProductsListener
    {
        /// <summary>
        /// Listens to queue and gets messages; messages are not deleted; 
        /// Messages will appear in queue again in 5 seconds
        /// </summary>
        /// <param name="queue">Cloud queue to listen</param>
        public void Listen(CloudQueue queue)
        {
            while (true)
            {
                // Get message frim queue; message will be invisible for 5 seconds
                CloudQueueMessage message = queue.GetMessage(new TimeSpan(0, 0, 10));

                // if there are no more messages
                if (message == null)
                {
                    continue;
                }

                var fileInfo = JsonConvert.DeserializeObject<FileInfo>(message.AsString);

                // some operation here is performed

                TableStorageHelper.AddTableLog(OperationType.Products, fileInfo.BlobPath, fileInfo.ProcessingType, OperationResult.Success);

                Console.WriteLine("Message successfully processed. Blob path {0}", fileInfo.BlobPath);
            }
        }

        /// <summary>
        /// Gets reference to the queue using SAS URL
        /// </summary>
        /// <param name="sasUrl">SAS URL to access queue</param>
        /// <returns>Cloud Queue object</returns>
        public CloudQueue GetQueueReference(string sasUrl)
        {
            var queue = new CloudQueue(new Uri(sasUrl));
            return queue;
        }
    }
}
