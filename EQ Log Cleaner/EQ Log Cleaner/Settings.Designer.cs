namespace EQ_Log_Cleaner
{
    partial class Settings
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
            this.CB_Parse_Chat = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_General = new System.Windows.Forms.TabPage();
            this.TP_Chat = new System.Windows.Forms.TabPage();
            this.GB_Chat = new System.Windows.Forms.GroupBox();
            this.CB_Tell_Windows = new System.Windows.Forms.CheckBox();
            this.CB_Chat_Channels = new System.Windows.Forms.CheckBox();
            this.CB_Normal_Cross_Tells = new System.Windows.Forms.CheckBox();
            this.CB_Normal_Chat = new System.Windows.Forms.CheckBox();
            this.TP_Class = new System.Windows.Forms.TabPage();
            this.B_Close = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TP_Chat.SuspendLayout();
            this.GB_Chat.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_Parse_Chat
            // 
            this.CB_Parse_Chat.AutoSize = true;
            this.CB_Parse_Chat.Location = new System.Drawing.Point(6, 6);
            this.CB_Parse_Chat.Name = "CB_Parse_Chat";
            this.CB_Parse_Chat.Size = new System.Drawing.Size(78, 17);
            this.CB_Parse_Chat.TabIndex = 0;
            this.CB_Parse_Chat.Text = "Parse Chat";
            this.CB_Parse_Chat.UseVisualStyleBackColor = true;
            this.CB_Parse_Chat.CheckedChanged += new System.EventHandler(this.CB_Parse_Chat_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_General);
            this.tabControl1.Controls.Add(this.TP_Chat);
            this.tabControl1.Controls.Add(this.TP_Class);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(259, 210);
            this.tabControl1.TabIndex = 1;
            // 
            // TP_General
            // 
            this.TP_General.Location = new System.Drawing.Point(4, 22);
            this.TP_General.Name = "TP_General";
            this.TP_General.Padding = new System.Windows.Forms.Padding(3);
            this.TP_General.Size = new System.Drawing.Size(251, 184);
            this.TP_General.TabIndex = 0;
            this.TP_General.Text = "General";
            this.TP_General.UseVisualStyleBackColor = true;
            // 
            // TP_Chat
            // 
            this.TP_Chat.Controls.Add(this.GB_Chat);
            this.TP_Chat.Controls.Add(this.CB_Parse_Chat);
            this.TP_Chat.Location = new System.Drawing.Point(4, 22);
            this.TP_Chat.Name = "TP_Chat";
            this.TP_Chat.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Chat.Size = new System.Drawing.Size(251, 211);
            this.TP_Chat.TabIndex = 1;
            this.TP_Chat.Text = "Chat";
            this.TP_Chat.UseVisualStyleBackColor = true;
            // 
            // GB_Chat
            // 
            this.GB_Chat.Controls.Add(this.CB_Tell_Windows);
            this.GB_Chat.Controls.Add(this.CB_Chat_Channels);
            this.GB_Chat.Controls.Add(this.CB_Normal_Cross_Tells);
            this.GB_Chat.Controls.Add(this.CB_Normal_Chat);
            this.GB_Chat.Location = new System.Drawing.Point(6, 29);
            this.GB_Chat.Name = "GB_Chat";
            this.GB_Chat.Size = new System.Drawing.Size(239, 176);
            this.GB_Chat.TabIndex = 1;
            this.GB_Chat.TabStop = false;
            // 
            // CB_Tell_Windows
            // 
            this.CB_Tell_Windows.AutoSize = true;
            this.CB_Tell_Windows.Location = new System.Drawing.Point(6, 88);
            this.CB_Tell_Windows.Name = "CB_Tell_Windows";
            this.CB_Tell_Windows.Size = new System.Drawing.Size(133, 17);
            this.CB_Tell_Windows.TabIndex = 4;
            this.CB_Tell_Windows.Text = "Remove Tell Windows";
            this.CB_Tell_Windows.UseVisualStyleBackColor = true;
            this.CB_Tell_Windows.CheckedChanged += new System.EventHandler(this.CB_Tell_Windows_CheckedChanged);
            // 
            // CB_Chat_Channels
            // 
            this.CB_Chat_Channels.AutoSize = true;
            this.CB_Chat_Channels.Location = new System.Drawing.Point(6, 65);
            this.CB_Chat_Channels.Name = "CB_Chat_Channels";
            this.CB_Chat_Channels.Size = new System.Drawing.Size(138, 17);
            this.CB_Chat_Channels.TabIndex = 3;
            this.CB_Chat_Channels.Text = "Remove Chat Channels";
            this.CB_Chat_Channels.UseVisualStyleBackColor = true;
            this.CB_Chat_Channels.CheckedChanged += new System.EventHandler(this.CB_Chat_Channels_CheckedChanged);
            // 
            // CB_Normal_Cross_Tells
            // 
            this.CB_Normal_Cross_Tells.AutoSize = true;
            this.CB_Normal_Cross_Tells.Location = new System.Drawing.Point(6, 42);
            this.CB_Normal_Cross_Tells.Name = "CB_Normal_Cross_Tells";
            this.CB_Normal_Cross_Tells.Size = new System.Drawing.Size(127, 17);
            this.CB_Normal_Cross_Tells.TabIndex = 2;
            this.CB_Normal_Cross_Tells.Text = "Remove Normal Tells";
            this.CB_Normal_Cross_Tells.UseVisualStyleBackColor = true;
            this.CB_Normal_Cross_Tells.CheckedChanged += new System.EventHandler(this.CB_Normal_Cross_Tells_CheckedChanged);
            // 
            // CB_Normal_Chat
            // 
            this.CB_Normal_Chat.AutoSize = true;
            this.CB_Normal_Chat.Location = new System.Drawing.Point(6, 19);
            this.CB_Normal_Chat.Name = "CB_Normal_Chat";
            this.CB_Normal_Chat.Size = new System.Drawing.Size(127, 17);
            this.CB_Normal_Chat.TabIndex = 1;
            this.CB_Normal_Chat.Text = "Remove Normal Chat";
            this.CB_Normal_Chat.UseVisualStyleBackColor = true;
            this.CB_Normal_Chat.CheckedChanged += new System.EventHandler(this.CB_Normal_Chat_CheckedChanged);
            // 
            // TP_Class
            // 
            this.TP_Class.Location = new System.Drawing.Point(4, 22);
            this.TP_Class.Name = "TP_Class";
            this.TP_Class.Size = new System.Drawing.Size(251, 211);
            this.TP_Class.TabIndex = 2;
            this.TP_Class.Text = "Class";
            this.TP_Class.UseVisualStyleBackColor = true;
            // 
            // B_Close
            // 
            this.B_Close.Location = new System.Drawing.Point(113, 226);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(75, 23);
            this.B_Close.TabIndex = 2;
            this.B_Close.Text = "Close";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.B_Close);
            this.Controls.Add(this.tabControl1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.TP_Chat.ResumeLayout(false);
            this.TP_Chat.PerformLayout();
            this.GB_Chat.ResumeLayout(false);
            this.GB_Chat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox CB_Parse_Chat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_General;
        private System.Windows.Forms.TabPage TP_Chat;
        private System.Windows.Forms.GroupBox GB_Chat;
        private System.Windows.Forms.CheckBox CB_Tell_Windows;
        private System.Windows.Forms.CheckBox CB_Chat_Channels;
        private System.Windows.Forms.CheckBox CB_Normal_Cross_Tells;
        private System.Windows.Forms.CheckBox CB_Normal_Chat;
        private System.Windows.Forms.TabPage TP_Class;
        private System.Windows.Forms.Button B_Close;
    }
}