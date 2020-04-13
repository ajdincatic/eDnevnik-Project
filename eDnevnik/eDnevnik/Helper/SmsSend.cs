using Microsoft.Extensions.Options;
using Nexmo.Api;
using Nexmo.Api.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDnevnik.Helper
{
    public class SmsConfig
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string BrojTelefonaPosiljaoca { get; set; }
    }

    public class SmsSend
    {
        public static void Send(IOptions<SmsConfig> options, string BrojTelefonaPrimaoca, string sadrzaj)
        {
            var client = new Client(new Credentials(options.Value.ApiKey, options.Value.ApiSecret));

            client.SMS.Send(new SMS.SMSRequest
            {
                from = options.Value.BrojTelefonaPosiljaoca,
                to = BrojTelefonaPrimaoca,
                text = sadrzaj,
                type = "unicode"
            });
        }
    }
}
