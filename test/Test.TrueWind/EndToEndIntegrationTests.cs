using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Test.Shared;
using Xunit;
using TrueWind.RestApi;
using System.Net.Http.Json;
using TrueWind.API.Public;

namespace Test.TrueWind;

public class EndToEndIntegrationTests : IDisposable
{
    private HttpClient _httpClient;

    public EndToEndIntegrationTests()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateClient();
    }

    [IntegrationTest("RestApi: health check")]
    [Fact]
    public async Task Health_check_endpoint_should_return_healthy()
    {
        // Act
        var httpResponseMessage = await _httpClient.GetAsync("/health");

        // Assert
        if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
        {
            var healthCheck = await httpResponseMessage.Content.ReadAsStringAsync();
            healthCheck.Should().Be("healthy");
        }
        else
        {
            var httpContent = await httpResponseMessage.Content.ReadAsStringAsync();
            Assert.True(false, $"Reason Phrase: {httpResponseMessage.ReasonPhrase} with Content: {httpContent}");
        }
    }

    [IntegrationTest("RestApi-TrueWind.API")]
    [Fact]
    public async Task Forecast_endpoint_should_return_restDtoForecast()
    {
        // Act
        var httpResponseMessage = await _httpClient.GetAsync("/api/1/venue/1/forecast");

        // Assert
        if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
        {
            var restDtoForecast = await httpResponseMessage.Content.ReadFromJsonAsync<RestDtoForecast>();
           restDtoForecast.Should().BeOfType<RestDtoForecast>();
        }
        else
        {
            var httpContent = await httpResponseMessage.Content.ReadAsStringAsync();
            Assert.True(false, $"Reason Phrase: {httpResponseMessage.ReasonPhrase} with Content: {httpContent}");
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
