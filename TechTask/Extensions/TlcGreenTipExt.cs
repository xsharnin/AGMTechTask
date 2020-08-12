using WebMap;

namespace TechTask.Extensions
{
    public static class TlcGreenTipExt
    {
        public static double GetRound6Lat(this TlcGreenTrip data)
        {
            return data.LatRound6.UnRound6();
        }
        public static double GetRound6Lng(this TlcGreenTrip data)
        {
            return data.LngRound6.UnRound6();
        }
        public static double GetRound7Lat(this TlcGreenTrip data)
        {
            return data.LatRound7.UnRound7();
        }
        public static double GetRound7Lng(this TlcGreenTrip data)
        {
            return data.LngRound7.UnRound7();
        }
    }
}
