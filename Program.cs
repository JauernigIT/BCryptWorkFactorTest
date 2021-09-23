using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace BCryptWorkFactorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int parallelTasks = 10;
            int minWorkFactor = 4;
            TimeSpan maxDuration = TimeSpan.FromSeconds(1);

            Console.WriteLine("BCrypt Work Factor Time Measurement - " + DateTime.Now.ToString("G", CultureInfo.CreateSpecificCulture("de-DE")) + "\n");
            Console.WriteLine($"- min work factor: {minWorkFactor}");
            Console.WriteLine($"- max duration: {maxDuration.TotalMilliseconds} ms\n");

            var tasks = new List<Task>();
            for (int i = 1; i <= parallelTasks; i++)
            {
                int taskNumber = i;
                var task = Task.Run(() => new BCryptMeasurer().MeasureWorkFactorTimes("BCryptWorkFactorTest-Password", taskNumber, minWorkFactor, maxDuration));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("\nProcessing done... press any key to exit.");
            Console.ReadKey();
        }
    }
}
