namespace TwitchBot.IRCBot.MusicBot
{
    partial class MusicBotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicBotForm));
            this.flashPlayerControl = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayerControl)).BeginInit();
            this.SuspendLayout();
            // 
            // flashPlayerControl
            // 
            this.flashPlayerControl.Enabled = true;
            this.flashPlayerControl.Location = new System.Drawing.Point(3, 0);
            this.flashPlayerControl.Name = "flashPlayerControl";
            this.flashPlayerControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashPlayerControl.OcxState")));
            this.flashPlayerControl.Size = new System.Drawing.Size(402, 318);
            this.flashPlayerControl.TabIndex = 0;
            // 
            // MusicBotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 330);
            this.Controls.Add(this.flashPlayerControl);
            this.Name = "MusicBotForm";
            this.Text = "MusicBotForm";
            this.Load += new System.EventHandler(this.MusicBotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flashPlayerControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash flashPlayerControl;
    }
}