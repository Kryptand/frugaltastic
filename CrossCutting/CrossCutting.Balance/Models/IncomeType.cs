using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrossCutting.Balance.Models
{
    public class IncomeType
    {
        [Key]
        public Guid IncomeTypeGuid { get; set; }
        public string TypeName { get; set; }

    }
}
