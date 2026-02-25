
using System.Text;
using System.Net.Http.Headers;
using System.Text.Json;
using SageX3OutlookInfrastructure.Exceptions;
using Polly;

namespace SageX3OutlookInfrastructure.Http
{
    public class SageHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly Polly.Retry.AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        public SageHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Polly retry policy: 3 retries with exponential backoff for transient failures
            _retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt))
                );
        }

        /// <summary>
        /// Sends a GET request to the Sage X3 API
        /// </summary>
        public async Task<T> GetAsync<T>(string endpoint, string? bearerToken = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            if (!string.IsNullOrEmpty(bearerToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }

            var response = await _retryPolicy.ExecuteAsync(() => _httpClient.SendAsync(request));

            return await HandleResponse<T>(response);
        }

        /// <summary>
        /// Sends a POST request with JSON body to the Sage X3 API
        /// </summary>
        public async Task<T> PostAsync<T>(string endpoint, object payload, string? bearerToken = null)
        {
            var json = JsonSerializer.Serialize(payload);
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrEmpty(bearerToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }

            var response = await _retryPolicy.ExecuteAsync(() => _httpClient.SendAsync(request));

            return await HandleResponse<T>(response);
        }

        /// <summary>
        /// Handles HTTP response: throws proper exceptions if Sage fails
        /// </summary>
        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new SageAuthenticationException("Sage X3 authentication failed.", "SAGE_AUTH_FAILED");
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new SageIntegrationException(
                    "Sage X3 returned an error.",
                    "SAGE_API_ERROR",
                    (int)response.StatusCode
                );
            }

            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}