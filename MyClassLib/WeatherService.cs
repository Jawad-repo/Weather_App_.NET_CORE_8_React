using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib
{
    public class WeatherService
    {
        private static readonly string[] Summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         };

        private static readonly string[] IconUrls = new[]
        {
            "https://shecodes-assets.s3.amazonaws.com/api/weather/icons/broken-clouds-day.png",
            "https://shecodes-assets.s3.amazonaws.com/api/weather/icons/mist-night.png",
            "http://shecodes-assets.s3.amazonaws.com/api/weather/icons/clear-sky-night.png",
            "https://shecodes-assets.s3.amazonaws.com/api/weather/icons/rain-day.png",
            "https://shecodes-assets.s3.amazonaws.com/api/weather/icons/clear-sky-day.png",
            "https://shecodes-assets.s3.amazonaws.com/api/weather/icons/few-clouds-night.png",
            "https://shecodes-assets.s3.amazonaws.com/api/weather/icons/snow-day.png"

        };

        public WeatherResponse GetWeatherResponse(string city)
        {
            var random = new Random();
            var weatherData = new WeatherResponse
            {
                City = "City", // Hardcoded for now, you can make it dynamic
                Country = city, // Hardcoded for now, you can make it dynamic
                Coordinates = new Coordinates
                {
                    Longitude = -0.7072694,
                    Latitude = 49.0579403
                },
                Condition = new WeatherCondition
                {
                    Description = Summaries[random.Next(Summaries.Length)],
                    IconUrl = IconUrls[random.Next(IconUrls.Length)],
                    Icon = "clear-sky-night"
                },
                Temperature = new TemperatureDetails
                {
                    Current = random.Next(-20, 55),
                    Humidity = random.Next(20, 100),
                    FeelsLike = random.Next(-20, 55),
                    Pressure = random.Next(900, 1100)
                },
                Wind = new WindDetails
                {
                    Speed = random.Next(0, 20),
                    Degree = random.Next(0, 360)
                },
                Time = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            return weatherData;
        }
        // New method to return 5-day weather forecast
        public WeatherForecastResponse GetDaysWeatherResponse(string city)
        {
            var random = new Random();
            var dailyForecasts = new DailyForecast[5];

            for (int i = 0; i < 5; i++)
            {
                dailyForecasts[i] = new DailyForecast
                {
                    Time = DateTimeOffset.UtcNow.AddDays(i).ToUnixTimeSeconds(),
                    Condition = new WeatherCondition
                    {
                        Description = Summaries[random.Next(Summaries.Length)],
                        IconUrl = IconUrls[random.Next(IconUrls.Length)],
                        Icon = "clear-sky-night"
                    },
                    Temperature = new TemperatureRange
                    {
                        Minimum = random.Next(-10, 10),
                        Maximum = random.Next(10, 30)
                    }
                };
            }

            return new WeatherForecastResponse
            {
                Daily = dailyForecasts
            };
        }

    }

    // The main response model
    public class WeatherResponse
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public Coordinates? Coordinates { get; set; }
        public WeatherCondition? Condition { get; set; }
        public TemperatureDetails? Temperature { get; set; }
        public WindDetails? Wind { get; set; }
        public long Time { get; set; }
    }

    // Main response class with an array of daily forecasts
    public class WeatherForecastResponse
    {
        public DailyForecast[]? Daily { get; set; }
    }

    // Represents a single day's forecast
    public class DailyForecast
    {
        public long Time { get; set; }
        public WeatherCondition? Condition { get; set; }
        public TemperatureRange? Temperature { get; set; }
    }

    // Coordinates data
    public class Coordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    // Weather condition details
    public class WeatherCondition
    {
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public string? Icon { get; set; }
    }

    // Temperature range for the day
    public class TemperatureRange
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }

    // Temperature details
    public class TemperatureDetails
    {
        public double Current { get; set; }
        public int Humidity { get; set; }
        public double FeelsLike { get; set; }
        public int Pressure { get; set; }
    }

    // Wind details
    public class WindDetails
    {
        public double Speed { get; set; }
        public int Degree { get; set; }
    }
}

