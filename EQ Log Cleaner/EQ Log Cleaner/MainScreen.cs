using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;

namespace EQ_Log_Cleaner
{
    public partial class MainScreen : Form
    {
        #region --- Variables -----------------------------------------------------

        string ProgramVersion = "1.0.0.0";
        string Title = "EQ Log Cleaner";

        string Player;

        //Holds the real filename. Used for when opening a Gzipped file to hold the real name not the temp file name.
        string OriginalFileName = "";
        //Holds the filename of the opened file. If the file was zipped, this will be the unzipped temporary file.
        string FileName = "";
        TempFileCollection TempFiles = new TempFileCollection();

        //Current line that has been read.
        string Line;
        //Boolean whether the current line will be added to the Lines List for writeback later.
        bool AddLine = true;


        //Built in chat channels
        Regex ChatRegex1 = new Regex("^\\[.{24}\\] (?<1>\\w+) (?<2>say to your guild, '|tells the guild, '|tells the guild, in .+, '|tell your party, '|tells the group, '|tells the group, in .+, '|tell your raid, '|tells the raid,  '|tells the raid,  in .+, '|say out of character, '|says out of character, '|shout, '|shouts, '|shouts, in .+, '|auction, '|auctions, '|auctions, in .+, '|say, '|says, '|says, in .+, '|say to your fellowship, '|tells the fellowship, '|tells the fellowship, in .+, ')(?<3>.+)'$", RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        //Normal tells / cross server tells
        Regex ChatRegex2 = new Regex("^\\[.{24}\\] (?<1>(\\w+|\\w+\\.\\w+)) (told|tells) (?<2>(\\w+|\\w+\\.\\w+))(, '|, in .+, '| '\\[queued\\], )(?<3>.+)'$", RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        //Chat Channels
        Regex ChatRegex3 = new Regex("^\\[.{24}\\] (?<1>(\\w+|\\w+\\.\\w+)) (tell|tells) (?<2>(\\w+|\\w+\\.\\w+)):\\d+, '(?<3>.+)'$", RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        //Tells that use the Tell Window
        Regex ChatRegex4 = new Regex("^\\[.{24}\\] (?<1>\\w+) -> (?<2>\\w+): (?<3>.+)$", RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        Match MyMatch;

        //General Count Variables
        int HaventRecoveredYet;
        int CantUseCommand;
        int FirstSelectTarget;
        int CannotSeeTarget;
        int CantCastWhileStunned;
        int TargetTooFarAway;
        int CanUseBanestrike;

        //Wizard Count Variables
        int CanUseForceWill;
        int CanUseForceFlames;
        int CanUseForceIce;
        int CanUseLowerElement;

        //Chat Count Variables
        int NormalChatCount;
        int NormalCrossTellCount;
        int ChatChannelCount;
        int TellWindowCount;

        #endregion

        public MainScreen()
        {
            InitializeComponent();
        }

        private void B_Open_Log_Click(object sender, EventArgs e)
        {
            //Open a new file selection box and set the title.
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = "Select an EverQuest Log File";

            //Set the default directory based on what is stored in the options and Filter the files displayed to show text files and gzip files
            OpenFileDialog1.InitialDirectory = Options.DefaultPath;
            OpenFileDialog1.Filter = "EQ Log Files|*.txt;*.txt.gz";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (CheckFile(OpenFileDialog1.FileName))
                {
                    LoadFile(OpenFileDialog1.FileName);
                }
            }
        }

        public bool CheckFile(string file)
        {
            bool FileGood = false;

            if (File.Exists(file))
            {
                int found = 0;
                for (int i = 0; i < file.Length; i++)
                    if (file[i] == '\\')
                        found = i + 1;

                if (file.Contains("_"))
                {
                    found = file.IndexOf('_', found);
                    if (file.Substring(found + 1, file.Length - found - 1).Contains("_"))
                    {
                        Player = file.Substring(found + 1, file.IndexOf('_', found + 1) - found - 1);
                        FileName = file;
                        FileGood = true;
                    }
                    else
                        MessageBox.Show("Can only find one underscore in the filename, cannot determine character name.\n\nEither fill in the Player field on the Options Page, or have the\ncharacter name between two underscores in the file name\n\nFor example:\n\n   eqlog_Gamanern_maelin.txt   (ok)\n\n   eqlog_Gamanern_maelin_20070812.txt   (ok - and shows the date)\n\n   eqlog_Gamanern_maelin_Warden_Hanver.txt   (ok - and shows the target)\n\n   Warden_Hanvar_20070812.txt   (Will call character Hanvar)\n\n   Warden_Hanver.txt   (Only one underscore)\n\n   Warden-Hanver.txt   (No underscores)");
                }
                else
                    MessageBox.Show("Cannot find any underscores in the filename, cannot determine character name.\n\nEither fill in the Player field on the Options Page, or have the\ncharacter name between two underscores in the file name\n\nFor example:\n\n   eqlog_Gamanern_maelin.txt   (ok)\n\n   eqlog_Gamanern_maelin_20070812.txt   (ok - and shows the date)\n\n   eqlog_Gamanern_maelin_Warden_Hanver.txt   (ok - and shows the target)\n\n   Warden_Hanvar_20070812.txt   (Will call character Hanvar)\n\n   Warden_Hanver.txt   (Only one underscore)\n\n   Warden-Hanver.txt   (No underscores)");
            }
            else
                MessageBox.Show("Cannot find file: " + file + "\n\nYou have possibly renamed or deleted the file and a new file hasn't been created yet.");

            return FileGood;
        }

        private void LoadFile(string file)
        {
            //Delete old temp files to prevent eating up space on the system.
            TempFiles.Delete();
            //Places the filename into a new string that doesn't change so that it can be referenced later, even if the filename itself changes.
            OriginalFileName = FileName;

            if (FileName.EndsWith(".gz"))
            {
                //Create a temporary file and place the name into a variable.
                var fn = Path.GetTempFileName();
                //Opens the selected file and puts it into a variable.
                var backup = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                //Puts the temp file into a variable
                var temp = new FileStream(fn, FileMode.Create);
                //Decompresses the selected file into a variable
                var gzip = new GZipStream(backup, CompressionMode.Decompress);
                //Copies the decompressed file into the temporary file.
                gzip.CopyTo(temp);
                gzip.Close();
                temp.Close();
                backup.Close();
                //Adds the temporary file to the list of temporary files.
                TempFiles.AddFile(fn, false);
                //Places the filename into a new string that doesn't change so that it can be referenced later, even if the filename itself changes.
                OriginalFileName = FileName;
                //Set the filename to the temporary files' name.
                FileName = fn;
            }
            ParseFile();
        }

        private void ParseFile()
        {
            ClearCount();

            //Create the streamreader and read the first two lines because the first line is headings.
            using (StreamReader sr = new StreamReader(FileName, Encoding.UTF7))
            {
                Line = sr.ReadLine();

                do
                {
                    ParseGeneral(Line);

                    if (Line.EndsWith("'") || Line.Contains("->"))
                        ParseChat(Line);

                    ParseWizard(Line);

                    Line = sr.ReadLine();

                } while (Line != null);

                //Update the Count Labels
                UpdateCount();
            }
        }

        private void ParseGeneral(string Line)
        {

            if (Line.Contains("You haven't recovered yet..."))
            {
                HaventRecoveredYet = HaventRecoveredYet + 1;
                AddLine = false;
            }
            else if (Line.Contains("You can't use that command right now..."))
            {
                CantUseCommand = CantUseCommand + 1;
                AddLine = false;
            }
            else if (Line.Contains("You must first select a target for this spell!"))
            {
                FirstSelectTarget = FirstSelectTarget + 1;
                AddLine = false;
            }
            else if (Line.Contains("You cannot see your target."))
            {
                CannotSeeTarget = CannotSeeTarget + 1;
                AddLine = false;
            }
            else if (Line.Contains("You can't cast spells while stunned!"))
            {
                CantCastWhileStunned = CantCastWhileStunned + 1;
                AddLine = false;
            }
            else if (Line.Contains("Your target is too far away, get closer!"))
            {
                TargetTooFarAway = TargetTooFarAway + 1;
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Banestrike again in"))
            {
                CanUseBanestrike = CanUseBanestrike + 1;
                AddLine = false;
            }

        }

        private void ParseWizard(string Line)
        {

            if (Line.Contains("You can use the ability Force of Will again in"))
            {
                CanUseForceWill = CanUseForceWill + 1;
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Force of Flame again in"))
            {
                CanUseForceFlames = CanUseForceFlames + 1;
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Force of Ice again in"))
            {
                CanUseForceIce = CanUseForceIce + 1;
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Lower Element again in"))
            {
                CanUseLowerElement = CanUseLowerElement + 1;
                AddLine = false;
            }

        }

        private void ParseChat(string Line)
        {
            //Check if the line is a proper chat message if there is a single quote at the end
            if (Line != null && Line.EndsWith("'"))
            {
                //Built in channels, say/group/raid/etc.
                MyMatch = ChatRegex1.Match(Line);

                if (MyMatch.Groups.Count == 4)
                {
                    NormalChatCount = NormalChatCount + 1;
                    if (Options.RemoveNormalChat)
                        AddLine = false;
                }
                else
                {
                    //Normal tells and Serverwide tells
                    MyMatch = ChatRegex2.Match(Line);

                    if (MyMatch.Groups.Count == 4)
                    {
                        NormalCrossTellCount = NormalCrossTellCount + 1;
                        if (Options.RemoveNormalTells)
                            AddLine = false;
                    }
                    else
                    {
                        //Chat Channels
                        MyMatch = ChatRegex3.Match(Line);

                        if (MyMatch.Groups.Count == 4)
                        {
                            ChatChannelCount = ChatChannelCount + 1;
                            if (Options.RemoveChatChannels)
                                AddLine = false;
                        }
                    }
                }
            }
            //If it doesn't end with a single quote, check if it has the arrow of a tell box.
            else if (Line != null && Line.Contains("->"))
            {
                //Tells that use the Tell window.
                MyMatch = ChatRegex4.Match(Line);

                if (MyMatch.Groups.Count == 4)
                {
                    TellWindowCount = TellWindowCount + 1;
                    if (Options.RemoveTellWindows)
                        AddLine = false;
                }
            }
        }

        private void UpdateCount()
        {
            L_Havent_Recovered_Yet_Count.Text = HaventRecoveredYet.ToString();
            L_Cant_Use_Command_Count.Text = CantUseCommand.ToString();
            L_First_Select_Target_Count.Text = FirstSelectTarget.ToString();
            L_Cannot_See_Target_Count.Text = CannotSeeTarget.ToString();
            L_Cant_Cast_While_Stunned_Count.Text = CantCastWhileStunned.ToString();
            L_Target_Too_Far_Away_Count.Text = TargetTooFarAway.ToString();
            L_Can_Use_Banestrike_Count.Text = CanUseBanestrike.ToString();

            L_Normal_Chat_Count.Text = NormalChatCount.ToString();
            L_Normal_Cross_Tell_Count.Text = NormalCrossTellCount.ToString();
            L_Chat_Channel_Count.Text = ChatChannelCount.ToString();
            L_Tell_Window_Count.Text = TellWindowCount.ToString();
        }

        private void ClearCount()
        {
            HaventRecoveredYet = 0;
            CantUseCommand = 0;
            FirstSelectTarget = 0;
            CannotSeeTarget = 0;
            CantCastWhileStunned = 0;
            TargetTooFarAway = 0;
            CanUseBanestrike = 0;

            CanUseForceWill = 0;
            CanUseForceFlames = 0;
            CanUseForceIce = 0;
            CanUseLowerElement = 0;

            NormalChatCount = 0;
            NormalCrossTellCount = 0;
            ChatChannelCount = 0;
            TellWindowCount = 0;

            L_Havent_Recovered_Yet_Count.Text = "0";
            L_Cant_Use_Command_Count.Text = "0";
            L_First_Select_Target_Count.Text = "0";
            L_Cannot_See_Target_Count.Text = "0";
            L_Cant_Cast_While_Stunned_Count.Text = "0";
            L_Target_Too_Far_Away_Count.Text = "0";
            L_Can_Use_Banestrike_Count.Text = "0";

            L_Normal_Chat_Count.Text = "0";
            L_Normal_Cross_Tell_Count.Text = "0";
            L_Chat_Channel_Count.Text = "0";
            L_Tell_Window_Count.Text = "0";
        }

        private void B_Clean_Log_Click(object sender, EventArgs e)
        {
            //Put the filename for the cleaned file in a string
            string NewFileName = FileName.Substring(0, FileName.Length - 4) + "-cleaned.txt";
            //Reset AddLine to true
            AddLine = true;

            //Startup the Writer
            using (StreamWriter sw = new StreamWriter(NewFileName))
            {
                //And the Reader
                using (StreamReader sr = new StreamReader(FileName, Encoding.UTF7))
                {
                    //Read the first line. Has to be done outside the loop or else the loop will start as null.
                    Line = sr.ReadLine();
                    //Start the parse loop until all lines are read
                    do
                    {
                        //Reset AddLine to true for the next loop
                        AddLine = true;
                        

                        //Parse General 
                        ParseGeneral(Line);

                        if (Options.ParseChat)
                            if (Line.EndsWith("'") || Line.Contains("->"))
                                ParseChat(Line);

                        if (Options.ParseWizard)
                            ParseWizard(Line);

                        //If AddLine is still true, write the line
                        if (AddLine)
                            sw.WriteLine(Line);

                        //Read the next line
                        Line = sr.ReadLine();

                    } while (Line != null) ;
                }
            }
            MessageBox.Show("Complete");
        }

        private void TSMI_Settings_Click(object sender, EventArgs e)
        {
            Settings Settings = new Settings();

            Settings.ShowDialog(this);
        }
    }
}
