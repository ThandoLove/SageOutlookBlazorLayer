using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SageX3OutlookApplication.Requests.TasksR

{
    public class UploadTaskRequest
    {
        [Required]
        public Guid TaskId { get; set; }

        [Required]
        [MaxLength(200)]
        public string? AttachmentName { get; set; }

        [Required]
        public IFormFile? File { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UploadedBy { get; set; }
    }
}