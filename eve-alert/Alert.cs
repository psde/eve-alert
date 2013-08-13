using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace evealert
{
    public delegate void AlertCallback(DateTime time, bool important, string title, string text);

    interface AlertInterface
    {
        void start();
        void stop();
        bool isStarted();
    }

    abstract class Alert : AlertInterface
    {
        public AlertCallback callback { get; set; }

        public Alert(AlertCallback callback)
        {
            this.callback = callback;
        }

        public abstract void start();
        public abstract void stop();
        public abstract bool isStarted();

        public void notify(DateTime time, bool important, string title, string text)
        {
            callback.BeginInvoke(DateTime.UtcNow, important, title, text, null, null);
        }
    }
}
