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

            foreach (IEnumerable<PrayerTime> timesForYear in prayerTimes.GroupBy(p => p.Tarih.Year))
            {
                var year = timesForYear.Select(t => t.Tarih.Year).First();
                file.WriteLine(year);

                foreach (IEnumerable<PrayerTime> timesForMonth in timesForYear.GroupBy(p => p.Tarih.Month))
                {
                    var lastDayOfMonth = timesForMonth.Last();

                    var minHourInMonthSabah = timesForMonth.Min(p => p.Sabah.Hours);
                    var minHourInMonthGunes = timesForMonth.Min(p => p.Gunes.Hours);
                    var minHourInMonthOgle = timesForMonth.Min(p => p.Ogle.Hours);
                    var minHourInMonthIkindi = timesForMonth.Min(p => p.Ikindi.Hours);
                    var minHourInMonthAksam = timesForMonth.Min(p => p.Aksam.Hours);
                    var minHourInMonthYatsi = timesForMonth.Where(t => t.YatsiTime.Hours != 0).Min(p => p.YatsiTime.Hours);

                    file.WriteLine(minHourInMonthSabah + " " + minHourInMonthGunes + " " + minHourInMonthOgle + " " +
                                               minHourInMonthIkindi + " " + minHourInMonthAksam + " " + minHourInMonthYatsi + " ");

                    foreach (PrayerTime prayerTime in timesForMonth)
                    {
                        var sabahMinutes = prayerTime.Sabah.TotalMinutes - (minHourInMonthSabah * 60);
                        var gunesMinutes = prayerTime.Gunes.TotalMinutes - (minHourInMonthGunes * 60);
                        var ogleMinutes = prayerTime.Ogle.TotalMinutes - (minHourInMonthOgle * 60);
                        var ikindiMinutes = prayerTime.Ikindi.TotalMinutes - (minHourInMonthIkindi * 60);
                        var aksamMinutes = prayerTime.Aksam.TotalMinutes - (minHourInMonthAksam * 60);
                        var yatsiMinutes = prayerTime.YatsiTime.TotalMinutes - (minHourInMonthYatsi * 60);

                        //handle case where prayer time for isha is after 12 
                        if (yatsiMinutes < 0)
                        {
                            yatsiMinutes = (prayerTime.YatsiTime.TotalMinutes + (24 * 60) - (minHourInMonthYatsi * 60));
                        }

                        WriteMinutesToFile(file, sabahMinutes, gunesMinutes, ogleMinutes, ikindiMinutes, aksamMinutes, yatsiMinutes);

                        //need to have 31 entries for every month
                        if (prayerTime == lastDayOfMonth)
                        {
                            for (int i = prayerTime.Tarih.Day; i < 31; i++)
                            {
                                WriteMinutesToFile(file, sabahMinutes, gunesMinutes, ogleMinutes, ikindiMinutes, aksamMinutes, yatsiMinutes);
                            }
                        }
                    }
                }
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

        private void WriteMinutesToFile(StreamWriter file, double sabah, double gunes, double ogle, double ikindi, double aksam, double yatsi)
        {
            file.WriteLine(sabah + " " + gunes + " " + ogle + " " + ikindi + " " + aksam + " " + yatsi + " ");
        }


    }
}
