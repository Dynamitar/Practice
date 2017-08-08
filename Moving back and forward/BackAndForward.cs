using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_back_and_forward
{
    class BackAndForward
    {
        static void Main()
        {
            int position = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            List<string> directions = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();
                directions.Add(line);
                if (line == "exit") break;
            }

            int forwardSum = 0;
            int backwardSum = 0;

            int currentPosition = 0;

            foreach (var item in directions)
            {
                if (item == "exit")
                {
                    break;
                }
                string[] elements = item.Split(' ');

                int times = int.Parse(elements[0]);
                string move = elements[1];
                int step = int.Parse(elements[2]); //% numbers.Length;

                for (int i = 0; i < times; i++)
                {
                    if (move == "forward")
                    {
                        currentPosition = (currentPosition + step) % numbers.Length;
                        forwardSum += numbers[currentPosition];
                    }
                    if (move == "backwards")
                    {
                        int temp = (currentPosition - step) % numbers.Length;

                        if (temp < 0)
                        {
                            currentPosition = numbers.Length + temp;
                        }
                        else
                        {
                            currentPosition = temp;
                        }
                        //currentPosition = (currentPosition - step) % numbers.Length;
                        backwardSum += numbers[currentPosition];
                    }


                }

                //if (move == "backwards")
                //{
                //    for (int i = 0; i < times; i++)
                //    {
                //        int temp = (currentPosition - step) % numbers.Length;
                //        if (temp < 0)
                //        {
                //            currentPosition = numbers.Length + temp;
                //        }
                //        else
                //        {
                //            currentPosition = temp;
                //        }
                //        //currentPosition = (currentPosition - step) % numbers.Length;
                //        backwardSum += numbers[currentPosition];
                //    }
                //}
            }

            Console.WriteLine("{0} {1}", forwardSum, backwardSum);

        }
    }
}
