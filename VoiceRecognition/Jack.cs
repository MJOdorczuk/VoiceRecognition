using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Diagnostics;

namespace VoiceRecognition
{
    public partial class Jack : Form
    {
        SpeechRecognitionEngine sre;
        private Menu currentMenu;
        public Jack()
        {
            InitializeComponent();
            currentMenu = MenuGenerator.GenericMenu(this);
            ReformGrammar();
        }

        private void EnableVC_button_Click(object sender, EventArgs e)
        {
            DisableVC_button.Enabled = true;
            sre.RecognizeAsync(RecognizeMode.Multiple);
            EnableVC_button.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            for(int i = 0; i < currentMenu.Commands.Count; i++)
            {
                if(e.Result.Text == currentMenu.Commands[i].Call)
                {
                    currentMenu = currentMenu.Commands[i].Execute();
                    ReformGrammar();
                    return;
                }
            }
        }

        public void ReformGrammar()
        {
            sre = new SpeechRecognitionEngine();
            Choices commands = new Choices();
            commands.Add(currentMenu.GetGrammar());
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);
            sre.UnloadAllGrammars();
            sre.LoadGrammarAsync(grammar);
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += Sre_SpeechRecognized;
        }

        private void DisableVC_button_Click(object sender, EventArgs e)
        {
            EnableVC_button.Enabled = true;
            sre.RecognizeAsyncStop();
            DisableVC_button.Enabled = false;
        }

        public void Print_in_log(string s)
        {
            richTextBox1.Text += "\n" + s;
        }
    }
}
