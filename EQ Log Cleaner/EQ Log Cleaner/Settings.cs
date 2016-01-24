using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQ_Log_Cleaner
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            CB_Parse_Chat.Checked = Options.ParseChat;

            if (CB_Parse_Chat.Checked)
                GB_Chat.Enabled = true;
            else
                GB_Chat.Enabled = false;
            
            CB_Normal_Chat.Checked = Options.RemoveNormalChat;
            CB_Normal_Cross_Tells.Checked = Options.RemoveNormalTells;
            CB_Chat_Channels.Checked = Options.RemoveChatChannels;
            CB_Tell_Windows.Checked = Options.RemoveTellWindows;
        }

        private void CB_Parse_Chat_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Parse_Chat.Checked)
            {
                GB_Chat.Enabled = true;
                Options.ParseChat = true;
            }
            else
            {
                GB_Chat.Enabled = false;
                Options.ParseChat = false;
            }
        }

        private void CB_Normal_Chat_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Normal_Chat.Checked)
                Options.RemoveNormalChat = true;
            else
                Options.RemoveNormalChat = false;
        }

        private void CB_Normal_Cross_Tells_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Normal_Cross_Tells.Checked)
                Options.RemoveNormalTells = true;
            else
                Options.RemoveNormalTells = false;
        }

        private void CB_Chat_Channels_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Chat_Channels.Checked)
                Options.RemoveChatChannels = true;
            else
                Options.RemoveChatChannels = false;
        }

        private void CB_Tell_Windows_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Tell_Windows.Checked)
                Options.RemoveTellWindows = true;
            else
                Options.RemoveTellWindows = false;
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
