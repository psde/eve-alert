using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace evealert
{
    public class Account
    {
        public string Charname { get; set; }

        public bool Enabled { get; set; }

        public List<AlertInterface> alertModules { get; set; }

        public Account()
        {
            Enabled = true;
            alertModules = new List<AlertInterface>();
        }

        public override string ToString()
        {
            return this.Charname;
        }
    }

    public enum NotificationPosition
    {
        TopLeft, TopRight, BottomLeft, BottomRight, Center
    }

    public class Settings
    {
        public NotificationPosition NotificationPosition { get; set; }
        public int NotificationFontSize { get; set; }
        public int NotificationOpacity { get; set; }
        public string SoundFileAttention { get; set; }
        public bool StartMinimized { get; set; }
        public bool StartStarted { get; set; }

        public List<Account> Accounts { get; set; }

        public Settings()
        {
            this.Accounts = new List<Account>();
            this.NotificationFontSize = 26;
            this.NotificationOpacity = 70;
        }

        static public void toXML(Settings settings, string path)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(Settings));
            
            using (var w = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
                ser.WriteObject(w, settings);
        }

        static public Settings fromXML(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Settings));

            // Deserialize the data and read it from the instance.
            Settings settings = (Settings)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            return settings;
        }
    }
}
