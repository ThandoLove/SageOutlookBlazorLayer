using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookInfrastructure.Http;
public interface ISageHttpClient
{
    Task<string> GetAsync(string url, string accessToken);
    Task<string> PostAsync(string url, string accessToken, object body);
}