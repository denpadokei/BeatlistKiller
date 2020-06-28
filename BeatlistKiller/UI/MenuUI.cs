using BeatlistKiller.Models;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeatlistKiller.UI
{
    public class MenuUI : MonoBehaviour
    {
        public static MenuUI Instance { get; private set; }

        //private ProcessKillerFlowCoordinator _processKillerFlowCoordinator; 

        private void Awake()
        {
            Logger.log.Info("Start MenuUI Awale");
            Instance = this;
        }

        public void CreateUI()
        {
            Logger.log.Info("Creat UI");
            var button = new MenuButton("Beatlist Killer", "Kill to beatlist Process.", () => { _ = ProcessKiller.KillProcesses(); }, true);
            MenuButtons.instance.RegisterButton(button);
        }


        //private void ShowSettingFlowCoordinator()
        //{
        //    if (this._processKillerFlowCoordinator == null) {
        //        this._processKillerFlowCoordinator = BeatSaberUI.CreateFlowCoordinator<ProcessKillerFlowCoordinator>();
        //    }

        //    BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(this._processKillerFlowCoordinator);
        //}
    }
}
