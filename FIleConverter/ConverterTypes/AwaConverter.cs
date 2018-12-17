using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileConverter.ConverterTypes
{
    class AwaConverter : ConverterBase
    {
        public override void Convert(StreamWriter file, IEnumerable<PrayerTime> prayerTimes)
        {
            SetHeader(file);


            var year = prayerTimes.Min(p => p.Tarih.Year);
            var prayerTimesForYear = prayerTimes.Where(p => p.Tarih.Year == year);

            var month = prayerTimesForYear.Min(p => p.Tarih.Month);
            var prayerTimesForMonth = prayerTimesForYear.Where(p => p.Tarih.Month == month);


            var minHourInMonthSabah = prayerTimesForMonth.Min(p => p.Sabah.Hours);
            var minHourInMonthGunes = prayerTimesForMonth.Min(p => p.Gunes.Hours);
            var minHourInMonthOgle = prayerTimesForMonth.Min(p => p.Ogle.Hours);
            var minHourInMonthIkindi = prayerTimesForMonth.Min(p => p.Ikindi.Hours);
            var minHourInMonthAksam = prayerTimesForMonth.Min(p => p.Aksam.Hours);
            var minHourInMonthYatsi = prayerTimesForMonth.Min(p => p.YatsiTime.Hours);


            file.WriteLine(year);
            file.WriteLine(minHourInMonthSabah + " " + minHourInMonthGunes + " " + minHourInMonthOgle +  " " + 
                                                minHourInMonthIkindi + " " + minHourInMonthAksam + " " + minHourInMonthYatsi);

            foreach (PrayerTime prayerTime in prayerTimesForMonth)
            {
                var sabahMinutes = prayerTime.Sabah.TotalMinutes - (minHourInMonthSabah * 60);
                var gunesMinutes = prayerTime.Gunes.TotalMinutes - (minHourInMonthGunes * 60);
                var ogleMinutes = prayerTime.Ogle.TotalMinutes - (minHourInMonthOgle * 60);
                var ikindiMinutes = prayerTime.Ikindi.TotalMinutes - (minHourInMonthIkindi * 60);
                var aksamMinutes = prayerTime.Aksam.TotalMinutes - (minHourInMonthAksam * 60);
                var yatsiMinutes = prayerTime.YatsiTime.TotalMinutes - (minHourInMonthYatsi * 60);

                file.WriteLine(sabahMinutes + " " + gunesMinutes + " " + ogleMinutes + " " + ikindiMinutes + " " + aksamMinutes + " " + yatsiMinutes);

            }

            




            
            Console.WriteLine("you have entered awaConverter Blud");
        }


        private void SetHeader(StreamWriter file)
        {
            file.WriteLine("London");
            file.WriteLine(DateTime.Now.ToString("d/M/yyyy"));
            file.WriteLine("2");
            file.WriteLine(Constants.Years.Count);
            file.WriteLine(Constants.Years.Min(y => y));
            for (int i = 0; i < 5; i++) { file.WriteLine(" "); }
        }



    }
}
