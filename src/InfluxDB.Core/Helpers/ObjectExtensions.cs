﻿using System;
using System.Text;
using InfluxDB.Core.Infrastructure.Influx;
using Newtonsoft.Json;

namespace InfluxDB.Core.Helpers
{
    public static class ObjectExtensions
    {
        private static DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static string ToJson(this object @object)
        {
            return JsonConvert.SerializeObject(@object);
        }

        public static T FromJson<T>(this string item)
        {
            var response = JsonConvert.DeserializeObject<T>(item);
            return response;
        }

        public static T ReadAs<T>(this InfluxDbApiResponse response)
        {
            var @object = JsonConvert.DeserializeObject<T>(response.Body);

            return @object;
        }

        /// <summary>Converts to unix time in milliseconds.</summary>
        /// <param name="date">The date.</param>
        /// <returns>The number of elapsed milliseconds</returns>
        public static long ToUnixTime(this DateTime date)
        {
            return Convert.ToInt64((date - _epoch).TotalMilliseconds);
        }

        /// <summary>Converts from unix time in milliseconds.</summary>
        /// <param name="unixTimeInMillis">The unix time in millis.</param>
        /// <returns></returns>
        public static DateTime FromUnixTime(this long unixTimeInMillis)
        {
            return _epoch.AddMilliseconds(unixTimeInMillis);
        }

        public static string NextPrintableString(this Random random, int length)
        {
            var data = new byte[length];

            for (int i = 0; i < data.Length; i++)
            {
                // Only printable UTF-8
                // and no backslashes for now
                // https://github.com/influxdb/influxdb/issues/3070
                do
                {
                    data[i] = (byte)random.Next(32, 127);
                }
                while (data[i] == 92);
            }

            var encoding = new UTF8Encoding();
            return encoding.GetString(data, 0, length);
        }
    }
}