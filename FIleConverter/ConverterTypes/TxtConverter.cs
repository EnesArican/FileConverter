using FIleConverter.ConverterTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                        item.tarih.ToShortDateString(), item.sabah, item.gunes, item.ogle, item.ikindi, item.aksam, item.yatsi));
            }
            Console.WriteLine("you have entered txtConverter Blud");
        }


        private void SetHeader(StreamWriter file)
        {
            file.WriteLine("Date             Fajr         Sunrise        Dhuhr         Asr          Maghrib        Isha'");
        }
    }
}
