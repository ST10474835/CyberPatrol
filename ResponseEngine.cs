using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrol
{
    internal class ResponseEngine
    {
        
            public static string GetResponse(string input, string userName)
            {
                // General conversation
                if (input.Contains("how are you"))
                    return $"I'm running smoothly and ready to help you stay safe online, {userName}!";

                if (input.Contains("what is your purpose") || input.Contains("your purpose"))
                    return $"My purpose is to educate South African citizens like yourself, {userName}, on cybersecurity threats and how to avoid them. I cover topics like phishing, password safety, and safe browsing.";

                if (input.Contains("what can i ask") || input.Contains("what can you do") || input.Contains("help"))
                    return $"Great question, {userName}! You can ask me about:\n\n" +
                           "     - Password safety\n" +
                           "     - Phishing scams\n" +
                           "     - Safe browsing\n" +
                           "     - Social engineering\n" +
                           "     - Malware and viruses\n" +
                           "     - Two-factor authentication\n" +
                           "     - Public Wi-Fi safety";

                if (input.Contains("your name") || input.Contains("who are you"))
                    return "I'm CyberBot SA, your cybersecurity awareness assistant, here to help keep you safe in the digital world!";

                if (input.Contains("thank"))
                    return $"You're welcome, {userName}! Staying informed is your best defence online.";

                // Password safety
                if (input.Contains("password"))
                    return "Strong passwords are your first line of defence!\n\n" +
                           "     - Use at least 12 characters\n" +
                           "     - Mix uppercase, lowercase, numbers and symbols\n" +
                           "     - Never reuse passwords across sites\n" +
                           "     - Consider using a password manager like Bitwarden\n" +
                           "     - Never share your password with anyone";

                // Phishing
                if (input.Contains("phishing") || input.Contains("phish") || input.Contains("suspicious email"))
                    return "Phishing is one of the most common cyber threats in South Africa!\n\n" +
                           "     - Be cautious of emails asking for personal or banking info\n" +
                           "     - Check the sender's email address carefully\n" +
                           "     - Never click suspicious links — hover to preview the URL first\n" +
                           "     - Legitimate organisations will never ask for passwords via email\n" +
                           "     - When in doubt, contact the organisation directly";

                // Safe browsing
                if (input.Contains("browsing") || input.Contains("safe browsing") || input.Contains("website"))
                    return "Safe browsing habits protect you from many online threats!\n\n" +
                           "     - Always check for HTTPS and a padlock icon in the address bar\n" +
                           "     - Avoid downloading files from untrusted websites\n" +
                           "     - Keep your browser and plugins updated\n" +
                           "     - Use a reputable browser like Chrome or Firefox\n" +
                           "     - Consider installing an ad blocker to avoid malicious ads";

                // Social engineering
                if (input.Contains("social engineering") || input.Contains("manipulation"))
                    return "Social engineering tricks people into revealing confidential information.\n\n" +
                           "     - Be sceptical of unsolicited calls or messages\n" +
                           "     - Never give out personal info to unverified callers\n" +
                           "     - Attackers often impersonate banks, SARS, or IT support\n" +
                           "     - Always verify the identity of the person contacting you\n" +
                           "     - Trust your instincts — if it feels wrong, it probably is";

                // Malware
                if (input.Contains("malware") || input.Contains("virus") || input.Contains("ransomware"))
                    return "Malware is malicious software designed to damage or gain unauthorised access.\n\n" +
                           "     - Install reputable antivirus software and keep it updated\n" +
                           "     - Never open email attachments from unknown senders\n" +
                           "     - Avoid pirated software — it often contains hidden malware\n" +
                           "     - Back up your data regularly in case of ransomware attacks\n" +
                           "     - Be cautious of USB drives from unknown sources";

                // Two-factor authentication
                if (input.Contains("two factor") || input.Contains("2fa") || input.Contains("authentication"))
                    return "Two-factor authentication (2FA) adds an extra layer of security!\n\n" +
                           "     - Enable 2FA on all important accounts (email, banking, social media)\n" +
                           "     - Use an authenticator app like Google Authenticator\n" +
                           "     - SMS-based 2FA is better than nothing but can be intercepted\n" +
                           "     - Never share your 2FA codes with anyone\n" +
                           "     - Most South African banks now support 2FA — use it!";

                // Public Wi-Fi
                if (input.Contains("wifi") || input.Contains("wi-fi") || input.Contains("public network"))
                    return "Public Wi-Fi in places like malls and cafes can be risky!\n\n" +
                           "     - Avoid accessing banking or sensitive accounts on public Wi-Fi\n" +
                           "     - Use a VPN to encrypt your connection\n" +
                           "     - Turn off auto-connect to Wi-Fi networks\n" +
                           "     - Verify the network name with staff before connecting\n" +
                           "     - Attackers can set up fake hotspots with similar names";

                // Default fallback
                return $"I didn't quite understand that, {userName}. Could you rephrase? " +
                       "You can type 'help' to see what topics I can assist you with.";
            }
        }
    }

