﻿using FileConverter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter
{
    public static class Constants
    {
        public static readonly List<int> Years = new List<int> { 2018, 2019 };

        public static readonly string RawFileName = "-namaz-vakitleri.txt";


        public static readonly string NewFileName = "FaziletPrayerTimes";


        public static readonly string RawFilePath = @"C:\Users\enes\Documents\fazilet-takvimi-namaz-vakitleri\";

        public static readonly ConverterType SelectedFileType = ConverterType.Awa;

    }
}
