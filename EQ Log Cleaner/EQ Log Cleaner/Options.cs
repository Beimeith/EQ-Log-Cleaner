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
        public static bool CompressAfterCleaning = true;
        public static bool DeleteOriginalAfterCleaning = false;

        public static bool ParseGeneral = true;
        public static bool RemoveHaventRecovered = true;
        public static bool RemoveCantUseCommand = true;
        public static bool RemoveFirstSelectTarget = true;
        public static bool RemoveCannotSeeTarget = true;
        public static bool RemoveCantCastWhileStunned = true;
        public static bool RemoveTargetTooFar = true;
        public static bool RemoveCanUseAbility = true;

        public static bool ParseChat = false;
        public static bool RemoveNormalChat = false;
        public static bool RemoveNormalTells = false;
        public static bool RemoveChatChannels = false;
        public static bool RemoveTellWindows = false;

        public static bool ParseClass = true;

        public static bool ParseWizard = true;


    }
}
