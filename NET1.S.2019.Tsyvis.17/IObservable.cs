namespace NET1.S._2019.Tsyvis._17
{
    /// <summary>
    /// Defines a provider for push-based notification.
    /// </summary>
    public interface IObservable
    {
        /// <summary>
        /// Registers the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        void Register(IObserver observer);

        /// <summary>
        /// Unregisters the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        void Unregister(IObserver observer);

        /// <summary>
        /// Notifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Notify(WeatherData data);
    }
}
