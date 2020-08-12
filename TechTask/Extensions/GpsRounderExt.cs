using System;

namespace TechTask.Extensions
{
    public static class GpsRounderExt
    {
        private const int _unRound1 = 10; 
        private const int _unRound2 = 100;
        private const int _unRound3 = 1000;
        private const int _unRound4 = 10000;
        private const int _unRound5 = 100000;
        private const int _unRound6 = 1000000;
        private const int _unRound7 = 10000000;

        public static int GetRound1(this double data)
        {
            return (int)Math.Round(data * _unRound1, 0);
        }
        public static double UnRound1(this int data)
        {
            return ((double)data) / _unRound1;
        }
        public static int GetRound2(this double data)
        {
            return (int)Math.Round(data * _unRound2, 0);
        }
        public static double UnRound2(this int data)
        {
            return ((double)data) / _unRound2;
        }
        public static int GetRound3(this double data)
        {
            return (int)Math.Round(data * _unRound3, 0);
        }
        public static double UnRound3(this int data)
        {
            return data / _unRound3;
        }
        public static int GetRound4(this double data)
        {
            return (int)Math.Round(data * _unRound4, 0);
        }
        public static double UnRound4(this int data)
        {
            return data / _unRound4;
        }
        public static int GetRound5(this double data)
        {
            return (int)Math.Round(data * _unRound5, 0);
        }
        public static double UnRound5(this int data)
        {
            return data / _unRound5;
        }
        public static int GetRound6(this double data)
        {
            return (int)Math.Round(data * _unRound6, 0);
        }
        public static double UnRound6(this int data)
        {
            return data / _unRound6;
        }
        public static int GetRound7(this double data)
        {
            return (int)Math.Round(data * _unRound7, 0);
        }
        public static double UnRound7(this int data)
        {
            return data / _unRound7;
        }
    }
}
