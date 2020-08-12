using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechTask.Services;
using TechTask.ViewModel;

namespace WebMap.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GPSPointController : ControllerBase
    {

        private readonly ILogger<GPSPointController> _logger;
        private readonly IGpsService _gpsService;

        public GPSPointController(ILogger<GPSPointController> logger, IGpsService gpsService)
        {
            _logger = logger;
            _gpsService = gpsService;
        }

        [HttpGet]
        public async Task<IEnumerable<GPSPoint>> Get()
        {
            return await _gpsService.GetInitialPoints();
        }

        [HttpGet("{zoom}")]
        public async Task<IEnumerable<GPSPoint>> Get(int zoom, double fromLat, double toLat, double fromLng, double toLng)
        {
            return await _gpsService.GetBoundPoints(zoom, fromLat, toLat, fromLng, toLng);
        }
    }
}
