using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;
using WebMap;

namespace ParserCsv
{
    public class TLCGreenTripCSVMapping : CsvMapping<TlcGreenTrip>
    {
        public TLCGreenTripCSVMapping() : base()
        {
            MapProperty(0, x => x.VendorId);
            MapProperty(1, x => x.PickupDT);
            MapProperty(2, x => x.DropOffDT);
            MapProperty(3, x => x.PassengerCount);
            MapProperty(4, x => x.TripDistance);
            MapProperty(5, x => x.PickupLng);
            MapProperty(6, x => x.PickupLat);
            MapProperty(7, x => x.RateCode);
            MapProperty(8, x => x.StoreAndFwdFlag);
            MapProperty(9, x => x.DropOffLng);
            MapProperty(10, x => x.DropOffLat);
            MapProperty(11, x => x.PaymentType);
            MapProperty(12, x => x.FareAmount);
            MapProperty(13, x => x.Extra);
            MapProperty(14, x => x.MtaTax);
            MapProperty(15, x => x.TipAmount);
            MapProperty(16, x => x.TollsAmount);
            MapProperty(17, x => x.ImpSurcharge);
            MapProperty(18, x => x.TotalAmount);

        }
    }
}
