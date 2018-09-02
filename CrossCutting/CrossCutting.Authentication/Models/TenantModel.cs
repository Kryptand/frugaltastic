using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrossCutting.Authentication.Models
{
    public class TenantModel
    {
        [Key]
        public Guid TenantGuid { get; set; }
        public string Description { get; set; }
    }
}
