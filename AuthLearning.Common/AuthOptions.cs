using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AuthLearning.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; } // Who generated token 
        public string Audience { get; set; } // For token 
        public string Secret { get; set; } // Key
        public int TokenLifetime { get; set; } // secs
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            //return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)); specific error, need to analyse
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("somethingyouwantwhichissecurewillworkk"));
        }

    }
}
