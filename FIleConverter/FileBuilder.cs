using FIleConverter.ConverterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleConverter
{
    public class FileBuilder
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string name = "PrayerTimes";


        public FileBuilder()
        {
            

        }


        public void Build(int conversionType)
        {
            IConverterBase fileConverter;

            switch (conversionType)
            {
                case 1:
                default:
                    fileConverter = new TxtConverter();
                    break;
            }

            fileConverter.Convert();
        }

    }
}
