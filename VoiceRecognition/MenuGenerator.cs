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
            Command volume_up_a_bit = new Command("up", 
                () => {
                    jack.Print_in_log("up a bit");
                    CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                    Debug.WriteLine("Current volume:" + defaultPlaybackDevice.Volume);
                    return main;
                });
            sounder.Commands.AddRange(new Command[] { volume_up_a_bit });
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
