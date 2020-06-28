using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using UnityEngine.SceneManagement;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;
using BeatlistKiller.UI;
using BS_Utils.Utilities;
using BeatlistKiller.Models;
using BeatSaberMarkupLanguage.Settings;
using BeatlistKiller.UI.Views;

namespace BeatlistKiller
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin instance { get; private set; }
        internal static string Name => "BeatlistKiller";

        private MenuUI _instance;

        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        [Init]
        public void Init(IPALogger logger)
        {
            instance = this;
            Logger.log = logger;
            Logger.log.Debug("Logger initialized.");
            
        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config

        [Init]
        public void InitWithConfig(IPA.Config.Config conf)
        {
            UI.Views.PluginConfig.Instance = conf.Generated<UI.Views.PluginConfig>();
            Logger.log.Debug("Config loaded");
        }

        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            Logger.log.Debug("OnApplicationStart");
            
            if (MenuUI.Instance == null) {
                _instance = new GameObject("ProcessKillerMenuUI").AddComponent<MenuUI>();
                
            }
            BSEvents.lateMenuSceneLoadedFresh += this.BSEvents_lateMenuSceneLoadedFresh;
        }

        private  void BSEvents_lateMenuSceneLoadedFresh(ScenesTransitionSetupDataSO scenes)
        {
            Logger.log.Info("MenuSceneLoadedFresh start");
            MenuUI.Instance.CreateUI();
            BSMLSettings.instance.AddSettingsMenu("Beatlist Killer", UI.Views.PluginConfig.ResourceName, UI.Views.PluginConfig.Instance);
            if (UI.Views.PluginConfig.Instance.IsAutoKill) {
                _ = ProcessKiller.KillProcesses();
            }
            Logger.log.Info("MenuSceneLoadedFresh end");
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Logger.log.Debug("OnApplicationQuit");

        }
    }
}
