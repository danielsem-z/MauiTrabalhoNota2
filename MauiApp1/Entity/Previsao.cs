﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MauiApp1.Entity
{
    public class PrevisaoEntity
    {
        [BsonId]
        [JsonIgnore]
        public ObjectId? Id { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        public Coord? Coord { get; set; }
        public List<Weather>? Weather { get; set; }
        public Main? Main { get; set; }
        public Wind? Wind { get; set; }
        public Clouds? Clouds { get; set; }
        public Sys? Sys { get; set; }
        public string? Name { get; set; }
        public int? Cod { get; set; }
    }

    public class Coord
    {
        public double? Lon { get; set; }
        public double? Lat { get; set; }
    }

    public class Weather
    {
        public int? Id { get; set; }
        public string? Main { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }

    public class Main
    {
        public double? Temp { get; set; }
        public double? FeelsLike { get; set; }
        public double? TempMin { get; set; }
        public double? TempMax { get; set; }
        public int? Pressure { get; set; }
        public int? Humidity { get; set; }
        public int? SeaLevel { get; set; }
        public int? GrndLevel { get; set; }
    }

    public class Wind
    {
        public double? Speed { get; set; }
        public int? Deg { get; set; }
        public double? Gust { get; set; }
    }

    public class Clouds
    {
        public int? All { get; set; }
    }

    public class Sys
    {
        public string? Country { get; set; }
        public int? Sunrise { get; set; }
        public int? Sunset { get; set; }
    }
}
