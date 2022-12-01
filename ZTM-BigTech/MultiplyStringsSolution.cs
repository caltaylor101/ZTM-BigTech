using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class MultiplyStringsSolution
    {
        public string Multiply3(string num1, string num2)
        {
            int carryOver = 0;
            string largeNum = "";
            string smallNum = "";
            List<string> numList = new List<string>();
            if (num1.Length == Math.Max(num1.Length, num2.Length))
            {
                largeNum = num1;
                smallNum = num2;
            }
            else
            {
                largeNum = num2;
                smallNum = num1;
            }

            // Multiple to get all sums
            for (int smallIndex = smallNum.Length - 1; smallIndex >= 0; smallIndex--)
            {
                StringBuilder numberToAdd = new StringBuilder();
                for (int leadingZeros = 1; leadingZeros <= (smallNum.Length - 1) - smallIndex; leadingZeros++)
                {
                    numberToAdd.Append(0);
                }
                for (int largeIndex = largeNum.Length - 1; largeIndex >= 0; largeIndex--)
                {
                    var result = (char.GetNumericValue(largeNum[largeIndex]) * char.GetNumericValue(smallNum[smallIndex])) + carryOver;
                    carryOver = (int)result / 10;
                    numberToAdd.Append((result % 10));
                }
                if (carryOver != 0)
                {
                    numberToAdd.Append(carryOver);
                }
                carryOver = 0;

                var charArray = numberToAdd.ToString().ToCharArray();
                Array.Reverse(charArray);
                string stringToAdd = new string(charArray);

                numList.Add(numberToAdd.ToString());
            }


            foreach (var number in numList)
            {
                Console.WriteLine(number);
            }
            // Add each sum together
            string sumTogether = numList[0];
            for (int i = 1; i < numList.Count; i++)
            {
                StringBuilder newSum = new StringBuilder();

                for (int wordIndex = 0; wordIndex < numList[i].Length; wordIndex++)
                {
                    if (sumTogether.Length >= wordIndex)
                    {
                        while (wordIndex < numList[i].Length)
                        {
                            newSum.Append(numList[i][wordIndex]);
                            wordIndex++;
                        }
                        break;
                    }    
                    var result = char.GetNumericValue(sumTogether[wordIndex]) + char.GetNumericValue(numList[i][wordIndex]) + carryOver;  
                    carryOver = (int)result / 10;
                    newSum.Append((result % 10));
                }
                //newSum.Append(carryOver);
                sumTogether = newSum.ToString();
            }

            Console.WriteLine("sum togther: " + sumTogether);
            return largeNum;

        }


        public string Multiply2(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            var maxLength = num1.Length + num2.Length;
            var digitResults = new int[maxLength];

            for (int i = 0; i < num1.Length; i++)
            {
                for (int j = 0; j < num2.Length; j++)
                {
                    digitResults[i + j + 1] += (num1[i] - '0') * (num2[j] - '0');
                }
            }

            for (int i = maxLength - 1; i > 0; i--)
            {
                digitResults[i - 1] += digitResults[i] / 10;
                digitResults[i] %= 10;
            }

            var result = "";

            var startIndex = 0;

            while (digitResults[startIndex] == 0)
            {
                startIndex++;
            }

            for (; startIndex < maxLength; startIndex++)
            {
                result += digitResults[startIndex];
            }

            return result;
        }


        public string Multiply(string num1, string num2)
        {
            // Check for 0's
            if (num1 == "0" || num2 == "0") return "0";
            // First get the maximum length the multiplication of these two numbers could be. if we did 999 * 999, the maximum length would be 6. 
            int maxLength = num1.Length + num2.Length;

            // Initialize an array to add the multiplied values. 
            int[] numberArray = new int[maxLength]; 

            // Multiply every value and store it in the array. 
            for (int i = 0; i < num1.Length; i++)
            {
                for (int j = 0; j < num2.Length; j++)
                {
                    // To account for the largest number we add a space. 
                    // This also helps us add each number to the correct placement later.
                    // Example: 12 * 13 and our initialized array of int[0, 0, 0, 0]
                    // 1 * 1 goes in [0, 1, 0, 0]
                    // 1 * 2 goes in [0, 1, 2, 0]
                    // 2 * 1 goes in [0, 1, 4, 0]
                    // 2 * 2 goes in [0, 1, 4, 4]
                    // This is basically the traditional multiplication, but doing it backwards.
                    // Typically, if we wrote it by hand we would start with the 1's and go back. 
                    // In this solution, we start from the largest number and go forward, adding the values together as we continue. 
                    // The num[i] - '0' is just a clever way to covert the character into an integer instead of calling char.GetNumericValue(num1[i]) 
                    numberArray[i + j + 1] += (num1[i] - '0') * (num2[j] - '0');
                }
            }

            // Once we have our array, we factor out each value. 
            // Consider 99 * 99 in the above loop. What we would be left with would be: [0, 81, 162, 81] 
            // We know that this example should be thousands, hundreds, tens, and single placements, so each of these should be a single digit. 
            // To resolve this, we can reduce each digit by utilizing the 10th's place preceding it. 
            for (int i = maxLength - 1; i > 0; i--)
            {
                // For 1 loop this code block would make our array turn into [ 0, 81, 170, 1]
                // We are shifting everything down the line by powers of 10 to get our final solution. 
                numberArray[i - 1] += numberArray[i] / 10;
                numberArray[i] %= 10;
            }
            // The loop would not do anything for our 12 * 12 example: [0, 1, 4, 4]

            // Finally, we check for instances like our 12 * 12 example. Where maybe the thousands place wasn't used. 
            int startIndex = 0;

            // Move our index so we only look at [1, 4, 4]
            while (numberArray[startIndex] == 0)
            {
                startIndex++;
            }

            // Create a string to save the result to.
            string result = "";

            // Use the start index to loop through the solution. 
            for (; startIndex < numberArray.Length; startIndex++)
            {
                result += numberArray[startIndex];
            }

            return result;
        }

    }
}
