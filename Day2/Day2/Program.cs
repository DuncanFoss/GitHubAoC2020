using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Program
    {
        static List<PasswordLine> passwordData;

        static void Main(string[] args)
        {
            PopulatePasswordData();
            Console.WriteLine(String.Format("Challenge 1 Count: {0}", CountValidPasswordsChallenge1()));
            Console.WriteLine(String.Format("Challenge 2 Count: {0}", CountValidPasswordsChallenge2()));

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        private static int CountValidPasswordsChallenge1()
        {
            int charCount,
                validCount = 0;

            foreach(PasswordLine currentLine in passwordData)
            {
                charCount = 0;
                foreach (char c in currentLine.Password)
                    if (c == currentLine.RequiredChar)
                        charCount++;
                if (charCount >= currentLine.NumberOne && charCount <= currentLine.NumberTwo)
                    validCount++;
            }

            return validCount;
        }

        private static int CountValidPasswordsChallenge2()
        {
            bool match1,
                 match2;
            int validCount = 0;

            foreach (PasswordLine currentLine in passwordData)
            {
                match1 = false;
                match2 = false;
                if (currentLine.Password[currentLine.NumberOne - 1] == currentLine.RequiredChar)
                    match1 = true;
                if (currentLine.Password[currentLine.NumberTwo - 1] == currentLine.RequiredChar)
                    match2 = true;
                if ((match1 || match2) && match1 != match2)
                    validCount++;
            }
            return validCount;
        }

        private static void PopulatePasswordData()
        {
            try
            {
                FileStream fileStream = new FileStream("passwordList.txt", FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    int minimum,
                        maximum,
                        dashIndex,
                        firstSpaceIndex,
                        lastSpaceIndex;

                    string currentLine;

                    passwordData = new List<PasswordLine>();

                    while (!streamReader.EndOfStream)
                    {
                        currentLine = streamReader.ReadLine();
                        dashIndex = currentLine.IndexOf('-');
                        firstSpaceIndex = currentLine.IndexOf(' ');
                        lastSpaceIndex = currentLine.LastIndexOf(' ');

                        int.TryParse(currentLine.Substring(0, dashIndex), out minimum);
                        int.TryParse(currentLine.Substring(dashIndex + 1, firstSpaceIndex - dashIndex - 1), out maximum);

                        passwordData.Add(new PasswordLine(minimum, maximum, currentLine[firstSpaceIndex + 1], currentLine.Substring(lastSpaceIndex + 1)));
                    }
                }
                fileStream.Close();
            }
            catch (Exception)
            {
                Console.Write("Error populating password data. Press any key to quit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
