using FileConverter;
using FileConverter.ConverterTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleConverter.ConverterTypes
{
    public abstract class ConverterBase : IConverterBase
    {
        protected FileStream NewFile;
        protected string Path;
        public ConverterBase(string path)
        {
           this.Path = path;
           this.NewFile = TryCreateFile(path);
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
