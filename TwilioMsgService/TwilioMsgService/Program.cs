using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace TwilioMsgService
{
    class Program
    {
        static void Main(string[] args)
        {
            string AccountSid = "[REMOVED]";
            string AuthToken = "[REMOVED]";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            Console.WriteLine("Attempting to Send Message");
            var message = twilio.SendMessage(
                "+15615551212", "+15615551212",
                "PH Level is High"
            );

            Console.WriteLine(message.Sid);

        }
    }
}
