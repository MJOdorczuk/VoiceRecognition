using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    class Menu
    {
        private readonly Jack jack;
        private List<Command> commands;

        public Menu(Jack jack, List<Command> commands)
        {
            this.jack = jack;
            this.Commands = commands;
        }

        internal List<Command> Commands { get => commands; set => commands = value; }

        public Menu React(SpeechRecognizedEventArgs e)
        {
            foreach(Command command in Commands)
            {
                if (command.Called(e.Result.Text)) return command.Execute();
            }
            return this;
        }

        public string[] GetGrammar()
        {
            List<string> ret = new List<string>();
            foreach(Command command in commands)
            {
                ret.Add(command.Call);
            }
            return ret.ToArray();
        }
    }
}
