using FileConverter.ConverterTypes;
using FileConverter.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileConverter
{
    public class FileBuilder
    {
        IConverterBase fileConverter;
        string Path { get; set; }

        public FileBuilder(ConverterType conversionType)
        {
            this.Path = SetNewFilePath(conversionType);
            SetConverterType(conversionType);
        }

        public void Build(IEnumerable<PrayerTime> prayerTimes)
        {
            if (File.Exists(this.Path)) { File.Delete(this.Path); }
            using (StreamWriter file = new StreamWriter(this.Path))
            {
                prayerTimes = prayerTimes.OrderBy(p => p.tarih);
                fileConverter.Convert(file, prayerTimes);
            }
        }

        private void SetConverterType(ConverterType conversionType)
        {
            switch (conversionType)
            {
                case ConverterType.Awa:
                    fileConverter = new AwaConverter();
                    break;
                case ConverterType.Txt:
                default:
                    fileConverter = new TxtConverter();
                    break;
            }
        }

        private string SetNewFilePath(ConverterType conversionType)
        {
            StringBuilder newFilePath = new StringBuilder().Append(Constants.RawFilePath + Constants.NewFileName);

            foreach (int year in Constants.Years)
            {
                newFilePath.Append("_" + year.ToString());
            }

            newFilePath.Append(conversionType == ConverterType.Awa ? ".awa" : ".txt");

            return newFilePath.ToString();
        }
    }
}
