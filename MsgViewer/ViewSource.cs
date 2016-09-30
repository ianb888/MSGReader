using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MsgViewer
{
    public partial class ViewSource : Form
    {
        public string pathToMessageSource = string.Empty;

        public ViewSource()
        {
            InitializeComponent();
        }

        private string GetTextFromFile()
        {
            string messageSource = string.Empty;

            FileInfo file = new FileInfo(pathToMessageSource);

            if (file.Exists)
            {
                Text = string.Format("{0} ({1} bytes)", file.Name, file.Length);
                toolStripStatusLabel1.Text = pathToMessageSource;
                messageSource = File.ReadAllText(pathToMessageSource);
            }
            else
            {
                Text = "Display Message Source";
                toolStripStatusLabel1.Text = "Unable to display message source.";
            }

            return messageSource;
        }

        private void ViewSource_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathToMessageSource))
            {
                textBox1.Text = GetTextFromFile();
            }
            ActiveControl = statusStrip1;
        }
    }
}