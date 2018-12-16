using FileConverter;
using FileConverter.ConverterTypes;
using System.Collections.Generic;
using System.IO;


namespace FIleConverter.ConverterTypes
{
    public abstract class ConverterBase : IConverterBase
    {
        protected FileStream NewFile { get; set; }
        protected string Path { get; set; }
        public ConverterBase(string path)
        {
           this.Path = path;
          // this.NewFile = TryCreateFile(path);
        }

        public abstract void Convert(IEnumerable<PrayerTime> prayerTimes);

        public FileStream TryCreateFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            return File.Create(path);
        }




    }
}
