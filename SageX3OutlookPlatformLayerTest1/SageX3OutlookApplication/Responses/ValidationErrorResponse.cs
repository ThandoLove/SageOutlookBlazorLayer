using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Responses
{
    public class ValidationErrorResponse
    {
        public bool Success => false;
        public List<string> Errors { get; set; } = new();
    }
}
