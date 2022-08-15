
using _Umuly.WebMvc.Models.Enums;

namespace _Umuly.WebMvc.Models

{
    public class Quote : BaseEntity
    {
        public int OwnerId { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public int CurrencyId { get; set; }
        public WeightUnitEnum WeightType { get; set; }
        public LengthUnitEnum LengthType { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public ModeEnum Mode { get; set; }
        public MovementTypeEnum MovementType { get; set; } 
        public IncontermEnum Incoterm { get; set; } 
        public PackageTypeEnum PackageType { get; set; } 
        public string QuoteNote { get; set; }
    }
}
