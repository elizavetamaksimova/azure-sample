using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage.Table;

namespace QueueListener.Helpers.Models
{
    public class ProductLogEntity : TableEntity
    {
        public ProductLogEntity()
        {
            RowKey = GetRowKey(DateTime.Now);
        }

        public string BlobPath { get; set; }

        public string ProcessingType { get; set; }

        public string Result { get; set; }

        public static string GetRowKey(DateTime dateTime)
        {
            int seqId = int.MaxValue - Environment.TickCount;
            return ((long) (new DateTime(2100, 1, 1) - dateTime).TotalMilliseconds).ToString("X16") + "-" +
                   Interlocked.Decrement(ref seqId).ToString("X8");
        }
    }
}
