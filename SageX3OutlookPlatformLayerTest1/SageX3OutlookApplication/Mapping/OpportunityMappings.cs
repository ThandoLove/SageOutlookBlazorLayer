using SageX3OutlookApplication.DTOs;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Mapping;

public static class OpportunityMappings
{
    public static OpportunityDto ToDto(this Opportunity entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        return new OpportunityDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Account = entity.Account,
            Value = entity.Value,
            Stage = entity.Stage,
            OwnerId = entity.OwnerId
        };
    }
}
