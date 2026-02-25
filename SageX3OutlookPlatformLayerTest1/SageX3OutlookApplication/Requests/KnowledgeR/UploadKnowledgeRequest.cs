using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SageX3OutlookApplication.Requests.KnowledgeR

{
    public class UploadKnowledgeRequest
    {
        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public required IFormFile File { get; set; }

        [Required]
        [MaxLength(100)]
        public required string UploadedBy { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }
    }
}