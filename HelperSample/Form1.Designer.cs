﻿namespace HelperSample
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
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.btnKBHook = new System.Windows.Forms.Button();
            this.btnMouseHook = new System.Windows.Forms.Button();
            this.btnFindHandle = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(562, 457);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            this.rtbOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbOutput_KeyPress);
            // 
            // btnKBHook
            // 
            this.btnKBHook.Location = new System.Drawing.Point(12, 463);
            this.btnKBHook.Name = "btnKBHook";
            this.btnKBHook.Size = new System.Drawing.Size(103, 23);
            this.btnKBHook.TabIndex = 1;
            this.btnKBHook.Text = "On/Off KB Hook";
            this.btnKBHook.UseVisualStyleBackColor = true;
            this.btnKBHook.Click += new System.EventHandler(this.btnKBHook_Click);
            // 
            // btnMouseHook
            // 
            this.btnMouseHook.Location = new System.Drawing.Point(121, 463);
            this.btnMouseHook.Name = "btnMouseHook";
            this.btnMouseHook.Size = new System.Drawing.Size(113, 23);
            this.btnMouseHook.TabIndex = 2;
            this.btnMouseHook.Text = "On/Off Mouse Hook";
            this.btnMouseHook.UseVisualStyleBackColor = true;
            this.btnMouseHook.Click += new System.EventHandler(this.btnMouseHook_Click);
            // 
            // btnFindHandle
            // 
            this.btnFindHandle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindHandle.Location = new System.Drawing.Point(378, 463);
            this.btnFindHandle.Name = "btnFindHandle";
            this.btnFindHandle.Size = new System.Drawing.Size(156, 23);
            this.btnFindHandle.TabIndex = 5;
            this.btnFindHandle.Text = "Find handle to send keys";
            this.btnFindHandle.UseVisualStyleBackColor = true;
            this.btnFindHandle.Click += new System.EventHandler(this.btnFindHandle_Click);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenshot.Location = new System.Drawing.Point(266, 463);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(78, 23);
            this.btnScreenshot.TabIndex = 6;
            this.btnScreenshot.Text = "Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 498);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.btnFindHandle);
            this.Controls.Add(this.btnMouseHook);
            this.Controls.Add(this.btnKBHook);
            this.Controls.Add(this.rtbOutput);
            this.MinimumSize = new System.Drawing.Size(578, 536);
            this.Name = "Form1";
            this.Text = "Helper Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button btnKBHook;
        private System.Windows.Forms.Button btnMouseHook;
        private System.Windows.Forms.Button btnFindHandle;
        private System.Windows.Forms.Button btnScreenshot;
    }
}

