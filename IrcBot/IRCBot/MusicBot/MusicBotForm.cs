using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitchBot.IRCBot.MusicBot
{
    public partial class MusicBotForm : Form
    {
        public bool VideoPlaying = false;
        public string VideoId = string.Empty;
        public MusicBotForm()
        {
            InitializeComponent();
        }

        private void MusicBotForm_Load(object sender, EventArgs e)
        {

        }

        public bool PlaySong(string id)
        {
            flashPlayerControl.Movie = "http://www.youtube.com/v/" + id + "?autoplay=1";
            return true;
        }
    }
}
