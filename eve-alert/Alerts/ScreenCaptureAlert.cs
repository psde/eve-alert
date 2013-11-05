using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Capture;
using Capture.Interface;
using System.Drawing;
using System.Timers;
using evealert.Alerts;
using System.Windows.Forms;

namespace evealert
{
    public class ScreenCaptureAlert : Alert<ChatLogAlertFactory>
    {
        private CaptureProcess captureProcess = null;
        private string characterName;
        private ScreenCaptureForm captureForm;
        private System.Timers.Timer timer;

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);
        private const uint WM_GETTEXT = 0x000D;

        static IEnumerable<IntPtr> EnumerateProcessWindowHandles(int processId)
        {
            var handles = new List<IntPtr>();
            try
            {
                foreach (ProcessThread thread in Process.GetProcessById(processId).Threads)
                    EnumThreadWindows(thread.Id,
                                        (hWnd, lParam) =>
                                        {
                                            handles.Add(hWnd);
                                            return true;
                                        }, IntPtr.Zero);
            }
            catch (Exception)
            { }
            return handles;
        }

        internal ScreenCaptureAlert() { }
        public ScreenCaptureAlert(string characterName)
        {
            this.characterName = characterName;

            init();
        }

        protected override void init()
        {
            this.captureForm = new ScreenCaptureForm(this);

            timer = new System.Timers.Timer(2000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        ~ScreenCaptureAlert()
        {
            this.captureForm = null;
            this.captureProcess = null;
        }

        private Process getProcess()
        {
            Process[] processes = Process.GetProcessesByName("ExeFile");
            foreach (Process process in processes)
            {
                foreach (var handle in EnumerateProcessWindowHandles(process.Id))
                {
                    StringBuilder message = new StringBuilder(1000);
                    SendMessage(handle, WM_GETTEXT, message.Capacity, message);
                    if (message.ToString().ToUpper() == "EVE - " + this.characterName.ToUpper())
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        public override string GetName()
        {
            return "Screen Capture Alert";
        }

        public override string GetDescription()
        {
            return "";
        }

        public override void start()
        {
            Process process = getProcess();

            if (process == null)
                return;

            CaptureConfig cc = new CaptureConfig()
            {
                Direct3DVersion = Direct3DVersion.AutoDetect,
                ShowOverlay = false
            };

            var captureInterface = new CaptureInterface();
            captureInterface.RemoteMessage += new MessageReceivedEvent(CaptureInterface_RemoteMessage);
            captureProcess = new CaptureProcess(process, cc, captureInterface);

            captureProcess.CaptureInterface.BeginGetScreenshot(new Rectangle(0, 0, 0, 0), new TimeSpan(0, 0, 1), Callback);
            captureForm.Show();

            timer.Start();
        }

        public override void stop()
        {
            timer.Stop();
            captureForm.Hide();
            captureProcess.CaptureInterface.Disconnect();
            captureProcess = null;
        }

        public override bool isStarted()
        {
            return captureProcess == null;
        }

        void CaptureInterface_RemoteMessage(MessageReceivedEventArgs message)
        {
            //MessageBox.Show(message.Message);
        }

        void Callback(IAsyncResult result)
        {
            Screenshot screenshot = captureProcess.CaptureInterface.EndGetScreenshot(result);
            
            try
            {
                //captureProcess.CaptureInterface.DisplayInGameText("Screenshot captured...");
                this.captureForm.showScreenshot(screenshot.CapturedBitmap.ToBitmap());
            }
            catch
            {
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            captureProcess.CaptureInterface.BeginGetScreenshot(new Rectangle(0, 0, 0, 0), new TimeSpan(0, 0, 1), Callback);
        }
    }

    public class ScreenCaptureAlertFactory : AlertFactory<ChatLogAlert>
    {
        public override string GetName()
        {
            return "Screen Capture Alert Factory";
        }

        public override AlertInterface Create(String charname)
        {
            ChatLogAlertForm form = new ChatLogAlertForm(new List<string>(), "");
            DialogResult result = form.ShowDialog();
            if (result != DialogResult.OK)
                return null;

            return new ScreenCaptureAlert(charname);
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
