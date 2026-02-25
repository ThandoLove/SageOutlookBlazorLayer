using global::SageX3OutlookInfrastructure.Exceptions;
using global::SageX3OutlookInfrastructure.Http;
using SageX3OutlookApplication.DTOs;


namespace SageX3OutlookInfrastructure.SageX3

{
    /// <summary>
    /// Handles attachment uploads and downloads to Sage X3 ERP
    /// </summary>
    public class SageX3AttachmentService
    {
        private readonly SageHttpClient _httpClient;

        public SageX3AttachmentService(SageHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Uploads an attachment to Sage X3
        /// </summary>
        public async Task<AttachmentDto> UploadAttachmentAsync(AttachmentDto attachment, string bearerToken)
        {
            try
            {
                return await _httpClient.PostAsync<AttachmentDto>("attachments/upload", attachment, bearerToken);
            }
            catch (Exception ex)
            {
                throw new SageIntegrationException("Failed to upload attachment to Sage X3.", "SAGE_ATTACHMENT_ERROR", ex);
            }
        }

        /// <summary>
        /// Download an attachment from Sage X3
        /// </summary>
        public async Task<byte[]> DownloadAttachmentAsync(Guid attachmentId, string bearerToken)
        {
            try
            {
                return await _httpClient.GetAsync<byte[]>($"attachments/download/{attachmentId}", bearerToken);
            }
            catch (Exception ex)
            {
                throw new SageIntegrationException("Failed to download attachment from Sage X3.", "SAGE_ATTACHMENT_ERROR", ex);
            }
        }
    }
}