using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrol
{
    internal class AudioPlayer
    {
            public static void PlayGreeting()
            {
                try
                {
                    string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CYBERPATROL ");

                    if (File.Exists(@"C:\Users\Student\source\repos\CyberPatrol\CyberPatrol\CYBERPATROL .wav"))
                    {
                        SoundPlayer player = new SoundPlayer(@"C:\Users\Student\source\repos\CyberPatrol\CyberPatrol\CYBERPATROL .wav");
                        player.PlaySync();
                    }
                    else
                    {
                        Console.WriteLine("[Voice greeting file not found]");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Could not play audio: {ex.Message}]");
                }
            }
        }
    }

