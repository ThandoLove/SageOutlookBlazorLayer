using SageX3OutlookApplication.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SageX3OutlookApplication.Interfaces;

public interface IAutoLinkService
{
    Task<AutoLinkResultDto> AutoLinkEmailAsync(string emailId);
    Task<List<AutoLinkResultDto>> GetAllAutoLinksAsync();
}
