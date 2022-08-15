using System.ComponentModel.DataAnnotations;

namespace _Umuly.WebApi.Models.Enums
{
    public enum IncontermEnum
    {
        [Display(Name = "Delivered Duty Paid")]
        DTP,
        [Display(Name = "Delivered At Place")]
        DAP

    }
}
