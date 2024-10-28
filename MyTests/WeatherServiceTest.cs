using MyClassLib;

namespace MyTests
{
    public class WeatherServiceTests
    {

        private readonly WeatherService _weatherService;

        public WeatherServiceTests()
        {
            _weatherService = new WeatherService();
        }

        [Fact]
        public void GetWeatherResponse_ShouldContainCoordinatesObject()
        {
            // Arrange
            string city = "TestCity";

            // Act
            var result = _weatherService.GetWeatherResponse(city);

            // Assert
            Assert.NotNull(result.City);
            Assert.NotNull(result.Country);
            Assert.NotNull(result.Coordinates);
            Assert.Equal(-0.7072694, result.Coordinates.Longitude, 5);
            Assert.Equal(49.0579403, result.Coordinates.Latitude, 5);
        }

        [Fact]
        public void GetWeatherResponse_ShouldContainConditionObject()
        {
            // Act
            var result = _weatherService.GetWeatherResponse("TestCity");

            // Assert
            Assert.NotNull(result.Condition);
            Assert.False(string.IsNullOrEmpty(result.Condition.Description), "Description is required");
            Assert.False(string.IsNullOrEmpty(result.Condition.IconUrl), "IconUrl is required");
            Assert.False(string.IsNullOrEmpty(result.Condition.Icon), "Icon is required");
        }

        [Fact]
        public void GetWeatherResponse_ShouldContainTemperatureDetailsObject()
        {
            // Act
            var result = _weatherService.GetWeatherResponse("TestCity");

            // Assert
            Assert.NotNull(result.Temperature);
            Assert.InRange(result.Temperature.Current, -100, 100);
            Assert.InRange(result.Temperature.FeelsLike, -100, 100);
            Assert.InRange(result.Temperature.Humidity, 0, 100);
            Assert.InRange(result.Temperature.Pressure, 800, 1200);
        }

        [Fact]
        public void GetWeatherResponse_ShouldContainWindDetailsObject()
        {
            // Act
            var result = _weatherService.GetWeatherResponse("TestCity");

            // Assert
            Assert.NotNull(result.Wind);
            Assert.InRange(result.Wind.Speed, 0, 150); // Allowing a wide range for testing
            Assert.InRange(result.Wind.Degree, 0, 360);
        }

        [Fact]
        public void GetWeatherResponse_ShouldContainTimestamp()
        {
            // Act
            var result = _weatherService.GetWeatherResponse("TestCity");

            // Assert
            Assert.True(result.Time > 0, "Timestamp should be a valid Unix time.");
        }


    }
}

// NOTES:

/*############### Sample Responce #################/

  ----------GetWeatherResponse-----------
{
  "city": "City",
  "country": "France",
  "coordinates": {
    "longitude": -0.7072694,
    "latitude": 49.0579403
  },
  "condition": {
    "description": "clear sky",
    "icon_url": "http://shecodes-assets.s3.amazonaws.com/api/weather/icons/clear-sky-night.png",
    "icon": "clear-sky-night"
  },
  "temperature": {
    "current": 12.55,
    "humidity": 93,
    "feels_like": 12.29,
    "pressure": 1013
  },
  "wind": {
    "speed": 5.02,
    "degree": 167
  },
  "time": 1729810157
}

/################################################*/

