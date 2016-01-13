using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        string OriginalFileName = "";
        string FileName = "";
        TempFileCollection TempFiles = new TempFileCollection();

        string Line;

        #endregion

        public MainScreen()
        {
            InitializeComponent();
        }

        private void B_Open_Log_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = Options.DefaultPath;

            OpenFileDialog1.Filter = "EQ Log Files|*.txt;*.txt.gz";
            OpenFileDialog1.Title = "Select an EverQuest Log File";

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

//                Options.DefaultPath = file.Substring(0, found);

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

            int CantUseCommand = 0;
            int HaventRecoveredYet = 0;
            int FirstSelectTarget = 0;
            int CannotSeeTarget = 0;
            int CantCastWhileStunned = 0;
            int TargetTooFarAway = 0;

            //Create the streamreader and read the first two lines because the first line is headings.
            StreamReader sr = new StreamReader(FileName, Encoding.UTF7);

            Line = sr.ReadLine();

            do
            {
                if (Line.Contains("You haven't recovered yet..."))
                {
                    HaventRecoveredYet = HaventRecoveredYet + 1;
                }
                else if (Line.Contains("You can't use that command right now..."))
                {
                    CantUseCommand = CantUseCommand + 1;
                }
                else if (Line.Contains("You must first select a target for this spell!"))
                {
                    FirstSelectTarget = FirstSelectTarget + 1;
                }
                else if (Line.Contains("You cannot see your target."))
                {
                    CannotSeeTarget = CannotSeeTarget + 1;
                }
                else if (Line.Contains("You can't cast spells while stunned!"))
                {
                    CantCastWhileStunned = CantCastWhileStunned + 1;
                }
                else if (Line.Contains("Your target is too far away, get closer!"))
                {
                    TargetTooFarAway = TargetTooFarAway + 1;
                }

                Line = sr.ReadLine();


            } while (Line != null);

            L_Cant_Use_Command_Count.Text = CantUseCommand.ToString();
            L_Havent_Recovered_Yet_Count.Text = HaventRecoveredYet.ToString();
            L_First_Select_Target_Count.Text = FirstSelectTarget.ToString();
            L_Cannot_See_Target_Count.Text = CannotSeeTarget.ToString();
            L_Cant_Cast_While_Stunned_Count.Text = CantCastWhileStunned.ToString();
            L_Target_Too_Far_Away_Count.Text = TargetTooFarAway.ToString();
        }

    }
}
