using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EndPoint.Models.DomainModels.PlanAggregates
{
    public class Plan
    {
        public long Id { get; set; }
        public Time Time { get; set; }
        [Required]
        public string Detail { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }

}
