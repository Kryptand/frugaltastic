using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrossCutting.Balance.Models
{
    public class Balance
    {
        [Key]
        public Guid BalanceGuid { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
