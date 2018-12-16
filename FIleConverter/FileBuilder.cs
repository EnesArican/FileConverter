using FileConverter.ConverterTypes;
using FIleConverter;
using FIleConverter.Enums;
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


        public FileBuilder(ConverterType conversionType)
        {
            switch (conversionType)
            {
                case ConverterType.Awa:
                    break;
                case ConverterType.Txt:
                default:
                    fileConverter = new TxtConverter(Constants.RawFilePath + "FaziletPrayerTimes.txt");
                    break;
            }
        }


        public void Build(IEnumerable<PrayerTime> prayerTimes)
        {
            fileConverter.Convert(prayerTimes);
        }

    }
}
