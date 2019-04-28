using System;
using System.Collections.Generic;
using System.Linq;

namespace NET1.S._2019.Tsyvis._17
{
    /// <summary>
    /// Provide creating and printing statistic report.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._17.IObserver" />
    public class StatisticReport : IObserver
    {
        private List<WeatherData> measurements = new List<WeatherData>();

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void Update(object sender, WeatherData data)
        {
            this.measurements.Add(data);
            this.PrintStatisticReport();
        }

        private void PrintStatisticReport()
        {
            Console.WriteLine($"Average temperature for all time: {this.measurements.Select(x => x.Temperature).Average()}");
            Console.WriteLine($"Average humidity for all time: {this.measurements.Select(x => x.Humidity).Average()}");
            Console.WriteLine($"Average pressure for all time: {this.measurements.Select(x => x.Pressure).Average()}");
        }
    }
}
