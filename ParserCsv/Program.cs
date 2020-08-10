using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using WebMap;

namespace ParserCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            TLCGreenTripCSVMapping csvMapper = new TLCGreenTripCSVMapping();
            CsvParser<TlcGreenTrip> csvParser = new CsvParser<TlcGreenTrip>(csvParserOptions, csvMapper);

            var stringBuilder = new StringBuilder()
                .AppendLine("VendorID,tpep_pickup_datetime,tpep_dropoff_datetime,passenger_count,trip_distance,pickup_longitude,pickup_latitude,RateCodeID,store_and_fwd_flag,dropoff_longitude,dropoff_latitude,payment_type,fare_amount,extra,mta_tax,tip_amount,tolls_amount,improvement_surcharge,total_amount")
                .AppendLine("2,2015-01-15 19:05:39,2015-01-15 19:23:42,1,1.59,-73.993896484375,40.750110626220703,1,N,-73.974784851074219,40.750617980957031,1,12,1,0.5,3.25,0,0.3,17.05")
                .AppendLine("1,2015-01-10 20:33:38,2015-01-10 20:53:28,1,3.30,-74.00164794921875,40.7242431640625,1,N,-73.994415283203125,40.759109497070313,1,14.5,0.5,0.5,2,0,0.3,17.8");

            var result = csvParser
                .ReadFromString(csvReaderOptions, stringBuilder.ToString())
                .ToList();

            */



            var parser = new TripsDataParser();
            parser.Execute();
        }
    }
}
