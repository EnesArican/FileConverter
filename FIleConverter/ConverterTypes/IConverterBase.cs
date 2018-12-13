﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.ConverterTypes
{
    interface IConverterBase
    {
        void Convert(IEnumerable<PrayerTime> prayerTimes);
    }
}