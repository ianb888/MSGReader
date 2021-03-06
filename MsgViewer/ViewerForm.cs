﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MsgReader;
using MsgViewer.Helpers;
using MsgViewer.Properties;

/*
   Copyright 2013-2015 Kees van Spelde

   Licensed under The Code Project Open License (CPOL) 1.02;
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.codeproject.com/info/cpol10.aspx

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace MsgViewer
{
    public partial class ViewerForm : Form
    {
        #region Fields
        /// <summary>
        /// Used to track all the created temporary folders
        /// </summary>
        readonly List<string> _tempFolders = new List<string>();
        bool windowInitialized = false;
        string currentFileOpen = string.Empty;
        #endregion

        #region Form events
        public ViewerForm()
        {
            InitializeComponent();

            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            if (Settings.Default.WindowPosition != Rectangle.Empty && IsVisibleOnAnyScreen(Settings.Default.WindowPosition))
            {
                // First set the bounds
                StartPosition = FormStartPosition.Manual;
                DesktopBounds = Settings.Default.WindowPosition;

                // Next set the window state to the saved value (which could be Maximized)
                WindowState = Settings.Default.WindowState;
            }
            else
            {
                // This resets the upper left corner of the window to windows standards
                StartPosition = FormStartPosition.CenterScreen;

                // We can still apply the saved size
                if (Settings.Default.WindowPosition != Rectangle.Empty)
                {
                    Size = Settings.Default.WindowPosition.Size;
                }
            }

            windowInitialized = true;
        }

        private bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }
            return false;
        }

        // On a move or resize in Normal state, record the new values as they occur.
        // This solves the problem of closing the app when minimized or maximized.
        private void TrackWindowState()
        {
            // Don't record the window setup, otherwise we lose the persistent values!
            if (!windowInitialized) { return; }

            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowPosition = DesktopBounds;
                Settings.Default.Save();
            }
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {
            //WindowPlacement.SetPlacement(Handle, Settings.Default.Placement);

            Closing += ViewerForm_Closing;
            genereateHyperlinksToolStripMenuItem.Checked = Settings.Default.GenereateHyperLinks;
            SetCulture(Settings.Default.Language);

            // Check if there are any command line arguments, i.e. the user double-clicked on a .msg file.
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string fileNamePath = args[1];
                fileNamePath.Trim();

                // This is just a sanity check, but its always expected to be a valid filename and path.
                if (!string.IsNullOrEmpty(fileNamePath))
                {
                    FileInfo file = new FileInfo(fileNamePath);

                    // More sanity checking, make sure the file really exists.
                    if (file.Exists)
                    {
                        OpenFile(fileNamePath);
                    }
                }
            }
        }

        private void ViewerForm_Closing(object sender, EventArgs e)
        {
            foreach (var tempFolder in _tempFolders)
            {
                if (Directory.Exists(tempFolder))
                {
                    Directory.Delete(tempFolder, true);
                }
            }
        }

        private void ViewerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Settings.Default.Placement = WindowPlacement.GetPlacement(Handle);

            // Only save the WindowState if Normal or Maximized
            switch (WindowState)
            {
                case FormWindowState.Normal:
                case FormWindowState.Maximized:
                    Settings.Default.WindowState = WindowState;
                    break;
                default:
                    Settings.Default.WindowState = FormWindowState.Normal;
                    break;
            }
            Settings.Default.Save();
        }

        private void ViewerForm_Move(object sender, EventArgs e)
        {
            TrackWindowState();
        }

        private void ViewerForm_Resize(object sender, EventArgs e)
        {
            TrackWindowState();
        }
#endregion

#region GetTemporaryFolder
        /// <summary>
        /// Creates a temporary folder name.
        /// </summary>
        /// <returns>Returns the full path of the newly created temporary directory.</returns>
        private static string GetTemporaryFolder()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
#endregion

#region WebBrowser events
        private void BackButton_Click_1(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void ForwardButton_Click_1(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }

        private void webBrowser1_Navigated_1(object sender, WebBrowserNavigatedEventArgs e)
        {
            StatusLabel.Text = e.Url.ToString();
            BackButton.Enabled = webBrowser1.CanGoBack;
            ForwardButton.Enabled = webBrowser1.CanGoForward;
        }
#endregion

#region SaveAsTextButton_Click
        private void SaveAsTextButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the save file dialog box.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                // ReSharper disable once LocalizableElement
                Filter = "TXT Files (.txt)|*.txt",
                FilterIndex = 1
            };

            if (Directory.Exists(Settings.Default.SaveDirectory))
            {
                saveFileDialog1.InitialDirectory = Settings.Default.SaveDirectory;
            }

            // Process input if the user clicked OK.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SaveDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);
                Settings.Default.Save();

                HtmlToText htmlToText = new HtmlToText();
                string text = htmlToText.Convert(webBrowser1.DocumentText);
                File.WriteAllText(saveFileDialog1.FileName, text);
            }
        }
#endregion

#region openToolStripMenuItem_Click
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            var openFileDialog1 = new OpenFileDialog
            {
                // ReSharper disable once LocalizableElement
                Filter = "Email Message|*.msg;*.eml",
                FilterIndex = 1,
                Multiselect = false
            };

            if (Directory.Exists(Settings.Default.InitialDirectory))
            {
                openFileDialog1.InitialDirectory = Settings.Default.InitialDirectory;
            }

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
                Settings.Default.Save();
                OpenFile(openFileDialog1.FileName);
            }
        }
#endregion

#region printToolStripMenuItem_Click
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
#endregion

#region exitToolStripMenuItem_Click
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
#endregion

#region OpenFile
        /// <summary>
        /// Opens the selected MSG of EML file
        /// </summary>
        /// <param name="fileName">The path and name of the file to open.</param>
        private void OpenFile(string fileName)
        {
            // Open the selected file to read.
            string tempFolder = null;

            try
            {
                tempFolder = GetTemporaryFolder();
                _tempFolders.Add(tempFolder);

                Reader msgReader = new Reader();
                string[] files = msgReader.ExtractToFolder(fileName, tempFolder, genereateHyperlinksToolStripMenuItem.Checked);
                string error = msgReader.GetErrorMessage();

                if (!string.IsNullOrEmpty(error))
                {
                    throw new Exception(error);
                }

                if (!string.IsNullOrEmpty(files[0]))
                {
                    webBrowser1.Navigate(files[0]);
                }

                FilesListBox.Items.Clear();

                foreach (string file in files)
                {
                    FilesListBox.Items.Add(file);
                }

                currentFileOpen = fileName;
            }
            catch (Exception ex)
            {
                currentFileOpen = string.Empty;

                if (!string.IsNullOrWhiteSpace(tempFolder) && Directory.Exists(tempFolder))
                {
                    Directory.Delete(tempFolder, true);
                }

                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endregion

#region GenereateHyperlinksToolStripMenuItem_Click
        private void GenereateHyperlinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (genereateHyperlinksToolStripMenuItem.Checked)
            {
                genereateHyperlinksToolStripMenuItem.Checked = true;
                Settings.Default.GenereateHyperLinks = true;
            }
            else
            {
                genereateHyperlinksToolStripMenuItem.Checked = false;
                Settings.Default.GenereateHyperLinks = false;
            }
            Settings.Default.Save();
        }
#endregion

#region LanguageToolStripMenuItem_Click
        private void LanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == LanguageEnglishMenuItem)
            {
                Settings.Default.Language = 1;
            }
            else
            {
                if (sender == LanguageFrenchMenuItem)
                {
                    Settings.Default.Language = 2;
                }
                else
                {
                    if (sender == LanguageGermanMenuItem)
                    {
                        Settings.Default.Language = 3;
                    }
                    else
                    {
                        if (sender == LanguageDutchMenuItem)
                        {
                            Settings.Default.Language = 4;
                        }
                    }
                }
            }
            SetCulture(Settings.Default.Language);
            Settings.Default.Save();
        }
#endregion

#region SetCulture
        /// <summary>
        /// Sets the culture
        /// </summary>
        /// <param name="culture"></param>
        private void SetCulture(int culture)
        {
            LanguageEnglishMenuItem.Checked = false;
            LanguageFrenchMenuItem.Checked = false;
            LanguageGermanMenuItem.Checked = false;
            LanguageDutchMenuItem.Checked = false;

            switch (culture)
            {
                case 1:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    LanguageEnglishMenuItem.Checked = true;
                    break;
                case 2:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                    LanguageFrenchMenuItem.Checked = true;
                    break;
                case 3:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
                    LanguageGermanMenuItem.Checked = true;
                    break;
                case 4:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("nl-NL");
                    LanguageDutchMenuItem.Checked = true;
                    break;
            }
        }
#endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void viewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSource viewSource = new ViewSource();
            viewSource.pathToMessageSource = currentFileOpen;
            viewSource.Show();
        }
    }
}