namespace SageX3OutlookInfrastructure.Exceptions;

public class SageIntegrationException : Exception
{
    public string? ErrorCode { get; }
    public int? ExternalStatusCode { get; }

    public SageIntegrationException() { }

    public SageIntegrationException(string message, Exception innerException)
        : base(message, innerException) { }

    public SageIntegrationException(string message, string errorCode, Exception innerException)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }

    public SageIntegrationException(string message, string errorCode, int? externalStatusCode = null)
        : base(message)
    {
        ErrorCode = errorCode;
        ExternalStatusCode = externalStatusCode;
    }
}
