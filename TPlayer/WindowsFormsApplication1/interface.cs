﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Google.GData.YouTube;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TPlayer
{
    public partial class TPlayerForm : Form
    {
        
        private readonly KeyboardHookListener m_KeyboardHookManager;
        public bool ctrlPressed = false;
        public bool shiftPressed = false;
        public bool altPressed = false;
        public bool playState = false;
        public bool YTState = false;
        public bool YTFocus = false;
        public bool shuffle = false;
        public bool loopFile = false;
        public bool loopPlaylist = false;
        public bool autoSavePlaylist = false;        
        

        public int currentlySelectedPlaylist = 1;

        public TVideo currentlyPlayingVideo = null;


        public TPlaylist currentTPlaylist = new TPlaylist();
        public TPlaylist randomPlaylist = new TPlaylist();
        
        public TPlayerForm()
        {
            InitializeComponent();

               
            m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            m_KeyboardHookManager.Enabled = false;
            activateGlobalHotkey();
            
            setPlaylistsGUI();
        }

        public void setPlaylistsGUI()
        {
            playlistResults.DataSource = currentTPlaylist.playlist;
        }

        public void setupRandomPlaylist()
        {
            
        }

        public void AddVideoToRandomPlaylist(string youtubeLink)
        {
            TVideo video = new TVideo();
            string vidID = TPlaylist.parseYTurl(youtubeLink);

            video = new TVideo { videoID = vidID };
            //if (!GetVideoInfo(video))
            //    randomPlaylist.playlist.Add();  
        }
        

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
         {
            //Console.Write(string.Format("KeyDown \t\t {0}\n", e.KeyCode));
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                ctrlPressed = true;
            }
            else if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
            {
                shiftPressed = true;
            }
            else if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
            {
                altPressed = true;
            }
            
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            //Console.Write(string.Format("KeyUp  \t\t {0} + ctrl {1} + alt {2} + shift {3} \n", e.KeyCode , ctrlPressed , altPressed, shiftPressed));
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
            {
                ctrlPressed = false;
            }
            else if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
            {
                shiftPressed = false;
            }
            else if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
            {
                altPressed = false;
            }
            else if (e.KeyCode == Keys.MediaPlayPause)
            {
                if (!YTplayer.Focused)
                { 
                    mediaPlayPause();
                }
            }
            else if (e.KeyCode == Keys.MediaNextTrack || (e.KeyCode == Keys.Right && ctrlPressed && shiftPressed))
            {
                mediaNext();
            }
            else if (e.KeyCode == Keys.MediaPreviousTrack || (e.KeyCode == Keys.Left && ctrlPressed && shiftPressed))
            {
                mediaPrev();
            }
        }

        private void mediaPlay()
        {
            
            Console.Write(string.Format("Media: Play\n"));
            YTplayer_CallFlash("playVideo()");
            playState = true;
                
        }
        private void mediaPause()
        {       
            Console.Write(string.Format("Media: Pause\n"));
            YTplayer_CallFlash("pauseVideo()");
            playState = false;

        }
        private void mediaPlayPause()
        {
            if (playState == true)
            {
                mediaPause();
            }
            else
            {
                mediaPlay();
            }
        }
        private void mediaRestart()
        {
            Console.Write(string.Format("Media: Restart\n"));
        }
        private void mediaNext()
        {
            Console.Write(string.Format("Media: Next\n"));
            switch (currentlySelectedPlaylist)
            {
                case 1:
                    if ((currentTPlaylist.current + 1 < currentTPlaylist.playlist.Count || loopPlaylist) && !shuffle && currentTPlaylist.playlist.Count > 0)
                    {
                        if (currentTPlaylist.current + 1 < currentTPlaylist.playlist.Count)
                            currentTPlaylist.current++;
                        else
                            currentTPlaylist.current = 0;

                        mediaLoadVideo(currentTPlaylist.playlist[currentTPlaylist.current].videoID);
                    }
                    else if (shuffle && currentTPlaylist.playlist.Count > 0)
                    {
                        Random random = new Random();
                        currentTPlaylist.current = random.Next(0, currentTPlaylist.playlist.Count - 1);
                        // Could choose the same song again
                        mediaLoadVideo(currentTPlaylist.playlist[currentTPlaylist.current].videoID);
                    }
                    else currentTPlaylist.isPlaying = false;
                    break;
                default: break;
            }
        }
        private void mediaPrev()
        {
            Console.Write(string.Format("Media: Prev\n"));
            switch (currentlySelectedPlaylist)
            {
                case 1:
                    if (currentTPlaylist.playlist.Count > 0 && !shuffle)
                    {
                        if (currentTPlaylist.current - 1 >= 0)
                            currentTPlaylist.current--;
                        else
                            currentTPlaylist.current = currentTPlaylist.playlist.Count - 1;

                        mediaLoadVideo(currentTPlaylist.playlist[currentTPlaylist.current].videoID);
                    }
                    break;
                default: break;

            }            
        }

        private bool GetVideoInfo(TVideo video)
        {
            try
            {
                string str =
                (new WebClient()).DownloadString("https://www.googleapis.com/youtube/v3/videos?id=" + video.videoID +
                                                 "&part=snippet,contentDetails&key=AIzaSyCxll2fv3MwHnA3SdQ7XFJWX5Vvbg67UF4");
                JObject root = JObject.Parse(str);

                JToken firstItems = ((JArray) root["items"]).FirstOrDefault();
                video.name = firstItems["snippet"]["title"].ToString();
                string duration = firstItems["contentDetails"]["duration"].ToString();
                video.duration = (int)XmlConvert.ToTimeSpan(duration).TotalSeconds;
                
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception thrown while getting youtube info.");
                return false;
            }
        }
        private void mediaLoadVideo(string vidId)
        {
            TVideo currentVideo = currentTPlaylist.playlist.FirstOrDefault(TVideo => TVideo.videoID == vidId);
            if (currentVideo == null)
            {
                currentVideo = new TVideo() {videoID = vidId};
                currentTPlaylist.playlist.Add(currentVideo);
            }

            currentlyPlayingVideo = currentVideo;

            Console.Write(string.Format("Media: Load '" + vidId + "'\n"));
            YTplayer_CallFlash("loadVideoById(" + vidId + ")");

            if (currentlySelectedPlaylist == 1)
            {
                currentTPlaylist.isPlaying = true;
                if (currentVideo.duration == 0)
                    GetVideoInfo(currentVideo);

            }
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
              //Console.Write(string.Format("KeyPress \t\t {0}\n", e.KeyChar));
        }
        
        
        private void activateGlobalHotkey(bool temp = false)
        {
            if (!temp) globalHotkeysToolStripMenuItem.Checked = true;
            m_KeyboardHookManager.KeyDown += HookManager_KeyDown;
            m_KeyboardHookManager.KeyUp += HookManager_KeyUp;
            
        }

        private void deactivateGlobalHotkey(bool temp = false)
        {
            if (!temp) globalHotkeysToolStripMenuItem.Checked = false;
            m_KeyboardHookManager.KeyDown -= HookManager_KeyDown;
            m_KeyboardHookManager.KeyUp -= HookManager_KeyUp;
            
        }
        private void globalHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globalHotkeysToolStripMenuItem.Checked == true)
            {
                deactivateGlobalHotkey();                
            }
            else
            {
                activateGlobalHotkey();
            }
        }

        private string YTplayer_CallFlash(string ytFunction){
            string flashXMLrequest = "";
            string response="";
            string flashFunction="";
            List<string> flashFunctionArgs = new List<string>();

            Regex func2xml = new Regex(@"([a-z][a-z0-9]*)(\(([^)]*)\))?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Match fmatch = func2xml.Match(ytFunction);

            if(fmatch.Captures.Count != 1){
                Console.Write("bad function request string");
                return "";
            }

            flashFunction=fmatch.Groups[1].Value.ToString();
            flashXMLrequest = "<invoke name=\"" + flashFunction + "\" returntype=\"xml\">";
            if (fmatch.Groups[3].Value.Length > 0)
            {
                flashFunctionArgs = parseDelimitedString(fmatch.Groups[3].Value);
                if (flashFunctionArgs.Count > 0)
                {
                    flashXMLrequest += "<arguments><string>";
                    flashXMLrequest += string.Join("</string><string>", flashFunctionArgs);
                    flashXMLrequest += "</string></arguments>";
                }
            }
            flashXMLrequest += "</invoke>";

            try
            {
                Console.Write("YTplayer_CallFlash: \"" + flashXMLrequest + "\"\r\n");
                response = YTplayer.CallFunction(flashXMLrequest);                
                Console.Write("YTplayer_CallFlash_response: \"" + response + "\"\r\n");
            }
            catch
            {
                Console.Write("YTplayer_CallFlash: error \"" + flashXMLrequest + "\"\r\n");
            }

            return response;
        }

        private void YTplayer_FlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e)
        {
            //Console.Write("YTplayer_FlashCall: raw: "+e.request.ToString()+"\r\n");
            // message is in xml format so we need to parse it
            XmlDocument document = new XmlDocument();
            document.LoadXml(e.request);
            // get attributes to see which command flash is trying to call
            XmlAttributeCollection attributes = document.FirstChild.Attributes;
            String command = attributes.Item(0).InnerText;
            // get parameters
            XmlNodeList list = document.GetElementsByTagName("arguments");
            List<string> listS = new List<string>();
            foreach (XmlNode l in list){
                listS.Add(l.InnerText);
            }

            
            //Console.Write("YTplayer_FlashCall: \"" + command.ToString() + "(" + string.Join(",", listS) + ")\r\n");
            // Interpret command
            switch (command)
            {
                case "onYouTubePlayerReady": YTready(listS[0]); break;
                case "YTStateChange": YTStateChange(listS[0]); break;
                case "YTError": YTStateError(listS[0]);  break;
                case "document.location.href.toString": YTplayer.SetReturnValue("<string>http://www.youtube.com/v/" + currentlyPlayingVideo + "</string>"); break;
                default: Console.Write("YTplayer_FlashCall: (unknownCommand)\r\n"); break;
            }
        }

        private void YTStateError(string error)
        {
            if (error == "101" || error == "150")
            {
                Console.WriteLine("Video does not allow embedding");
                mediaNext();
            }
        }

        private void YTStateChange(string YTplayState)
        {
            switch (int.Parse(YTplayState))
            {
                case -1: playState = false; break; //not started yet
                case 1: playState = true; break; //playing
                case 2: playState = false; break; //paused
                //case 3: ; break; //buffering
                case 0: playState = false; if (!loopFile) mediaNext(); else YTplayer_CallFlash("seekTo(0)"); break; //ended
            }
        }

        private void YTready(string playerID)
        {
            YTState = true;
            
            //start eventHandlers
            YTplayer_CallFlash("addEventListener(\"onStateChange\",\"YTStateChange\")");
            YTplayer_CallFlash("addEventListener(\"onError\",\"YTError\")");

        }

        private void YTplayer_FSCommand(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent e)
        {
            Console.Write("YTplayer_FSCommand: " + e.command.ToString() + "(" + e.args.ToString() + ")" + "\r\n");
        }


        private static List<string> parseDelimitedString (string arguments, char delim = ',')
        {
            bool inQuotes = false;
            bool inNonQuotes = false;
            int whiteSpaceCount = 0;
            
            List<string> strings = new List<string>();

            StringBuilder sb = new StringBuilder();
            foreach (char c in arguments)
            {
                if (c == '\'' || c == '"')
                {
                    if (!inQuotes)
                        inQuotes = true;
                    else
                        inQuotes = false;

                    whiteSpaceCount = 0;
                }else if (c == delim)
                {
                    if (!inQuotes)
                    {
                        if (whiteSpaceCount > 0 && inQuotes)
                        {
                            sb.Remove(sb.Length - whiteSpaceCount, whiteSpaceCount);
                            inNonQuotes = false;
                        }
                        strings.Add(sb.Replace("'", string.Empty).Replace("\"", string.Empty).ToString());
                        sb.Remove(0, sb.Length);                       
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    whiteSpaceCount = 0;
                }
                else if (char.IsWhiteSpace(c))
                {                    
                    if (inNonQuotes || inQuotes)
                    {
                        sb.Append(c);
                        whiteSpaceCount++;
                    }
                }
                else
                {
                    if (!inQuotes) inNonQuotes = true;
                    sb.Append(c);
                    whiteSpaceCount = 0;
                }
            }
            strings.Add(sb.Replace("'", string.Empty).Replace("\"", string.Empty).ToString());


            return strings;
        }

        class InputBox
        {
            /// <summary>
            /// Displays a dialog with a prompt and textbox where the user can enter information
            /// </summary>
            /// <param name="title">Dialog title</param>
            /// <param name="promptText">Dialog prompt</param>
            /// <param name="value">Sets the initial value and returns the result</param>
            /// <returns>Dialog result</returns>
            public static DialogResult Show(string title, string promptText, ref string value)
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = promptText;
                textBox.Text = value;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 372, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 107);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value = textBox.Text;
                return dialogResult;
            }
        }

        private void inserUrlMenuItem_Click(object sender, EventArgs e)
        {
            string value = "";

            if (InputBox.Show("Load video id", "&Enter youtube vidId:", ref value) == DialogResult.OK)
            {
                string vidId = TPlaylist.parseYTurl(value);
                if (!string.IsNullOrWhiteSpace(vidId))
                {
                    Console.Write("loadUrl: " + vidId);
                    mediaLoadVideo(vidId);
                }
                else
                {
                    MessageBox.Show("invalid Video Id \"" + vidId + "\"");
                }
            }
        }

        private void YTplayer_Enter(object sender, EventArgs e)
        {
            YTFocus = true;
            //if(globalHotkeysToolStripMenuItem.Checked) deactivateGlobalHotkey(true);
        }

        private void YTplayer_Leave(object sender, EventArgs e)
        {
            YTFocus = false;
            //if (globalHotkeysToolStripMenuItem.Checked) activateGlobalHotkey(true);
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            //if (globalHotkeysToolStripMenuItem.Checked && YTFocus) activateGlobalHotkey(true);
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            
            //if (globalHotkeysToolStripMenuItem.Checked && YTFocus) deactivateGlobalHotkey(true);
        }

        private void playMenuItem_Click(object sender, EventArgs e)
        {
            mediaPlay();
        }

        private void pauseMenuItem_Click(object sender, EventArgs e)
        {
            mediaPause();
        }

        private void stopMenuItem_Click(object sender, EventArgs e)
        {
            mediaRestart();
        }

        private void previousMenuItem_Click(object sender, EventArgs e)
        {
            mediaPrev();
        }

        private void nextMenuItem_Click(object sender, EventArgs e)
        {
            mediaNext();
        }

        private void addToPlaylistMenuItem_Click(object sender, EventArgs e)
        {
            string currentVideoId=YTplayer_CallFlash("getPlaylist()");
            string currentDuration = YTplayer_CallFlash("getDuration()");
        }

        public class TVideo
        {
            public TVideo()
            {
                videoID = string.Empty;
                name = string.Empty;
                duration = 0;
            }
            public string videoID { get; set; }
            public string name { get; set; }
            public int duration { get; set; } //duration in seconds
        }

        public class TPlaylist
        {
            public string name = "";
            public string path = "";
            public BindingList<TVideo> playlist = new BindingList<TVideo>();
            public int current = 0; // curently playing
            public bool isPlaying = false;

            public void saveToFile(bool showDialog = false, string ytpFile = null)
            {
                string ret = "";

                foreach (TVideo tVid in this.playlist)
                {
                    ret += tVid.videoID.Replace("\"", " ") + '\t' + tVid.name.Replace("\"", " ") + '\t' + tVid.duration.ToString().Replace("\"", " ") + "\r\n";
                }

                if ((!string.IsNullOrWhiteSpace(ytpFile) || !string.IsNullOrWhiteSpace(this.path)) && !showDialog)
                {
                    if (!string.IsNullOrWhiteSpace(ytpFile))
                    {
                        File.WriteAllText(ytpFile, ret);
                        this.path = ytpFile;
                        this.name = Path.GetFileNameWithoutExtension(ytpFile);
                    }
                    else
                    {
                        File.WriteAllText(this.path, ret);
                    }
                }
                else
                {
                    Stream myStream;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "YouTube Playlist File (.ytp)|*.ytp|YouTube VideoIds File (.txt)|*.txt";
                    saveFileDialog1.FilterIndex = 1;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        if ((myStream = saveFileDialog1.OpenFile()) != null)
                        {
                            if (myStream.CanWrite)
                            {
                                StreamWriter myWritter = new StreamWriter(myStream, System.Text.Encoding.ASCII);
                                myWritter.Write(ret);
                                myWritter.Flush();
                                this.path = saveFileDialog1.FileName;
                                this.name = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                            }
                            else
                            {
                                MessageBox.Show("can't write to " + saveFileDialog1.FileName);
                            }
                            myStream.Close();
                        }
                    }
                }

            }

            public void loadFromFile(bool showDialog = false, bool clearPlaylist = true , string[] ytpFiles = null)
            {
                if (clearPlaylist)
                {
                    this.playlist = new BindingList<TVideo>();
                }

                if ((ytpFiles == null && string.IsNullOrWhiteSpace(this.path)) || showDialog)
                {
                    // Create an instance of the open file dialog box.
                    OpenFileDialog loadTPlaylistFileDialog = new OpenFileDialog();

                    // Set filter options and filter index.
                    loadTPlaylistFileDialog.Filter = "YouTube Playlist File (.ytp)|*.ytp|YouTube VideoIds File (.txt)|*.txt";
                    loadTPlaylistFileDialog.FilterIndex = 1;
                    loadTPlaylistFileDialog.Multiselect = true;

                    // Call the ShowDialog method to show the dialog box.
                    DialogResult userClickedOK = loadTPlaylistFileDialog.ShowDialog();

                    // Process input if the user clicked OK.
                    if (userClickedOK == DialogResult.OK)
                    {
                        TVideo TVideoEntry = new TVideo();
                        List<string> parsedLine = new List<string>();
                        if (loadTPlaylistFileDialog.FileNames.Length == 1)
                        {
                            this.path = loadTPlaylistFileDialog.FileNames[0].ToString();
                            this.name = Path.GetFileNameWithoutExtension(loadTPlaylistFileDialog.FileNames[0]);
                        }

                        foreach (string file in loadTPlaylistFileDialog.FileNames)
                        {
                            using (StreamReader reader = new StreamReader(file))
                            {
                                while (!reader.EndOfStream)
                                {
                                    parsedLine = parseDelimitedString(reader.ReadLine(), '\t');
                                    
                                    string vidID = parsedLine.Count>0 ? parseYTurl(parsedLine[0]) : "";
                                    if (!string.IsNullOrWhiteSpace(vidID))
                                    {
                                        switch (parsedLine.Count)
                                        {
                                            case 3: TVideoEntry = new TVideo { videoID = vidID, name = parsedLine[1], duration = int.Parse(parsedLine[2]) }; this.playlist.Add(TVideoEntry); break; //default playlist
                                            case 1: TVideoEntry = new TVideo { videoID = vidID }; this.playlist.Add(TVideoEntry); break; //only youtubeVideoId playlist
                                            default: Console.Write("Ignoring: Wrong line Format (" + parsedLine.Count.ToString() + " collumns)\r\n"); break; //error                                
                                        }
                                    }
                                    else
                                    {
                                        Console.Write("Ignoring: invalid video ID \"" + (parsedLine.Count>0? parseYTurl(parsedLine[0]):"") + "\" \r\n");
                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    if (ytpFiles == null)
                    {
                        ytpFiles[0] = this.path;
                    }
                    TVideo TVideoEntry = new TVideo();
                    List<string> parsedLine = new List<string>();
                    if (ytpFiles.Length == 1)
                    {
                        this.path = ytpFiles[1].ToString();
                    }
                    foreach (string file in ytpFiles)
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {

                            while (!reader.EndOfStream)
                            {
                                parsedLine = parseDelimitedString(reader.ReadLine(), '\t');
                                string vidID = parsedLine.Count > 0 ? parseYTurl(parsedLine[0]) : "";
                                if (!string.IsNullOrWhiteSpace(vidID))
                                {
                                    switch (parsedLine.Count)
                                    {
                                        case 3: TVideoEntry = new TVideo { videoID = vidID, name = parsedLine[1], duration = int.Parse(parsedLine[2]) }; this.playlist.Add(TVideoEntry); break; //default playlist
                                        case 1: TVideoEntry = new TVideo { videoID = vidID }; this.playlist.Add(TVideoEntry); break; //only youtubeVideoId playlist
                                        default: Console.Write("Ignoring: Wrong line Format (" + parsedLine.Count.ToString() + " collumns)\r\n"); break; //error                                
                                    }
                                }
                                else
                                {
                                    Console.Write("Ignoring: invalid video ID \"" + (parsedLine.Count > 0 ? parseYTurl(parsedLine[0]) : "") + "\" \r\n");
                                }
                            }
                        }
                    }
                }
                this.updateCurrent();
            }

            public void removeVideoID(string videoId = "")
            {
                if (this.playlist.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(videoId))
                    {
                        videoId = this.playlist[this.current].videoID;
                    }
                    this.playlist.RemoveAll(TVideo => TVideo.videoID == videoId);
                    this.updateCurrent();
                }
            }

            public void updateCurrent()
            {
                if (this.playlist.Count > 0  && this.current >= this.playlist.Count)
                {
                    this.current = playlist.Count-1;
                }
            }

            public static string parseYTurl(string YTurl)
            {
                string videoId = "";
                Match match = Regex.Match(YTurl, @"(http.*?v=([a-z0-9_-]{8,13}))|([a-z0-9_-]{8,13})", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                if (match.Success)
                {
                    if (match.Groups[2].Success)
                    {
                        videoId = match.Groups[2].Captures[0].ToString();
                    }
                    else
                    {
                        videoId = match.Groups[3].Captures[0].ToString();
                    }
                }
                return videoId;
            }

            internal void clear()
            {
                this.playlist = new BindingList<TVideo>();
                this.current = 0;
            }
        }
        
        private void addInsertUrlMenuItem_Click(object sender, EventArgs e)
        {
            
            string value = "";

            if (InputBox.Show("Load video id", "&Enter youtube vidId:", ref value) == DialogResult.OK)
            {
                Console.Write("loadUrl: " + value);
                string vidID = TPlaylist.parseYTurl(value);
                if (string.IsNullOrWhiteSpace(vidID))
                {
                    MessageBox.Show("invalid URL or vidId");
                }
                else
                {
                    currentTPlaylist.playlist.Add(new TVideo { videoID = vidID });
                    currentTPlaylist.current = currentTPlaylist.playlist.Count - 1;
                    mediaLoadVideo(vidID);                    
                }
            }
            
        }

        private void loadPlaylistMenuItem_Click(object sender, EventArgs e)
        {
            currentTPlaylist.loadFromFile(true);
            playlistResults.DataSource = currentTPlaylist;
            mediaLoadVideo(currentTPlaylist.playlist[currentTPlaylist.current].videoID);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTPlaylist.saveToFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTPlaylist.saveToFile(true);
        }

        private void newPlaylistMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resSave = MessageBox.Show("Save", "Save current playlist " + currentTPlaylist.name + "?", MessageBoxButtons.YesNoCancel);
            switch (resSave){
                case DialogResult.Yes: currentTPlaylist.saveToFile(); break;
                case DialogResult.Cancel: return ; 
            }
            currentTPlaylist= new TPlaylist();
        }

        private void loopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loopPlaylist = loopToolStripMenuItem.Checked = !loopToolStripMenuItem.Checked;
        }

        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shuffle = shuffleToolStripMenuItem.Checked = !shuffleToolStripMenuItem.Checked;
        }

        private void removeFromPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTPlaylist.removeVideoID();
        }

        private void urlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = "";

            if (InputBox.Show("Load video id", "&Enter youtube vidId:", ref value) == DialogResult.OK)
            {
                Console.Write("loadUrl: " + value);
                string vidID = TPlaylist.parseYTurl(value);
                if (string.IsNullOrWhiteSpace(vidID))
                {
                    MessageBox.Show("invalid URL or vidId");
                }
                else
                {
                    currentTPlaylist.playlist.Add(new TVideo { videoID = vidID });
                }
            }
        }

        
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTPlaylist.clear();
        }

        private void playlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTPlaylist.loadFromFile(true, false);
            playlistResults.DataSource = typeof(List<string>);
            playlistResults.DataSource = currentTPlaylist.playlist;
            playlistResults.Refresh();
        }

        private void playToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            mediaLoadVideo(currentTPlaylist.playlist.ElementAtOrDefault(playlistResults.CurrentCell.RowIndex).videoID);
        }

        private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTPlaylist.removeVideoID(currentTPlaylist.playlist.ElementAtOrDefault(playlistResults.CurrentCell.RowIndex).videoID);
        }

        private void allToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            currentTPlaylist.playlist.Clear();
            currentTPlaylist.current = 0;
            currentTPlaylist.isPlaying = false;
        }


        delegate int PlaySongCallback(string text, out TVideo video);

        /// <summary>
        /// Queues a song for playing
        /// </summary>
        /// <param name="youtubeLink"></param>
        /// <returns>
        /// 0 - Success
        /// 1 - Invalid File
        /// 2 - Song too long
        /// </returns>
        public int QueueOrPlaySong(string youtubeLink, out TVideo video)
        {
            video = null;
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                PlaySongCallback d = new PlaySongCallback(QueueOrPlaySong);
                object[] args = new object[] {youtubeLink, video};
                int retVal = (int)this.Invoke(d, args);
                video = (TVideo)args[1];
                return retVal;
            }
            else
            {
                string vidID = TPlaylist.parseYTurl(youtubeLink);
                if (!string.IsNullOrWhiteSpace(vidID))
                {
                    video = new TVideo {videoID = vidID};
                    if (!GetVideoInfo(video))
                        return 1;

                    if (video.duration > 8*60)
                        return 2;
;
                    currentTPlaylist.playlist.Add(video);
                    if (!currentTPlaylist.isPlaying)
                    {
                        currentTPlaylist.current = currentTPlaylist.playlist.Count - 1;
                        mediaLoadVideo(vidID);
                    }
                }
                else return 1;
                return 0;
            }
        }

        delegate TVideo GetCurrentVideoCallback();

        public TVideo GetCurrentVideo()
        {
            if (this.textBox1.InvokeRequired)
            {
                GetCurrentVideoCallback d = new GetCurrentVideoCallback(GetCurrentVideo);
                return (TVideo)this.Invoke(d, null);
            }
            else
            {
                return currentlyPlayingVideo;
            }
        }
    }

    public static class BindingListExtensions
    {
        public static void RemoveAll<T>(this BindingList<T> list, Func<T, bool> predicate)
        {
            // first check predicates -- uses System.Linq
            // could collapse into the foreach, but still must use 
            // ToList() or ToArray() to avoid deferred execution                       
            var toRemove = list.Where(predicate).ToList();

            // then loop and remove after
            foreach (var item in toRemove)
            {
                list.Remove(item);
            }
        }
    }
}
