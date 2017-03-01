using System;
using System.Collections.Generic;

namespace InfluxDB.Core.Infrastructure.Validation
{
    internal static class Validate
    {
        public static void NotNull<T>(T value, string paramName) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        public static void NotNull<T>(T value, string paramName, string message) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(paramName, message);
        }

        public static void IfTrue(bool value, string message)
        {
            if (value)
                throw new ArgumentException(message);
        }

        public static void NotNullOrEmpty(string value, string paramName)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException(paramName);
        }

        public static void NotZeroLength<T>(T[] array, string paramName)
        {
            if (array.Length == 0)
                throw new ArgumentOutOfRangeException(paramName);
        }

        public static void NotZeroLength<T>(T[] array, string paramName, string message)
        {
            if (array.Length == 0)
                throw new ArgumentOutOfRangeException(paramName, message);
        }

        public static void NotZeroLength<T>(List<T> list, string paramName)
        {
            if (list.Count == 0)
                throw new ArgumentOutOfRangeException(paramName);
        }
    }
}