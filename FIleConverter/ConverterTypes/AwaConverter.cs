using FileConverter;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileConverter.ConverterTypes
{
    class AwaConverter : ConverterBase
    {
        public override void Convert(StreamWriter file, IEnumerable<PrayerTime> prayerTimes)
        {
            SetHeader(file);
            foreach (PrayerTime item in prayerTimes)
            {
                file.WriteLine(string.Format("{0}       {1}         {2}         {3}         {4}         {5}         {6}",
                        item.tarih.ToShortDateString(), item.sabah, item.gunes, item.ogle, item.ikindi, item.aksam, item.yatsi));
            }
            Console.WriteLine("you have entered awaConverter Blud");
        }


        private void SetHeader(StreamWriter file)
        {
            file.WriteLine("London");
            file.WriteLine(DateTime.Now.ToString("d/M/yyyy"));
            Console.WriteLine(DateTime.Now.ToString("d/M/yyyy"));
        }
    }
}
