using System.ComponentModel.DataAnnotations;

namespace _Umuly.WebMvc.Models.Enums
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
