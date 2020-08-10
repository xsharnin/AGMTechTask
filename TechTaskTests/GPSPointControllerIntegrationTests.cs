using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTask;
using TechTask.ViewModel;
using Xunit;

namespace TechTaskTests
{
    public class GPSPointControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GPSPointControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetInitialPoints()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/gpspoint");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var gpsPoints = JsonConvert.DeserializeObject<GPSPoint[]>(stringResponse);
            Assert.True(gpsPoints.Length == 190);
            Assert.DoesNotContain(gpsPoints, x => x.Lat < 40.30);
            Assert.DoesNotContain(gpsPoints, x => x.Lat > 45.01);
            Assert.DoesNotContain(gpsPoints, x => x.Lng < -79.46);
            Assert.DoesNotContain(gpsPoints, x => x.Lng > -71.52);
        }

        [Fact]
        public async Task CanGetBoundsPoints()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/gpspoint/12?fromLat=40.587484385165396&toLat=41.10689748545046&fromLng=-74.2523080016981&toLng=-73.304737200916847");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var gpsPoints = JsonConvert.DeserializeObject<GPSPoint[]>(stringResponse);

            Assert.True(gpsPoints.Length>100);
            Assert.DoesNotContain(gpsPoints, x => x.Lat < 40.58);
            Assert.DoesNotContain(gpsPoints, x => x.Lat > 41.11);
            Assert.DoesNotContain(gpsPoints, x => x.Lng < -74.26);
            Assert.DoesNotContain(gpsPoints, x => x.Lng > -73.30);
        }
    }
}
