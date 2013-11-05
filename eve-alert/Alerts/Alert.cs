using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace evealert
{
    public delegate void AlertCallback(DateTime time, bool important, string title, string text);

    [KnownType(typeof(ChatLogAlert))]
    [KnownType(typeof(GameLogAlert))]
    public abstract class AlertInterface
    {
        public abstract void start();
        public abstract void stop();
        public abstract bool isStarted();
        public abstract string GetName();
        public abstract string GetDescription();
        public abstract AlertFactoryInterface getFactory();
        protected abstract void init();
    }

    public interface AlertFactoryInterface
    {
        string GetName();
        AlertInterface Create(String charname);
        AlertInterface Modify(AlertInterface original);
    }

    public abstract class AlertFactory<Alert> : AlertFactoryInterface
        where Alert : AlertInterface
    {
        public abstract string GetName();
        public abstract AlertInterface Create(String charname);
        public abstract AlertInterface Modify(AlertInterface original);
        public override string ToString()
        {
            return this.GetName();
        }
    }

    public abstract class Alert<T> : AlertInterface 
        where T : AlertFactoryInterface, new()
    {
        [IgnoreDataMember]
        [XmlIgnore]
        public static T factory = new T();

        public override AlertFactoryInterface getFactory()
        {
            return factory;
        }

        public Alert()
        {
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            init();
        }

        /*public override string ToString()
        {
            return Alert<T>.factory.GetName();
        }*/

        public void notify(DateTime time, bool important, string title, string text)
        {
            MainForm.alertCallback.BeginInvoke(DateTime.UtcNow, important, title, text, null, null);
        }
    }
}
