using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONArray
{
    public static class Extensions
    {
        /// <summary>
        /// Converts JArray to List<T>
        /// </summary>
        /// <typeparam name="T">Type of list elements</typeparam>
        /// <param name="jArray">Object-caller</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this JArray jArray)
        {
            try
            {
                var values = new List<T>();
                foreach (var token in jArray.Values())
                {
                    T value = token.Value<T>();
                    values.Add(value);
                }

                return values;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        /// <summary>
        /// Counts frequency of element in list
        /// </summary>
        /// <typeparam name="T">Type of elements</typeparam>
        /// <param name="list">List-caller</param>
        /// <param name="value">Element</param>
        /// <returns>Frequency of element</returns>
        public static int CountFrequency<T>(this List<T> list, T value)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.Equals(value))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
