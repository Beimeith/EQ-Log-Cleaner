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

        string ProgramVersion = "0.0.2.0";
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

        //Boolean whether a file has been loaded
        bool fileloaded = false;
        //Boolean whether the file being parsed is a compressed file or not
        bool zip = false;

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
        int HaventRecoveredYetCount;
        int CantUseCommandCount;
        int FirstSelectTargetCount;
        int CannotSeeTargetCount;
        int CantCastWhileStunnedCount;
        int TargetTooFarAwayCount;
        int CanUseAbilityCount;

        //Chat Count Variables
        int NormalChatCount;
        int NormalCrossTellCount;
        int ChatChannelCount;
        int TellWindowCount;

        #endregion

        public MainScreen()
        {
            InitializeComponent();
            Text = Title + " Beta v" + ProgramVersion;
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
                    fileloaded = true;
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
            //Reset zip boolean when loading a new file. 
            zip = false;
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
                zip = true;
            }
            ParseFile();
        }

        private void ParseFile()
        {
            ClearCount();

            //Create the streamreader and read the first two lines because the first line is headings.
            using (StreamReader sr = new StreamReader(FileName, Encoding.UTF8))
            {
                Line = sr.ReadLine();

                do
                {
                        ParseGeneral(Line);

                        ParseClass(Line);
                    
                        if (Line.EndsWith("'") || Line.Contains("->"))
                            ParseChat(Line);

                    Line = sr.ReadLine();

                } while (Line != null);

                //Update the Count Labels
                UpdateCount();

                MessageBox.Show("Loading Complete");
            }
        }

        private void ParseGeneral(string Line)
        {

            if (Line.Contains("You haven't recovered yet..."))
            {
                HaventRecoveredYetCount = HaventRecoveredYetCount + 1;
                if (Options.RemoveHaventRecovered)
                    AddLine = false;
            }
            else if (Line.Contains("You can't use that command right now..."))
            {
                CantUseCommandCount = CantUseCommandCount + 1;
                if (Options.RemoveCantUseCommand)
                    AddLine = false;
            }
            else if (Line.Contains("You must first select a target for this spell!"))
            {
                FirstSelectTargetCount = FirstSelectTargetCount + 1;
                if (Options.RemoveFirstSelectTarget)
                    AddLine = false;
            }
            else if (Line.Contains("You cannot see your target."))
            {
                CannotSeeTargetCount = CannotSeeTargetCount + 1;
                if (Options.RemoveCannotSeeTarget)
                    AddLine = false;
            }
            else if (Line.Contains("You can't cast spells while stunned!"))
            {
                CantCastWhileStunnedCount = CantCastWhileStunnedCount + 1;
                if (Options.RemoveCantCastWhileStunned)
                    AddLine = false;
            }
            else if (Line.Contains("Your target is too far away, get closer!"))
            {
                TargetTooFarAwayCount = TargetTooFarAwayCount + 1;
                if (Options.RemoveTargetTooFar)
                    AddLine = false;
            }
            else if (Line.Contains("You can use the ability "))
            {
                CanUseAbilityCount = CanUseAbilityCount + 1;
                if (Options.RemoveCanUseAbility)
                    AddLine = false;
            }

        }

        private void ParseClass(string Line)
        {
            if (Options.ParseWizard)
                ParseWizard(Line);
        }

        private void ParseWizard(string Line)
        {

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
            L_Havent_Recovered_Yet_Count.Text = HaventRecoveredYetCount.ToString();
            L_Cant_Use_Command_Count.Text = CantUseCommandCount.ToString();
            L_First_Select_Target_Count.Text = FirstSelectTargetCount.ToString();
            L_Cannot_See_Target_Count.Text = CannotSeeTargetCount.ToString();
            L_Cant_Cast_While_Stunned_Count.Text = CantCastWhileStunnedCount.ToString();
            L_Target_Too_Far_Away_Count.Text = TargetTooFarAwayCount.ToString();
            L_Can_Use_Ability_Count.Text = CanUseAbilityCount.ToString();

            L_Normal_Chat_Count.Text = NormalChatCount.ToString();
            L_Normal_Cross_Tell_Count.Text = NormalCrossTellCount.ToString();
            L_Chat_Channel_Count.Text = ChatChannelCount.ToString();
            L_Tell_Window_Count.Text = TellWindowCount.ToString();
        }

        private void ClearCount()
        {
            HaventRecoveredYetCount = 0;
            CantUseCommandCount = 0;
            FirstSelectTargetCount = 0;
            CannotSeeTargetCount = 0;
            CantCastWhileStunnedCount = 0;
            TargetTooFarAwayCount = 0;
            CanUseAbilityCount = 0;

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
            L_Can_Use_Ability_Count.Text = "0";

            L_Normal_Chat_Count.Text = "0";
            L_Normal_Cross_Tell_Count.Text = "0";
            L_Chat_Channel_Count.Text = "0";
            L_Tell_Window_Count.Text = "0";
        }

        private void B_Clean_Log_Click(object sender, EventArgs e)
        {
            if (!fileloaded)
            {
                MessageBox.Show("You need to open a log file before you can clean it...", "Oops...");
                return;
            }

            //Reset AddLine to true
            AddLine = true;

            try
            {
                //Create a temporary file that will hold the cleaned log.
                var fn = Path.GetTempFileName();
                //Add the Temporary file to the list of temp files so it can be properly disposed of.
                TempFiles.AddFile(fn, false);

                //String that will hold the permanent cleaned file.
                string NewFileName;

                //If the original file ended with a .gz then it was compressed so we need to name our new file as .gz as well. 
                if (OriginalFileName.EndsWith(".gz"))
                {
                    NewFileName = OriginalFileName.Substring(0, OriginalFileName.Length - 7) + "-cleaned.txt.gz";
                }
                else if (OriginalFileName.EndsWith(".txt") && Options.CompressAfterCleaning)
                {
                    NewFileName = OriginalFileName.Substring(0, OriginalFileName.Length - 4) + "-cleaned.txt.gz";
                }
                else
                {
                    NewFileName = OriginalFileName.Substring(0, OriginalFileName.Length - 4) + "-cleaned.txt";
                }

                //Startup the Writer
                using (StreamWriter sw = new StreamWriter(fn))
                {
                    //And the Reader
                    using (StreamReader sr = new StreamReader(FileName, Encoding.UTF8))
                    {

                        //Read the first line. Has to be done outside the loop or else the loop will start as null.
                        Line = sr.ReadLine();
                        //Start the parse loop until all lines are read
                        do
                        {
                            //Reset AddLine to true for the next loop
                            AddLine = true;

                            //Parse General 
                            if (Options.ParseGeneral)
                                ParseGeneral(Line);

                            if (Options.ParseChat)
                                if (Line.EndsWith("'") || Line.Contains("->"))
                                    ParseChat(Line);

                            if (Options.ParseClass)
                                ParseClass(Line);

                            //If AddLine is still true, write the line
                            if (AddLine)
                                sw.WriteLine(Line);

                            //Read the next line
                            Line = sr.ReadLine();

                        } while (Line != null);
                    }
                }
                
                //Now we write from the temporary file to the permanent file.
                //fFrst we need to check if it should be compressed or not.

                //Compress to Zip
                if (zip || Options.CompressAfterCleaning)
                {
                    var fi = new FileInfo(fn);
                    var write = new FileStream(NewFileName, FileMode.CreateNew);
                    var gzip = new GZipStream(write, CompressionMode.Compress);
                    var log = fi.OpenRead();
                    log.CopyTo(gzip);
                    log.Close();
                    gzip.Close();
                    write.Close();
                }
                else
                {
                    var fi = new FileInfo(fn);
                    var write = new FileStream(NewFileName, FileMode.CreateNew);
                    var log = fi.OpenRead();
                    log.CopyTo(write);
                    log.Close();
                    write.Close();
                }
                File.Delete(OriginalFileName);
                MessageBox.Show("Cleaning Complete");
            }
            catch (Exception error)
            {
                if (Line != null)
                    MessageBox.Show(Line);

                MessageBox.Show(error.ToString());
                
            }
                
        }

        private void TSMI_Settings_Click(object sender, EventArgs e)
        {
            Settings Settings = new Settings();

            Settings.ShowDialog(this);
        }
    }
}
