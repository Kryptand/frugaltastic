using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrossCutting.Balance.Models
{
    public class Expenditure
    {
        [Key]
        public Guid ExpenditureGuid { get; set; }
        [ForeignKey("BankAccount")]
        public Guid BankAccountGuid { get; set; }
        public DateTime DueDate { get; set; }
        public string For { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("ExpenditureType")]
        public Guid ExpenditureTypeGuid { get; set; }
        public ExpenditureType ExpenditureType { get; set; }
    }
}
