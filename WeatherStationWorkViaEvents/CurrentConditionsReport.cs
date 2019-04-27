using System;

namespace WeatherStationWorkViaEvents
{
    /// <summary>
    /// Saved and updated current conditions report.
    /// </summary>
    public class CurrentConditionsReport
    {
        private WeatherChangedEventArgs weatherData;

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void Update(object sender, WeatherChangedEventArgs data)
        {
            this.weatherData = data;
            this.PrintCurrentConditionsReport();
        }

        private void PrintCurrentConditionsReport()
        {
            Console.WriteLine($"Temperature: {this.weatherData.Temperature}");
            Console.WriteLine($"Humidity: {this.weatherData.Humidity}");
            Console.WriteLine($"Pressure: {this.weatherData.Pressure}");
        }
    }
}
