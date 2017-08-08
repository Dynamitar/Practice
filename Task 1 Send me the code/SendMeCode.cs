using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task_1_Send_me_the_code
{
    public class SendMeCode
    {
        public static void Main()
        {

            string message = Console.ReadLine();

            long[] numbers = new long[message.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(message[i].ToString());
            }

            Array.Reverse(numbers);

            int[] indexes = new int[numbers.Length];
            int indexCounter = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                indexes[i] = indexCounter++;
            }

            long result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (indexes[i] % 2 != 0)
                {
                    result += numbers[i] * (indexes[i] * indexes[i]);
                }
                if (indexes[i] % 2 == 0)
                {
                    result += (numbers[i] * numbers[i]) * indexes[i];
                }
            }
            long lengthOfCodedMessage = 0;
            long remainderOfResult = result % 26;

            long lastDigit = result % 10;
            if (lastDigit == 0)
            {
                Console.WriteLine(result);
                Console.WriteLine("Big Vik wins again!");
            }
            else
            {
                lengthOfCodedMessage = lastDigit;
                var newMessage = remainderOfResult + 1;

                char[] letters = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                StringBuilder finalResult = new StringBuilder();

                int counter = 0;

                for (int i = 0; i <= letters.Length; i++)
                {
                    long startLetter = newMessage - 1 + i;
                    if (finalResult.Length == lastDigit)
                    {
                        break;
                    }
                    else
                    {
                        finalResult.Append(letters[startLetter]);

                        if (letters[startLetter] == 'Z')
                        {
                            //finalResult.Append('Y');
                            //finalResult.Append('Z');
                            newMessage = 0;
                            i = 0;
                        }

                        counter++;
                    }
                }
                Console.WriteLine(result);
                Console.WriteLine(finalResult);
            }

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine("{0} {1}", numbers[i], indexes[i]);
            //}
        }
    }
}
