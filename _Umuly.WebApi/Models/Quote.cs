
using _Umuly.WebApi.Models.Enums;

namespace _Umuly.WebApi.Models
{
    public class Quote : BaseEntity
    {
        public int QuoteOwnerId { get; set; }
        public QuoteOwner QuoteOwner { get; set; }
        public int FromCityId { get; set; }

        public City FromCity { get; set; }
        public int ToCityId { get; set; }

        public City ToCity { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
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
