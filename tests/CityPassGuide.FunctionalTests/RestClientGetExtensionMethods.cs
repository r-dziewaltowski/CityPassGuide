using Ardalis.HttpClientTestExtensions;
using RestSharp;
using Xunit.Abstractions;

namespace CityPassGuide.FunctionalTests;

public static class RestClientGetExtensionMethods
{
  public static async Task<T> GetAndDeserializeAsync<T>(this HttpClient client, RestRequest restRequest, ITestOutputHelper? output = null)
  {
    var requestUri = GetRequestUri(client, restRequest);
    return await client.GetAndDeserializeAsync<T>(requestUri, output);
  }

  public static async Task<HttpResponseMessage> GetAndEnsureNotFoundAsync(this HttpClient client, RestRequest restRequest, ITestOutputHelper? output = null)
  {
    var requestUri = GetRequestUri(client, restRequest);
    return await client.GetAndEnsureNotFoundAsync(requestUri, output);
  }

  private static string GetRequestUri(HttpClient client, RestRequest restRequest)
  {
    var restClient = new RestClient(client);
    var requestUri = restClient.BuildUri(restRequest).ToString();
    return requestUri;
  }
}
