using System;

namespace KeraNaidi.Data.Models
{
    public class TokenResponse
    {
        public string Token {get;set;} = string.Empty;
        public DateTime Expiration{get;set;}
        public string UserName {get;set;} = string.Empty;
    }
}
