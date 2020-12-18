using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        private static List<int> numberList;

        static void Main(string[] args)
        {
            populateList();

            int[] challenge1 = ChallengeOneNumbers(),
                  challenge2 = ChallengeTwoNumbers();

            Console.WriteLine(String.Format("Part 1 Answer: {0}", challenge1[0] * challenge1[1]));
            Console.WriteLine(String.Format("Part 2 Answer: {0}", challenge2[0] * challenge2[1] * challenge2[2]));

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        private static int[] ChallengeOneNumbers()
        {
            int number1 = -1,
                number2 = -1,
                total = -1;

            for (int i = 0; i < numberList.Count && total != 2020; i++)
            {
                number1 = numberList[i];
                for (int j = i + 1; j < numberList.Count && total != 2020; j++)
                {
                    number2 = numberList[j];
                    total = number1 + number2;
                }
            }

            int[] results = { number1, number2};

            return results;
        }

        private static int[] ChallengeTwoNumbers()
        {
            int number1 = -1,
                number2 = -1,
                number3 = -1,
                total = 0;

            for (int i = 0; i < numberList.Count && total != 2020; i++)
            {
                number1 = numberList[i];
                for (int j = i + 1; j < numberList.Count && total != 2020; j++)
                {
                    number2 = numberList[j];
                    for (int k = j + 1; k < numberList.Count && total != 2020; k++)
                    {
                        number3 = numberList[k];
                        total = number1 + number2 + number3;
                    }
                }
            }

            int[] numbers = { number1, number2, number3 };

            return numbers;
        }

        private static void populateList() {
            numberList = new List<int>();

            try
            {
                FileStream fileStream = new FileStream("numberList.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        numberList.Add(int.Parse(streamReader.ReadLine()));
                    }
                }

                fileStream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error while generating number list. Program will close.\n" +
                    "              Press any key to exit...");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}