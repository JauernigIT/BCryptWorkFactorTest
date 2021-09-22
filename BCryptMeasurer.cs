﻿using System;
using System.Diagnostics;

namespace BCryptWorkFactorTest
{
    class BCryptMeasurer
    {
        public void MeasureWorkFactorTimes(int minWorkFactor, TimeSpan maxDuration)
        {
            int currentWorkFactor = minWorkFactor;
            while (true)
            {
                var sw = new Stopwatch();
                sw.Start();
                BCrypt.Net.BCrypt.HashPassword("BCryptWorkFactorTest", currentWorkFactor);
                sw.Stop();

                Console.WriteLine($"Work factor {currentWorkFactor}:\t{sw.Elapsed.TotalMilliseconds} ms");
                currentWorkFactor++;

                if (sw.Elapsed > maxDuration)
                {
                    break;
                }
            }
        }
    }
}