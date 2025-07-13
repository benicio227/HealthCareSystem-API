using HealthCareSystem.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HealthCareSystem.Infrastructure.Email
{
    public class SmsService : ISmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromNumber;

        public SmsService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"]!;
            _authToken = configuration["Twilio:AuthToken"]!;
            _fromNumber = configuration["Twilio:FromNumber"]!;
        }
        public async Task SendSms(string phoneNumber, string messageBody)
        {

            TwilioClient.Init(_accountSid, _authToken);

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber(phoneNumber),
                from: new PhoneNumber(_fromNumber),
                body: messageBody
            );

            Console.WriteLine($"Mensagem enviada com SID: {message.Sid}");
        }
    }
}
