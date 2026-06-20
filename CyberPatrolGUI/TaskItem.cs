using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class TaskItem
    {
        
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string ReminderDate { get; set; }
            public bool IsCompleted { get; set; }
            public DateTime CreatedAt { get; set; }

            public override string ToString()
            {
                string status = IsCompleted ? "✔ Done" : "⏳ Pending";
                string reminder = string.IsNullOrEmpty(ReminderDate)
                    ? "No reminder"
                    : "Reminder: " + ReminderDate;
                return $"[{status}] {Title} — {reminder}";
            }
        }
    }


