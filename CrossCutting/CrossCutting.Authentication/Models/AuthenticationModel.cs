using System;
using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Authentication.Models{
    public class AuthenticationModel
    {
        [Key]
        public Guid AuthenticationGuid { get; set; }
        public string UserIdentification { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
