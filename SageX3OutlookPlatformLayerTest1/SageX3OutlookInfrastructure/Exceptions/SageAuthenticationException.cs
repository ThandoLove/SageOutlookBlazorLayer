namespace SageX3OutlookInfrastructure.Exceptions;

public class SageAuthenticationException : Exception
{
    public string? ErrorCode { get; }

    public SageAuthenticationException() { }

    public SageAuthenticationException(string message) : base(message) { }

    public SageAuthenticationException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public SageAuthenticationException(string message, Exception innerException)
        : base(message, innerException) { }
}
