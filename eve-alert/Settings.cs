using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace evealert
{
    public class Account
    {

        public string Charname { get; set; }
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

        // ...
        public List<string> SystemNames { get; set; }
        public string CharacterName { get; set; }
        public string IntelChannel { get; set; }

        // Not used yet
        public List<Account> Accounts { get; set; }

        static public void toXML(Settings settings, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextWriter textWriter = new StreamWriter(path);
            serializer.Serialize(textWriter, settings);
            textWriter.Close();
        }

        static public Settings fromXML(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Settings));
            TextReader textReader = new StreamReader(path);
            Settings settings = (Settings)deserializer.Deserialize(textReader);
            textReader.Close();
            return settings;
        }
    }
}
