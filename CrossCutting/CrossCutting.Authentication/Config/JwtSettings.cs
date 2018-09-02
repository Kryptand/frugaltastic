using System;

namespace CrossCutting.Authentication.Config
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public long ExpirationTime { get; set; }
        public DateTime? NotBefore { get; set; }
        public long IssuedAt { get; set; }
        public string JwtId { get; set; }
        public string Tenant { get; set; }
    }
}
