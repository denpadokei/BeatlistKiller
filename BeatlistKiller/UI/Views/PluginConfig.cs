using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using BeatlistKiller.Models;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BeatlistKiller.UI.Views
{
    internal class PluginConfig// : PersistentSingleton<ProcessKillerSettingView>
    {
        // For this method of setting the ResourceName, this class must be the first class in the file.
        public static string ResourceName => "BeatlistKiller.UI.Views.ProcessKillerSettingView.bsml";
        // Must be 'virtual' if you want BSIPA to detect a value change and save the config automatically.

        public static PluginConfig Instance { get; set; }

        /// <summary>説明 を取得、設定</summary>
        [UIValue("auto-kill")]
        public virtual bool IsAutoKill { get; set; } = false;
        
        /// <summary>説明 を取得、設定</summary>
        [UIValue("time-span")]
        public virtual float TimeSpan { get; set; } = 1f;

        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
            //PluginConfig.Instance.Load();
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            // Do stuff when the config is changed.
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
            this.IsAutoKill = other.IsAutoKill;
            this.TimeSpan = other.TimeSpan;
        }
    }
}
