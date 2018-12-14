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
        void Convert(IEnumerable<PrayerTime> prayerTimes);

        FileStream TryCreateFile(string path);
    }
}
