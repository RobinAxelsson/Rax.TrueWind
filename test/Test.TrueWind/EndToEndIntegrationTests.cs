using FluentAssertions;
using System.Net;
using Test.Shared;
using Xunit;

namespace TrueWind.EndToEndIntegration.Test
{
    public class EndToEndIntegrationTests : IDisposable
    {
        private static HttpClient _httpClient;

        //public EndToEndIntegrationTests()
        //{ 
        //    Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        //    var webApplicationFactory = new WebApplicationFactory<Startup>();
        //    _httpClient = webApplicationFactory.CreateClient();
        //}

        //[EndToEndIntegrationTest(nameof(SmhiClient))]
        //public async Task GetMovies_WhenOperatingNormally_ShouldSucceed()
        //{
        //    // Act
        //    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //    var httpResponseMessage = await _httpClient.GetAsync("api/movies/");

        //    // Assert
        //    if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
        //    {
        //        var actualMovieResource = await httpResponseMessage.Content.ReadAsAsync<IEnumerable<MovieResource>>();
        //        actualMovieResource.Should().NotBeEmpty();
        //    }
        //    else
        //    {
        //        var httpContent = await httpResponseMessage.Content.ReadAsStringAsync();
        //        Assert.Fail($"Reason Phrase: {httpResponseMessage.ReasonPhrase} with Content: {httpContent}");
        //    }
        //}

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
