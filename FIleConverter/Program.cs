using FileConverter;
using FileConverter.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the File Converter App for Fazilet prayer times!");
            Console.WriteLine("\nPlease Select the file you would like to generate:");
            Console.WriteLine("\n1 - readable text file");
            Console.WriteLine("\n2 - awa file (for clock)");

            int fileType = Convert.ToInt32(Console.ReadLine());

            List<PrayerTime> prayerTimes = new List<PrayerTime>();

            FileBuilder builder = new FileBuilder((ConverterType)fileType);


            GetPrayerTimes(prayerTimes);

            builder.Build(prayerTimes);

            Console.WriteLine("\nDone Blud");
            Console.ReadLine();

        }


      

        public static void GetPrayerTimes(List<PrayerTime> prayerTimes)
        {
            foreach (int year in Constants.Years)
            {
                var filePath = Constants.RawFilePath + year + Constants.RawFileName;
                using (StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open)))
                {
                    prayerTimes.AddRange(JsonConvert.DeserializeObject<IEnumerable<PrayerTime>>(reader.ReadToEnd()));
                }

            }  
        }
    }
}
