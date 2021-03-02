using System;

namespace csharp_syntax
{
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;

    class ArrayPractice
    {
        public static void CreateArray()
        {
            /*
             * Currently only works with single digits between commas, must be improved to account for more
             */

            string userInputValues;
            int arrayLength;
            int numberOfCommas;

            Console.Write("Please enter the length of the array");
            arrayLength = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[arrayLength];

            do
            {
                Console.WriteLine("Please enter int values to fill array, separate values by comma");
                Console.WriteLine("Please enter only numbers separated by commas");

                userInputValues = Console.ReadLine() ?? "Not Valid";

                numberOfCommas = userInputValues?.Count(c => c.Equals(',')) ?? 0;

            } while (Regex.Match(userInputValues,"[^0-9]").Length > 0 && numberOfCommas != arrayLength - 1);

            {
                int value = 0;
                int numLength = 0;
                char currentNum;
                int amtOfNumsInArray = 0;

                for (int i = 0; i < userInputValues.Length; i += 1)
                {
                    currentNum = userInputValues[i];

                    if (userInputValues[i].Equals(','))
                    {
                        if (amtOfNumsInArray == 0) arr[i - numLength] = value;

                        else arr[i - (numLength + amtOfNumsInArray)] = value;

                        numLength = 0;
                        value = 0;
                        amtOfNumsInArray += 1;
                        
                    }
                    else
                    {
                        numLength += 1;

                        if (numLength == 1) value += (int)char.GetNumericValue(currentNum);


                        if (i == userInputValues.Length - 1) arr[arrayLength-1] = value;
                    }



                    Console.WriteLine(numLength);
                    Console.WriteLine(value);
                    //value += (char)Convert.ToInt32(userInputValue[i]);
                    Console.WriteLine("[{0}]", string.Join(", ", arr));
                }
            }

        }
    }
}
