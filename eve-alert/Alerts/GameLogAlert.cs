using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using evealert.Alerts;

namespace evealert
{
    public class GameLogAlert : Alert<GameLogAlertFactory>
    {
        private System.Timers.Timer timer;
        private string directory;
        private string file;
        private DateTime lastTime;

        private DateTime lastHitToTime;
        private DateTime lastHitFromTime;

        private DateTime lastSpecialWordTime;

        [DataMemberAttribute]
        public List<string> specialWords;

        [DataMemberAttribute]
        public string characterName;

        internal GameLogAlert() { }
        public GameLogAlert(string characterName, List<string> specialWords)
        {
            this.characterName = characterName;
            this.specialWords = specialWords;

            init();
        }

        protected override void init()
        {
            this.directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EVE\logs\Gamelogs\";
            timer = new System.Timers.Timer(10000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public List<string> getKeywords()
        {
            return this.specialWords;
        }

        public string getCharacterName()
        {
            return this.characterName;
        }

        public override string GetName()
        {
            return "Game Log Alert";
        }

        public override string GetDescription()
        {
            return String.Join(",", this.specialWords);
        }

        public override void start()
        {
            this.lastTime = DateTime.UtcNow - TimeSpan.FromMinutes(10);
            this.lastHitToTime = DateTime.UtcNow - TimeSpan.FromMinutes(5);
            this.lastHitFromTime = DateTime.UtcNow - TimeSpan.FromMinutes(5);
            this.lastSpecialWordTime = DateTime.UtcNow - TimeSpan.FromMinutes(5);
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

        private bool parseFile(string file)
        {
            if (new FileInfo(file).LastWriteTime < DateTime.Now - TimeSpan.FromMinutes(10))
                return false;

            int i = 0;
            using (FileStream logFileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader logFileReader = new StreamReader(logFileStream))
            while (!logFileReader.EndOfStream)
            {
                i += 1;
                string line = logFileReader.ReadLine();

                if (i == 3)
                {
                    if(line.IndexOf("Listener: " + this.characterName) == -1)
                        return false;

                    if (this.file != file)
                    {
                        this.file = file;
                    }
                }

                if (line.Count() <= 25)
                    continue;

                string dateLine = line.Substring(2, 19);

                DateTime dateTime;

                //[ 2013.07.08 22:23:45 ]
                if (DateTime.TryParseExact(dateLine, "yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime) && dateTime > this.lastTime)
                {
                    this.lastTime = dateTime;
                    if (line.IndexOf("(combat)") != -1)
                    {
                        if (line.IndexOf("<font size=10>from</font>") != -1 || line.IndexOf("misses you completely") != -1)
                        {
                            this.lastHitFromTime = dateTime;
                        }

                        if (line.IndexOf("<font size=10>to</font>") != -1 || line.IndexOf("misses") != -1)
                        {
                            this.lastHitToTime = dateTime;
                        }

                        foreach (string word in specialWords)
                        {
                            if (line.IndexOf(word) != -1)
                            {
                                if (dateTime > this.lastSpecialWordTime)
                                {
                                    this.lastSpecialWordTime = dateTime + TimeSpan.FromSeconds(30);
                                    notify(dateTime, true, this.characterName, word + " on grid!");
                                }
                            }
                        }
                    }
                }

            }

            if(i <= 3)
                return false;

            return true;
        }

        private bool analyseFiles()
        {
            if (File.Exists(this.file) && parseFile(this.file))
                 return true;

            var sorted = Directory.GetFiles(directory).OrderByDescending(f => new FileInfo(f).LastWriteTime);

            foreach (string f in sorted)
            {
                if (new FileInfo(f).LastWriteTime < DateTime.Now - TimeSpan.FromMinutes(10))
                    return false;

                try
                {
                    if (parseFile(f))
                        return true;
                }
                catch (Exception exc)
                {
                    timer.Stop();
                    MessageBox.Show(exc.Message);
                }
            }

            return false;
        }

        private bool reported = false;
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (analyseFiles())
            {
                if (lastHitToTime < DateTime.UtcNow - TimeSpan.FromSeconds(40) && lastHitFromTime > DateTime.UtcNow - TimeSpan.FromSeconds(40))
                {
                    if(!reported)
                        notify(DateTime.UtcNow, true, this.characterName, "No damage incoming, but outgoing, lost aggro?");
                    reported = true;
                }
                else if (lastHitToTime < DateTime.UtcNow - TimeSpan.FromSeconds(25) || lastHitFromTime < DateTime.UtcNow - TimeSpan.FromSeconds(25))
                {
                    if (!reported)
                        notify(DateTime.UtcNow, true, this.characterName, "No damage incoming/outgoing, anom empty or dead?");
                    reported = true;
                }
                else
                {
                    reported = false;
                }
            }
        }
    }

    public class GameLogAlertFactory : AlertFactory<GameLogAlert>
    {
        public override string GetName()
        {
            return "Game Log Alert Factory";
        }

        public override AlertInterface Create(String charname)
        {
            GameLogAlertForm form = new GameLogAlertForm(new List<String>());
            DialogResult result = form.ShowDialog();
            if (result != DialogResult.OK)
                return null;

            return new GameLogAlert(charname, form.getKeywords());
        }

        public override AlertInterface Modify(AlertInterface original)
        {
            GameLogAlert alert = (GameLogAlert)original;
            GameLogAlertForm form = new GameLogAlertForm(alert.getKeywords());
            DialogResult result = form.ShowDialog();
            if (result != DialogResult.OK)
                return original;

            return new GameLogAlert(alert.getCharacterName(), form.getKeywords());
        }
    }
}
