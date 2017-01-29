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
            this.TC_Main = new System.Windows.Forms.TabControl();
            this.TP_General = new System.Windows.Forms.TabPage();
            this.CB_Delete_Original_After_Cleaning = new System.Windows.Forms.CheckBox();
            this.CB_Compress_After_Cleaning = new System.Windows.Forms.CheckBox();
            this.GB_General = new System.Windows.Forms.GroupBox();
            this.CB_Can_Use_Ability = new System.Windows.Forms.CheckBox();
            this.CB_Target_Too_Far = new System.Windows.Forms.CheckBox();
            this.CB_Cant_Cast_While_Stunned = new System.Windows.Forms.CheckBox();
            this.CB_Cannot_See_Target = new System.Windows.Forms.CheckBox();
            this.CB_First_Select_Target = new System.Windows.Forms.CheckBox();
            this.CB_Cant_Use_Command = new System.Windows.Forms.CheckBox();
            this.CB_Havent_Recovered = new System.Windows.Forms.CheckBox();
            this.CB_Parse_General = new System.Windows.Forms.CheckBox();
            this.TP_Chat = new System.Windows.Forms.TabPage();
            this.GB_Chat = new System.Windows.Forms.GroupBox();
            this.CB_Tell_Windows = new System.Windows.Forms.CheckBox();
            this.CB_Chat_Channels = new System.Windows.Forms.CheckBox();
            this.CB_Normal_Cross_Tells = new System.Windows.Forms.CheckBox();
            this.CB_Normal_Chat = new System.Windows.Forms.CheckBox();
            this.TP_Class = new System.Windows.Forms.TabPage();
            this.TC_Parse_Class = new System.Windows.Forms.TabControl();
            this.TP_Wizards = new System.Windows.Forms.TabPage();
            this.CB_Parse_Wizards = new System.Windows.Forms.CheckBox();
            this.GB_Parse_Wizards = new System.Windows.Forms.GroupBox();
            this.CB_Parse_Class = new System.Windows.Forms.CheckBox();
            this.B_Close = new System.Windows.Forms.Button();
            this.TC_Main.SuspendLayout();
            this.TP_General.SuspendLayout();
            this.GB_General.SuspendLayout();
            this.TP_Chat.SuspendLayout();
            this.GB_Chat.SuspendLayout();
            this.TP_Class.SuspendLayout();
            this.TC_Parse_Class.SuspendLayout();
            this.TP_Wizards.SuspendLayout();
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
            // TC_Main
            // 
            this.TC_Main.Controls.Add(this.TP_General);
            this.TC_Main.Controls.Add(this.TP_Chat);
            this.TC_Main.Controls.Add(this.TP_Class);
            this.TC_Main.Location = new System.Drawing.Point(13, 12);
            this.TC_Main.Name = "TC_Main";
            this.TC_Main.SelectedIndex = 0;
            this.TC_Main.Size = new System.Drawing.Size(353, 297);
            this.TC_Main.TabIndex = 1;
            // 
            // TP_General
            // 
            this.TP_General.Controls.Add(this.CB_Delete_Original_After_Cleaning);
            this.TP_General.Controls.Add(this.CB_Compress_After_Cleaning);
            this.TP_General.Controls.Add(this.GB_General);
            this.TP_General.Controls.Add(this.CB_Parse_General);
            this.TP_General.Location = new System.Drawing.Point(4, 22);
            this.TP_General.Name = "TP_General";
            this.TP_General.Padding = new System.Windows.Forms.Padding(3);
            this.TP_General.Size = new System.Drawing.Size(345, 271);
            this.TP_General.TabIndex = 0;
            this.TP_General.Text = "General";
            this.TP_General.UseVisualStyleBackColor = true;
            // 
            // CB_Delete_Original_After_Cleaning
            // 
            this.CB_Delete_Original_After_Cleaning.AutoSize = true;
            this.CB_Delete_Original_After_Cleaning.Location = new System.Drawing.Point(6, 248);
            this.CB_Delete_Original_After_Cleaning.Name = "CB_Delete_Original_After_Cleaning";
            this.CB_Delete_Original_After_Cleaning.Size = new System.Drawing.Size(164, 17);
            this.CB_Delete_Original_After_Cleaning.TabIndex = 5;
            this.CB_Delete_Original_After_Cleaning.Text = "Delete Original After Cleaning";
            this.CB_Delete_Original_After_Cleaning.UseVisualStyleBackColor = true;
            this.CB_Delete_Original_After_Cleaning.CheckedChanged += new System.EventHandler(this.CB_Delete_Original_After_Cleaning_CheckedChanged);
            // 
            // CB_Compress_After_Cleaning
            // 
            this.CB_Compress_After_Cleaning.AutoSize = true;
            this.CB_Compress_After_Cleaning.Location = new System.Drawing.Point(6, 227);
            this.CB_Compress_After_Cleaning.Name = "CB_Compress_After_Cleaning";
            this.CB_Compress_After_Cleaning.Size = new System.Drawing.Size(141, 17);
            this.CB_Compress_After_Cleaning.TabIndex = 4;
            this.CB_Compress_After_Cleaning.Text = "Compress After Cleaning";
            this.CB_Compress_After_Cleaning.UseVisualStyleBackColor = true;
            this.CB_Compress_After_Cleaning.CheckedChanged += new System.EventHandler(this.CB_Compress_After_Cleaning_CheckedChanged);
            // 
            // GB_General
            // 
            this.GB_General.Controls.Add(this.CB_Can_Use_Ability);
            this.GB_General.Controls.Add(this.CB_Target_Too_Far);
            this.GB_General.Controls.Add(this.CB_Cant_Cast_While_Stunned);
            this.GB_General.Controls.Add(this.CB_Cannot_See_Target);
            this.GB_General.Controls.Add(this.CB_First_Select_Target);
            this.GB_General.Controls.Add(this.CB_Cant_Use_Command);
            this.GB_General.Controls.Add(this.CB_Havent_Recovered);
            this.GB_General.Location = new System.Drawing.Point(6, 29);
            this.GB_General.Name = "GB_General";
            this.GB_General.Size = new System.Drawing.Size(333, 192);
            this.GB_General.TabIndex = 3;
            this.GB_General.TabStop = false;
            // 
            // CB_Can_Use_Ability
            // 
            this.CB_Can_Use_Ability.AutoSize = true;
            this.CB_Can_Use_Ability.Location = new System.Drawing.Point(6, 157);
            this.CB_Can_Use_Ability.Name = "CB_Can_Use_Ability";
            this.CB_Can_Use_Ability.Size = new System.Drawing.Size(186, 17);
            this.CB_Can_Use_Ability.TabIndex = 7;
            this.CB_Can_Use_Ability.Text = "Remove \"You can use the ability\"";
            this.CB_Can_Use_Ability.UseVisualStyleBackColor = true;
            this.CB_Can_Use_Ability.CheckedChanged += new System.EventHandler(this.CB_Can_Use_Ability_CheckedChanged);
            // 
            // CB_Target_Too_Far
            // 
            this.CB_Target_Too_Far.AutoSize = true;
            this.CB_Target_Too_Far.Location = new System.Drawing.Point(6, 134);
            this.CB_Target_Too_Far.Name = "CB_Target_Too_Far";
            this.CB_Target_Too_Far.Size = new System.Drawing.Size(257, 17);
            this.CB_Target_Too_Far.TabIndex = 6;
            this.CB_Target_Too_Far.Text = "Remove \"Your target is too far away, get closer!\"";
            this.CB_Target_Too_Far.UseVisualStyleBackColor = true;
            this.CB_Target_Too_Far.CheckedChanged += new System.EventHandler(this.CB_Target_Too_Far_CheckedChanged);
            // 
            // CB_Cant_Cast_While_Stunned
            // 
            this.CB_Cant_Cast_While_Stunned.AutoSize = true;
            this.CB_Cant_Cast_While_Stunned.Location = new System.Drawing.Point(6, 111);
            this.CB_Cant_Cast_While_Stunned.Name = "CB_Cant_Cast_While_Stunned";
            this.CB_Cant_Cast_While_Stunned.Size = new System.Drawing.Size(247, 17);
            this.CB_Cant_Cast_While_Stunned.TabIndex = 5;
            this.CB_Cant_Cast_While_Stunned.Text = "Remove \"You can\'t cast spells while stunned!\"";
            this.CB_Cant_Cast_While_Stunned.UseVisualStyleBackColor = true;
            this.CB_Cant_Cast_While_Stunned.CheckedChanged += new System.EventHandler(this.CB_Cant_Cast_While_Stunned_CheckedChanged);
            // 
            // CB_Cannot_See_Target
            // 
            this.CB_Cannot_See_Target.AutoSize = true;
            this.CB_Cannot_See_Target.Location = new System.Drawing.Point(6, 88);
            this.CB_Cannot_See_Target.Name = "CB_Cannot_See_Target";
            this.CB_Cannot_See_Target.Size = new System.Drawing.Size(210, 17);
            this.CB_Cannot_See_Target.TabIndex = 4;
            this.CB_Cannot_See_Target.Text = "Remove \"You cannot see your target.\"";
            this.CB_Cannot_See_Target.UseVisualStyleBackColor = true;
            this.CB_Cannot_See_Target.CheckedChanged += new System.EventHandler(this.CB_Cannot_See_Target_CheckedChanged);
            // 
            // CB_First_Select_Target
            // 
            this.CB_First_Select_Target.AutoSize = true;
            this.CB_First_Select_Target.Location = new System.Drawing.Point(6, 65);
            this.CB_First_Select_Target.Name = "CB_First_Select_Target";
            this.CB_First_Select_Target.Size = new System.Drawing.Size(273, 17);
            this.CB_First_Select_Target.TabIndex = 3;
            this.CB_First_Select_Target.Text = "Remove \"You must first select a target for this spell!\"";
            this.CB_First_Select_Target.UseVisualStyleBackColor = true;
            this.CB_First_Select_Target.CheckedChanged += new System.EventHandler(this.CB_First_Select_Target_CheckedChanged);
            // 
            // CB_Cant_Use_Command
            // 
            this.CB_Cant_Use_Command.AutoSize = true;
            this.CB_Cant_Use_Command.Location = new System.Drawing.Point(6, 42);
            this.CB_Cant_Use_Command.Name = "CB_Cant_Use_Command";
            this.CB_Cant_Use_Command.Size = new System.Drawing.Size(269, 17);
            this.CB_Cant_Use_Command.TabIndex = 2;
            this.CB_Cant_Use_Command.Text = "Remove \"You can\'t use that command right now...\"";
            this.CB_Cant_Use_Command.UseVisualStyleBackColor = true;
            this.CB_Cant_Use_Command.CheckedChanged += new System.EventHandler(this.CB_Cant_Use_Command_CheckedChanged);
            // 
            // CB_Havent_Recovered
            // 
            this.CB_Havent_Recovered.AutoSize = true;
            this.CB_Havent_Recovered.Location = new System.Drawing.Point(6, 19);
            this.CB_Havent_Recovered.Name = "CB_Havent_Recovered";
            this.CB_Havent_Recovered.Size = new System.Drawing.Size(213, 17);
            this.CB_Havent_Recovered.TabIndex = 1;
            this.CB_Havent_Recovered.Text = "Remove \"You haven\'t recovered yet...\"";
            this.CB_Havent_Recovered.UseVisualStyleBackColor = true;
            this.CB_Havent_Recovered.CheckedChanged += new System.EventHandler(this.CB_Havent_Recovered_CheckedChanged);
            // 
            // CB_Parse_General
            // 
            this.CB_Parse_General.AutoSize = true;
            this.CB_Parse_General.Location = new System.Drawing.Point(6, 6);
            this.CB_Parse_General.Name = "CB_Parse_General";
            this.CB_Parse_General.Size = new System.Drawing.Size(93, 17);
            this.CB_Parse_General.TabIndex = 2;
            this.CB_Parse_General.Text = "Parse General";
            this.CB_Parse_General.UseVisualStyleBackColor = true;
            this.CB_Parse_General.CheckedChanged += new System.EventHandler(this.CB_Parse_General_CheckedChanged);
            // 
            // TP_Chat
            // 
            this.TP_Chat.Controls.Add(this.GB_Chat);
            this.TP_Chat.Controls.Add(this.CB_Parse_Chat);
            this.TP_Chat.Location = new System.Drawing.Point(4, 22);
            this.TP_Chat.Name = "TP_Chat";
            this.TP_Chat.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Chat.Size = new System.Drawing.Size(345, 271);
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
            this.GB_Chat.Size = new System.Drawing.Size(239, 117);
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
            this.TP_Class.Controls.Add(this.TC_Parse_Class);
            this.TP_Class.Controls.Add(this.CB_Parse_Class);
            this.TP_Class.Location = new System.Drawing.Point(4, 22);
            this.TP_Class.Name = "TP_Class";
            this.TP_Class.Size = new System.Drawing.Size(345, 271);
            this.TP_Class.TabIndex = 2;
            this.TP_Class.Text = "Class";
            this.TP_Class.UseVisualStyleBackColor = true;
            // 
            // TC_Parse_Class
            // 
            this.TC_Parse_Class.Controls.Add(this.TP_Wizards);
            this.TC_Parse_Class.Location = new System.Drawing.Point(6, 29);
            this.TC_Parse_Class.Name = "TC_Parse_Class";
            this.TC_Parse_Class.SelectedIndex = 0;
            this.TC_Parse_Class.Size = new System.Drawing.Size(336, 195);
            this.TC_Parse_Class.TabIndex = 3;
            // 
            // TP_Wizards
            // 
            this.TP_Wizards.Controls.Add(this.CB_Parse_Wizards);
            this.TP_Wizards.Controls.Add(this.GB_Parse_Wizards);
            this.TP_Wizards.Location = new System.Drawing.Point(4, 22);
            this.TP_Wizards.Name = "TP_Wizards";
            this.TP_Wizards.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Wizards.Size = new System.Drawing.Size(328, 169);
            this.TP_Wizards.TabIndex = 0;
            this.TP_Wizards.Text = "Wizards";
            this.TP_Wizards.UseVisualStyleBackColor = true;
            // 
            // CB_Parse_Wizards
            // 
            this.CB_Parse_Wizards.AutoSize = true;
            this.CB_Parse_Wizards.Location = new System.Drawing.Point(6, 6);
            this.CB_Parse_Wizards.Name = "CB_Parse_Wizards";
            this.CB_Parse_Wizards.Size = new System.Drawing.Size(94, 17);
            this.CB_Parse_Wizards.TabIndex = 5;
            this.CB_Parse_Wizards.Text = "Parse Wizards";
            this.CB_Parse_Wizards.UseVisualStyleBackColor = true;
            this.CB_Parse_Wizards.CheckedChanged += new System.EventHandler(this.CB_Parse_Wizards_CheckedChanged);
            // 
            // GB_Parse_Wizards
            // 
            this.GB_Parse_Wizards.Location = new System.Drawing.Point(6, 29);
            this.GB_Parse_Wizards.Name = "GB_Parse_Wizards";
            this.GB_Parse_Wizards.Size = new System.Drawing.Size(316, 117);
            this.GB_Parse_Wizards.TabIndex = 4;
            this.GB_Parse_Wizards.TabStop = false;
            // 
            // CB_Parse_Class
            // 
            this.CB_Parse_Class.AutoSize = true;
            this.CB_Parse_Class.Location = new System.Drawing.Point(6, 6);
            this.CB_Parse_Class.Name = "CB_Parse_Class";
            this.CB_Parse_Class.Size = new System.Drawing.Size(81, 17);
            this.CB_Parse_Class.TabIndex = 2;
            this.CB_Parse_Class.Text = "Parse Class";
            this.CB_Parse_Class.UseVisualStyleBackColor = true;
            this.CB_Parse_Class.CheckedChanged += new System.EventHandler(this.CB_Parse_Class_CheckedChanged);
            // 
            // B_Close
            // 
            this.B_Close.Location = new System.Drawing.Point(140, 375);
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
            this.ClientSize = new System.Drawing.Size(378, 410);
            this.Controls.Add(this.B_Close);
            this.Controls.Add(this.TC_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.TC_Main.ResumeLayout(false);
            this.TP_General.ResumeLayout(false);
            this.TP_General.PerformLayout();
            this.GB_General.ResumeLayout(false);
            this.GB_General.PerformLayout();
            this.TP_Chat.ResumeLayout(false);
            this.TP_Chat.PerformLayout();
            this.GB_Chat.ResumeLayout(false);
            this.GB_Chat.PerformLayout();
            this.TP_Class.ResumeLayout(false);
            this.TP_Class.PerformLayout();
            this.TC_Parse_Class.ResumeLayout(false);
            this.TP_Wizards.ResumeLayout(false);
            this.TP_Wizards.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox CB_Parse_Chat;
        private System.Windows.Forms.TabControl TC_Main;
        private System.Windows.Forms.TabPage TP_General;
        private System.Windows.Forms.TabPage TP_Chat;
        private System.Windows.Forms.GroupBox GB_Chat;
        private System.Windows.Forms.CheckBox CB_Tell_Windows;
        private System.Windows.Forms.CheckBox CB_Chat_Channels;
        private System.Windows.Forms.CheckBox CB_Normal_Cross_Tells;
        private System.Windows.Forms.CheckBox CB_Normal_Chat;
        private System.Windows.Forms.TabPage TP_Class;
        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.GroupBox GB_General;
        private System.Windows.Forms.CheckBox CB_Cannot_See_Target;
        private System.Windows.Forms.CheckBox CB_First_Select_Target;
        private System.Windows.Forms.CheckBox CB_Cant_Use_Command;
        private System.Windows.Forms.CheckBox CB_Havent_Recovered;
        private System.Windows.Forms.CheckBox CB_Parse_General;
        private System.Windows.Forms.CheckBox CB_Cant_Cast_While_Stunned;
        private System.Windows.Forms.CheckBox CB_Target_Too_Far;
        private System.Windows.Forms.CheckBox CB_Can_Use_Ability;
        private System.Windows.Forms.TabControl TC_Parse_Class;
        private System.Windows.Forms.TabPage TP_Wizards;
        private System.Windows.Forms.CheckBox CB_Parse_Wizards;
        private System.Windows.Forms.GroupBox GB_Parse_Wizards;
        private System.Windows.Forms.CheckBox CB_Parse_Class;
        private System.Windows.Forms.CheckBox CB_Compress_After_Cleaning;
        private System.Windows.Forms.CheckBox CB_Delete_Original_After_Cleaning;
    }
}