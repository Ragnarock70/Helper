namespace MBox
{
    partial class Shortcut
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMasterKey = new System.Windows.Forms.TextBox();
            this.tbSlaveKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMasterKey
            // 
            this.tbMasterKey.Location = new System.Drawing.Point(14, 13);
            this.tbMasterKey.Name = "tbMasterKey";
            this.tbMasterKey.ReadOnly = true;
            this.tbMasterKey.Size = new System.Drawing.Size(80, 20);
            this.tbMasterKey.TabIndex = 0;
            this.tbMasterKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMasterKey_KeyDown);
            // 
            // tbSlaveKey
            // 
            this.tbSlaveKey.Location = new System.Drawing.Point(108, 13);
            this.tbSlaveKey.Name = "tbSlaveKey";
            this.tbSlaveKey.ReadOnly = true;
            this.tbSlaveKey.Size = new System.Drawing.Size(80, 20);
            this.tbSlaveKey.TabIndex = 1;
            this.tbSlaveKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSlaveKey_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = ">";
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.Location = new System.Drawing.Point(194, -3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(17, 18);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "˄";
            this.btnUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDown.Location = new System.Drawing.Point(194, 26);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(17, 20);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "˅";
            this.btnDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(194, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(17, 18);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Shortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSlaveKey);
            this.Controls.Add(this.tbMasterKey);
            this.Name = "Shortcut";
            this.Size = new System.Drawing.Size(211, 46);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMasterKey;
        private System.Windows.Forms.TextBox tbSlaveKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnDelete;
    }
}
