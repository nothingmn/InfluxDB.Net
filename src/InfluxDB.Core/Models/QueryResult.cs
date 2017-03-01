﻿namespace InfluxDB.Core.Models
{
    public class QueryResult
    {
        public string Error { get; set; }
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public string Error { get; set; }
        public Serie[] Series { get; set; }
    }
}