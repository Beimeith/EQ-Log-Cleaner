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
            //Set General Checkboxes

            CB_Compress_After_Cleaning.Checked = Options.CompressAfterCleaning;

            CB_Delete_Original_After_Cleaning.Checked = Options.DeleteOriginalAfterCleaning;

            CB_Parse_General.Checked = Options.ParseGeneral;

            if (CB_Parse_General.Checked)
                GB_General.Enabled = true;
            else
                GB_General.Enabled = false;

            CB_Havent_Recovered.Checked = Options.RemoveHaventRecovered;
            CB_Cant_Use_Command.Checked = Options.RemoveCantUseCommand;
            CB_First_Select_Target.Checked = Options.RemoveFirstSelectTarget;
            CB_Cannot_See_Target.Checked = Options.RemoveCannotSeeTarget;
            CB_Cant_Cast_While_Stunned.Checked = Options.RemoveCantCastWhileStunned;
            CB_Target_Too_Far.Checked = Options.RemoveTargetTooFar;
            CB_Can_Use_Ability.Checked = Options.RemoveCanUseAbility;
            
            //Set Chat Checkboxes

            CB_Parse_Chat.Checked = Options.ParseChat;

            if (CB_Parse_Chat.Checked)
                GB_Chat.Enabled = true;
            else
                GB_Chat.Enabled = false;
            
            CB_Normal_Chat.Checked = Options.RemoveNormalChat;
            CB_Normal_Cross_Tells.Checked = Options.RemoveNormalTells;
            CB_Chat_Channels.Checked = Options.RemoveChatChannels;
            CB_Tell_Windows.Checked = Options.RemoveTellWindows;

            //Set Class Checkboxes

            CB_Parse_Class.Checked = Options.ParseClass;

            if (CB_Parse_Class.Checked)
                TC_Parse_Class.Enabled = true;
            else
                TC_Parse_Class.Enabled = false;

            //Set Wizard Checkboxes

            CB_Parse_Wizards.Checked = Options.ParseWizard;

            if (CB_Parse_Wizards.Checked)
                GB_Parse_Wizards.Enabled = true;
            else
                GB_Parse_Wizards.Enabled = false;

        }
        
#region Chat Settings

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

        #endregion

#region General Settings

        private void CB_Parse_General_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Parse_General.Checked)
            {
                GB_General.Enabled = true;
                Options.ParseGeneral = true;
            }
            else
            {
                GB_General.Enabled = false;
                Options.ParseGeneral = false;
            }
        }

        private void CB_Havent_Recovered_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Havent_Recovered.Checked)
                Options.RemoveHaventRecovered = true;
            else
                Options.RemoveHaventRecovered = false;
        }

        private void CB_Cant_Use_Command_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Cant_Use_Command.Checked)
                Options.RemoveCantUseCommand = true;
            else
                Options.RemoveCantUseCommand = false;
        }

        private void CB_First_Select_Target_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_First_Select_Target.Checked)
                Options.RemoveFirstSelectTarget = true;
            else
                Options.RemoveFirstSelectTarget = false;
        }

        private void CB_Cannot_See_Target_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Cannot_See_Target.Checked)
                Options.RemoveCannotSeeTarget = true;
            else
                Options.RemoveCannotSeeTarget = false;
        }

        private void CB_Cant_Cast_While_Stunned_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Cant_Cast_While_Stunned.Checked)
                Options.RemoveCantCastWhileStunned = true;
            else
                Options.RemoveCantCastWhileStunned = false;
        }

        private void CB_Target_Too_Far_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Target_Too_Far.Checked)
                Options.RemoveTargetTooFar = true;
            else
                Options.RemoveTargetTooFar = false;
        }

        private void CB_Can_Use_Ability_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Can_Use_Ability.Checked)
                Options.RemoveCanUseAbility = true;
            else
                Options.RemoveCanUseAbility = false;
        }

        private void CB_Compress_After_Cleaning_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Compress_After_Cleaning.Checked)
                Options.CompressAfterCleaning = true;
            else
                Options.CompressAfterCleaning = false;
        }

        private void CB_Delete_Original_After_Cleaning_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Delete_Original_After_Cleaning.Checked)
                Options.DeleteOriginalAfterCleaning = true;
            else
                Options.DeleteOriginalAfterCleaning = false;
        }

        #endregion

        #region Class Settings

        private void CB_Parse_Class_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Parse_Class.Checked)
            {
                TC_Parse_Class.Enabled = true;
                Options.ParseClass = true;
            }
            else
            {
                TC_Parse_Class.Enabled = false;
                Options.ParseClass = false;
            }
        }

        private void CB_Parse_Wizards_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Parse_Wizards.Checked)
            {
                GB_Parse_Wizards.Enabled = true;
                Options.ParseWizard = true;
            }
            else
            {
                GB_Parse_Wizards.Enabled = false;
                Options.ParseWizard = false;
            }
        }

#endregion

        private void B_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
