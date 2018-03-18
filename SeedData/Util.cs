using System;

namespace SeedData
{
    public static class Util
    {
        public static Random Random => new Random();

        /// <summary>
        /// Generates a random DateTime between 1 year ago and today.
        /// </summary>
        /// <returns></returns>
        public static DateTime RandomDate()
        {
            var start = DateTime.Now.AddYears(-1);
            var range = (DateTime.Now - start).Days;
            return start.AddDays(Random.Next(range));
        }

        /// <summary>
        /// Generates a random DateTime between date and today.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime RandomDate(DateTime date)
        {
            var range = (DateTime.Now - date).Days;
            return date.AddDays(Random.Next(range));
        }
    }
}