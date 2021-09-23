using System;
using System.Diagnostics;

namespace BCryptWorkFactorTest
{
    class BCryptMeasurer
    {
        public void MeasureWorkFactorTimes(string password, int taskNumber, int minWorkFactor, TimeSpan maxDuration)
        {
            // dummy dry run to initialize BCrypt internals
            BCrypt.Net.BCrypt.HashPassword("dry-run", 4);

            int currentWorkFactor = minWorkFactor;
            while (true)
            {
                var sw = new Stopwatch();
                sw.Start();
                BCrypt.Net.BCrypt.HashPassword(password, currentWorkFactor);
                sw.Stop();

                Console.WriteLine($"[{taskNumber}]\tWork factor {currentWorkFactor}:\t{sw.Elapsed.TotalMilliseconds} ms");
                currentWorkFactor++;

                if (sw.Elapsed > maxDuration)
                {
                    break;
                }
            }
        }
    }
}
