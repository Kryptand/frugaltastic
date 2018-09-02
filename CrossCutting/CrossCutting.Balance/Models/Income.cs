using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossCutting.Balance.Models
{
    public class Income
    {
        [Key]
        public Guid IncomeGuid { get; set; }
        [ForeignKey("BankAccount")]
        public Guid BankAccountGuid { get; set; }
        [ForeignKey("IncomeType")]
        public Guid IncomeTypeGuid { get; set; }
        public IncomeType IncomeType { get; set; }
        public DateTime DueDate { get; set; }
        public decimal ValueDecimal { get; set; }
    }
}