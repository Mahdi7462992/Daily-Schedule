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
        public Day Day { get; set; }
    }
    public enum Day
    {
        Saturday = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6,
    }
    public enum Time
    {

        _06_00_To_08_00 = 0,
        _08_00_To_10_00 = 1,
        _10_00_To_12_00 = 2,
        _12_00_To_14_00 = 3,
        _14_00_To_16_00 = 4,
        _16_00_To_18_00 = 5,
        _18_00_To_20_00 = 6,
        _20_00_To_22_00 = 7,
        _22_00_To_00_00 = 8,
        _00_00_To_02_00 = 9,
        _02_00_To_04_00 = 10,
        _04_00_To_06_00 = 11,

        //06:00-08:00=0
        //08:00-10:00=1
        //10:00-12:00=2
        //12:00-14:00=3
        //14:00-16:00=4
        //16:00-18:00=5
        //18:00-20:00=6
        //20:00-22:00=7
        //22:00-00:00=8
        //00:00-02:00=9
        //02:00-04:00=10
        //04:00-06:00=11
    }
    
}
