namespace _Umuly.WebApi.Dto
{
    public class QuoteOwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string? CompanyName { get; set; }
    }
}
