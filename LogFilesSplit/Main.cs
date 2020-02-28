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

        public Main()
        {
            InitializeComponent();
            Text = Application.ProductName + " " + Application.ProductVersion;
            txtPath.Text= ConfigurationManager.AppSettings["path"];
            txtDateKeyWord.Text = ConfigurationManager.AppSettings["dateKeyWord"];
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo root = new DirectoryInfo(path);
                FileInfo[] files = root.GetFiles();
                barFiles.Value = 0;
                barFiles.Maximum = files.Length;
                foreach (FileInfo file in files)
                {
                    string f = file.Name;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
