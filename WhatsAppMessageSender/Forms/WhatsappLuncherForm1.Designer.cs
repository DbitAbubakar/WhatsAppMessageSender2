using System.Drawing;

namespace WhatsAppMessageSender.Forms
{
    partial class WhatsappLuncherForm1
    {

        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        // Clean up any resources being used.
        // <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhatsappLuncherForm1));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtChatName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.resumbtn = new System.Windows.Forms.PictureBox();
            this.sndbtn = new System.Windows.Forms.PictureBox();
            this.stopbtn = new System.Windows.Forms.PictureBox();
            this.Launchericon = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.resumbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sndbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Launchericon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(66, 283);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(377, 122);
            this.txtMessage.TabIndex = 3;
            // 
            // txtChatName
            // 
            this.txtChatName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatName.Enabled = false;
            this.txtChatName.Location = new System.Drawing.Point(70, 108);
            this.txtChatName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtChatName.Multiline = true;
            this.txtChatName.Name = "txtChatName";
            this.txtChatName.Size = new System.Drawing.Size(373, 145);
            this.txtChatName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter Persons/Groups Name (Comma Seperated)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter Your  Message";
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Enabled = false;
            this.txtLogs.Location = new System.Drawing.Point(451, 108);
            this.txtLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLogs.MaxLength = 3276700;
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(402, 297);
            this.txtLogs.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Log";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 34);
            this.label4.TabIndex = 14;
            this.label4.Text = "Launch WhatsApp";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label4, "Open Whatsapp");
            this.label4.Click += new System.EventHandler(this.btnLaunchWhatsapp_Click);
            // 
            // resumbtn
            // 
            this.resumbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resumbtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resumbtn.Image = ((System.Drawing.Image)(resources.GetObject("resumbtn.Image")));
            this.resumbtn.Location = new System.Drawing.Point(130, 434);
            this.resumbtn.Name = "resumbtn";
            this.resumbtn.Size = new System.Drawing.Size(64, 50);
            this.resumbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resumbtn.TabIndex = 17;
            this.resumbtn.TabStop = false;
            this.toolTip1.SetToolTip(this.resumbtn, "Resume Start Again");
            this.resumbtn.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // sndbtn
            // 
            this.sndbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sndbtn.BackColor = System.Drawing.Color.Transparent;
            this.sndbtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sndbtn.Image = ((System.Drawing.Image)(resources.GetObject("sndbtn.Image")));
            this.sndbtn.Location = new System.Drawing.Point(791, 434);
            this.sndbtn.Name = "sndbtn";
            this.sndbtn.Size = new System.Drawing.Size(62, 53);
            this.sndbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sndbtn.TabIndex = 16;
            this.sndbtn.TabStop = false;
            this.toolTip1.SetToolTip(this.sndbtn, "Send Messages");
            this.sndbtn.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // stopbtn
            // 
            this.stopbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopbtn.BackColor = System.Drawing.Color.Transparent;
            this.stopbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stopbtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.stopbtn.Image = ((System.Drawing.Image)(resources.GetObject("stopbtn.Image")));
            this.stopbtn.Location = new System.Drawing.Point(66, 434);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(58, 53);
            this.stopbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.stopbtn.TabIndex = 15;
            this.stopbtn.TabStop = false;
            this.stopbtn.Tag = "";
            this.toolTip1.SetToolTip(this.stopbtn, "Stop to send Messaging");
            this.stopbtn.Click += new System.EventHandler(this.btnStop_Click_1);
            // 
            // Launchericon
            // 
            this.Launchericon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Launchericon.Image = ((System.Drawing.Image)(resources.GetObject("Launchericon.Image")));
            this.Launchericon.Location = new System.Drawing.Point(317, 18);
            this.Launchericon.Name = "Launchericon";
            this.Launchericon.Size = new System.Drawing.Size(36, 40);
            this.Launchericon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Launchericon.TabIndex = 13;
            this.Launchericon.TabStop = false;
            this.toolTip1.SetToolTip(this.Launchericon, "Open Whatsapp");
            this.Launchericon.Click += new System.EventHandler(this.btnLaunchWhatsapp_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // WhatsappLuncherForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(883, 501);
            this.Controls.Add(this.resumbtn);
            this.Controls.Add(this.sndbtn);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Launchericon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChatName);
            this.Controls.Add(this.txtMessage);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WhatsappLuncherForm1";
            this.Text = "Automate WhatsApp Messages - Vaseef";
            ((System.ComponentModel.ISupportInitialize)(this.resumbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sndbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Launchericon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtChatName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox Launchericon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox stopbtn;
        private System.Windows.Forms.PictureBox sndbtn;
        private System.Windows.Forms.PictureBox resumbtn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
