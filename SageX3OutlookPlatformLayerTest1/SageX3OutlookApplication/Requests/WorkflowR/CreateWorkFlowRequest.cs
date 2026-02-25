using System.ComponentModel.DataAnnotations;


namespace SageX3OutlookApplication.Requests.WorkflowR

{
    public class CreateWorkflowRequest
    {
        [Required]
        [MaxLength(150)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public string? DefinitionJson { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public string? ActionType { get; internal set; }
        public string? EntityType { get; internal set; }
        public Guid EntityId { get; internal set; }
    }
}