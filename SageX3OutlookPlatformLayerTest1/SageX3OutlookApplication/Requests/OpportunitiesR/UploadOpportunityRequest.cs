using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SageX3OutlookApplication.Requests.OpportunitiesR

{
    public class UploadOpportunityRequest
    {
        [Required]
        public Guid OpportunityId { get; set; }

        [Required]
        [MaxLength(200)]
        public string? DocumentName { get; set; }

        [Required]
        public IFormFile? File { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UploadedBy { get; set; }
    }
}