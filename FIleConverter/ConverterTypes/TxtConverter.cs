using FileConverter.ConverterTypes;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileConverter.ConverterTypes
{
    class TxtConverter : ConverterBase
    {
        public override void Convert(StreamWriter file, IEnumerable<PrayerTime> prayerTimes)
        {
            SetHeader(file);
            foreach (PrayerTime item in prayerTimes)
            {
                file.WriteLine(string.Format("{0}       {1}         {2}         {3}         {4}         {5}         {6}", 
                        item.Tarih.ToShortDateString(), item.Sabah.ToString(@"hh\:mm"), item.Gunes.ToString(@"hh\:mm"), item.Ogle.ToString(@"hh\:mm"), 
                                                        item.Ikindi.ToString(@"hh\:mm"), item.Aksam.ToString(@"hh\:mm"), item.Yatsi));
            }
            Console.WriteLine("you have entered txtConverter Blud");
        }


        private void SetHeader(StreamWriter file)
        {
            file.WriteLine("Date             Fajr         Sunrise        Dhuhr         Asr          Maghrib        Isha'");
        }
    }
}
