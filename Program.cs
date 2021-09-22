using System;
using System.Globalization;

namespace BCryptWorkFactorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int minWorkFactor = 4;
            TimeSpan maxDuration = TimeSpan.FromSeconds(1);

            Console.WriteLine("BCrypt Work Factor Time Measurement - " + DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("de-DE")) + "\n");
            Console.WriteLine($"- min work factor: {minWorkFactor}");
            Console.WriteLine($"- max duration: {maxDuration.TotalMilliseconds} ms\n");

            new BCryptMeasurer().MeasureWorkFactorTimes("BCryptWorkFactorTest-Password", minWorkFactor, maxDuration);
        }
    }
}
