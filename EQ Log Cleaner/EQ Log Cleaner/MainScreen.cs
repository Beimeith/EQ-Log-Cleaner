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

        //Holds the real filename. Used for when opening a Gzipped file to hold the
        string OriginalFileName = "";
        string FileName = "";
        TempFileCollection TempFiles = new TempFileCollection();

        List<string> Lines = new List<string>();
        string Line;
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

            

            //Create the streamreader and read the first two lines because the first line is headings.
            using (StreamReader sr = new StreamReader(FileName, Encoding.UTF7))
            {
                Line = sr.ReadLine();
                if (Line != null)
                    Lines.Add(Line);

                AddLine = true;

                do
                {

                    ParseGeneral(Line);


                    if (Line.EndsWith("'") || Line.Contains("->"))
                    {
                        ParseChat(Line);
                    }

                    ParseWizard(Line);

                    if (AddLine)
                        Lines.Add(Line);

                    Line = sr.ReadLine();
                    AddLine = true;

                } while (Line != null);
            }


        }

        private void ParseGeneral(string Line)
        {

            if (Line.Contains("You haven't recovered yet..."))
            {
                int HaventRecoveredYet = Convert.ToInt32(L_Havent_Recovered_Yet_Count.Text);
                HaventRecoveredYet = HaventRecoveredYet + 1;
                L_Havent_Recovered_Yet_Count.Text = HaventRecoveredYet.ToString();
                AddLine = false;
            }
            else if (Line.Contains("You can't use that command right now..."))
            {
                int CantUseCommand = Convert.ToInt32(L_Cant_Use_Command_Count.Text);
                CantUseCommand = CantUseCommand + 1;
                L_Cant_Use_Command_Count.Text = CantUseCommand.ToString();
                AddLine = false;
            }
            else if (Line.Contains("You must first select a target for this spell!"))
            {
                int FirstSelectTarget = Convert.ToInt32(L_First_Select_Target_Count.Text);
                FirstSelectTarget = FirstSelectTarget + 1;
                L_First_Select_Target_Count.Text = FirstSelectTarget.ToString();
                AddLine = false;
            }
            else if (Line.Contains("You cannot see your target."))
            {
                int CannotSeeTarget = Convert.ToInt32(L_Cannot_See_Target_Count.Text);
                L_Cannot_See_Target_Count.Text = CannotSeeTarget.ToString();
                CannotSeeTarget = CannotSeeTarget + 1;
                AddLine = false;
            }
            else if (Line.Contains("You can't cast spells while stunned!"))
            {
                int CantCastWhileStunned = Convert.ToInt32(L_Cant_Cast_While_Stunned_Count.Text);
                CantCastWhileStunned = CantCastWhileStunned + 1;
                L_Cant_Cast_While_Stunned_Count.Text = CantCastWhileStunned.ToString();
                AddLine = false;
            }
            else if (Line.Contains("Your target is too far away, get closer!"))
            {
                int TargetTooFarAway = Convert.ToInt32(L_Target_Too_Far_Away_Count.Text);
                TargetTooFarAway = TargetTooFarAway + 1;
                L_Target_Too_Far_Away_Count.Text = TargetTooFarAway.ToString();
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Banestrike again in"))
            {
                int CanUseBanestrike = Convert.ToInt32(L_Can_Use_Banestrike_Count.Text);
                CanUseBanestrike = CanUseBanestrike + 1;
                L_Can_Use_Banestrike_Count.Text = CanUseBanestrike.ToString();
                AddLine = false;
            }

            

        }

        private void ParseWizard(string Line)
        {
          

            if (Line.Contains("You can use the ability Force of Will again in"))
            {
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Force of Flame again in"))
            {
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Force of Ice again in"))
            {
                AddLine = false;
            }
            else if (Line.Contains("You can use the ability Lower Element again in"))
            {
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
                    int NormalChatCount = Convert.ToInt32(L_Normal_Chat_Count.Text);
                    NormalChatCount = NormalChatCount + 1;
                    L_Normal_Chat_Count.Text = NormalChatCount.ToString();
                    AddLine = false;
                }
                else
                {
                    //Normal tells and Serverwide tells
                    MyMatch = ChatRegex2.Match(Line);

                    if (MyMatch.Groups.Count == 4)
                    {
                        int NormalCrossTellCount = Convert.ToInt32(L_Normal_Cross_Tell_Count.Text);
                        NormalCrossTellCount = NormalCrossTellCount + 1;
                        L_Normal_Cross_Tell_Count.Text = NormalCrossTellCount.ToString();
                        AddLine = false;
                    }
                    else
                    {
                        //Chat Channels
                        MyMatch = ChatRegex3.Match(Line);

                        if (MyMatch.Groups.Count == 4)
                        {
                            int ChatChannelCount = Convert.ToInt32(L_Chat_Channel_Count.Text);
                            ChatChannelCount = ChatChannelCount + 1;
                            L_Chat_Channel_Count.Text = ChatChannelCount.ToString();
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
                    int TellWindowCount = Convert.ToInt32(L_Tell_Window_Count.Text);
                    TellWindowCount = TellWindowCount + 1;
                    L_Tell_Window_Count.Text = TellWindowCount.ToString();
                    AddLine = false;
                }
            }
        }


        private void B_Clean_Log_Click(object sender, EventArgs e)
        {
            FileName = FileName.Substring(0, FileName.Length - 4) + "-cleaned.txt";

            File.WriteAllLines(FileName, Lines);
            Lines.Clear();
            MessageBox.Show("Complete");
        }
    }
}
