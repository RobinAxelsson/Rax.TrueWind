using System.Net.Http.Json;
using System.Net;
using TrueWind.API.Internals.Services.Smhi.ResourceModels;
using TrueWind.API.Internals.Services.Smhi.Exceptions;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;

namespace TrueWind.API.Internals.Services.Smhi;

internal sealed class SmhiGateway : IDisposable
{
    private bool _disposed;
    HttpClient? _httpClient;
    HttpClient HttpClient => _httpClient ??= new HttpClient();
    private const string _pointRequestEndpoint = @"https://salihaxelsson.com/truewind/api/1/point/data.json";
    public async Task<Forecast> GetGkssData()
    {
        var httpResponseMessage = await HttpClient.GetAsync(_pointRequestEndpoint).ConfigureAwait(false);

        await EnsureSuccess(httpResponseMessage.IsSuccessStatusCode, httpResponseMessage.StatusCode, httpResponseMessage.Content);

        SmhiPointRequest? smhiPointRequest = null;
        try
        {
            smhiPointRequest = await httpResponseMessage.Content.ReadFromJsonAsync<SmhiPointRequest>();
            ArgumentNullException.ThrowIfNull(smhiPointRequest);
        }
        catch (Exception ex)
        {
            if(ex is ArgumentNullException ||
                ex is NotSupportedException ||
                ex is JsonException)
            {
                throw new SmhiResourceNotParsedException($"{nameof(HttpContentJsonExtensions.ReadFromJsonAsync)} failed using endpoint {_pointRequestEndpoint}", ex);
            }

            throw;
        }

        return new Forecast(smhiPointRequest!.ApprovedTime);
    }

    private static async Task EnsureSuccess(bool isSuccessStatusCode, HttpStatusCode statusCode, HttpContent content)
    {
        if (isSuccessStatusCode)
        {
            return;
        }

        var httpContent = await content.ReadAsStringAsync().ConfigureAwait(false);

        switch (statusCode)
        {
            case HttpStatusCode.NotFound:
                throw new SmhiServiceNotFoundException("The Smhi Service call resulted in a Not Found Status Code");
            default:
                throw new SmhiServiceNotFoundException($"The Smhi Service call resulted in a status code of: {statusCode}, with body: {httpContent}");
        }
    }

    [ExcludeFromCodeCoverage]
    private void Dispose(bool disposing)
    {
        if (disposing && !_disposed && _httpClient != null)
        {
            var localHttpClient = _httpClient;
            localHttpClient.Dispose();
            _httpClient = null;
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

}