namespace MBox
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMainWindow = new System.Windows.Forms.Button();
            this.btnSecondaryWindow = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.rbKeyboard = new System.Windows.Forms.RadioButton();
            this.groupBox1gbDevices = new System.Windows.Forms.GroupBox();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbMouse = new System.Windows.Forms.RadioButton();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbSlaves = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTransferAll = new System.Windows.Forms.RadioButton();
            this.rbTransferShortcuts = new System.Windows.Forms.RadioButton();
            this.gbQOTD = new System.Windows.Forms.GroupBox();
            this.rbQOTDFrench = new System.Windows.Forms.RadioButton();
            this.rbQOTDEnglish = new System.Windows.Forms.RadioButton();
            this.rbQOTDNope = new System.Windows.Forms.RadioButton();
            this.cbDebugLog = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flpShortcuts = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddShortcut = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.llEmail = new System.Windows.Forms.LinkLabel();
            this.lEmail = new System.Windows.Forms.Label();
            this.lCredits2 = new System.Windows.Forms.Label();
            this.lCredits1 = new System.Windows.Forms.Label();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.rltbOutput = new MBox.RichLogTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1gbDevices.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbQOTD.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flpShortcuts.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMainWindow
            // 
            this.btnMainWindow.Location = new System.Drawing.Point(46, 47);
            this.btnMainWindow.Name = "btnMainWindow";
            this.btnMainWindow.Size = new System.Drawing.Size(155, 23);
            this.btnMainWindow.TabIndex = 1;
            this.btnMainWindow.Text = "Chose Master Window";
            this.btnMainWindow.UseVisualStyleBackColor = true;
            this.btnMainWindow.Click += new System.EventHandler(this.btnMainWindow_Click);
            // 
            // btnSecondaryWindow
            // 
            this.btnSecondaryWindow.Enabled = false;
            this.btnSecondaryWindow.Location = new System.Drawing.Point(46, 76);
            this.btnSecondaryWindow.Name = "btnSecondaryWindow";
            this.btnSecondaryWindow.Size = new System.Drawing.Size(155, 23);
            this.btnSecondaryWindow.TabIndex = 2;
            this.btnSecondaryWindow.Text = "Chose Slave Window";
            this.btnSecondaryWindow.UseVisualStyleBackColor = true;
            this.btnSecondaryWindow.Click += new System.EventHandler(this.btnSecondaryWindow_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(86, 131);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rbKeyboard
            // 
            this.rbKeyboard.AutoSize = true;
            this.rbKeyboard.Location = new System.Drawing.Point(12, 19);
            this.rbKeyboard.Name = "rbKeyboard";
            this.rbKeyboard.Size = new System.Drawing.Size(70, 17);
            this.rbKeyboard.TabIndex = 5;
            this.rbKeyboard.Text = "Keyboard";
            this.rbKeyboard.UseVisualStyleBackColor = true;
            this.rbKeyboard.CheckedChanged += new System.EventHandler(this.rbKeyboard_CheckedChanged);
            // 
            // groupBox1gbDevices
            // 
            this.groupBox1gbDevices.Controls.Add(this.rbBoth);
            this.groupBox1gbDevices.Controls.Add(this.rbMouse);
            this.groupBox1gbDevices.Controls.Add(this.rbKeyboard);
            this.groupBox1gbDevices.Location = new System.Drawing.Point(16, 15);
            this.groupBox1gbDevices.Name = "groupBox1gbDevices";
            this.groupBox1gbDevices.Size = new System.Drawing.Size(101, 89);
            this.groupBox1gbDevices.TabIndex = 6;
            this.groupBox1gbDevices.TabStop = false;
            this.groupBox1gbDevices.Text = "Devices hooked";
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Checked = true;
            this.rbBoth.Location = new System.Drawing.Point(12, 65);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(47, 17);
            this.rbBoth.TabIndex = 7;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            this.rbBoth.CheckedChanged += new System.EventHandler(this.rbBoth_CheckedChanged);
            // 
            // rbMouse
            // 
            this.rbMouse.AutoSize = true;
            this.rbMouse.Location = new System.Drawing.Point(12, 42);
            this.rbMouse.Name = "rbMouse";
            this.rbMouse.Size = new System.Drawing.Size(57, 17);
            this.rbMouse.TabIndex = 6;
            this.rbMouse.Text = "Mouse";
            this.rbMouse.UseVisualStyleBackColor = true;
            this.rbMouse.CheckedChanged += new System.EventHandler(this.rbMouse_CheckedChanged);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(678, 340);
            this.tcMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.lbSlaves);
            this.tabPage1.Controls.Add(this.btnMainWindow);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.btnSecondaryWindow);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(670, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbSlaves
            // 
            this.lbSlaves.FormattingEnabled = true;
            this.lbSlaves.Location = new System.Drawing.Point(263, 47);
            this.lbSlaves.Name = "lbSlaves";
            this.lbSlaves.Size = new System.Drawing.Size(210, 95);
            this.lbSlaves.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.gbQOTD);
            this.tabPage2.Controls.Add(this.cbDebugLog);
            this.tabPage2.Controls.Add(this.groupBox1gbDevices);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(670, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTransferAll);
            this.groupBox1.Controls.Add(this.rbTransferShortcuts);
            this.groupBox1.Location = new System.Drawing.Point(309, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 89);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shortcuts";
            // 
            // rbTransferAll
            // 
            this.rbTransferAll.AutoSize = true;
            this.rbTransferAll.Location = new System.Drawing.Point(10, 42);
            this.rbTransferAll.Name = "rbTransferAll";
            this.rbTransferAll.Size = new System.Drawing.Size(102, 17);
            this.rbTransferAll.TabIndex = 10;
            this.rbTransferAll.Text = "Transfer all keys";
            this.rbTransferAll.UseVisualStyleBackColor = true;
            this.rbTransferAll.CheckedChanged += new System.EventHandler(this.rbTransferAll_CheckedChanged);
            // 
            // rbTransferShortcuts
            // 
            this.rbTransferShortcuts.AutoSize = true;
            this.rbTransferShortcuts.Checked = true;
            this.rbTransferShortcuts.Location = new System.Drawing.Point(10, 19);
            this.rbTransferShortcuts.Name = "rbTransferShortcuts";
            this.rbTransferShortcuts.Size = new System.Drawing.Size(132, 17);
            this.rbTransferShortcuts.TabIndex = 9;
            this.rbTransferShortcuts.TabStop = true;
            this.rbTransferShortcuts.Text = "Transfer only shortcuts";
            this.rbTransferShortcuts.UseVisualStyleBackColor = true;
            this.rbTransferShortcuts.CheckedChanged += new System.EventHandler(this.rbTransferShortcuts_CheckedChanged);
            // 
            // gbQOTD
            // 
            this.gbQOTD.Controls.Add(this.rbQOTDFrench);
            this.gbQOTD.Controls.Add(this.rbQOTDEnglish);
            this.gbQOTD.Controls.Add(this.rbQOTDNope);
            this.gbQOTD.Location = new System.Drawing.Point(123, 15);
            this.gbQOTD.Name = "gbQOTD";
            this.gbQOTD.Size = new System.Drawing.Size(180, 89);
            this.gbQOTD.TabIndex = 8;
            this.gbQOTD.TabStop = false;
            this.gbQOTD.Text = "Quote of the day";
            // 
            // rbQOTDFrench
            // 
            this.rbQOTDFrench.AutoSize = true;
            this.rbQOTDFrench.Location = new System.Drawing.Point(12, 65);
            this.rbQOTDFrench.Name = "rbQOTDFrench";
            this.rbQOTDFrench.Size = new System.Drawing.Size(127, 17);
            this.rbQOTDFrench.TabIndex = 10;
            this.rbQOTDFrench.Text = "Français s\'il vous plait";
            this.rbQOTDFrench.UseVisualStyleBackColor = true;
            this.rbQOTDFrench.CheckedChanged += new System.EventHandler(this.rbQOTDFrench_CheckedChanged);
            // 
            // rbQOTDEnglish
            // 
            this.rbQOTDEnglish.AutoSize = true;
            this.rbQOTDEnglish.Checked = true;
            this.rbQOTDEnglish.Location = new System.Drawing.Point(12, 42);
            this.rbQOTDEnglish.Name = "rbQOTDEnglish";
            this.rbQOTDEnglish.Size = new System.Drawing.Size(85, 17);
            this.rbQOTDEnglish.TabIndex = 9;
            this.rbQOTDEnglish.TabStop = true;
            this.rbQOTDEnglish.Text = "In english Sir";
            this.rbQOTDEnglish.UseVisualStyleBackColor = true;
            this.rbQOTDEnglish.CheckedChanged += new System.EventHandler(this.rbQOTDEnglish_CheckedChanged);
            // 
            // rbQOTDNope
            // 
            this.rbQOTDNope.AutoSize = true;
            this.rbQOTDNope.Location = new System.Drawing.Point(12, 19);
            this.rbQOTDNope.Name = "rbQOTDNope";
            this.rbQOTDNope.Size = new System.Drawing.Size(161, 17);
            this.rbQOTDNope.TabIndex = 8;
            this.rbQOTDNope.Text = "GTFO with your stupid things";
            this.rbQOTDNope.UseVisualStyleBackColor = true;
            this.rbQOTDNope.CheckedChanged += new System.EventHandler(this.rbQOTDNope_CheckedChanged);
            // 
            // cbDebugLog
            // 
            this.cbDebugLog.AutoSize = true;
            this.cbDebugLog.Checked = true;
            this.cbDebugLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDebugLog.Location = new System.Drawing.Point(16, 120);
            this.cbDebugLog.Name = "cbDebugLog";
            this.cbDebugLog.Size = new System.Drawing.Size(131, 17);
            this.cbDebugLog.TabIndex = 7;
            this.cbDebugLog.Text = "Show debug message";
            this.cbDebugLog.UseVisualStyleBackColor = true;
            this.cbDebugLog.CheckedChanged += new System.EventHandler(this.cbDebugLog_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flpShortcuts);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(670, 314);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Shortcuts";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flpShortcuts
            // 
            this.flpShortcuts.AutoScroll = true;
            this.flpShortcuts.Controls.Add(this.btnAddShortcut);
            this.flpShortcuts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpShortcuts.Location = new System.Drawing.Point(0, 3);
            this.flpShortcuts.Name = "flpShortcuts";
            this.flpShortcuts.Size = new System.Drawing.Size(670, 311);
            this.flpShortcuts.TabIndex = 0;
            // 
            // btnAddShortcut
            // 
            this.btnAddShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddShortcut.Location = new System.Drawing.Point(3, 3);
            this.btnAddShortcut.Name = "btnAddShortcut";
            this.btnAddShortcut.Size = new System.Drawing.Size(211, 46);
            this.btnAddShortcut.TabIndex = 0;
            this.btnAddShortcut.Text = "Add shortcut";
            this.btnAddShortcut.UseVisualStyleBackColor = true;
            this.btnAddShortcut.Click += new System.EventHandler(this.btnAddShortcut_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.llEmail);
            this.tabPage3.Controls.Add(this.lEmail);
            this.tabPage3.Controls.Add(this.lCredits2);
            this.tabPage3.Controls.Add(this.lCredits1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(670, 314);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(577, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "© Ragnarock";
            // 
            // llEmail
            // 
            this.llEmail.AutoSize = true;
            this.llEmail.Location = new System.Drawing.Point(450, 286);
            this.llEmail.Name = "llEmail";
            this.llEmail.Size = new System.Drawing.Size(99, 13);
            this.llEmail.TabIndex = 3;
            this.llEmail.TabStop = true;
            this.llEmail.Text = "mbox@hotmail.com";
            this.llEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEmail_LinkClicked);
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Location = new System.Drawing.Point(107, 286);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(346, 13);
            this.lEmail.TabIndex = 2;
            this.lEmail.Text = "Any suggestion ? Review ? Criticism ? Or just want to talk ? E-mail me at";
            // 
            // lCredits2
            // 
            this.lCredits2.AutoSize = true;
            this.lCredits2.Font = new System.Drawing.Font("Microsoft Sans Serif", 74F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCredits2.Location = new System.Drawing.Point(238, 101);
            this.lCredits2.Name = "lCredits2";
            this.lCredits2.Size = new System.Drawing.Size(196, 113);
            this.lCredits2.TabIndex = 1;
            this.lCredits2.Text = "ME";
            // 
            // lCredits1
            // 
            this.lCredits1.AutoSize = true;
            this.lCredits1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCredits1.Location = new System.Drawing.Point(146, 16);
            this.lCredits1.Name = "lCredits1";
            this.lCredits1.Size = new System.Drawing.Size(389, 55);
            this.lCredits1.TabIndex = 0;
            this.lCredits1.Text = "All credits go to...";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(678, 24);
            this.menuMain.TabIndex = 8;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miQuit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // miQuit
            // 
            this.miQuit.Name = "miQuit";
            this.miQuit.Size = new System.Drawing.Size(97, 22);
            this.miQuit.Text = "&Quit";
            this.miQuit.Click += new System.EventHandler(this.miQuit_Click);
            // 
            // rltbOutput
            // 
            this.rltbOutput.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rltbOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rltbOutput.Location = new System.Drawing.Point(0, 364);
            this.rltbOutput.Name = "rltbOutput";
            this.rltbOutput.ReadOnly = true;
            this.rltbOutput.ShowDebugMessages = false;
            this.rltbOutput.Size = new System.Drawing.Size(678, 185);
            this.rltbOutput.TabIndex = 0;
            this.rltbOutput.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(294, 189);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(117, 55);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Open test form";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 549);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.rltbOutput);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "Form1";
            this.Text = "MBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1gbDevices.ResumeLayout(false);
            this.groupBox1gbDevices.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbQOTD.ResumeLayout(false);
            this.gbQOTD.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.flpShortcuts.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichLogTextBox rltbOutput;
        private System.Windows.Forms.Button btnMainWindow;
        private System.Windows.Forms.Button btnSecondaryWindow;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rbKeyboard;
        private System.Windows.Forms.GroupBox groupBox1gbDevices;
        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbMouse;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbDebugLog;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miQuit;
        private System.Windows.Forms.GroupBox gbQOTD;
        private System.Windows.Forms.RadioButton rbQOTDFrench;
        private System.Windows.Forms.RadioButton rbQOTDEnglish;
        private System.Windows.Forms.RadioButton rbQOTDNope;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lCredits1;
        private System.Windows.Forms.Label lCredits2;
        private System.Windows.Forms.LinkLabel llEmail;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lbSlaves;
        private System.Windows.Forms.FlowLayoutPanel flpShortcuts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTransferAll;
        private System.Windows.Forms.RadioButton rbTransferShortcuts;
        private System.Windows.Forms.Button btnAddShortcut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTest;

    }
}

