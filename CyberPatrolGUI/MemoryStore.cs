using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class MemoryStore
    // Stores user name and topics discussed during the session
    {
        
            public string UserName { get; set; }
            public string FavouriteTopic { get; set; }
            public string LastTopic { get; set; }
            public List<string> TopicsDiscussed { get; set; }
                = new List<string>();

            // Task assistant state
            public bool WaitingForReminder { get; set; }
            public string PendingTaskTitle { get; set; }
            public string PendingTaskDescription { get; set; }

            public void RememberTopic(string topic)
            {
                if (!TopicsDiscussed.Contains(topic))
                    TopicsDiscussed.Add(topic);
                LastTopic = topic;
                FavouriteTopic = topic;
            }
        }
    }

        
    

