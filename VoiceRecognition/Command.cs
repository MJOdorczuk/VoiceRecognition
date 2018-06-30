using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    class Command
    {
        private readonly string call;
        private readonly Func<Menu> executive;


        public string Call => call;

        internal Func<Menu> Execute => executive;

        public Command(string call, Func<Menu> executive)
        {
            this.call = call;
            this.executive = executive;
        }

        public bool Called(string call)
        {
            return call == this.Call;
        }
    }
}
