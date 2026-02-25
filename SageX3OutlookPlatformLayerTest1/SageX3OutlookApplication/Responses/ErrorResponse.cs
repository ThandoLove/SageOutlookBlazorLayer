using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Responses
{
    public class ErrorResponse
    {
        public bool Success => false;
        public string Message { get; set; } = string.Empty;
    }
}
