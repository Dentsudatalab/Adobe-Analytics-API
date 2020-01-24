namespace Adobe.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;
    using Utility;

    public static class HttpClientExtensions
    {
        /// <summary>
        /// Makes a GET call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="queryParams">Additional query parameters.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> GetApiResponse<T>(this HttpClient httpClient, Uri requestUri, Dictionary<string, string> queryParams = null)
        {
            return await httpClient.GetApiResponse<T>(requestUri.ToString(), queryParams);
        }

        /// <summary>
        /// Makes a GET call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="queryParams">Additional query parameters.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> GetApiResponse<T>(this HttpClient httpClient, string requestUri, Dictionary<string, string> queryParams = null)
        {
            if (queryParams != null)
            {
                var uriBuilder = new UriBuilder(requestUri);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);

                foreach (var (key, value) in queryParams)
                {
                    query[key] = value;
                }

                uriBuilder.Query = query.ToString();
                requestUri = uriBuilder.ToString();
            }

            var response = await httpClient.GetAsync(requestUri);

            return await ParseResponseMessage<T>(response);
        }

        /// <summary>
        /// Makes a DELETE call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="queryParams">Additional query parameters.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> DeleteApiResponse<T>(this HttpClient httpClient, Uri requestUri, Dictionary<string, string> queryParams = null)
        {
            return await httpClient.DeleteApiResponse<T>(requestUri.ToString(), queryParams);
        }

        /// <summary>
        /// Makes a DELETE call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="queryParams">Additional query parameters.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> DeleteApiResponse<T>(this HttpClient httpClient, string requestUri, Dictionary<string, string> queryParams = null)
        {
            if (queryParams != null)
            {
                var uriBuilder = new UriBuilder(requestUri);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);

                foreach (var (key, value) in queryParams)
                {
                    query[key] = value;
                }

                uriBuilder.Query = query.ToString();
                requestUri = uriBuilder.ToString();
            }

            var response = await httpClient.DeleteAsync(requestUri);

            return await ParseResponseMessage<T>(response);
        }

        /// <summary>
        /// Makes a POST call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="body">The body of the POST request.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> PostApiResponse<T>(this HttpClient httpClient, Uri requestUri, object body)
        {
            return await httpClient.PostApiResponse<T>(requestUri.ToString(), body);
        }

        /// <summary>
        /// Makes a POST call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="body">The body of the POST request.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> PostApiResponse<T>(this HttpClient httpClient, string requestUri, object body)
        {
            var bodyString = JsonConvert.SerializeObject(body);
            var stringContent = new StringContent(bodyString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestUri, stringContent);

            return await ParseResponseMessage<T>(response);
        }

        /// <summary>
        /// Makes a PUT call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="body">The body of the POST request.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> PutApiResponse<T>(this HttpClient httpClient, Uri requestUri, object body)
        {
            return await httpClient.PostApiResponse<T>(requestUri.ToString(), body);
        }

        /// <summary>
        /// Makes a PUT call to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="body">The body of the POST request.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> PutApiResponse<T>(this HttpClient httpClient, string requestUri, object body)
        {
            var bodyString = JsonConvert.SerializeObject(body);
            var stringContent = new StringContent(bodyString, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(requestUri, stringContent);

            return await ParseResponseMessage<T>(response);
        }

        /// <summary>
        /// Makes a POST call with a content type of "application/x-www-form-urlencoded" to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="body">The body of the POST request.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> PostFormResponse<T>(this HttpClient httpClient, Uri requestUri, Dictionary<string, string> body)
        {
            return await httpClient.PostFormResponse<T>(requestUri.ToString(), body);
        }

        /// <summary>
        /// Makes a POST call with a content type of "application/x-www-form-urlencoded" to the uri specified and parses the JSON response.
        /// </summary>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <param name="httpClient">The client to use to make the request.</param>
        /// <param name="requestUri">The uri to call.</param>
        /// <param name="body">The body of the POST request.</param>
        /// <returns>A parsed response from the uri.</returns>
        public static async Task<ApiResponse<T>> PostFormResponse<T>(this HttpClient httpClient, string requestUri, Dictionary<string, string> body)
        {
            var stringContent = new FormUrlEncodedContent(body);
            stringContent.Headers.Remove("Content-Type");
            stringContent.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var reqMsg = new HttpRequestMessage
            {
                Content = stringContent,
                RequestUri = new Uri(requestUri),
                Method = HttpMethod.Post
            };

            var response = await httpClient.SendAsync(reqMsg);

            return await ParseResponseMessage<T>(response);
        }

        private static async Task<ApiResponse<T>> ParseResponseMessage<T>(HttpResponseMessage response)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<T>(content);

                    if (result == null)
                    {
                        var parseError = new ApiError { DeveloperMessage = content };
                        return new ApiResponse<T>(parseError);
                    }

                    return new ApiResponse<T>(result);
                }

                var error = JsonConvert.DeserializeObject<ApiError>(content);
                error.Messages = error.Messages ?? new string[] { };
                error.Messages = error.Messages.Append($"StatusCode: {response.StatusCode}").Append($"Content: {content}").ToArray();
                return new ApiResponse<T>(error);
            }
            catch (JsonException)
            {
                var apiError = new ApiError
                {
                    Messages = new[]
                    {
                        "An unknown error occurred. Please try again."
                    }
                };

                return new ApiResponse<T>(apiError);
            }
        }
    }
}