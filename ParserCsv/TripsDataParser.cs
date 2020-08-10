using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTask.Data;
using TechTask.Extensions;
using TinyCsvParser;
using WebMap;

namespace ParserCsv
{
    public class TripsDataParser
    {
        public void Execute() 
        {
            CsvParser<TlcGreenTrip> csvParser = csvParser = CreateCsvParser();

            var pipeline = csvParser
                        .ReadFromFile(@"C:\Work\Observr\yellow_tripdata_2015-01.csv", Encoding.ASCII)
                        .Where(x=>x.IsValid)
                        .Select(x => x.Result)
                        .AsSequential();

            WriteToDatabase(pipeline);

        }

        private CsvParser<TlcGreenTrip> CreateCsvParser()
        {
            var csvMapping = new TLCGreenTripCSVMapping();
            var csvParserOptions = CreateCsvParserOptions();

            return new CsvParser<TlcGreenTrip>(csvParserOptions, csvMapping);
        }

        private CsvParserOptions CreateCsvParserOptions()
        {
            var skipHeader = true; // The dataset has a header.
            var fieldsSeparator = ','; // Separator is a , for the example.
            var orderedResults = false; // Not important for the import. Save some memory.
            var degreeOfParallelism = 4; // Use all cores!

            return new CsvParserOptions(skipHeader, fieldsSeparator, degreeOfParallelism, orderedResults);
        }

        private void WriteToDatabase(IEnumerable<TlcGreenTrip> entities)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TripsDbContext>();
            optionsBuilder.UseSqlServer("Server=L000373;Database=TlcGreenTrips;Trusted_Connection=True;MultipleActiveResultSets=true");

            var sw = Stopwatch.StartNew();
            Console.WriteLine("Start getting seq ");
            var collection = entities.ToArray();
            sw.Stop();
            Console.WriteLine($"Got seq with {collection.Length} elements {sw.Elapsed}");

            var batches = new List<List<TlcGreenTrip>>();
            var batch = new List<TlcGreenTrip>();
            sw.Restart();
            foreach (var x in collection)
            {
                x.LatRound1 = x.PickupLat.GetRound1();
                x.LngRound1 = x.PickupLng.GetRound1();
                x.LatRound2 = x.PickupLat.GetRound2();
                x.LngRound2 = x.PickupLng.GetRound2();
                x.LatRound3 = x.PickupLat.GetRound3();
                x.LngRound3 = x.PickupLng.GetRound3();
                x.LatRound4 = x.PickupLat.GetRound4();
                x.LngRound4 = x.PickupLng.GetRound4();
                x.LatRound5 = x.PickupLat.GetRound5();
                x.LngRound5 = x.PickupLng.GetRound5();
                x.LatRound6 = x.PickupLat.GetRound6();
                x.LngRound6 = x.PickupLng.GetRound6();
                x.LatRound7 = x.PickupLat.GetRound7();
                x.LngRound7 = x.PickupLng.GetRound7();
                batch.Add(x);

                if (batch.Count == 10)
                {
                    batches.Add(batch);
                    batch = new List<TlcGreenTrip>();
                }
            }
            batches.Add(batch);
            sw.Stop();
            Console.WriteLine($"bathes created seq  with {batches.Count} elements {sw.Elapsed}");

            Parallel.ForEach(batches, new ParallelOptions { 
            MaxDegreeOfParallelism = 10}, (list) =>
            {
                using (var dbContext = new TripsDbContext(optionsBuilder.Options))
                {
                    dbContext.AddRange(list);
                    dbContext.SaveChanges();
                }
            });
        }
    }
}
