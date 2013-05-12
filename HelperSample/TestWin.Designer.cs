namespace HelperSample
{
    partial class TestWin
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
            this.btnScrnShot = new System.Windows.Forms.Button();
            this.btnOpenGetPixel = new System.Windows.Forms.Button();
            this.btnBitBlt = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScrnShot
            // 
            this.btnScrnShot.Location = new System.Drawing.Point(33, 64);
            this.btnScrnShot.Name = "btnScrnShot";
            this.btnScrnShot.Size = new System.Drawing.Size(75, 23);
            this.btnScrnShot.TabIndex = 0;
            this.btnScrnShot.Text = "Screen Me !";
            this.btnScrnShot.UseVisualStyleBackColor = true;
            this.btnScrnShot.Click += new System.EventHandler(this.btnScrnShot_Click);
            // 
            // btnOpenGetPixel
            // 
            this.btnOpenGetPixel.Location = new System.Drawing.Point(33, 132);
            this.btnOpenGetPixel.Name = "btnOpenGetPixel";
            this.btnOpenGetPixel.Size = new System.Drawing.Size(75, 23);
            this.btnOpenGetPixel.TabIndex = 1;
            this.btnOpenGetPixel.Text = "w/ GetPixel";
            this.btnOpenGetPixel.UseVisualStyleBackColor = true;
            this.btnOpenGetPixel.Click += new System.EventHandler(this.btnOpenGetPixel_Click);
            // 
            // btnBitBlt
            // 
            this.btnBitBlt.Location = new System.Drawing.Point(114, 132);
            this.btnBitBlt.Name = "btnBitBlt";
            this.btnBitBlt.Size = new System.Drawing.Size(75, 23);
            this.btnBitBlt.TabIndex = 2;
            this.btnBitBlt.Text = "w/ BitBlt";
            this.btnBitBlt.UseVisualStyleBackColor = true;
            this.btnBitBlt.Click += new System.EventHandler(this.btnBitBlt_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(114, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "SearchTheRedDot";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // TestWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBitBlt);
            this.Controls.Add(this.btnOpenGetPixel);
            this.Controls.Add(this.btnScrnShot);
            this.Name = "TestWin";
            this.Text = "TestWin";
            this.Load += new System.EventHandler(this.TestWin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScrnShot;
        private System.Windows.Forms.Button btnOpenGetPixel;
        private System.Windows.Forms.Button btnBitBlt;
        private System.Windows.Forms.Button btnSearch;
    }
}