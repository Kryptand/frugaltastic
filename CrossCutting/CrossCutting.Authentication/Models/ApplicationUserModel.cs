using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossCutting.Authentication.Models
{
    public class ApplicationUserModel
    {
        [Key]
        public Guid ApplicationUserGuid { get; set; }
        [ForeignKey("AuthenticationModel")]
        public Guid AuthenticationModelGuid { get; set; }
        [ForeignKey("TenantModel")]
        public Guid TenantGuid { get; set; }
        public TenantModel Tenant { get; set; }
        public virtual AuthenticationModel AuthenticationModel { get; set; }

    }
}
