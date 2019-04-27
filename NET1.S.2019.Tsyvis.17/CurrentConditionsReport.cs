using System;

namespace NET1.S._2019.Tsyvis._17
{
    /// <summary>
    /// Saved and updated current conditions report.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._17.IObserver" />
    public class CurrentConditionsReport : IObserver
    {
        private WeatherData weatherData;

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void Update(object sender, WeatherData data)
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
