using System;

namespace CrossCutting.Balance.Models
{
    public interface IRecurring
    {
        DateTime BeginDate { get; set; }
        int DayInterval { get; set; }
        DateTime EndDate { get; set; }
    }
}