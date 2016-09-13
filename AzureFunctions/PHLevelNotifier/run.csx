using System;
using Twilio;
using System.Configuration;

public static void Run(string myEventHubMessage, TraceWriter log)
{
    log.Info($"C# Event Hub trigger function processed a message: {myEventHubMessage}");
    
    string AccountSid = ConfigurationManager.AppSettings["TwilioAccountSID"];
    string AuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
    var twilio = new TwilioRestClient(AccountSid, AuthToken);

    log.Info("Attempting to Send Message");
    var message = twilio.SendMessage(
        ConfigurationManager.AppSettings["TwilioFrom"], 
        ConfigurationManager.AppSettings["TwilioTo"],
        myEventHubMessage
    );
    log.Info("Message ID: " + message.Sid);
    
}