
namespace  SageX3OutlookApplication.DTOs
{
    public class LeadDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = "New";
    }
}