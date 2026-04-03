using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberPatrol
{
    internal class ConsoleUI
    {
        
            public static void DrawBorder()
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  ╔══════════════════════════════════════════════════════════╗");
                Console.WriteLine("  ║                                                          ║");
                Console.WriteLine("  ║           CYBERBOT CYBERPATROL — CYBERSECURITY ASSISTANT          ║");
                Console.WriteLine("  ║                                                          ║");
                Console.WriteLine("  ╚══════════════════════════════════════════════════════════╝");
                Console.ResetColor();
            }

            public static void DrawDivider()
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n  ────────────────────────────────────────────────────────────\n");
                Console.ResetColor();
            }

            public static void DrawSectionHeader(string title)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n  ┌─ {title.ToUpper()} ─");
                Console.ResetColor();
            }

            public static void ShowLoadingBar()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n  Initialising CyberBot SA ");

                for (int i = 0; i < 20; i++)
                {
                    Console.Write("█");
                    Thread.Sleep(50);
                }

                Console.WriteLine(" Done!\n");
                Console.ResetColor();
            }

            public static void ShowStartupSequence()
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string[] steps = {
                "  [✔] Loading cybersecurity knowledge base...",
                "  [✔] Initialising response engine...",
                "  [✔] Setting up secure session...",
                "  [✔] CyberBot SA is ready!"
            };

                foreach (string step in steps)
                {
                    Console.WriteLine(step);
                    Thread.Sleep(400);
                }

                Console.ResetColor();
                Console.WriteLine();
            }

            public static void PrintWarning(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  ⚠  {message}");
                Console.ResetColor();
            }

            public static void PrintSuccess(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  ✔  {message}");
                Console.ResetColor();
            }

            public static void PrintInfo(string message)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  ℹ  {message}");
                Console.ResetColor();
            }
        }
    }

