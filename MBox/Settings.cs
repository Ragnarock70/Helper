//-----------------------
// Copyright © Ragnarock
//----------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MBox
{
    [Serializable]
    internal class Settings
    {
        private const string FilePath = "Settings.mbox";

        internal bool ShowDebugMessages { get; set; }
        internal bool UseShortcuts { get; set; }
        internal Devices DevicesHooked { get; set; }
        internal Quote QOTD { get; set; }

        internal SortedDictionary<int, Tuple<Keys, Keys>> shortcuts { get; set; } 


        internal static readonly Settings Instance;

        static Settings()
        {
            Instance = File.Exists(FilePath)
                           ? Serial.Deserialize<Settings>(FilePath)
                           : new Settings();
        }

        ~Settings()
        {
            Save();
        }

        private static void Save()
        {
            Serial.Serialize(FilePath, Instance);
        }
    }

    enum Quote
    {
        GTFO,
        English,
        French
    }

    enum Devices
    {
        Keyboard,
        Mouse,
        Both
    }

}
