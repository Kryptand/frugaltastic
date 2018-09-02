using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrossCutting.Balance.Models
{
    public class ExpenditureType
    {
        [Key]
        public Guid ExpenditureGuid { get; set; }
        public string TypeName { get; set; }
    }
}
