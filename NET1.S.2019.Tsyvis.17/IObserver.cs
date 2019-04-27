namespace NET1.S._2019.Tsyvis._17
{
    /// <summary>
    /// Provide mechanism for receiving push-based notifications.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        void Update(object sender, WeatherData data);
    }
}
