using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    public class PrayerTime
    {
        public DateTime tarih { get; set; }

        public string isani { get; set; }

        public string asani { get; set; }

        public string imsak { get; set; }

        public string ogle { get; set; }

        public string sabah { get; set; }

        public string ikindi { get; set; }

        public string kible { get; set; }

        public string aksam { get; set; }

        public string yatsi { get; set; }

        public int bolge_id { get; set; }

        public string gunes { get; set; }

        public string israk { get; set; }

        public int Year
        {
            get { return tarih.Year; }
        }

        public int Month
        {
            get { return tarih.Month; }
        }

        public int Day
        {
            get { return tarih.Day; }
        }


    }
}
