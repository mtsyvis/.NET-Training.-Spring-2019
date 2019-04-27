using System;

namespace WeatherStationWorkViaEvents
{
    /// <summary>
    /// Data about weather
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WeatherChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherChangedEventArgs"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public WeatherChangedEventArgs(double temperature, double humidity, double pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        /// <summary>
        /// Gets or sets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public double Temperature { get; set; }

        /// <summary>
        /// Gets or sets the humidity.
        /// </summary>
        /// <value>
        /// The humidity.
        /// </value>
        public double Humidity { get; set; }

        /// <summary>
        /// Gets or sets the pressure.
        /// </summary>
        /// <value>
        /// The pressure.
        /// </value>
        public double Pressure { get; set; }
    }
}
