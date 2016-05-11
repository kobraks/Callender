namespace Client
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
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Calender = new System.Windows.Forms.MonthCalendar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.właściwościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajWydarzenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IncomingEvents = new System.Windows.Forms.GroupBox();
            this.EventDetalies = new System.Windows.Forms.GroupBox();
            this.EventTitle = new System.Windows.Forms.Label();
            this.EventTime = new System.Windows.Forms.Label();
            this.EventDescription = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.EventDetalies.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 113);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Calender
            // 
            this.Calender.Location = new System.Drawing.Point(270, 37);
            this.Calender.Name = "Calender";
            this.Calender.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.właściwościToolStripMenuItem,
            this.profilToolStripMenuItem,
            this.dodajWydarzenieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(613, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // właściwościToolStripMenuItem
            // 
            this.właściwościToolStripMenuItem.Name = "właściwościToolStripMenuItem";
            this.właściwościToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.właściwościToolStripMenuItem.Text = "Właściwości";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // dodajWydarzenieToolStripMenuItem
            // 
            this.dodajWydarzenieToolStripMenuItem.Name = "dodajWydarzenieToolStripMenuItem";
            this.dodajWydarzenieToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.dodajWydarzenieToolStripMenuItem.Text = "Dodaj Wydarzenie";
            // 
            // IncomingEvents
            // 
            this.IncomingEvents.Location = new System.Drawing.Point(12, 37);
            this.IncomingEvents.Name = "IncomingEvents";
            this.IncomingEvents.Size = new System.Drawing.Size(186, 232);
            this.IncomingEvents.TabIndex = 4;
            this.IncomingEvents.TabStop = false;
            this.IncomingEvents.Text = "Nadchodzące Wydażenia";
            // 
            // EventDetalies
            // 
            this.EventDetalies.Controls.Add(this.EventDescription);
            this.EventDetalies.Controls.Add(this.EventTime);
            this.EventDetalies.Controls.Add(this.EventTitle);
            this.EventDetalies.Location = new System.Drawing.Point(270, 261);
            this.EventDetalies.Name = "EventDetalies";
            this.EventDetalies.Size = new System.Drawing.Size(325, 203);
            this.EventDetalies.TabIndex = 5;
            this.EventDetalies.TabStop = false;
            this.EventDetalies.Text = "Szczegóły";
            // 
            // EventTitle
            // 
            this.EventTitle.AutoSize = true;
            this.EventTitle.Location = new System.Drawing.Point(6, 27);
            this.EventTitle.Name = "EventTitle";
            this.EventTitle.Size = new System.Drawing.Size(24, 17);
            this.EventTitle.TabIndex = 0;
            this.EventTitle.Text = "13";
            // 
            // EventTime
            // 
            this.EventTime.AutoSize = true;
            this.EventTime.Location = new System.Drawing.Point(6, 87);
            this.EventTime.Name = "EventTime";
            this.EventTime.Size = new System.Drawing.Size(46, 17);
            this.EventTime.TabIndex = 1;
            this.EventTime.Text = "label2";
            // 
            // EventDescription
            // 
            this.EventDescription.AutoSize = true;
            this.EventDescription.Location = new System.Drawing.Point(6, 155);
            this.EventDescription.Name = "EventDescription";
            this.EventDescription.Size = new System.Drawing.Size(46, 17);
            this.EventDescription.TabIndex = 2;
            this.EventDescription.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 493);
            this.Controls.Add(this.EventDetalies);
            this.Controls.Add(this.IncomingEvents);
            this.Controls.Add(this.Calender);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EventDetalies.ResumeLayout(false);
            this.EventDetalies.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.MonthCalendar Calender;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem właściwościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajWydarzenieToolStripMenuItem;
        private System.Windows.Forms.GroupBox IncomingEvents;
        private System.Windows.Forms.GroupBox EventDetalies;
        private System.Windows.Forms.Label EventDescription;
        private System.Windows.Forms.Label EventTime;
        private System.Windows.Forms.Label EventTitle;
    }
}

