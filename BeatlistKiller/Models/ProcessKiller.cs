using IPA.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatlistKiller.Models
{
    public static class ProcessKiller
    {
        public static void KillProcesses()
        {
            foreach (var p in Process.GetProcessesByName("beatlist").Where(x => x.MainWindowHandle == IntPtr.Zero)) {
                try {
                    p.Kill();
                }
                catch (Exception e) {
                    Logger.log.Error(e);
                }
            }
        }
    }
}
