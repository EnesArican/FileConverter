using FileConverter.ConverterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    public class FileBuilder
    {
        IConverterBase fileConverter;


        public FileBuilder(int? conversionType)
        {
            string path = "hello";
            switch (conversionType)
            {
                case 1:
                default:
                    fileConverter = new TxtConverter(path);
                    break;
            }
        }


        public void Build(IEnumerable<PrayerTime> prayerTimes)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string name = "PrayerTimes";

          
            fileConverter.Convert(prayerTimes);
        }

    }
}
