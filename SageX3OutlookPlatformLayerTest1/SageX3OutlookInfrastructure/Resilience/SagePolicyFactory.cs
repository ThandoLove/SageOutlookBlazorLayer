using Polly;

using Polly.Extensions.Http;
using System.Net.Http;

namespace SageX3OutlookInfrastructure.Resilience
{
    public class SagePolicyFactory
    {
        // Creates a retry policy: Wait 2s, 4s, and 8s before failing
        public static IAsyncPolicy<HttpResponseMessage> GetHttpRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        // Creates a circuit breaker to stop requests if Sage is down
        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromMinutes(1));
        }
    }
}

