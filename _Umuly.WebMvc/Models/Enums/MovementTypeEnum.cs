using System.ComponentModel.DataAnnotations;

namespace _Umuly.WebMvc.Models.Enums
{
    public enum MovementTypeEnum
    {
        [Display(Name = "DOOR TO DOOR")]
        DTD,
        [Display(Name = "PORT TO PORT")]
        PTP,
        [Display(Name = "DOOR TO PORT")]
        DTP,
        [Display(Name = "PORT TO DOOR")]
        PTD
    }
}
