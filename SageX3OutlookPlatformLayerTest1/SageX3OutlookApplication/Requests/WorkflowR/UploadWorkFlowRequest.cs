using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SageX3OutlookApplication.Requests.WorkflowR

{
    public class UploadWorkflowRequest
    {
        [Required]
        [MaxLength(150)]
        public string? WorkflowName { get; set; }

        [Required]
        public IFormFile? DefinitionFile { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UploadedBy { get; set; }
    }
}