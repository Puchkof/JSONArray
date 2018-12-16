using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONArray
{
    /// <summary>
    /// Presents class that can manage two json arrays from file
    /// </summary>
    public class JSONArrays
    {
        // json arrays of numbers
        private List<int> numbers1;
        private List<int> numbers2;

        // lists of unique numbers
        private List<int> uniqueNumbers1;
        private List<int> uniqueNumbers2;

        /// <summary>
        /// Initializes instance of JSONArrays class
        /// </summary>
        /// <param name="filePath">Path to the file with json</param>
        public JSONArrays(string filePath)
        {
            numbers1 = new List<int>();
            numbers2 = new List<int>();
            uniqueNumbers1 = new List<int>();
            uniqueNumbers2 = new List<int>();
            ReadFile(filePath);
        }


        /// <summary>
        /// Prints unique numbers in arrays
        /// </summary>
        public void PrintUniqueNumbers()
        {
            Console.WriteLine("1. Unique numbers in arrays: ");
            foreach (var value in uniqueNumbers1)
            {
                Console.Write(value + " ");
            }
            foreach (var value in uniqueNumbers2)
            {
                if (!uniqueNumbers1.Contains(value))
                {
                    Console.Write(value + " ");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints odd unique numbers in first array and their count in second array
        /// </summary>
        public void PrintUniqueOddNumbers()
        {
            Console.WriteLine("2. Unique odd numbers from first array and their count in second array: ");
            foreach (var value in uniqueNumbers1)
            {
                if (value % 2 != 0)
                {
                    Console.WriteLine("Value - {0}, Count - {1}", value, numbers2.CountFrequency(value));
                }
            }
        }

        /// <summary>
        /// Prints sum of even numbers from first array that are not present in second array
        /// </summary>
        public void SumOfEvenNumbers()
        {
            Console.WriteLine("3. Sum of even numbers from first array that are not present in second array");
            var sum = 0;
            foreach (var value in numbers1)
            {
                if (value % 2 == 0 && !uniqueNumbers2.Contains(value))
                {
                    sum += value;
                }
            }
            Console.WriteLine(sum);
        }


        /// <summary>
        /// Prints arrays
        /// </summary>
        public void PrintArrays()
        {
            Console.WriteLine("First array:");
            foreach (var value in numbers1)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Second array:");
            foreach (var value in numbers2)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Reads arrays from json file
        /// </summary>
        /// <param name="filePath">File path</param>
        private void ReadFile(string filePath)
        {
            try
            {
                JObject jObject;
                using (var reader = new StreamReader(filePath))
                {
                    var json = reader.ReadToEnd();
                    jObject = JObject.Parse(json);
                }
                var jArray1 = (JArray)jObject["Array1"];
                var jArray2 = (JArray)jObject["Array2"];
                numbers1 = jArray1.ToList<int>();
                numbers2 = jArray2.ToList<int>();
                CollectUniqueNumbers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Collects unique numbers in both arrays
        /// </summary>
        private void CollectUniqueNumbers()
        {
            foreach (var value in numbers1)
            {
                if (!uniqueNumbers1.Contains(value))
                {
                    uniqueNumbers1.Add(value);
                }
            }

            foreach (var value in numbers2)
            {
                if (!uniqueNumbers2.Contains(value))
                {
                    uniqueNumbers2.Add(value);
                }
            }
        }
    }
}
