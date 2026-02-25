using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SageX3OutlookApplication.Requests.WorkflowR

{
    public class UpdateWorkflowRequest
    {
        [Required]
        public Guid Id { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? DefinitionJson { get; set; }

        public bool? IsActive { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UpdatedBy { get; set; }
        public string? Status { get; internal set; }
    }
}