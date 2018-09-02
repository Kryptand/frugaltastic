using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrossCutting.Balance.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionGuid { get; set; }
        [Key]
        public Guid BankAccountGuid { get; set; }
        public DateTime ScheduledAt { get; set; }
        public decimal TransactionValue { get; set; }
    }
}
