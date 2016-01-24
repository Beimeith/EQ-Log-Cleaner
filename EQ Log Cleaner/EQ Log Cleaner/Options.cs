using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ_Log_Cleaner
{
    class Options
    {
        public static string DefaultPath = "C:\\EverQuest\\Logs";

        public static bool ParseWizard = false;


        public static bool ParseChat = false;
        public static bool RemoveNormalChat = false;
        public static bool RemoveNormalTells = false;
        public static bool RemoveChatChannels = false;
        public static bool RemoveTellWindows = false;


    }
}
