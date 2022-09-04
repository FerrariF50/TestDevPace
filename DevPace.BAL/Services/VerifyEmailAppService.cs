using Customer.BAL.Interfaces;
using System;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Customer.BAL.Services
{
    public class VerifyEmailAppService : IVerifyEmailAppService
    {
        public string MatchEmailPattern =
          @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
   + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
   + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
   + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
        public bool IsValidEmail(string email)
        {
            var regex = new Regex(MatchEmailPattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
