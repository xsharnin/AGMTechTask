using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTask.Data;
using TechTask.Extensions;
using TechTask.ViewModel;
using WebMap;

namespace TechTask.Services
{
    public interface IGpsService
    {
        Task<IEnumerable<GPSPoint>> GetBoundPoints(int zoom, double fromLat, double toLat, double fromLng, double toLng);
        Task<IEnumerable<GPSPoint>> GetInitialPoints();
    }

    public class GpsService : IGpsService
    {
        private readonly ILogger<GpsService> _logger;
        private readonly TripsDbContext _tripsDbContext;

        public GpsService(ILogger<GpsService> logger, TripsDbContext tripsDbContext)
        {
            _logger = logger;
            _tripsDbContext = tripsDbContext;
        }

        public async Task<IEnumerable<GPSPoint>> GetInitialPoints()
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound1, LatRound1, Count(*) PassengerCount
                                from TlcGreenTrips 
                                where LngRound1 between -794 and -715 and
                                      LatRound1 between 403 and 450 
                                group by LngRound1, LatRound1 ")
                    .Select(trip => new GPSPoint
                    {
                        Lng = trip.LngRound1.UnRound1(),
                        Lat = trip.LatRound1.UnRound1(),
                        Count = trip.PassengerCount
                    }).ToListAsync();
                _logger.LogDebug("GetInitialPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        public async Task<IEnumerable<GPSPoint>> GetBoundPoints(int zoom, double fromLat, double toLat, double fromLng, double toLng)
        {
            if (zoom < 10)
                return await GetRound1BoundPoints(fromLat, toLat, fromLng, toLng);

            if (zoom < 12)
                return await GetRound2HalfBoundPoints(fromLat, toLat, fromLng, toLng);

            if (zoom < 15)
                return await GetRound2BoundPoints(fromLat, toLat, fromLng, toLng);

            if (zoom < 18)
                return await GetRound3BoundPoints(fromLat, toLat, fromLng, toLng);

            if (zoom < 20)
                return await GetRound4BoundPoints(fromLat, toLat, fromLng, toLng);

            if (zoom < 23)
                return await GetRound5BoundPoints(fromLat, toLat, fromLng, toLng);

            if (zoom < 20)
                return await GetRound6BoundPoints(fromLat, toLat, fromLng, toLng);

            if (zoom < 23)
                return await GetRound6BoundPoints(fromLat, toLat, fromLng, toLng);
            return null;
        }

        private async Task<IEnumerable<GPSPoint>> GetRound1BoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound1, LatRound1, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound1 between {0} and {1} 
                                    and LatRound1 between {2} and {3}
                                    group by LngRound1, LatRound1",
                    fromLng.GetRound1(), toLng.GetRound1(), fromLat.GetRound1(), toLat.GetRound1())
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound1.UnRound1(),
                        Lat = x.LatRound1.UnRound1(),
                        Count = x.PassengerCount
                    }).ToListAsync();
                _logger.LogDebug("GetRound1BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        private async Task<IEnumerable<GPSPoint>> GetRound2HalfBoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound2, LatRound2, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound2 between {0} and {1} 
                                    and LatRound2 between {2} and {3}
                                    group by LngRound2, LatRound2",
                    fromLng.GetRound2()-5, toLng.GetRound2()-5, fromLat.GetRound2()-5, toLat.GetRound2()-5)
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound2.UnRound2(),
                        Lat = x.LatRound2.UnRound2(),
                        Count = x.PassengerCount
                    }).ToListAsync();
                _logger.LogDebug("GetRound2BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        private async Task<IEnumerable<GPSPoint>> GetRound2BoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound2, LatRound2, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound2 between {0} and {1} 
                                    and LatRound2 between {2} and {3}
                                    group by LngRound2, LatRound2",
                    fromLng.GetRound2(), toLng.GetRound2(), fromLat.GetRound2(), toLat.GetRound2())
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound2.UnRound2(),
                        Lat = x.LatRound2.UnRound2(),
                        Count = x.PassengerCount
                    }).ToListAsync();
                _logger.LogDebug("GetRound2BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        private async Task<IEnumerable<GPSPoint>> GetRound3BoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound3, LatRound3, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound3 between {0} and {1} 
                                    and LatRound3 between {2} and {3}
                                    group by LngRound3, LatRound3",
                    fromLng.GetRound3(), toLng.GetRound3(), fromLat.GetRound3(), toLat.GetRound3())
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound3.UnRound3(),
                        Lat = x.LatRound3.UnRound3(),
                        Count = x.PassengerCount
                    }).ToListAsync();
                _logger.LogDebug("GetRound3BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        private async Task<IEnumerable<GPSPoint>> GetRound4BoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound4, LatRound4, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound4 between {0} and {1} 
                                    and LatRound4 between {2} and {3}
                                    group by LngRound4, LatRound4",
                    fromLng.GetRound4(), toLng.GetRound4(), fromLat.GetRound4(), toLat.GetRound4())
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound4.UnRound4(),
                        Lat = x.LatRound4.UnRound4()
                    }).ToListAsync();
                _logger.LogDebug("GetRound4BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        private async Task<IEnumerable<GPSPoint>> GetRound5BoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound5, LatRound5, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound5 between {0} and {1} 
                                    and LatRound5 between {2} and {3}
                                    group by LngRound5, LatRound5",
                    fromLng.GetRound5(), toLng.GetRound5(), fromLat.GetRound5(), toLat.GetRound5())
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound5.UnRound5(),
                        Lat = x.LatRound5.UnRound5()
                    }).ToListAsync();
                _logger.LogDebug("GetRound5BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        private async Task<IEnumerable<GPSPoint>> GetRound6BoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound6, LatRound6, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound6 between {0} and {1} 
                                    and LatRound6 between {2} and {3}
                                    group by LngRound6, LatRound6",
                    fromLng.GetRound6(), toLng.GetRound6(), fromLat.GetRound6(), toLat.GetRound6())
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound6.UnRound6(),
                        Lat = x.LatRound6.UnRound6()
                    }).ToListAsync();
                _logger.LogDebug("GetRound6BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }

        private async Task<IEnumerable<GPSPoint>> GetRound7BoundPoints(double fromLat, double toLat, double fromLng, double toLng)
        {
            try
            {
                var result = await _tripsDbContext
                    .Trips
                    .FromSqlRaw(@"select LngRound7, LatRound7, Count(*) PassengerCount
                                    from TlcGreenTrips 
                                    where LngRound7 between {0} and {1} 
                                    and LatRound7 between {2} and {3}
                                    group by LngRound7, LatRound7",
                    fromLng.GetRound7(), toLng.GetRound7(), fromLat.GetRound7(), toLat.GetRound7())
                    .Select(x => new GPSPoint
                    {
                        Lng = x.LngRound7.UnRound7(),
                        Lat = x.LatRound7.UnRound7()
                    }).ToListAsync();
                _logger.LogDebug("GetRound7BoundPoints returns {result}", result.Count);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed get initial points", ex);
                throw;
            }
        }
    }
}
