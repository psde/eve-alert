using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Timers;
using System.Globalization;

namespace evealert
{
    class LogAlert : Alert
    {
        private System.Timers.Timer timer;
        private string directory;
        private string file;
        private string channel;
        private DateTime lastTime;
        private List<string> systems;

        public LogAlert(AlertCallback callback, List<string> systems, string channel)
        : base(callback)
        {
            this.lastTime = DateTime.UtcNow - TimeSpan.FromMinutes(10);
            this.directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EVE\logs\Chatlogs\";
            this.systems = systems;
            this.channel = channel;

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public override void start()
        {
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
                            if (system.Length >= 3)
                            {
                                abbrvSystem = system.Substring(0, system.IndexOf("-"));
                                if (abbrvSystem.Length <= 2)
                                {
                                    abbrvSystem = system.Substring(0, 2);
                                }
                            }

                            string lowerBody = body.ToLower();

                            if (lowerBody.IndexOf(system.ToLower()) != -1 || lowerBody.IndexOf(" " + abbrvSystem.ToLower() + " ") != -1)
                            {
                                if (lowerBody.IndexOf("status") != -1)
                                {
                                    // Nothing
                                }
                                else if (lowerBody.IndexOf("clear") != -1 || lowerBody.IndexOf("clr") != -1)
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
    }
}
