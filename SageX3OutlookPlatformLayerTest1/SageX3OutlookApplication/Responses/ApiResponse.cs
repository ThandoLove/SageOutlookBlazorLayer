using System;
using System.Collections.Generic;
using System.Text;

namespace SageX3OutlookApplication.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Error { get; set; }
    public T? Data { get; set; }

    public static ApiResponse<T> Fail(string error) => new() { Success = false, Error = error };
    public static ApiResponse<T> Ok(T data) => new() { Success = true, Data = data };
}
