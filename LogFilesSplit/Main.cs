using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.IO;

namespace LogFilesSplit
{
    public partial class Main : Form
    {
        string path
        {
            get
            {
                if (txtPath.Text.LastIndexOf('1') + 1 != txtPath.Text.Length)
                    return txtPath.Text + "\\";
                else
                    return txtPath.Text;
            }
        }

        string dateFormat
        {
            get { return txtDateKeyWord.Text; }
        }

        DateTime oneOClock;
        public Main()
        {
            InitializeComponent();
            Text = Application.ProductName + " " + Application.ProductVersion;
            txtPath.Text= ConfigurationManager.AppSettings["path"];
            txtDateKeyWord.Text = ConfigurationManager.AppSettings["dateKeyWord"];
            
            #region 定时执行
            string[] settingTime = ConfigurationManager.AppSettings["dailyRun"].Split(':');
            int H = Convert.ToUInt16(settingTime[0]);
            int M = Convert.ToUInt16(settingTime[1]);
            int S = Convert.ToUInt16(settingTime[2]);
            oneOClock = DateTime.Today.AddHours(H).AddMinutes(M).AddSeconds(S);
            SetTaskAtFixedTime();
            #endregion
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string f = "";
            try
            {
                DirectoryInfo root = new DirectoryInfo(path);
                FileInfo[] files = root.GetFiles();
                barFiles.Value = 0;
                barFiles.Maximum = files.Length;
                foreach (FileInfo file in files)
                {
                    f = file.Name;

                    for (int i = 0; i <= f.Length - dateFormat.Length; i++)
                    {
                        string dateStr = f.Substring(i, dateFormat.Length);
                        try { Convert.ToDateTime(dateStr); }
                        catch { continue; }

                        if (!Directory.Exists(path + dateStr))
                            Directory.CreateDirectory(path + dateStr);

                        string destDirName = path + dateStr + "\\" + f.Substring(0, i - 1) + "\\";
                        if (!Directory.Exists(destDirName))
                            Directory.CreateDirectory(destDirName);

                        Directory.Move(file.FullName, destDirName + f);
                        break;
                    }
                    barFiles.Value++;
                }
                dtpLastRun.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(f + "\r\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SetTaskAtFixedTime()
        {
            DateTime now = DateTime.Now;
            if (now > oneOClock)
            {
                oneOClock = oneOClock.AddDays(1);
                //oneOClock = oneOClock.AddSeconds(10);
            }
            int msUntilFour = (int)((oneOClock - now).TotalMilliseconds);

            var t = new System.Threading.Timer(DoAtTime);
            t.Change(msUntilFour, System.Threading.Timeout.Infinite);
        }

        //要执行的任务
        void DoAtTime(object state)
        {
            //System.InvalidOperationException:“线程间操作无效: 从不是创建控件“TxtTotal
            Invoke(new Action(() =>
            {
                btnRun_Click(new object(), new EventArgs());
            }));
            //再次设定下一次定时
            SetTaskAtFixedTime();
        }
    }
}
