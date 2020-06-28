//using System.Collections.Generic;
//using System.ComponentModel;
//using System.IO;
//using System.Runtime.CompilerServices;
//using BeatlistKiller.UI.Views;
//using BeatSaberMarkupLanguage.Attributes;
//using IPA.Config.Stores;
//using static IPA.Config.Config;

//namespace BeatlistKiller.Configuration
//{
//    internal class PluginConfig
//    {
//        public static string FilePath => Path.Combine(Directory.GetCurrentDirectory(), "UserData", "Beatlistkiller.ini");

//        public static PluginConfig Instance { get; } = new PluginConfig();

//        private PluginConfig()
//        {
//            this.Load();
//            this.Save();
//        }

//        public bool AutoKill = false;
//        public float TimeSpan  = 1; // Must be 'virtual' if you want BSIPA to detect a value change and save the config automatically.

//        public void Save()
//        {
//            ConfigSerializer.SaveConfig(this, FilePath);
//        }

//        public void Load()
//        {
//            ConfigSerializer.LoadConfig(this, FilePath);
//        }
//    }
//}