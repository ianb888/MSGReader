namespace MsgViewer
{
    partial class ViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageEnglishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageFrenchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageGermanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageDutchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genereateHyperlinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PrintButton = new System.Windows.Forms.ToolStripButton();
            this.ForwardButton = new System.Windows.Forms.ToolStripButton();
            this.BackButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsTextButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.Name = "StatusLabel";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.FilesListBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Name = "panel2";
            // 
            // FilesListBox
            // 
            resources.ApplyResources(this.FilesListBox, "FilesListBox");
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.Name = "FilesListBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.genereateHyperlinksToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageEnglishMenuItem,
            this.LanguageFrenchMenuItem,
            this.LanguageGermanMenuItem,
            this.LanguageDutchMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // LanguageEnglishMenuItem
            // 
            resources.ApplyResources(this.LanguageEnglishMenuItem, "LanguageEnglishMenuItem");
            this.LanguageEnglishMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LanguageEnglishMenuItem.Name = "LanguageEnglishMenuItem";
            this.LanguageEnglishMenuItem.Click += new System.EventHandler(this.LanguageToolStripMenuItem_Click);
            // 
            // LanguageFrenchMenuItem
            // 
            resources.ApplyResources(this.LanguageFrenchMenuItem, "LanguageFrenchMenuItem");
            this.LanguageFrenchMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LanguageFrenchMenuItem.Name = "LanguageFrenchMenuItem";
            this.LanguageFrenchMenuItem.Click += new System.EventHandler(this.LanguageToolStripMenuItem_Click);
            // 
            // LanguageGermanMenuItem
            // 
            resources.ApplyResources(this.LanguageGermanMenuItem, "LanguageGermanMenuItem");
            this.LanguageGermanMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LanguageGermanMenuItem.Name = "LanguageGermanMenuItem";
            this.LanguageGermanMenuItem.Click += new System.EventHandler(this.LanguageToolStripMenuItem_Click);
            // 
            // LanguageDutchMenuItem
            // 
            resources.ApplyResources(this.LanguageDutchMenuItem, "LanguageDutchMenuItem");
            this.LanguageDutchMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LanguageDutchMenuItem.Name = "LanguageDutchMenuItem";
            this.LanguageDutchMenuItem.Click += new System.EventHandler(this.LanguageToolStripMenuItem_Click);
            // 
            // genereateHyperlinksToolStripMenuItem
            // 
            resources.ApplyResources(this.genereateHyperlinksToolStripMenuItem, "genereateHyperlinksToolStripMenuItem");
            this.genereateHyperlinksToolStripMenuItem.CheckOnClick = true;
            this.genereateHyperlinksToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.genereateHyperlinksToolStripMenuItem.Name = "genereateHyperlinksToolStripMenuItem";
            this.genereateHyperlinksToolStripMenuItem.Click += new System.EventHandler(this.GenereateHyperlinksToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated_1);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintButton,
            this.ForwardButton,
            this.BackButton,
            this.SaveAsTextButton});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // PrintButton
            // 
            resources.ApplyResources(this.PrintButton, "PrintButton");
            this.PrintButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ForwardButton
            // 
            resources.ApplyResources(this.ForwardButton, "ForwardButton");
            this.ForwardButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ForwardButton.Image = global::MsgViewer.Properties.Resources.ForwardIcon;
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click_1);
            // 
            // BackButton
            // 
            resources.ApplyResources(this.BackButton, "BackButton");
            this.BackButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BackButton.Image = global::MsgViewer.Properties.Resources.BackIcon;
            this.BackButton.Name = "BackButton";
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click_1);
            // 
            // SaveAsTextButton
            // 
            resources.ApplyResources(this.SaveAsTextButton, "SaveAsTextButton");
            this.SaveAsTextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsTextButton.Name = "SaveAsTextButton";
            this.SaveAsTextButton.Click += new System.EventHandler(this.SaveAsTextButton_Click);
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // ViewerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("WindowState", global::MsgViewer.Properties.Settings.Default, "WindowState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ViewerForm";
            this.WindowState = global::MsgViewer.Properties.Settings.Default.WindowState;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewerForm_FormClosed);
            this.Load += new System.EventHandler(this.ViewerForm_Load);
            this.Move += new System.EventHandler(this.ViewerForm_Move);
            this.Resize += new System.EventHandler(this.ViewerForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BackButton;
        private System.Windows.Forms.ToolStripButton ForwardButton;
        private System.Windows.Forms.ToolStripButton PrintButton;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripButton SaveAsTextButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageEnglishMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageFrenchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageGermanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageDutchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genereateHyperlinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

