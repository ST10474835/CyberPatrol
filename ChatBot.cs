using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberPatrol
{
    internal class ChatBot
    {
     
            private string userName;

            public void Start()
            {
                DisplayWelcomeBanner();
                GetUserName();
                StartConversation();
            }

            private void DisplayWelcomeBanner()
            {
                ConsoleUI.DrawBorder();
                ConsoleUI.DrawDivider();
                ConsoleUI.PrintInfo("Type 'help' at any time to see available topics.");
                ConsoleUI.PrintInfo("Type 'exit' to end the session.");
                ConsoleUI.DrawDivider();
            }

            private void GetUserName()
            {
                bool validName = false;

                while (!validName)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    TypeText("  Please enter your name to get started: ");
                    Console.ResetColor();

                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                      ConsoleUI.PrintWarning("Name cannot be empty. Please try again.\n");
                    }
                    else
                    {
                        userName = input.Trim();
                        validName = true;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                TypeText($"\n  Hello, {userName}! Great to have you here.");
                Console.WriteLine();
                TypeText("  I'm CyberBot SA, your cybersecurity awareness assistant.");
                Console.WriteLine();
                TypeText("  I'm here to help you stay safe online.");
                Console.WriteLine("\n");
                Console.ResetColor();
            }

            private void StartConversation()
            {
                bool running = true;

                ConsoleUI.DrawDivider();

                while (running)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"  {userName}: ");
                    Console.ResetColor();

                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                      ConsoleUI.PrintWarning("Input cannot be empty. Please type a question.\n");
                        continue;
                    }

                    input = input.Trim().ToLower();

                    if (input == "exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        TypeText($"\n  Goodbye, {userName}! Stay safe online. Remember, cybersecurity starts with YOU.\n");
                        Console.ResetColor();
                        running = false;
                    }
                    else
                    {
                        string response = ResponseEngine.GetResponse(input, userName);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypeText($"\n  CyberBot: {response}\n");
                        Console.ResetColor();
                        ConsoleUI.DrawDivider();
                    }
                }
            }

            public static void TypeText(string message, int delay = 30)
            {
                foreach (char c in message)
                {
                    Console.Write(c);
                    Thread.Sleep(delay);
                }
            }
        }
    }


