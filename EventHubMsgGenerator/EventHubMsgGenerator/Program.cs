using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace EventHubMsgGenerator
{
    class Program
    {
        static string eventHubName = "eventhubdemo";
        static string connectionString = "Endpoint=sb://eventhubtestjmr.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=W2stnRWj4HZ8gZGBL223OgSapdPvB0bkSP/Zbmui+Fk=";

        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl-C to stop the sender process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();
            SendingRandomMessages();
        }

        static void SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
            while (true)
            {
                Random rnd = new Random();
                try
                {
                    var myPh = rnd.Next(0, 10);

                    phReadingObj ph = new phReadingObj();
                    ph.nurseryId = 1;
                    ph.rowId = 2;
                    ph.phReading = myPh;

                    var serializedstring = JsonConvert.SerializeObject(ph);
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, serializedstring);
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(serializedstring)));
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

                Thread.Sleep(5000);
            }
        }
    }

    class phReadingObj
    {
        public int nurseryId { get; set; }
        public int rowId { get; set; }
        public int sensorId { get; set; }
        public double phReading { get; set; }
        public DateTime DTStamp = DateTime.Now;
    }
}
