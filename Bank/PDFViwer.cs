using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;

namespace Bank
{
    public partial class PDFViwer : Form
    {
        public PDFViwer()
        {
            InitializeComponent();

            axAcroPDF1.src = JswDatatable.PdFPath;
            LblFileName.Text = JswDatatable.PdFPath.Split('\\')[JswDatatable.PdFPath.Split('\\').Count() - 1];
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            string download = string.Empty;
            string userPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            DirectoryInfo user = new DirectoryInfo(userPath);
            if (user.Exists)
            {
                // Identify the "%USERPROFILE%\Downloads" directory on Windows Vista, 7, 8 systems.
                DirectoryInfo downloads = new DirectoryInfo(user + @"\Downloads");
                if (downloads.Exists)
                {
                    // return the full path "C:\Users\USERNAME\Downloads"
                    download = downloads.FullName;
                }
                else
                {
                    // Couldn't find it, maybe they're on Windows XP
                    string xpDocs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    DirectoryInfo xpDownloads = new DirectoryInfo(xpDocs + @"\Downloads");
                    if (xpDownloads.Exists)
                    {
                        // return the full path "C:\Documents and Settings\USERNAME\My Documents\Downloads"
                        download = xpDownloads.FullName;
                    }
                    else
                    {
                        // Couldn't identify a "Downloads" directory in either location
                        throw new DirectoryNotFoundException("Cannot identify the users 'Downloads' directory.");
                    }
                }
            }



            if (File.Exists(download + "\\" + LblFileName.Text))
            {
                File.Delete(download + "\\" + LblFileName.Text);
            }
            File.Copy(JswDatatable.PdFPath, download + "\\" + LblFileName.Text);

            DialogResult ans = MessageBox.Show("File Downloaded at " + download + "\\" + LblFileName.Text + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(download + "\\" + LblFileName.Text);
            }
        }
    }
}
