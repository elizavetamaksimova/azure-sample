using System;
using Microsoft.WindowsAzure.Storage.Table;
using QueueListener.Helpers.Models;
using QueueListener.Models;

namespace QueueListener.Helpers
{
    public static class TableStorageHelper
    {
        private const string SasUrl = "https://productdbstorage.table.core.windows.net/Products?sv=2017-04-17&tn=Products&sig=3qYFnQThDE%2BpIKaMgOy9DAB21GOa%2FRJAYRw3olt4oM4%3D&se=2017-11-11T07%3A38%3A34Z&sp=au";

        public static void AddTableLog(OperationType operationType, string blobPath, ProcessingType type, OperationResult result)
        {
            var cloudTable = new CloudTable(new Uri(SasUrl));

            var productLogEntity = new ProductLogEntity
            {
                PartitionKey = operationType.ToString(),
                BlobPath = blobPath,
                ProcessingType = type.ToString(),
                Result = result.ToString()
            };

            TableOperation insertOperation = TableOperation.Insert(productLogEntity);
            cloudTable.Execute(insertOperation);
        }
    }
}
