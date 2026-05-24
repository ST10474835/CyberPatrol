namespace CyberPatrolGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)

            {
                if (disposing && (components != null))
                    components.Dispose();
                base.Dispose(disposing);
            }
            

            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblAscii = new System.Windows.Forms.Label();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.lblBotName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAscii
            // 
            this.lblAscii.BackColor = System.Drawing.Color.Black;
            this.lblAscii.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold);
            this.lblAscii.ForeColor = System.Drawing.Color.Cyan;
            this.lblAscii.Location = new System.Drawing.Point(0, 0);
            this.lblAscii.Name = "lblAscii";
            this.lblAscii.Size = new System.Drawing.Size(950, 120);
            this.lblAscii.TabIndex = 0;
            this.lblAscii.Text = resources.GetString("lblAscii.Text");
            this.lblAscii.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CyberBot profile picture displayed on the form
            // 
            this.picProfile.BackColor = System.Drawing.Color.Black;
            this.picProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProfile.Location = new System.Drawing.Point(10, 128);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(80, 80);
            this.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfile.TabIndex = 1;
            this.picProfile.TabStop = false;
            // 
            // lblBotName
            // 
            this.lblBotName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.lblBotName.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblBotName.ForeColor = System.Drawing.Color.Cyan;
            this.lblBotName.Location = new System.Drawing.Point(98, 128);
            this.lblBotName.Name = "lblBotName";
            this.lblBotName.Size = new System.Drawing.Size(300, 80);
            this.lblBotName.TabIndex = 2;
            this.lblBotName.Text = "  CyberBot SA\n  Cybersecurity Assistant";
            this.lblBotName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitle.Location = new System.Drawing.Point(0, 212);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(950, 38);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.Black;
            this.rtbChat.ForeColor = System.Drawing.Color.Cyan;
            this.rtbChat.Location = new System.Drawing.Point(0, 254);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChat.Size = new System.Drawing.Size(935, 400);
            this.rtbChat.TabIndex = 4;
            this.rtbChat.Text = "";
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Location = new System.Drawing.Point(0, 663);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(805, 22);
            this.txtInput.TabIndex = 5;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(815, 660);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 37);
            this.btnSend.TabIndex = 6;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(950, 715);
            this.Controls.Add(this.lblAscii);
            this.Controls.Add(this.picProfile);
            this.Controls.Add(this.lblBotName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnSend);
            this.Name = "Form1";
            this.Text = "CyberBot SA — CyberPatrol";
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            private System.Windows.Forms.Label lblAscii;
            private System.Windows.Forms.PictureBox picProfile;
            private System.Windows.Forms.Label lblBotName;
            private System.Windows.Forms.Label lblTitle;
            private System.Windows.Forms.RichTextBox rtbChat;
            private System.Windows.Forms.TextBox txtInput;
            private System.Windows.Forms.Button btnSend;
        }
    }

    


