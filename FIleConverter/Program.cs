using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the File Converter App for Fazilet prayer times!");
           
            Console.WriteLine("\n Please Press Enter to Continue");

            Console.ReadLine();

            string path = @"C:\Users\enes\Documents\fazilet-takvimi-namaz-vakitleri\2019-namaz-vakitleri.txt";

            using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {

                IEnumerable<PrayerTime> prayerTimes = JsonConvert.DeserializeObject<IEnumerable<PrayerTime>>(reader.ReadToEnd());


                foreach (PrayerTime obj in prayerTimes)
                {
                    Console.WriteLine(obj.isani);
                }






            }

            Console.WriteLine("Done Blud");
            Console.ReadLine();

        }
    }
}
