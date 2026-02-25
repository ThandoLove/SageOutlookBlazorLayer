namespace SageX3OutlookApplication.DTOs

{
    public class OpportunityDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Account { get; set; }
        public decimal Value { get; set; }
        public string? Stage { get; set; }
        public Guid OwnerId { get; set; }
    }
}