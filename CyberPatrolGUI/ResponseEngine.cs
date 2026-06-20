using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class ResponseEngine
  
    {
    
            private static Random random = new Random();
            private static MemoryStore memory;

            private static List<string> phishingResponses =
                new List<string>
            {
            "Be cautious of emails asking for personal " +
            "information. Scammers disguise themselves as " +
            "trusted organisations.",

            "Never click links in unexpected emails. Rather " +
            "type the website address directly into your browser.",

            "Check the sender's email address carefully — " +
            "scammers use addresses that look almost correct " +
            "but have small differences.",

            "Legitimate banks and government departments will " +
            "NEVER ask for your password or PIN via email or SMS."
            };

            private static List<string> passwordResponses =
                new List<string>
            {
            "Use at least 12 characters mixing uppercase, " +
            "lowercase, numbers and symbols. Never reuse " +
            "passwords across sites.",

            "Consider using a password manager like Bitwarden " +
            "— it generates and stores strong passwords safely.",

            "Never share your password with anyone, including " +
            "IT support. A real IT person will never ask for " +
            "your password.",

            "Avoid using personal details like your name, " +
            "birthday or pet's name — these are easy for " +
            "hackers to guess."
            };

            private static Dictionary<string, string>
                keywordResponses =
                new Dictionary<string, string>
            {
            { "browsing",
                "Safe browsing habits protect you!\n\n" +
                "     - Always check for HTTPS in the address bar\n"+
                "     - Avoid downloading from untrusted websites\n" +
                "     - Keep your browser updated\n" +
                "     - Consider installing an ad blocker" },
            { "social engineering",
                "Social engineering tricks people into revealing " +
                "confidential information.\n\n" +
                "     - Be sceptical of unsolicited calls\n" +
                "     - Attackers impersonate banks or SARS\n" +
                "     - Always verify who contacts you" },
            { "malware",
                "Malware is designed to damage your device.\n\n" +
                "     - Install reputable antivirus software\n" +
                "     - Never open attachments from unknown senders\n"+
                "     - Back up your data regularly" },
            { "2fa",
                "Two-factor authentication adds extra security!\n\n"+
                "     - Enable 2FA on all important accounts\n" +
                "     - Use Google Authenticator or similar\n" +
                "     - Never share your 2FA codes with anyone" },
            { "wifi",
                "Public Wi-Fi can be very risky!\n\n" +
                "     - Avoid banking on public Wi-Fi\n" +
                "     - Use a VPN to encrypt your connection\n" +
                "     - Verify the network name with staff first" },
            { "privacy",
                "Privacy is crucial for staying safe online!\n\n" +
                "     - Review your social media privacy settings\n" +
                "     - Limit personal info you share online\n" +
                "     - Use private browsing on shared devices" },
            { "scam",
                "Scams are very common in South Africa!\n\n" +
                "     - If too good to be true, it probably is\n" +
                "     - Never send money to unverified people\n" +
                "     - Report scams to SAPS or your bank" }
            };

            public static void SetMemory(MemoryStore mem)
            {
                memory = mem;
            }

            public static string GetResponse(
                string input, string userName)
            {
                string sentiment = SentimentDetector.Detect(input);
                string prefix =
                    SentimentDetector.GetSentimentPrefix(sentiment);

                // ── Activity log commands ─────────────────────────
                if (input.Contains("show activity log") ||
                    input.Contains("what have you done") ||
                    input.Contains("activity log") ||
                    input.Contains("what have you done for me"))
                {
                    ActivityLog.AddEntry("User viewed activity log");
                    return ActivityLog.GetLog();
                }

                // ── Quiz commands ─────────────────────────────────
                if (input.Contains("start quiz") ||
                    input.Contains("play quiz") ||
                    input.Contains("quiz me") ||
                    input.Contains("take quiz"))
                {
                    QuizEngine.StartQuiz();
                    ActivityLog.AddEntry("Quiz started");
                    return "  🎮 Starting the Cybersecurity Quiz!\n" +
                        "  Answer with A, B, C or D.\n" +
                        "  Type 'quit quiz' to exit anytime.\n\n" +
                        QuizEngine.GetCurrentQuestion();
                }

                if (input == "quit quiz" && QuizEngine.IsActive)
                {
                    QuizEngine.IsActive = false;
                    return "  ℹ  Quiz ended. Type 'start quiz' " +
                        "to try again!";
                }

                if (QuizEngine.IsActive)
                {
                    string result = QuizEngine.AnswerQuestion(input);
                    if (QuizEngine.IsActive)
                        result += "\n\n" +
                            QuizEngine.GetCurrentQuestion();
                    return result;
                }

                // ── Task commands — waiting for reminder ──────────
                if (memory != null && memory.WaitingForReminder)
                {
                    memory.WaitingForReminder = false;
                    string reminder = "";

                    if (input.Contains("yes") ||
                        input.Contains("remind"))
                    {
                        reminder = input;
                        var task = new TaskItem
                        {
                            Title = memory.PendingTaskTitle,
                            Description =
                                memory.PendingTaskDescription,
                            ReminderDate = reminder
                        };
                        DatabaseHelper.AddTask(task);
                        ActivityLog.AddEntry(
                            "Task added with reminder: " +
                            memory.PendingTaskTitle +
                            " — " + reminder);
                        memory.PendingTaskTitle = null;
                        memory.PendingTaskDescription = null;
                        return "  ✔  Got it! I will remind you: " +
                            reminder + "\n" +
                            "  Task saved to your database!";
                    }
                    else
                    {
                        var task = new TaskItem
                        {
                            Title = memory.PendingTaskTitle,
                            Description =
                                memory.PendingTaskDescription,
                            ReminderDate = ""
                        };
                        DatabaseHelper.AddTask(task);
                        ActivityLog.AddEntry(
                            "Task added without reminder: " +
                            memory.PendingTaskTitle);
                        memory.PendingTaskTitle = null;
                        memory.PendingTaskDescription = null;
                        return "  ✔  Task saved without a reminder.";
                    }
                }

                // ── Add task NLP detection ────────────────────────
                if (input.Contains("add task") ||
                    input.Contains("new task") ||
                    input.Contains("create task") ||
                    input.Contains("add a task") ||
                    (input.Contains("remind me") &&
                     input.Contains("to")))
                {
                    string taskTitle = input;
                    taskTitle = taskTitle
                        .Replace("add task", "")
                        .Replace("add a task", "")
                        .Replace("new task", "")
                        .Replace("create task", "")
                        .Replace("remind me to", "")
                        .Replace("remind me", "")
                        .Trim();

                    if (string.IsNullOrWhiteSpace(taskTitle))
                        taskTitle = "Cybersecurity task";

                    // Capitalise first letter
                    taskTitle = char.ToUpper(taskTitle[0]) +
                        taskTitle.Substring(1);

                    memory.PendingTaskTitle = taskTitle;
                    memory.PendingTaskDescription =
                        "Cybersecurity task: " + taskTitle;
                    memory.WaitingForReminder = true;

                    ActivityLog.AddEntry(
                        "Task creation started: " + taskTitle);

                    return "  ✔  Task added: '" + taskTitle +
                        "'\n  Description: Cybersecurity task: " +
                        taskTitle + "\n\n" +
                        "  Would you like a reminder? " +
                        "If yes type when (e.g. 'in 3 days' or " +
                        "'tomorrow'). If no type 'no'.";
                }

                // ── View tasks ────────────────────────────────────
                if (input.Contains("view tasks") ||
                    input.Contains("show tasks") ||
                    input.Contains("my tasks") ||
                    input.Contains("list tasks"))
                {
                    var tasks = DatabaseHelper.GetAllTasks();
                    if (tasks.Count == 0)
                        return "  ℹ  You have no tasks yet.\n" +
                            "  Type 'add task' followed by your " +
                            "task to add one!";

                    string result =
                        "  ℹ  Here are your tasks:\n\n";
                    foreach (var t in tasks)
                        result += "     [ID:" + t.Id + "] " +
                            t.ToString() + "\n";
                    result +=
                        "\n  To complete: type 'complete task " +
                        "[ID]'\n" +
                        "  To delete: type 'delete task [ID]'";
                    ActivityLog.AddEntry("User viewed task list");
                    return result;
                }

                // ── Complete task ─────────────────────────────────
                if (input.Contains("complete task"))
                {
                    string[] parts = input.Split(' ');
                    foreach (var part in parts)
                    {
                        if (int.TryParse(part, out int id))
                        {
                            if (DatabaseHelper.CompleteTask(id))
                            {
                                ActivityLog.AddEntry(
                                    "Task " + id +
                                    " marked as complete");
                                return "  ✔  Task " + id +
                                    " marked as complete!";
                            }
                        }
                    }
                    return "  ⚠  Please type the task ID. " +
                        "Example: 'complete task 1'";
                }

                // ── Delete task ───────────────────────────────────
                if (input.Contains("delete task"))
                {
                    string[] parts = input.Split(' ');
                    foreach (var part in parts)
                    {
                        if (int.TryParse(part, out int id))
                        {
                            if (DatabaseHelper.DeleteTask(id))
                            {
                                ActivityLog.AddEntry(
                                    "Task " + id + " deleted");
                                return "  ✔  Task " + id +
                                    " deleted successfully!";
                            }
                        }
                    }
                    return "  ⚠  Please type the task ID. " +
                        "Example: 'delete task 1'";
                }

                // ── Conversation flow ─────────────────────────────
                if (input.Contains("tell me more") ||
                    input.Contains("explain more") ||
                    input.Contains("give me another tip") ||
                    input.Contains("more info"))
                {
                    if (memory != null && memory.LastTopic != null)
                        return "Sure! Here's more on " +
                            memory.LastTopic + ":\n\n" +
                            GetTopicResponse(
                                memory.LastTopic, userName);
                    return "Could you remind me what topic? " +
                        "Type 'help' to see all topics.";
                }

                // ── Memory recall ─────────────────────────────────
                if (input.Contains("what do you remember") ||
                    input.Contains("what did i tell you"))
                {
                    if (memory != null &&
                        memory.FavouriteTopic != null)
                        return "I remember you were interested in " +
                            memory.FavouriteTopic + ", " +
                            userName + "! Want more tips on that?";
                    return "I don't have anything stored yet, " +
                        userName + ". Keep chatting!";
                }

                // ── General responses ─────────────────────────────
                if (input.Contains("how are you"))
                    return prefix + "I'm running smoothly, " +
                        userName + "! Ready to help you stay " +
                        "safe online.";

                if (input.Contains("help") ||
                    input.Contains("what can you do") ||
                    input.Contains("your purpose"))
                    return "Here's what I can help you with, " +
                        userName + ":\n\n" +
                        "  💬 CHAT TOPICS:\n" +
                        "     - Password safety\n" +
                        "     - Phishing scams\n" +
                        "     - Safe browsing\n" +
                        "     - Social engineering\n" +
                        "     - Malware, 2FA, Wi-Fi, Privacy\n\n" +
                        "  📋 TASK ASSISTANT:\n" +
                        "     - 'add task [task name]'\n" +
                        "     - 'view tasks'\n" +
                        "     - 'complete task [ID]'\n" +
                        "     - 'delete task [ID]'\n\n" +
                        "  🎮 QUIZ:\n" +
                        "     - 'start quiz'\n\n" +
                        "  📜 ACTIVITY LOG:\n" +
                        "     - 'show activity log'\n\n" +
                        "  💡 OTHER:\n" +
                        "     - 'tell me more'\n" +
                        "     - 'what do you remember'\n" +
                        "     - 'exit'";

                if (input.Contains("who are you") ||
                    input.Contains("your name"))
                    return "I'm CyberBot SA — your cybersecurity " +
                        "awareness assistant!";

                if (input.Contains("thank"))
                    return "You're welcome, " + userName +
                        "! Staying informed is your best defence.";

                // ── Keyword responses ─────────────────────────────
                if (input.Contains("phish") ||
                    input.Contains("suspicious email"))
                {
                    if (memory != null)
                        memory.RememberTopic("phishing");
                    ActivityLog.AddEntry(
                        "User asked about phishing");
                    return prefix + phishingResponses[
                        random.Next(phishingResponses.Count)];
                }

                if (input.Contains("password"))
                {
                    if (memory != null)
                        memory.RememberTopic("password safety");
                    ActivityLog.AddEntry(
                        "User asked about passwords");
                    return prefix + passwordResponses[
                        random.Next(passwordResponses.Count)];
                }

                foreach (var keyword in keywordResponses.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        if (memory != null)
                            memory.RememberTopic(keyword);
                        ActivityLog.AddEntry(
                            "User asked about " + keyword);
                        return prefix + keywordResponses[keyword];
                    }
                }

                // ── Default fallback ──────────────────────────────
                return "I didn't quite understand that, " +
                    userName + ". Could you rephrase?\n" +
                    "Type 'help' to see available topics.";
            }

            private static string GetTopicResponse(
                string topic, string userName)
            {
                if (topic.Contains("phish"))
                    return phishingResponses[
                        random.Next(phishingResponses.Count)];
                if (topic.Contains("password"))
                    return passwordResponses[
                        random.Next(passwordResponses.Count)];
                foreach (var keyword in keywordResponses.Keys)
                    if (topic.Contains(keyword))
                        return keywordResponses[keyword];
                return "Type 'help' to see all topics!";
            }
        }
    }

        
    

