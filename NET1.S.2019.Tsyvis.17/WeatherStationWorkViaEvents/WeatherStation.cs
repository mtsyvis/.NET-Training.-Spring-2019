using System;

namespace WeatherStationWorkViaEvents
{
    /// <summary>
    /// Provide work weather station.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._17.IObservable" />
    public class WeatherStation
    {
        private WeatherChangedEventArgs currentWeatherData;

        public event EventHandler<WeatherChangedEventArgs> WeatherChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class.
        /// </summary>
        public WeatherStation() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class.
        /// </summary>  
        /// <param name="data">The data.</param>
        public WeatherStation(WeatherChangedEventArgs data)
        {
            this.currentWeatherData = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public WeatherStation(double temperature, double humidity, double pressure)
        {
            currentWeatherData.Temperature = temperature;
            currentWeatherData.Humidity = humidity;
            currentWeatherData.Pressure = pressure;
        }

        /// <summary>
        /// Weathers the change.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public void WeatherChange(double temperature, double humidity, double pressure)
        {
            this.currentWeatherData = new WeatherChangedEventArgs(temperature, humidity, pressure);
            this.OnWeatherChanged();
        }

        private void OnWeatherChanged()
        {
            var local = WeatherChanged;
            local?.Invoke(
                this,
                new WeatherChangedEventArgs(
                    this.currentWeatherData.Temperature,
                    this.currentWeatherData.Humidity,
                    this.currentWeatherData.Pressure));
        }
    }
}
