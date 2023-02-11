//TODO: Implement this class

//using System.Net.Http.Json;
//using System.Net;
//using TrueWind.ViVa.Exceptions;
//using System.Text.Json;
//using System.Diagnostics.CodeAnalysis;
//using TrueWind.Core.ValueObjects;
//using TrueWind.Core.Entities;
//using TrueWind.ViVa.ResourceModels;

//namespace TrueWind.ViVa;

//public class ViVaAPI : IDisposable
//{
//    private bool _disposed;
//    private HttpClient? _httpClient;
//    private HttpClient HttpClient => _httpClient ??= new HttpClient();
//    private readonly string _mavholmsbadanEndPoint = @"https://services.viva.sjofartsverket.se:8080/output/vivaoutputservice.svc/vivastation/100";

//    public async Task<Forecast> GetGkssData()
//    {
//        var httpResponseMessage = await HttpClient.GetAsync(_mavholmsbadanEndPoint).ConfigureAwait(false);

//        await EnsureSuccess(httpResponseMessage.IsSuccessStatusCode, httpResponseMessage.StatusCode, httpResponseMessage.Content);

//        GetSingleStationResult? getSingleStationResult = null;
//        try
//        {
//            getSingleStationResult = await httpResponseMessage.Content.ReadFromJsonAsync<GetSingleStationResult>();
//            ArgumentNullException.ThrowIfNull(getSingleStationResult);
//        }
//        catch (Exception ex)
//        {
//            if (ex is ArgumentNullException ||
//                ex is NotSupportedException ||
//                ex is JsonException)
//            {
//                throw new ViVaResourceNotParsedException($"{nameof(HttpContentJsonExtensions.ReadFromJsonAsync)} failed using endpoint {_mavholmsbadanEndPoint}", ex);
//            }

//            throw;
//        }

//        var validTime = getSingleStationResult.TimeSeries[0].ValidTime;

//        var parameters = getSingleStationResult.TimeSeries[0].Parameters;
//        var avgWind = GetValueAndHeight(parameters, "ws");
//        var gustWind = GetValueAndHeight(parameters, "gust");
//        var windDirection = GetValueAndHeight(parameters, "wd");
//        var airPressure = GetValueAndHeight(parameters, "msl");
//        var airTemperature = GetValueAndHeight(parameters, "t");

//        var forecast = new Forecast(
//            _mavholmsbadanEndPoint,
//            approvedTime: getSingleStationResult!.ApprovedTime,
//            validTime: validTime,
//            avgWind: new WindSpeed(avgWind.value, avgWind.height),
//            maxWind: new WindSpeed(gustWind.value, gustWind.height),
//            windDirection: new Direction((int)windDirection.value, windDirection.height),
//            airTemperature: new AirTemperature((int)airTemperature.value, airTemperature.height),
//            airPressure: new AirPressure((int)airPressure.value, airPressure.height)
//            );

//        return forecast;
//    }

//    private static async Task EnsureSuccess(bool isSuccessStatusCode, HttpStatusCode statusCode, HttpContent content)
//    {
//        if (isSuccessStatusCode)
//        {
//            return;
//        }

//        var httpContent = await content.ReadAsStringAsync().ConfigureAwait(false);

//        switch (statusCode)
//        {
//            case HttpStatusCode.NotFound:
//                throw new ViVaServiceNotFoundException("The ViVa Service call resulted in a Not Found Status Code");
//            default:
//                throw new ViVaServiceNotFoundException($"The ViVa Service call resulted in a status code of: {statusCode}, with body: {httpContent}");
//        }
//    }

//    [ExcludeFromCodeCoverage]
//    private void Dispose(bool disposing)
//    {
//        if (disposing && !_disposed && _httpClient != null)
//        {
//            var localHttpClient = _httpClient;
//            localHttpClient.Dispose();
//            _httpClient = null;
//            _disposed = true;
//        }
//    }
//    private static (float value, int height) GetValueAndHeight(Parameter[] parameters, string key)
//    {
//        var parameter = parameters.First(x => x.Name == key);
//        return (parameter.Values[0], parameter.Level);
//    }

//    public void Dispose()
//    {
//        Dispose(true);
//    }

//}