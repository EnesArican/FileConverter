using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.ConverterTypes
{
    interface IConverterBase
    {
        void Convert(StreamWriter file, IEnumerable<PrayerTime> prayerTimes);

    }
}
