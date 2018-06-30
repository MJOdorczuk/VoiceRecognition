using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    static class MenuGenerator
    {
        public static Menu GenericMenu(Jack jack)
        {
            List<Menu> menus = new List<Menu>();
            //// MAIN MENU
            Menu main = new Menu(jack, new List<Command>());
            menus.Add(main);
            Command exit = new Command("exit", () => { jack.Close(); jack.Print_in_log("exit");  return main; });
            Menu opener = new Menu(jack, new List<Command>());
            menus.Add(opener);
            Command open = new Command("open", () => { jack.Print_in_log("open"); return opener; });
            Menu sounder = new Menu(jack, new List<Command>());
            menus.Add(sounder);
            Command volume = new Command("volume", () => { jack.Print_in_log("volume"); return sounder; });
            Menu brighter = new Menu(jack, new List<Command>());
            menus.Add(brighter);
            Command brightness = new Command("brightness", () => { jack.Print_in_log("brightness"); return brighter; });
            main.Commands.AddRange(new Command[] { exit, open, volume, brightness });
            //// OPENER MENU
            Command open_paint = new Command("paint", 
                () => {
                    jack.Print_in_log("open_paint");
                    ProcessStartInfo start = new ProcessStartInfo();
                    start.FileName = @"C:\WINDOWS\system32\mspaint.exe";
                    start.WindowStyle = ProcessWindowStyle.Normal;
                    start.CreateNoWindow = true;
                    Process.Start(start);
                    return main;
                });
            opener.Commands.AddRange(new Command[] { open_paint });
            //// SOUNDER MENU
            Command volume_up_a_bit = new Command("little up", 
                () => {
                    jack.Print_in_log("up a bit");
                    CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                    if(defaultPlaybackDevice.Volume < 98)
                    {
                        defaultPlaybackDevice.Volume += 2;
                    }
                    else defaultPlaybackDevice.Volume = 100;
                    return main;
                });
            Command volume_up_a_lot = new Command("up a lot",
                () =>
                {
                    jack.Print_in_log("up a lot");
                    CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                    if (defaultPlaybackDevice.Volume < 80)
                    {
                        defaultPlaybackDevice.Volume += 20;
                    }
                    else defaultPlaybackDevice.Volume = 100;
                    return main;
                });
            Command volume_down_a_bit = new Command("little down",
                () =>
                {
                    jack.Print_in_log("down a bit");
                    CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                    if (defaultPlaybackDevice.Volume > 2)
                    {
                        defaultPlaybackDevice.Volume -= 2;
                    }
                    else defaultPlaybackDevice.Volume = 0;
                    return main;
                });
            Command volume_down_a_lot = new Command("down a lot",
                () =>
                {
                    jack.Print_in_log("down a lot");
                    CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                    if (defaultPlaybackDevice.Volume > 20)
                    {
                        defaultPlaybackDevice.Volume -= 20;
                    }
                    else defaultPlaybackDevice.Volume = 0;
                    return main;
                });
            sounder.Commands.AddRange(new Command[] { volume_up_a_bit, volume_up_a_lot, volume_down_a_bit, volume_down_a_lot });
            //// BRIGHTER MENU
            //// POPULAR
            List<Command> popular = new List<Command>();
            Command back_to_main_menu = new Command("back", () => { jack.Print_in_log("back"); return main; });
            popular.Add(back_to_main_menu);
            foreach(Menu menu in menus)
            {
                menu.Commands.AddRange(popular.ToArray());
            }
            return main;
        }
    }
}
