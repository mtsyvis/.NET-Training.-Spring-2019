using System;
using WeatherStationWorkViaEvents;

namespace WeatherStationWorkViaEventsTest
{
    class WeatherStationTestViaEvents
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            var conditionsReport = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            weatherStation.WeatherChanged += conditionsReport.Update;
            weatherStation.WeatherChanged += statisticReport.Update;

            weatherStation.WeatherChange(20, 5, 730);
            Console.WriteLine("--------------------------");
            weatherStation.WeatherChange(30, 20, 766);
        }
    }
}
