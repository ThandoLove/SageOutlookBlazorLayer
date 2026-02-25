using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Interfaces;

public interface ISecurityFilterService
{
    bool IsAuthorized(Guid userId, string resource);
}
