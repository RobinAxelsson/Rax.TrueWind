using System.Net.Http.Json;
using System.Net;
using TrueWind.Smhi.Exceptions;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;
using TrueWind.Core.ValueObjects;
using TrueWind.Core.Entities;
using TrueWind.Smhi.ResourceModels;
using TrueWind.Smhi.ConfigurationProviders;

namespace TrueWind.Smhi;

public class SmhiAPI : IDisposable
{
    private bool _disposed;
    private HttpClient? _httpClient;
    private HttpClient HttpClient => _httpClient ??= new HttpClient();
    private readonly string _pointRequestEndpoint;

    public SmhiAPI() : this(new ConfigurationProvider()) {}

    public SmhiAPI(ConfigurationProviderBase configurationProvider)
    {
        _pointRequestEndpoint = configurationProvider.GetUrlSmhiGkss();
    }

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
            if (ex is ArgumentNullException ||
                ex is NotSupportedException ||
                ex is JsonException)
            {
                throw new SmhiResourceNotParsedException($"{nameof(HttpContentJsonExtensions.ReadFromJsonAsync)} failed using endpoint {_pointRequestEndpoint}", ex);
            }

            throw;
        }

        var validTime = smhiPointRequest.TimeSeries[0].ValidTime;

        var parameters = smhiPointRequest.TimeSeries[0].Parameters;
        var avgWind = GetValueAndHeight(parameters, "ws");
        var gustWind = GetValueAndHeight(parameters, "gust");
        var windDirection = GetValueAndHeight(parameters, "wd");
        var airPressure = GetValueAndHeight(parameters, "msl");
        var airTemperature = GetValueAndHeight(parameters, "t");

        var forecast = new Forecast(
            _pointRequestEndpoint,
            approvedTime: smhiPointRequest!.ApprovedTime,
            validTime: validTime,
            avgWind: new WindSpeed(avgWind.value, avgWind.height),
            maxWind: new WindSpeed(gustWind.value, gustWind.height),
            windDirection: new Direction((int)windDirection.value, windDirection.height),
            airTemperature: new AirTemperature((int)airTemperature.value, airTemperature.height),
            airPressure: new AirPressure((int)airPressure.value, airPressure.height)
            );

        return forecast;
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
    private static (float value, int height) GetValueAndHeight(Parameter[] parameters, string key)
    {
        var parameter = parameters.First(x => x.Name == key);
        return (parameter.Values[0], parameter.Level);
    }

    public void Dispose()
    {
        Dispose(true);
    }

}