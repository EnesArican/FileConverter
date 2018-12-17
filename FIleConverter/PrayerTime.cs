using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    public class PrayerTime
    {
        public DateTime Tarih { get; set; }

        public string Isani { get; set; }

        public string Asani { get; set; }

        public string Imsak { get; set; }

        public TimeSpan Sabah { get; set; }

        public TimeSpan Gunes { get; set; }

        public TimeSpan Ogle { get; set; }

        public TimeSpan Ikindi { get; set; }

        public TimeSpan Aksam { get; set; }

        public TimeSpan YatsiTime
        {
            get
            {
                return TimeSpan.Parse(Yatsi.Substring(0,5));
            }
        }

        public string Yatsi { get; set; }

        public string Kible { get; set; }

        public int Bolge_id { get; set; }

        public string Israk { get; set; }


    }
}
