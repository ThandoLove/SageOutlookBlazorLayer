using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Requests.LeadsR

{
    public class CreateLeadRequest
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}