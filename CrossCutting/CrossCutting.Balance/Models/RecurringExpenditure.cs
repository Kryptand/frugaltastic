using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Balance.Models
{
    public class RecurringExpenditure : Expenditure, IRecurring
    {
        public DateTime BeginDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int DayInterval { get; set; }
    }
}
