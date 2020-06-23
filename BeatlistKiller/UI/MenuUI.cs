using BeatlistKiller.Models;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatlistKiller.UI
{
    public class MenuUI
    {
        public static void CreateUI()
        {
            var button = new MenuButton("BeatlistListKiller", ProcessKiller.KillProcesses);
            MenuButtons.instance.RegisterButton(button);
        }
    }
}
