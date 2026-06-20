using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class ActivityLog
   
        {
            // Stores last 10 actions with timestamps
            private static List<string> log = new List<string>();

            public static void AddEntry(string action)
            {
                string entry =
                    "[" + DateTime.Now.ToString("HH:mm:ss") +
                    "] " + action;
                log.Add(entry);

                // Keep only last 10 entries
                if (log.Count > 10)
                    log.RemoveAt(0);
            }

            public static string GetLog()
            {
                if (log.Count == 0)
                    return "  ℹ  No activity recorded yet.";

                string result =
                    "  ℹ  Here is a summary of recent actions:\n\n";
                for (int i = 0; i < log.Count; i++)
                {
                    result += "     " + (i + 1) +
                        ". " + log[i] + "\n";
                }
                return result;
            }

            public static void Clear()
            {
            log.Clear();
            }
        }
    }


