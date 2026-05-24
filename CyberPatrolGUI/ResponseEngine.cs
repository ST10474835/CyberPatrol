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

            // Random response lists
            private static List<string> phishingResponses = new List<string>
        {
            "Be cautious of emails asking for personal information. " +
            "Scammers often disguise themselves as trusted organisations.",

            "Never click links in unexpected emails. " +
            "Rather type the website address directly into your browser.",

            "Check the sender's email address carefully — scammers use " +
            "addresses that look almost correct but have small differences.",

            "Legitimate banks and government departments will NEVER ask " +
            "for your password or PIN via email or SMS."
        };

            private static List<string> passwordResponses = new List<string>
        {
            "Use at least 12 characters mixing uppercase, lowercase, " +
            "numbers and symbols. Never reuse passwords across sites.",

            "Consider using a password manager like Bitwarden — it " +
            "generates and stores strong passwords for you safely.",

            "Never share your password with anyone, including IT support. " +
            "A real IT person will never ask for your password.",

            "Avoid using personal details like your name, birthday or " +
            "pet's name — these are easy for hackers to guess."
        };

            private static Dictionary<string, string> keywordResponses =
                new Dictionary<string, string>
            {
            { "browsing", "Safe browsing habits protect you from many threats!\n\n" +
                "     - Always check for HTTPS in the address bar\n" +
                "     - Avoid downloading files from untrusted websites\n" +
                "     - Keep your browser updated\n" +
                "     - Consider installing an ad blocker" },

            { "social engineering", "Social engineering tricks people into " +
                "revealing confidential information.\n\n" +
                "     - Be sceptical of unsolicited calls or messages\n" +
                "     - Attackers often impersonate banks or SARS\n" +
                "     - Always verify the identity of who contacts you" },

            { "malware", "Malware is malicious software designed to damage " +
                "or gain unauthorised access.\n\n" +
                "     - Install reputable antivirus software\n" +
                "     - Never open attachments from unknown senders\n" +
                "     - Back up your data regularly" },

            { "2fa", "Two-factor authentication adds an extra layer of security!\n\n" +
                "     - Enable 2FA on all important accounts\n" +
                "     - Use an authenticator app like Google Authenticator\n" +
                "     - Never share your 2FA codes with anyone" },

            { "wifi", "Public Wi-Fi can be very risky!\n\n" +
                "     - Avoid banking on public Wi-Fi\n" +
                "     - Use a VPN to encrypt your connection\n" +
                "     - Verify the network name with staff before connecting" },

            { "privacy", "Privacy is a crucial part of staying safe online!\n\n" +
                "     - Review your social media privacy settings regularly\n" +
                "     - Limit what personal info you share online\n" +
                "     - Use private browsing when on shared devices" },

            { "scam", "Scams are unfortunately very common in South Africa!\n\n" +
                "     - If it sounds too good to be true, it probably is\n" +
                "     - Never send money to someone you haven't met\n" +
                "     - Report scams to the SAPS or your bank immediately" }
            };

            public static void SetMemory(MemoryStore mem)
            {
                memory = mem;
            }

            public static string GetResponse(string input, string userName)
            {
                // Detect sentiment first
                string sentiment = SentimentDetector.Detect(input);
                string sentimentPrefix = SentimentDetector.GetSentimentPrefix(sentiment);

                // Conversation flow — follow-up handling
                if (input.Contains("tell me more") || input.Contains("explain more") ||
                    input.Contains("give me another tip") || input.Contains("more info"))
                {
                    if (memory != null && memory.LastTopic != null)
                        return $"Sure! Here's more on {memory.LastTopic}:\n\n" +
                               GetTopicResponse(memory.LastTopic, userName);
                    else
                        return "Could you remind me what topic you'd like more info on? " +
                               "Type 'help' to see all available topics.";
                }

                // Memory recall
                if (input.Contains("what do you remember") ||
                    input.Contains("what did i tell you"))
                {
                    if (memory != null && memory.FavouriteTopic != null)
                        return $"I remember that you were interested in " +
                               $"{memory.FavouriteTopic}, {userName}! " +
                               $"Would you like more tips on that?";
                    else
                        return $"I don't have anything stored yet, {userName}. " +
                               "Keep chatting and I'll remember your interests!";
                }

                // General conversation
                if (input.Contains("how are you"))
                    return sentimentPrefix + $"I'm running smoothly and ready to " +
                           $"help you stay safe online, {userName}!";

                if (input.Contains("your purpose") || input.Contains("what can you do")
                    || input.Contains("help"))
                    return $"Great question, {userName}! You can ask me about:\n\n" +
                           "     - Password safety\n" +
                           "     - Phishing scams\n" +
                           "     - Safe browsing\n" +
                           "     - Social engineering\n" +
                           "     - Malware and viruses\n" +
                           "     - Two-factor authentication (2FA)\n" +
                           "     - Public Wi-Fi safety\n" +
                           "     - Privacy\n" +
                           "     - Scams";

                if (input.Contains("your name") || input.Contains("who are you"))
                    return "I'm CyberBot SA, your cybersecurity awareness assistant!";

                if (input.Contains("thank"))
                    return $"You're welcome, {userName}! " +
                           "Staying informed is your best defence online.";

                // Keyword topics with random responses
                if (input.Contains("phish") || input.Contains("suspicious email"))
                {
                    if (memory != null) memory.RememberTopic("phishing");
                    return sentimentPrefix + phishingResponses[random.Next(phishingResponses.Count)];
                }

                if (input.Contains("password"))
                {
                    if (memory != null) memory.RememberTopic("password safety");
                    return sentimentPrefix + passwordResponses[random.Next(passwordResponses.Count)];
                }

                // Dictionary-based keyword responses
                foreach (var keyword in keywordResponses.Keys)
                {
                    if (input.Contains(keyword))
                    {
                        if (memory != null) memory.RememberTopic(keyword);
                        return sentimentPrefix + keywordResponses[keyword];
                    }
                }

                // Default fallback
                return $"I didn't quite understand that, {userName}. " +
                       "Could you rephrase? Type 'help' to see available topics.";
            }

            private static string GetTopicResponse(string topic, string userName)
            {
                if (topic.Contains("phish"))
                    return phishingResponses[random.Next(phishingResponses.Count)];
                if (topic.Contains("password"))
                    return passwordResponses[random.Next(passwordResponses.Count)];
                foreach (var keyword in keywordResponses.Keys)
                    if (topic.Contains(keyword))
                        return keywordResponses[keyword];

                return "Type 'help' to see all the topics I can help with!";
            }
        }
    }

