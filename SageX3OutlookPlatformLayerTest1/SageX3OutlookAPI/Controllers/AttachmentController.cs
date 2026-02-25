using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.AttachmentR;

[Authorize]
[Route("api/attachments")]
public class AttachmentController : ControllerBase // Changed to ControllerBase
{
    private readonly IAttachmentService _attachmentService;

    public AttachmentController(IAttachmentService attachmentService)
        => _attachmentService = attachmentService;

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromBody] UploadAttachmentRequest request)
    {
        var result = await _attachmentService.UploadAttachmentAsync(request);

        if (result.Success)
        {
            // ✅ Ok() handles success (200 OK)
            return Ok(new { id = result.Id, message = "Upload successful" });
        }

        // ✅ BadRequest() handles failure (400 Bad Request)
        return BadRequest(result.Error ?? "Upload failed");
    }
}
