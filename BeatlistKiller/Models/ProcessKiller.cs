using BeatlistKiller.UI.Views;
using IPA.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeatlistKiller.Models
{
    public static class ProcessKiller
    {
        private static volatile bool _isRunning = false;


        public static async Task KillProcesses()
        {
            if (_isRunning) {
                return;
            }
            _isRunning = true;
            try {
                await Task.Run(async () =>
                {
                    do {
                        Logger.log.Debug("Start kill process");
                        foreach (var p in Process.GetProcessesByName("beatlist").Where(x => x.MainWindowHandle == IntPtr.Zero)) {
                            try {
                                Logger.log.Debug($"kill process ID : {p.Id}");
                                p.Kill();
                            }
                            catch (Exception e) {
                                Logger.log.Error(e);
                            }
                        }
                        var timespan = new TimeSpan(0, 0, (int)UI.Views.PluginConfig.Instance.TimeSpan).TotalMilliseconds;

                        //Logger.log.Info($"timespan : {PluginConfig.Instance.TimeSpan}");
                        //Logger.log.Info($"milliseconds : {timespan}");

                        await Task.Delay((int)timespan);

                    } while (UI.Views.PluginConfig.Instance.IsAutoKill);
                }).ConfigureAwait(false);
                _isRunning = false;
            }
            catch (Exception e) {
                Logger.log.Error($"{e}");
                _isRunning = false;
            }
            Logger.log.Debug("finish kill process");
        }
    }
}
