using Microsoft.WindowsAzure.Storage.Queue;
using QueueListener.Listeners;

namespace QueueListener
{
    public class Program
    {
        private const string SasUrl = "https://productdbstorage.queue.core.windows.net/products?sv=2017-04-17&sig=Y70U170JBWtezbAIP9c4XC5DFrCzh2Z%2Be59YLjAaHXU%3D&se=2017-11-11T07%3A37%3A36Z&sp=rp";

        public static void Main(string[] args)
        {
            var listener = new ProductsListener();
            CloudQueue queue = listener.GetQueueReference(SasUrl);

            listener.Listen(queue);
        }
    }
}
