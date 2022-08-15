using System.ComponentModel.DataAnnotations;

namespace _Umuly.WebApi.Models.Enums
{
    public enum ModeEnum
    {
        [Display(Name = "Full Container Load")]
        LCL,
        [Display(Name = "Less Container Load")]
        FCL,
        AIR
    }
}
