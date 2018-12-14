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
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.Path))
            {
                file.WriteLine("Date    Fajr    Sunrise     Dhuhr      Asr      Maghrib     Isha'");

                foreach (PrayerTime item in prayerTimes)
                {
                    string[] times = { item.tarih.ToShortDateString(), item.sabah, item.gunes, item.ogle, item.ikindi, item.aksam, item.yatsi };
                    file.WriteLine(string.Format("{0}   {1}     {2}     {3}     {4}", times));
                }
            }

            Console.WriteLine("you have entered txtConverter Blud");
        }
    }
}
