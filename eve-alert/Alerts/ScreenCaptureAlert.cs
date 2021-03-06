﻿using System;
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
using System.Runtime.Serialization;

namespace evealert
{
    public class ScreenCaptureAlert : Alert<ScreenCaptureAlertFactory>
    {
        private CaptureProcess captureProcess = null;
        private ScreenCaptureForm captureForm;
        private System.Timers.Timer timer;

        [DataMemberAttribute]
        public string characterName;

        [DataMemberAttribute]
        public Rectangle selectedRegion;

        [DataMemberAttribute]
        public int opacity;

        [DataMemberAttribute]
        public bool borderless;

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
            this.selectedRegion = new Rectangle(0, 0, 0, 0);
            this.opacity = 100;
            this.borderless = false;

            init();
        }

        protected override void init()
        {
            this.captureForm = new ScreenCaptureForm(this);
            this.captureForm.setOpacity(this.opacity);
            this.captureForm.setBorderless(this.borderless);

            timer = new System.Timers.Timer(2000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        ~ScreenCaptureAlert()
        {
            this.captureForm = null;
            this.captureProcess = null;
        }

        public void setSelectedRetion(Rectangle rect)
        {
            this.selectedRegion = rect;
            this.OnTimedEvent(null, null);
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
                Direct3DVersion = Direct3DVersion.Direct3D9,
                ShowOverlay = false
            };

            var captureInterface = new CaptureInterface();
            captureInterface.RemoteMessage += new MessageReceivedEvent(CaptureInterface_RemoteMessage);
            captureProcess = new CaptureProcess(process, cc, captureInterface);

            captureProcess.CaptureInterface.BeginGetScreenshot(this.selectedRegion, new TimeSpan(0, 0, 1), Callback);
            captureForm.Show();

            timer.Start();
        }

        public override void stop()
        {
            timer.Stop();
            captureForm.Hide();
            if(captureProcess != null)
                captureProcess.CaptureInterface.Disconnect();
            captureProcess = null;
        }

        public override bool isStarted()
        {
            return captureProcess == null;
        }

        public void setOpacity(int o)
        {
            this.opacity = o;
            this.captureForm.setOpacity(this.opacity);
        }

        public void setBorderless(bool b)
        {
            this.borderless = b;
            this.captureForm.setBorderless(this.borderless);
        }

        void CaptureInterface_RemoteMessage(MessageReceivedEventArgs message)
        {
            //MessageBox.Show(message.Message);
        }

        void Callback(IAsyncResult result)
        {
            if (captureProcess == null)
                return;

            Screenshot screenshot = captureProcess.CaptureInterface.EndGetScreenshot(result);
            
            try
            {
                captureProcess.CaptureInterface.DisplayInGameText("Screenshot captured...");
                this.captureForm.showScreenshot(screenshot.CapturedBitmap.ToBitmap());
            }
            catch
            {
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            captureProcess.CaptureInterface.BeginGetScreenshot(this.selectedRegion, new TimeSpan(0, 0, 1), Callback);
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
            //ChatLogAlertForm form = new ChatLogAlertForm(new List<string>(), "");
            //DialogResult result = form.ShowDialog();
            //if (result != DialogResult.OK)
            //    return null;

            return new ScreenCaptureAlert(charname);
        }

        public override AlertInterface Modify(AlertInterface original)
        {
            return original;
            //ChatLogAlert alert = (ChatLogAlert)original;
            //ChatLogAlertForm form = new ChatLogAlertForm(alert.systems, alert.channel);
            //DialogResult result = form.ShowDialog();
            //if (result != DialogResult.OK)
            //    return original;

            //return new ChatLogAlert(form.getSystems(), form.getChannel());
        }
    }
}
