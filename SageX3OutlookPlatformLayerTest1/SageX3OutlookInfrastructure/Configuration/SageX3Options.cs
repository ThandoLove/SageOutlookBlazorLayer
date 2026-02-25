using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookInfrastructure.Configuration;
public class SageX3Options
{
    public string BaseUrl { get; set; } = "https://mock-sagex3.local/api";
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}