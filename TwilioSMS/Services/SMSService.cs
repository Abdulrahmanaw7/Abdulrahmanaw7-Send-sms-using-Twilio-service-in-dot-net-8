using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using TwilioSMS.Helpers;

namespace TwilioSMS.Services
{
    public class SMSService(IOptions<TwilioSettings> twilio) : ISMSService
    {
        private readonly TwilioSettings _twilio = twilio.Value;


        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);

            var result = MessageResource.Create(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(_twilio.TwilioPhoneNumber),
                    to: mobileNumber
                );

            return result;
        }
    }
}
