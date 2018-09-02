using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrossCutting.Balance.Models
{
    public class BankAccount
    {
        [Key]
        public Guid BankAccountGuid { get; set; }
        [Key]
        public Guid TenantGuid { get; set; }
        [Key]
        public Guid UserGuid { get; set; }
        public string Description { get; set; }
        public string AccountIdentifier { get; set; }
        [ForeignKey("AccountBalance")]
        public Guid BalanceGuid { get; set; }
        public Balance AccountBalance { get; set; }

    }
}
