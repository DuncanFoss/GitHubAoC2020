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
            int number1 = 0,
                number2 = 0,
                number3 = 0,
                total = 0;

            populateList();

            for(int i = 0; i < numberList.Count && total != 2020; i++)
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

            Console.WriteLine("N1: {0}\nN2: {1}\nN3: {2}", number1, number2, number3);
            Console.WriteLine("Answer: " + number1 * number2 * number3);
            Console.Write("Press any key to exit...");
            Console.ReadKey();
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