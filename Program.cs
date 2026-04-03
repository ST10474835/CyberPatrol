using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrol
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Title = "CyberBot SA - Cybersecurity Awareness Assistant";
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                DisplayHelper.ShowLogo();
                AudioPlayer.PlayGreeting();

            ConsoleUI.ShowLoadingBar();
            ConsoleUI.ShowStartupSequence();
            ConsoleUI.DrawDivider();

                ChatBot bot = new ChatBot();
                bot.Start();
            }
        }
    }

    

