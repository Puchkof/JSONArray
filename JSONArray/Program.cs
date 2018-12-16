using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONArray
{
    /* This program works with json file that consists of json object
     * with two properties "Array1" and "Array2" that are arrays of numbers.
     * If file structure is broken, program may throw exception.
     */
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // file is in bin/Debug as default
                var arrays = new JSONArrays("json.json");
                arrays.PrintArrays();
                arrays.PrintUniqueNumbers();
                arrays.PrintUniqueOddNumbers();
                arrays.SumOfEvenNumbers();
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Something went wrong. Check file structure and try again");
                Console.ReadKey();
            }
        }
    }
}
