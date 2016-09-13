using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace TwilioResponder.Controllers
{
    public class SmsController : TwilioController
    {
        [HttpPost]
        public ActionResult Index(SmsRequest request)
        {
            // set message based on command received
            var msg = "Invalid Command Received.";
            if (request.Body.ToLower().Contains("add acid")) msg = "Increasing Acid Flow";
            if (request.Body.ToLower().Contains("add water")) msg = "Increasing Water Flow";
            if (request.Body.ToLower().Contains("reduce acid")) msg = "Reducing Acid flow";
            if (request.Body.ToLower().Contains("reduce water")) msg = "Reducing Water Flow";

            //TODO: Fire off message to event hub to trigger action on IoT Device

            // Send response back to twilio to give feedback to the user. 
            var response = new TwilioResponse();
            response.Sms(msg);
            return TwiML(response);
        }
    }
}