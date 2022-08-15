using _Umuly.WebApi.Models.Enums;

namespace _Umuly.WebApi.Dto
{
    public class QuoteDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public int CurrencyId { get; set; }
        public WeightUnitEnum WeightType { get; set; }//ok
        public LengthUnitEnum LengthType { get; set; }//ok
        public int Weight { get; set; }//ok
        public int Height { get; set; }//ok
        public int Width { get; set; }//ok
        public int Length { get; set; }//ok
        public ModeEnum Mode { get; set; }//ok
        public MovementTypeEnum MovementType { get; set; } //ok
        public IncontermEnum Incoterm { get; set; } //ok
        public PackageTypeEnum PackageType { get; set; } //ok
        public string QuoteNote { get; set; }//ok
    }
}
