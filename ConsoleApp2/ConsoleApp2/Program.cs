using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class WebsiteDataModel
    {
        public string WebsiteUrl { get; set; } = "";
        public string WebsiteData { get; set; } = "";
    }
    internal class Bacon { }
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("DownloadWebsiteAsync_WithReturnValue >> ");
            WebsiteDataModel task = await DownloadWebsiteAsync_WithReturnValue();
            Console.WriteLine(task.WebsiteUrl);

            Console.WriteLine("DownloadWebsiteAsync_WithoutReturnValue >> ");
            await DownloadWebsiteAsync_WithoutReturnValue();
      
            Bacon obj = await FryBaconAsync(2);

            Console.ReadLine();
        }


        private static async Task<WebsiteDataModel>DownloadWebsiteAsync_WithReturnValue()
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();
            output.WebsiteUrl = "https://www.yahoo.com";
            output.WebsiteData = await client.DownloadStringTaskAsync("https://www.yahoo.com");
            return output;
       }


        private static async Task DownloadWebsiteAsync_WithoutReturnValue()
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();
            output.WebsiteUrl = "https://www.yahoo.com";
            output.WebsiteData = await client.DownloadStringTaskAsync("https://www.yahoo.com");
        }


        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(1000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(1000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }


        public async Task<int> GetUrlContentLengthAsync()
        {
            var client = new HttpClient();
            Task<string> getStringTask =client.GetStringAsync("https://docs.microsoft.com/dotnet");
            DoIndependentWork();
            string contents = await getStringTask;
            return contents.Length;
        }

        void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
    }


}
