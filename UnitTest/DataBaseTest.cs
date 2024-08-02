//using Microsoft.EntityFrameworkCore;
//using WeatherBroadcast.Domain.Entities;
//using WeatherBroadcast.Infrastructure;
//namespace UnitTest;

//public class DataBaseTest
//{

//    private WeatherBroadcastDbContext GetInMemoryDbContext()
//    {
//        var options = new DbContextOptionsBuilder<WeatherBroadcastDbContext>()
//            .UseInMemoryDatabase(databaseName: "TestDatabase")
//            .Options;

//        return new WeatherBroadcastDbContext(options);
//    }

//    [Fact]
//    public void CanStoreAndRetrieveJsonData()
//    {
//        // Arrange
//        var context = GetInMemoryDbContext();
//        var jsonContent = "{\"latitude\":52.52,\"longitude\":13.419998,\"generationtime_ms\":0.02002716064453125,\"utc_offset_seconds\":0,\"timezone\":\"GMT\",\"timezone_abbreviation\":\"GMT\",\"elevation\":38.0,\"hourly_units\":{\"time\":\"iso8601\",\"temperature_2m\":\"°C\"},\"hourly\":{\"time\":[\"2024-08-02T00:00\",\"2024-08-02T01:00\",\"2024-08-02T02:00\",\"2024-08-02T03:00\",\"2024-08-02T04:00\",\"2024-08-02T05:00\",\"2024-08-02T06:00\",\"2024-08-02T07:00\",\"2024-08-02T08:00\",\"2024-08-02T09:00\",\"2024-08-02T10:00\",\"2024-08-02T11:00\",\"2024-08-02T12:00\",\"2024-08-02T13:00\",\"2024-08-02T14:00\",\"2024-08-02T15:00\",\"2024-08-02T16:00\",\"2024-08-02T17:00\",\"2024-08-02T18:00\",\"2024-08-02T19:00\",\"2024-08-02T20:00\",\"2024-08-02T21:00\",\"2024-08-02T22:00\",\"2024-08-02T23:00\",\"2024-08-03T00:00\",\"2024-08-03T01:00\",\"2024-08-03T02:00\",\"2024-08-03T03:00\",\"2024-08-03T04:00\",\"2024-08-03T05:00\",\"2024-08-03T06:00\",\"2024-08-03T07:00\",\"2024-08-03T08:00\",\"2024-08-03T09:00\",\"2024-08-03T10:00\",\"2024-08-03T11:00\",\"2024-08-03T12:00\",\"2024-08-03T13:00\",\"2024-08-03T14:00\",\"2024-08-03T15:00\",\"2024-08-03T16:00\"";
//        var jsonData = new WeatherData { JsonContent = jsonContent };

//        // Act
//        context.WeatherData.Add(jsonData);
//        context.SaveChanges();

//        var retrievedJsonData = context.WeatherData.FirstOrDefault(x => x.Id == jsonData.Id);

//        // Assert
//        Assert.NotNull(retrievedJsonData);
//        Assert.Equal(jsonContent, retrievedJsonData.JsonContent);
//    }

//    [Fact]
//    public void CanRetrieveJsonData()
//    {
//        // Arrange
//        var context = GetInMemoryDbContext();
//        var jsonContent = "{\"latitude\":52.52,\"longitude\":13.419998,\"generationtime_ms\":0.02002716064453125,\"utc_offset_seconds\":0,\"timezone\":\"GMT\",\"timezone_abbreviation\":\"GMT\",\"elevation\":38.0,\"hourly_units\":{\"time\":\"iso8601\",\"temperature_2m\":\"°C\"},\"hourly\":{\"time\":[\"2024-08-02T00:00\",\"2024-08-02T01:00\",\"2024-08-02T02:00\",\"2024-08-02T03:00\",\"2024-08-02T04:00\",\"2024-08-02T05:00\",\"2024-08-02T06:00\",\"2024-08-02T07:00\",\"2024-08-02T08:00\",\"2024-08-02T09:00\",\"2024-08-02T10:00\",\"2024-08-02T11:00\",\"2024-08-02T12:00\",\"2024-08-02T13:00\",\"2024-08-02T14:00\",\"2024-08-02T15:00\",\"2024-08-02T16:00\",\"2024-08-02T17:00\",\"2024-08-02T18:00\",\"2024-08-02T19:00\",\"2024-08-02T20:00\",\"2024-08-02T21:00\",\"2024-08-02T22:00\",\"2024-08-02T23:00\",\"2024-08-03T00:00\",\"2024-08-03T01:00\",\"2024-08-03T02:00\",\"2024-08-03T03:00\",\"2024-08-03T04:00\",\"2024-08-03T05:00\",\"2024-08-03T06:00\",\"2024-08-03T07:00\",\"2024-08-03T08:00\",\"2024-08-03T09:00\",\"2024-08-03T10:00\",\"2024-08-03T11:00\",\"2024-08-03T12:00\",\"2024-08-03T13:00\",\"2024-08-03T14:00\",\"2024-08-03T15:00\",\"2024-08-03T16:00\"";
//        context.WeatherData.Add(new WeatherData { JsonContent = jsonContent });
//        context.SaveChanges();

//        // Act
//        var retrievedJsonData = context.WeatherData.FirstOrDefault(x => x.JsonContent == jsonContent);

//        // Assert
//        Assert.NotNull(retrievedJsonData);
//        Assert.Equal(jsonContent, retrievedJsonData.JsonContent);
//    }

//}

