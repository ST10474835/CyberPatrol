using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class MemoryStore
   
        {
            public string UserName { get; set; }
            public string FavouriteTopic { get; set; }
            public string LastTopic { get; set; }
            public List<string> TopicsDiscussed { get; set; } = new List<string>();

            public void RememberTopic(string topic)
            {
                if (!TopicsDiscussed.Contains(topic))
                    TopicsDiscussed.Add(topic);
                LastTopic = topic;
                FavouriteTopic = topic; // most recent = favourite
            }
        }
    }

