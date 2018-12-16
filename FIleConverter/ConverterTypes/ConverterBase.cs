using FileConverter;
using FileConverter.ConverterTypes;
using System.Collections.Generic;
using System.IO;


namespace FIleConverter.ConverterTypes
{
    public abstract class ConverterBase : IConverterBase
    {
        public abstract void Convert(StreamWriter file, IEnumerable<PrayerTime> prayerTimes);
    }
}
