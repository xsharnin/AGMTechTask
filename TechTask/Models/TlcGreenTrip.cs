using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMap
{
    public class TlcGreenTrip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Description("A code indicating the LPEP provider that provided the record. 1= Creative Mobile Technologies, LLC; 2= VeriFone Inc.")]
        public string VendorId { get; set; }

        [Description("The date and time when the meter was engaged.")]
        public DateTime PickupDT { get; set; }

        [Description("The date and time when the meter was disengaged.")]
        public DateTime DropOffDT{ get; set; }

        [Description("This flag indicates whether the trip record was held in vehicle memory before sending to the vendor, aka “store and forward,” because the vehicle did not have a connection to the server. Y= store and forward trip N= not a store and forward trip.")]
        public string StoreAndFwdFlag { get; set; }

        [Description("The final rate code in effect at the end of the trip. 1= Standard rate 2=JFK 3=Newark 4=Nassau or Westchester 5=Negotiated fare 6=Group ride.")]
        public int RateCode { get; set; }

        [Description("Longitude where the meter was engaged.")]
        public double PickupLng { get; set; }

        [Description("Latitude where the meter was engaged.")]
        public double PickupLat { get; set; }

        [Description("Longitude where the meter was timed off.")]
        public double DropOffLng { get; set; }

        [Description("Latitude where the meter was timed off.")]
        public double DropOffLat { get; set; }

        [Description("The number of passengers in the vehicle. This is a driver-entered value.")]
        public int PassengerCount { get; set; }

        [Description("The elapsed trip distance in miles reported by the taximeter.")]
        public float TripDistance { get; set; }

        [Description("The time-and-distance fare calculated by the meter.")]
        public decimal FareAmount { get; set; }

        [Description("Miscellaneous extras and surcharges. Currently, this only includes the $0.50 and $1 rush hour and overnight charges.")]
        public decimal Extra { get; set; }

        [Description("$0.50 MTA tax that is automatically triggered based on the metered rate in use.")]
        public decimal MtaTax { get; set; }

        [Description("Tip amount – This field is automatically populated for credit card tips. Cash tips are not included.")]
        public decimal TipAmount { get; set; }

        [Description("Total amount of all tolls paid in trip.")]
        public decimal TollsAmount { get; set; }

        [Description("Ehail fee.")]
        public decimal EhailFee { get; set; }

        [Description("The total amount charged to passengers. Does not include cash tips.")]
        public decimal TotalAmount { get; set; }

        [Description("A numeric code signifying how the passenger paid for the trip. 1= Credit card 2= Cash 3= No charge 4= Dispute 5= Unknown 6= Voided trip.")]
        public int PaymentType { get; set; }

        [Description("Distance between service.")]
        public float DistanceBetweenService { get; set; }

        [Description("Time between service.")]
        public float TimeBetweenService { get; set; }

        [Description("A code indicating whether the trip was a street-hail or a dispatch that is automatically assigned based on the metered rate in use but can be altered by the driver. 1= Street-hail 2= Dispatch.")]
        public int TripType { get; set; }

        [Description("$0.30 improvement surcharge assessed on hailed trips at the flag drop. The improvement surcharge began being levied in 2015..")]
        public float ImpSurcharge { get; set; }

        //aggregated Fields
        //Lng and Lat rounded to 1 digits
        public int LngRound1 { get; set; }
        public int LatRound1 { get; set; }
        //Lng and Lat rounded to 2 digits
        public int LngRound2 { get; set; }
        public int LatRound2 { get; set; }

        //Lng and Lat rounded to 3 digits
        public int LngRound3 { get; set; }
        public int LatRound3 { get; set; }
        //Lng and Lat rounded to 4 digits
        public int LngRound4 { get; set; }
        public int LatRound4 { get; set; }

        //Lng and Lat rounded to 5 digits
        public int LngRound5 { get; set; }
        public int LatRound5 { get; set; }
        //Lng and Lat rounded to 6 digits
        public int LngRound6 { get; set; }
        public int LatRound6 { get; set; }

        //Lng and Lat rounded to 7 digits
        public int LngRound7 { get; set; }
        public int LatRound7 { get; set; }
    }
}
