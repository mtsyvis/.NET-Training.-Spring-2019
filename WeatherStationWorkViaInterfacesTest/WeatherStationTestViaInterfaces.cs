using NET1.S._2019.Tsyvis._17;

namespace WeatherStationWorkViaInterfacesTest
{
    public class WeatherStationTestViaInterfaces
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData(30, 756, 10);
            var weatherStation = new WeatherStation(weatherData);

            var conditionsReport = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            weatherStation.Register(conditionsReport);
            weatherStation.Register(statisticReport);

            weatherStation.WeatherChange(20,740, 5);
        }
    }
}
