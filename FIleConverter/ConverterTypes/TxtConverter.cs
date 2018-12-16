using FIleConverter.ConverterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.ConverterTypes
{
    class TxtConverter : ConverterBase
    {
        public TxtConverter(string path) : base(path){ }

        public override void Convert(IEnumerable<PrayerTime> prayerTimes)
        {
            prayerTimes = prayerTimes.OrderBy(p => p.tarih);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.Path))
            {
                file.WriteLine("Date             Fajr         Sunrise        Dhuhr         Asr          Maghrib        Isha'");

                foreach (PrayerTime item in prayerTimes)
                {
                    file.WriteLine(string.Format("{0}       {1}         {2}         {3}         {4}         {5}         {6}", item.tarih.ToShortDateString(), item.sabah, item.gunes, item.ogle, item.ikindi, item.aksam, item.yatsi));
                }
            }

            Console.WriteLine("you have entered txtConverter Blud");
        }
    }
}
