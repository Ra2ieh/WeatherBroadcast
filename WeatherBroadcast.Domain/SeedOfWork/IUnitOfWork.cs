﻿

namespace WeatherBroadcast.Domain.SeedOfWork;

public interface IUnitOfWork
{
    IWeatherRepository WeatherRepository { get; }
}