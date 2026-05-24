using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrol
{
    internal class DisplayHelper
    {
            public static void ShowLogo()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
  ██████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗  ██████╗ ████████╗
 ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝
 ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ██████╔╝██║   ██║   ██║   
 ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ██╔══██╗██║   ██║   ██║   
 ╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ██████╔╝╚██████╔╝   ██║   
  ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═════╝  ╚═════╝    ╚═╝   
");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@" ██████╗██╗   ██╗██████╗ ███████╗██████╗ ██████╗  █████╗ ████████╗██████╗  ██████╗ ██╗     
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔═══██╗██║     
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝██████╔╝███████║   ██║   ██████╔╝██║   ██║██║     
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗██╔═══╝ ██╔══██║   ██║   ██╔══██╗██║   ██║██║     
╚██████╗   ██║   ██████╔╝███████╗██║  ██║██║     ██║  ██║   ██║   ██║  ██║╚██████╔╝███████╗
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                                           ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ============================================================");
                Console.WriteLine("     Your most trusted guide to staying safe onilne  ");
                Console.WriteLine("  ============================================================");
                Console.ResetColor();
            }
        }
    }

