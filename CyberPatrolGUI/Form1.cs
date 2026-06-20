   using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberPatrolGUI
{
    // Part 3 complete — Task Assistant Quiz NLP and Activity Log integrated
    public partial class Form1 : Form
    {
            private MemoryStore memory = new MemoryStore();
            private bool nameEntered = false;

            public Form1()
            {
                InitializeComponent();
                ApplyTheme();
                PlayVoiceGreeting();
                ShowWelcomeMessage();
            }

            private void ApplyTheme()
            {
                this.BackColor = Color.Black;
                this.Text = "CyberBot SA — CyberPatrol";
                this.Size = new Size(950, 780);
                this.MinimumSize = new Size(950, 780);

                lblAscii.ForeColor = Color.Cyan;
                lblAscii.BackColor = Color.Black;
                lblAscii.Font = new Font("Consolas", 7,
                    FontStyle.Bold);

                lblTitle.ForeColor = Color.Cyan;
                lblTitle.BackColor = Color.FromArgb(10, 10, 30);
                lblTitle.Font = new Font("Consolas", 11,
                    FontStyle.Bold);
                lblTitle.Text =
                    "  🔒 CYBERBOT SA — CYBERPATROL  |  " +
                    "Cybersecurity Awareness Assistant";

                picProfile.Size = new Size(80, 80);
                picProfile.SizeMode = PictureBoxSizeMode.Zoom;
                picProfile.BackColor = Color.Black;
                picProfile.BorderStyle = BorderStyle.FixedSingle;

                try
                {
                    string imgPath =
                        @"C:\Users\Student\source\repos\" +
                        @"CyberPatrol\CyberPatrolGUI\cyberbot.png";
                    if (File.Exists(@"C:\Users\Student\source\repos\CyberPatrol\CyberPatrolGUI\cyberbot.png.png"))
                        picProfile.Image = Image.FromFile(@"C:\Users\Student\source\repos\CyberPatrol\CyberPatrolGUI\cyberbot.png.png");
                }
                catch { }

                lblBotName.ForeColor = Color.Cyan;
                lblBotName.BackColor = Color.FromArgb(10, 10, 30);
                lblBotName.Font = new Font("Consolas", 10,
                    FontStyle.Bold);
                lblBotName.Text =
                    "  CyberBot SA\n  Cybersecurity Assistant";

                rtbChat.BackColor = Color.Black;
                rtbChat.ForeColor = Color.Cyan;
                rtbChat.Font = new Font("Consolas", 11);
                rtbChat.ReadOnly = true;
                rtbChat.BorderStyle = BorderStyle.FixedSingle;

                txtInput.BackColor = Color.FromArgb(15, 15, 30);
                txtInput.ForeColor = Color.White;
                txtInput.Font = new Font("Consolas", 11);
                txtInput.BorderStyle = BorderStyle.FixedSingle;

                btnSend.BackColor = Color.DarkCyan;
                btnSend.ForeColor = Color.White;
                btnSend.Font = new Font("Consolas", 11,
                    FontStyle.Bold);
                btnSend.FlatStyle = FlatStyle.Flat;
                btnSend.FlatAppearance.BorderColor = Color.Cyan;
                btnSend.Text = "Send ▶";
            }

            private void PlayVoiceGreeting()
            {
                try
                {
                    string path =
                        @"C:\Users\Student\source\repos\" +
                        @"CyberPatrol\CyberPatrol\CYBERPATROL .wav";
                    if (File.Exists(path))
                    {
                        SoundPlayer player = new SoundPlayer(path);
                        player.Play();
                    }
                }
                catch { }
            }

            private void ShowWelcomeMessage()
            {
                AppendDivider();
                AppendBot(
                    "  ℹ  Type 'help' to see all available " +
                    "features.\n" +
                    "  ℹ  Type 'start quiz' to test your " +
                    "cybersecurity knowledge.\n" +
                    "  ℹ  Type 'add task' to manage your " +
                    "cybersecurity tasks.\n" +
                    "  ℹ  Type 'show activity log' to see " +
                    "recent actions.\n" +
                    "  ℹ  Type 'exit' to end the session.",
                    Color.Cyan);
                AppendDivider();
                AppendBot(
                    "  Please enter your name to get started:",
                    Color.Yellow);
            }

            private void btnSend_Click(
                object sender, EventArgs e)
            {
                ProcessInput();
            }

            private void txtInput_KeyDown(
                object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    ProcessInput();
                }
            }

            private void ProcessInput()
            {
                string input = txtInput.Text.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    AppendWarning(
                        "Input cannot be empty. " +
                        "Please type something.");
                    return;
                }

                txtInput.Clear();

                if (!nameEntered)
                {
                    memory.UserName = input;
                    ResponseEngine.SetMemory(memory);
                    nameEntered = true;

                    AppendUser(input);
                    AppendDivider();
                    AppendBot(
                        "  Hello, " + memory.UserName +
                        "! Great to have you here. 🎉",
                        Color.LightGreen);
                    AppendBot(
                        "  I am CyberBot SA, your cybersecurity" +
                        " awareness assistant.",
                        Color.LightGreen);
                    AppendBot(
                        "  Type 'help' to see everything I can " +
                        "do for you!",
                        Color.LightGreen);

                    // Check DB connection
                    if (DatabaseHelper.TestConnection())
                        AppendBot(
                            "  ✔  Task database connected " +
                            "successfully!",
                            Color.LightGreen);
                    else
                        AppendBot(
                            "  ⚠  Database not connected. Tasks " +
                            "will not be saved.\n" +
                            "  Please check MySQL is running.",
                            Color.OrangeRed);

                    AppendDivider();
                    ActivityLog.AddEntry(
                        "Session started for user: " +
                        memory.UserName);
                    return;
                }

                AppendUser(input);

                if (input.ToLower() == "exit")
                {
                    ActivityLog.AddEntry(
                        "Session ended for user: " +
                        memory.UserName);
                    AppendBot(
                        "  Goodbye, " + memory.UserName +
                        "! Stay safe online. 🔒\n" +
                        "  Remember — cybersecurity starts " +
                        "with YOU.",
                        Color.LightGreen);
                    AppendDivider();
                    btnSend.Enabled = false;
                    txtInput.Enabled = false;
                    return;
                }

                string response = ResponseEngine.GetResponse(
                    input.ToLower(), memory.UserName);

                AppendBot(response, Color.Cyan);
                AppendDivider();
            }

            private void AppendBot(string message, Color color)
            {
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.SelectionLength = 0;
                rtbChat.SelectionColor = Color.DarkGray;
                rtbChat.AppendText("\n  [CyberBot SA]\n");
                rtbChat.SelectionColor = color;
                rtbChat.AppendText(message + "\n");
                rtbChat.ScrollToCaret();
            }

            private void AppendUser(string message)
            {
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.SelectionLength = 0;
                rtbChat.SelectionColor = Color.DarkGray;
                rtbChat.AppendText(
                    "\n  [" +
                    (nameEntered ? memory.UserName : "You") +
                    "]\n");
                rtbChat.SelectionColor = Color.Yellow;
                rtbChat.AppendText("  " + message + "\n");
                rtbChat.ScrollToCaret();
            }

            private void AppendWarning(string message)
            {
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.SelectionLength = 0;
                rtbChat.SelectionColor = Color.Red;
                rtbChat.AppendText("\n  ⚠  " + message + "\n");
                rtbChat.ScrollToCaret();
            }

            private void AppendDivider()
            {
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.SelectionLength = 0;
                rtbChat.SelectionColor = Color.DarkCyan;
                rtbChat.AppendText(
                    "\n  ────────────────────────────────" +
                    "────────────────────────\n");
                rtbChat.ScrollToCaret();
            }
        }
    }

        
    


    

    

