using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._17
{
    /// <summary>
    /// Provide work weather station.
    /// </summary>
    /// <seealso cref="NET1.S._2019.Tsyvis._17.IObservable" />
    public class WeatherStation : IObservable
    {
        private List<IObserver> observers = new List<IObserver>();

        private WeatherData weatherData;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public WeatherStation(WeatherData data)
        {
            this.weatherData = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public WeatherStation(double temperature, double humidity, double pressure)
        {
            weatherData.Temperature = temperature;
            weatherData.Humidity = humidity;
            weatherData.Pressure = pressure;
        }

        /// <summary>
        /// Weathers the change.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public void WeatherChange(double temperature, double humidity, double pressure)
        {
            this.weatherData = new WeatherData(temperature, humidity, pressure);
            this.Notify(this.weatherData);
        }

        /// <summary>
        /// Registers the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Register(IObserver observer)
        {
            this.observers.Add(observer);
        }

        /// <summary>
        /// Unregisters the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Unregister(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Notify(WeatherData data)
        {
            foreach (var observer in this.observers)
            {
                observer.Update(this, data);
            }
        }
    }
}
