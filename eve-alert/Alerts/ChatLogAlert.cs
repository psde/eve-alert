using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Timers;
using System.Globalization;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using evealert.Alerts;

namespace evealert
{
    public class ChatLogAlert : Alert<ChatLogAlertFactory>
    {
        private System.Timers.Timer timer;
        private string directory;
        private string file;
        private DateTime lastTime;

        [DataMemberAttribute]
        public List<string> systems;

        [DataMemberAttribute]
        public string channel;

        internal ChatLogAlert() { }
        public ChatLogAlert(List<string> systems, string channel)
        {
            this.systems = systems;
            this.channel = channel;

            init();
        }

        protected override void init()
        {
            this.directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EVE\logs\Chatlogs\";
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public override string GetName()
        {
            return "Chat Log Alert";
        }

        public override string GetDescription()
        {
            return "#" + this.channel + ": " + String.Join(",", this.systems);
        }

        public override void start()
        {
            this.lastTime = DateTime.UtcNow - TimeSpan.FromMinutes(10);
            timer.Start();
        }

        public override void stop()
        {
            timer.Stop();
        }

        public override bool isStarted()
        {
            return timer.Enabled;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var sorted = Directory.GetFiles(directory).Where(f => new FileInfo(f).Name.StartsWith(this.channel)).OrderByDescending(f => new FileInfo(f).LastWriteTime);

            if (sorted.Count() == 0)
                return;

            string file = sorted.ElementAt(0);

            if (this.file != file)
            {
                this.file = file;
            }

            try
            {
                using(FileStream logFileStream = new FileStream(this.file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader logFileReader = new StreamReader(logFileStream))
                while (!logFileReader.EndOfStream)
                {
                    string line = logFileReader.ReadLine();
                    if (line.Count() <= 25 || line.IndexOf(">") == -1)
                        continue;

                    string dateLine = line.Substring(3, 19);
                    string sender = line.Substring(25, line.IndexOf(">") - 26);
                    string body = line.Substring(line.IndexOf(">")+2);

                    DateTime dateTime;

                    //[ 2013.07.08 22:23:45 ]
                    if (DateTime.TryParseExact(dateLine, "yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime) && dateTime > this.lastTime)
                    {
                        this.lastTime = dateTime;

                        foreach (string system in this.systems)
                        {
                            string abbrvSystem = system;
                            /*
                            if (system.Length >= 3)
                            {
                                abbrvSystem = system.Substring(0, system.IndexOf("-"));
                                if (abbrvSystem.Length <= 2)
                                {
                                    abbrvSystem = system.Substring(0, 2);
                                }
                            }*/
                            abbrvSystem = system.Substring(0, 3); //To me it seems like everyone's using the first 3 letters, no matter the dashes  --Bittey

                            string lowerBody = body.ToLower();

                            if (lowerBody.Contains(system.ToLower()) || StringIsolated(abbrvSystem.ToLower(),lowerBody))
                            {
                                if (Settings.StatusWords.Exists(x => lowerBody.Contains(x)))
                                {
                                    // Nothing
                                }
                                else if (Settings.ClearWords.Exists(x => lowerBody.Contains(x)))
                                {
                                    // System clear
                                    notify(dateTime, false, this.channel, system + ": " + sender + " > " + body);
                                }
                                else
                                {
                                    // Hostile?
                                    notify(dateTime, true, this.channel, system + ": " + sender + " > " + body);
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception exc)
            {
                timer.Stop();
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Returns true if substring is contained in line and is a seperate word.
        /// </summary>
        bool StringIsolated(string substring, string line)
        {
            if (line.StartsWith(substring + " "))
                return true;
            if (line.EndsWith(" " + substring))
                return true;
            if (line.Contains(" " + substring + " "))
                return true;
            return false; //if substring == line, it yields no information, so just ignore.
        }

    }

    public class ChatLogAlertFactory : AlertFactory<ChatLogAlert>
    {
        public override string GetName()
        {
            return "Chat Log Alert Factory";
        }

        public override AlertInterface Create(String charname)
        {
            ChatLogAlertForm form = new ChatLogAlertForm(new List<string>(), "");
            DialogResult result = form.ShowDialog();
            if (result != DialogResult.OK)
                return null;

            return new ChatLogAlert(form.getSystems(), form.getChannel());
        }

        public override AlertInterface Modify(AlertInterface original)
        {
            ChatLogAlert alert = (ChatLogAlert)original;
            ChatLogAlertForm form = new ChatLogAlertForm(alert.systems, alert.channel);
            DialogResult result = form.ShowDialog();
            if (result != DialogResult.OK)
                return original;

            return new ChatLogAlert(form.getSystems(), form.getChannel());
        }
    }
}
