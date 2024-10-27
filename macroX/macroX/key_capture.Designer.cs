namespace macroX
{
    partial class key_capture
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(key_capture));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel_superior = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.macrox_logo_superior = new System.Windows.Forms.PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.button_OK = new Guna.UI2.WinForms.Guna2Button();
            this.label_key = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.panel_superior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macrox_logo_superior)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 5;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel_superior
            // 
            this.panel_superior.Controls.Add(this.macrox_logo_superior);
            this.panel_superior.FillColor = System.Drawing.Color.Black;
            this.panel_superior.FillColor2 = System.Drawing.Color.Black;
            this.panel_superior.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel_superior.Location = new System.Drawing.Point(0, 0);
            this.panel_superior.Name = "panel_superior";
            this.panel_superior.Size = new System.Drawing.Size(214, 30);
            this.panel_superior.TabIndex = 0;
            this.panel_superior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_superior_MouseMove);
            // 
            // macrox_logo_superior
            // 
            this.macrox_logo_superior.BackColor = System.Drawing.Color.Transparent;
            this.macrox_logo_superior.Image = ((System.Drawing.Image)(resources.GetObject("macrox_logo_superior.Image")));
            this.macrox_logo_superior.Location = new System.Drawing.Point(2, 3);
            this.macrox_logo_superior.Name = "macrox_logo_superior";
            this.macrox_logo_superior.Size = new System.Drawing.Size(26, 26);
            this.macrox_logo_superior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.macrox_logo_superior.TabIndex = 7;
            this.macrox_logo_superior.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.Controls.Add(this.button_OK);
            this.guna2Panel1.Controls.Add(this.label_key);
            this.guna2Panel1.Controls.Add(this.label35);
            this.guna2Panel1.Controls.Add(this.panel_superior);
            this.guna2Panel1.Controls.Add(this.guna2ProgressBar1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(214, 130);
            this.guna2Panel1.TabIndex = 1;
            this.guna2Panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseClick);
            // 
            // button_OK
            // 
            this.button_OK.Animated = true;
            this.button_OK.BorderRadius = 3;
            this.button_OK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_OK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_OK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_OK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_OK.FillColor = System.Drawing.Color.Black;
            this.button_OK.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.ForeColor = System.Drawing.Color.White;
            this.button_OK.ImageSize = new System.Drawing.Size(0, 0);
            this.button_OK.Location = new System.Drawing.Point(126, 95);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(78, 25);
            this.button_OK.TabIndex = 51;
            this.button_OK.Text = "OK";
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_key
            // 
            this.label_key.AutoSize = true;
            this.label_key.BackColor = System.Drawing.Color.Transparent;
            this.label_key.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_key.ForeColor = System.Drawing.Color.White;
            this.label_key.Location = new System.Drawing.Point(25, 59);
            this.label_key.Name = "label_key";
            this.label_key.Size = new System.Drawing.Size(12, 17);
            this.label_key.TabIndex = 43;
            this.label_key.Text = "-";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Century Gothic", 9.85F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(21, 42);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 17);
            this.label35.TabIndex = 26;
            this.label35.Text = "Tecla/Key:";
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ProgressBar1.FillColor = System.Drawing.Color.White;
            this.guna2ProgressBar1.Location = new System.Drawing.Point(1, 28);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.ProgressColor = System.Drawing.Color.White;
            this.guna2ProgressBar1.ProgressColor2 = System.Drawing.Color.White;
            this.guna2ProgressBar1.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2ProgressBar1.ShadowDecoration.Enabled = true;
            this.guna2ProgressBar1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.guna2ProgressBar1.Size = new System.Drawing.Size(214, 3);
            this.guna2ProgressBar1.TabIndex = 6;
            this.guna2ProgressBar1.Text = "guna2ProgressBar1";
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // key_capture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(214, 130);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "key_capture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "key_capture";
            this.panel_superior.ResumeLayout(false);
            this.panel_superior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.macrox_logo_superior)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel panel_superior;
        private System.Windows.Forms.PictureBox macrox_logo_superior;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label_key;
        private Guna.UI2.WinForms.Guna2Button button_OK;
    }
}