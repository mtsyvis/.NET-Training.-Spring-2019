using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherStationWorkViaEvents
{
    /// <summary>
    /// Provide creating and printing statistic report.
    /// </summary>
    public class StatisticReport
    {
        private List<WeatherChangedEventArgs> measurements = new List<WeatherChangedEventArgs>();

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void Update(object sender, WeatherChangedEventArgs data)
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
