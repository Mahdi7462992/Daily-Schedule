using System.ComponentModel.DataAnnotations;

namespace EndPoint.Models.DomainModels.PlanAggregates
{
    public enum Time
    {
        [Display(Name = "06:00 to 08:00")]
        _06_To_08 = 0,

        [Display(Name = "08:00 to 10:00")]
        _08_To_10 = 1,

        [Display(Name = "10:00 to 12:00")]
        _10_To_12 = 2,

        [Display(Name = "12:00 to 14:00")]
        _12_To_14 = 3,

        [Display(Name = "14:00 to 16:00")]
        _14_To_16 = 4,

        [Display(Name = "16:00 to 18:00")]
        _16_To_18 = 5,

        [Display(Name = "18:00 to 20:00")]
        _18_To_20 = 6,

        [Display(Name = "20:00 to 22:00")]
        _20_To_22 = 7,

        [Display(Name = "22:00 to 00:00")]
        _22_To_00 = 8,

        [Display(Name = "00:00 to 02:00")]
        _00_To_02 = 9,

        [Display(Name = "02:00 to 04:00")]
        _02_To_04 = 10,

        [Display(Name = "04:00 to 06:00")]
        _04_To_06 = 11,
    }

}
