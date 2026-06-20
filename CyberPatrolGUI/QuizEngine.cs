using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class QuizEngine
    {
       
    
        public class QuizQuestion
        {
            public string Question { get; set; }
            public List<string> Options { get; set; }
            public int CorrectIndex { get; set; }
            public string Explanation { get; set; }
        }

     
        
            public static List<QuizQuestion> Questions =
                new List<QuizQuestion>
            {
            new QuizQuestion {
                Question = "What should you do if you receive " +
                    "an email asking for your password?",
                Options = new List<string> {
                    "A) Reply with your password",
                    "B) Delete the email",
                    "C) Report the email as phishing",
                    "D) Ignore it" },
                CorrectIndex = 2,
                Explanation = "Always report phishing emails. " +
                    "Legitimate organisations never ask for " +
                    "passwords via email."
            },
            new QuizQuestion {
                Question = "True or False: Using the same " +
                    "password for all accounts is safe.",
                Options = new List<string> {
                    "A) True",
                    "B) False" },
                CorrectIndex = 1,
                Explanation = "False! If one account is hacked, " +
                    "all your accounts become vulnerable."
            },
            new QuizQuestion {
                Question = "What does HTTPS mean in a website " +
                    "address?",
                Options = new List<string> {
                    "A) The site is fast",
                    "B) The site is secure and encrypted",
                    "C) The site is free",
                    "D) The site is popular" },
                CorrectIndex = 1,
                Explanation = "HTTPS means the connection is " +
                    "encrypted — always look for it before " +
                    "entering personal info."
            },
            new QuizQuestion {
                Question = "What is phishing?",
                Options = new List<string> {
                    "A) A type of malware",
                    "B) A trick to steal your personal info",
                    "C) A safe browsing technique",
                    "D) A type of firewall" },
                CorrectIndex = 1,
                Explanation = "Phishing tricks you into giving " +
                    "personal information by pretending to be " +
                    "a trusted source."
            },
            new QuizQuestion {
                Question = "True or False: Public Wi-Fi is " +
                    "always safe to use for banking.",
                Options = new List<string> {
                    "A) True",
                    "B) False" },
                CorrectIndex = 1,
                Explanation = "False! Public Wi-Fi is risky. " +
                    "Always use a VPN or mobile data for " +
                    "banking."
            },
            new QuizQuestion {
                Question = "What is two-factor authentication " +
                    "(2FA)?",
                Options = new List<string> {
                    "A) Using two passwords",
                    "B) An extra security step after your password",
                    "C) A type of antivirus",
                    "D) Logging in from two devices" },
                CorrectIndex = 1,
                Explanation = "2FA adds an extra verification " +
                    "step — like a code sent to your phone — " +
                    "making accounts much more secure."
            },
            new QuizQuestion {
                Question = "What should you do before clicking " +
                    "a link in an email?",
                Options = new List<string> {
                    "A) Click it immediately",
                    "B) Hover over it to preview the URL",
                    "C) Forward it to friends",
                    "D) Reply to the sender" },
                CorrectIndex = 1,
                Explanation = "Always hover over links to see " +
                    "the real URL before clicking — this helps " +
                    "spot fake links."
            },
            new QuizQuestion {
                Question = "True or False: Antivirus software " +
                    "protects you from all cyber threats.",
                Options = new List<string> {
                    "A) True",
                    "B) False" },
                CorrectIndex = 1,
                Explanation = "False! Antivirus helps but cannot " +
                    "protect against everything. Safe behaviour " +
                    "is also essential."
            },
            new QuizQuestion {
                Question = "What is social engineering?",
                Options = new List<string> {
                    "A) Building social media profiles",
                    "B) Manipulating people to reveal info",
                    "C) Engineering software for social apps",
                    "D) A type of firewall" },
                CorrectIndex = 1,
                Explanation = "Social engineering manipulates " +
                    "people psychologically to give up " +
                    "confidential information."
            },
            new QuizQuestion {
                Question = "How long should a strong password " +
                    "be?",
                Options = new List<string> {
                    "A) At least 4 characters",
                    "B) At least 6 characters",
                    "C) At least 12 characters",
                    "D) Exactly 8 characters" },
                CorrectIndex = 2,
                Explanation = "A strong password should be at " +
                    "least 12 characters with a mix of " +
                    "uppercase, lowercase, numbers and symbols."
            },
            new QuizQuestion {
                Question = "True or False: You should share " +
                    "your 2FA code with IT support if they " +
                    "ask.",
                Options = new List<string> {
                    "A) True",
                    "B) False" },
                CorrectIndex = 1,
                Explanation = "False! Never share your 2FA code " +
                    "with anyone — real IT support will never " +
                    "ask for it."
            }
            };

            public static int CurrentQuestion = 0;
            public static int Score = 0;
            public static bool IsActive = false;

            public static void StartQuiz()
            {
                CurrentQuestion = 0;
                Score = 0;
                IsActive = true;
            }

            public static string GetCurrentQuestion()
            {
                if (CurrentQuestion >= Questions.Count)
                    return null;

                var q = Questions[CurrentQuestion];
                string display =
                    "  📝 Question " + (CurrentQuestion + 1) +
                    " of " + Questions.Count + ":\n\n" +
                    "  " + q.Question + "\n\n";
                foreach (var opt in q.Options)
                    display += "     " + opt + "\n";
                display +=
                    "\n  Type the letter of your answer (A/B/C/D):";
                return display;
            }

            public static string AnswerQuestion(string answer)
            {
                if (CurrentQuestion >= Questions.Count)
                    return null;

                var q = Questions[CurrentQuestion];
                string letter = answer.Trim().ToUpper();

                int answerIndex = -1;
                if (letter == "A") answerIndex = 0;
                else if (letter == "B") answerIndex = 1;
                else if (letter == "C") answerIndex = 2;
                else if (letter == "D") answerIndex = 3;

                if (answerIndex == -1)
                    return "  ⚠  Please type A, B, C or D only.";

                string result;
                if (answerIndex == q.CorrectIndex)
                {
                    Score++;
                    result = "  ✔  Correct! Well done!\n\n" +
                        "  ℹ  " + q.Explanation;
                }
                else
                {
                    string correctLetter = "";
                    if (q.CorrectIndex == 0) correctLetter = "A";
                    else if (q.CorrectIndex == 1) correctLetter = "B";
                    else if (q.CorrectIndex == 2) correctLetter = "C";
                    else if (q.CorrectIndex == 3) correctLetter = "D";

                    result = "  ✗  Incorrect. The correct answer " +
                        "was " + correctLetter + ".\n\n" +
                        "  ℹ  " + q.Explanation;
                }

                CurrentQuestion++;

                if (CurrentQuestion >= Questions.Count)
                {
                    IsActive = false;
                    result += "\n\n" + GetFinalScore();
                    ActivityLog.AddEntry(
                        "Quiz completed — Score: " +
                        Score + "/" + Questions.Count);
                }

                return result;
            }

            public static string GetFinalScore()
            {
                string feedback;
                if (Score >= 9)
                    feedback = "🏆 Outstanding! You are a " +
                        "cybersecurity pro!";
                else if (Score >= 7)
                    feedback = "✔ Great job! You know your " +
                        "cybersecurity well!";
                else if (Score >= 5)
                    feedback = "ℹ Not bad! Keep learning to " +
                        "stay safe online.";
                else
                    feedback = "⚠ Keep learning! Cybersecurity " +
                        "knowledge keeps you safe.";

                return
                    "  ─────────────────────────────────────\n" +
                    "  🎯 QUIZ COMPLETE!\n" +
                    "  Your score: " + Score + " out of " +
                    Questions.Count + "\n" +
                    "  " + feedback + "\n" +
                    "  ─────────────────────────────────────";
            }
        }
    }


