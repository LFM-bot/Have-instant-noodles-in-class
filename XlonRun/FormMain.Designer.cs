namespace XlonRun
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.timerPicMove = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerPlayerMove = new System.Windows.Forms.Timer(this.components);
            this.timerHunterMove = new System.Windows.Forms.Timer(this.components);
            this.TimerHunterShow = new System.Windows.Forms.Timer(this.components);
            this.timerSpeak = new System.Windows.Forms.Timer(this.components);
            this.BGM = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemDifficutySetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEsay = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHard = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Slabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.buttonHowToPlay = new System.Windows.Forms.Button();
            this.buttonNextLevel = new System.Windows.Forms.Button();
            this.buttonLevel2Again = new System.Windows.Forms.Button();
            this.buttonAgain = new System.Windows.Forms.Button();
            this.buttonT = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BGM)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPicMove
            // 
            this.timerPicMove.Interval = 10;
            this.timerPicMove.Tick += new System.EventHandler(this.timerPicMove_Tick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // timerPlayerMove
            // 
            this.timerPlayerMove.Interval = 10;
            this.timerPlayerMove.Tick += new System.EventHandler(this.timerPlayerMove_Tick);
            // 
            // timerHunterMove
            // 
            this.timerHunterMove.Interval = 30;
            this.timerHunterMove.Tick += new System.EventHandler(this.timerHunterMove_Tick);
            // 
            // TimerHunterShow
            // 
            this.TimerHunterShow.Tick += new System.EventHandler(this.timerHunterShow_Tick);
            // 
            // timerSpeak
            // 
            this.timerSpeak.Interval = 30;
            this.timerSpeak.Tick += new System.EventHandler(this.timerSpeak_Tick);
            // 
            // BGM
            // 
            this.BGM.Enabled = true;
            this.BGM.Location = new System.Drawing.Point(0, 390);
            this.BGM.Name = "BGM";
            this.BGM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BGM.OcxState")));
            this.BGM.Size = new System.Drawing.Size(59, 34);
            this.BGM.TabIndex = 2;
            this.BGM.Visible = false;
            this.BGM.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.BGM_PlayStateChange);
            this.BGM.KeyDownEvent += new AxWMPLib._WMPOCXEvents_KeyDownEventHandler(this.BGM_KeyDownEvent);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(255)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDifficutySetting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemDifficutySetting
            // 
            this.MenuItemDifficutySetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemEsay,
            this.MenuItemNormal,
            this.MenuItemHard});
            this.MenuItemDifficutySetting.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemDifficutySetting.Image")));
            this.MenuItemDifficutySetting.Name = "MenuItemDifficutySetting";
            this.MenuItemDifficutySetting.Size = new System.Drawing.Size(37, 29);
            // 
            // MenuItemEsay
            // 
            this.MenuItemEsay.BackColor = System.Drawing.Color.Transparent;
            this.MenuItemEsay.Image = global::XlonRun.Properties.Resources.确认;
            this.MenuItemEsay.Name = "MenuItemEsay";
            this.MenuItemEsay.Size = new System.Drawing.Size(100, 22);
            this.MenuItemEsay.Text = "简单";
            this.MenuItemEsay.Click += new System.EventHandler(this.MenuItemEsay_Click);
            // 
            // MenuItemNormal
            // 
            this.MenuItemNormal.Name = "MenuItemNormal";
            this.MenuItemNormal.Size = new System.Drawing.Size(100, 22);
            this.MenuItemNormal.Text = "一般";
            this.MenuItemNormal.Click += new System.EventHandler(this.MenuItemNormal_Click);
            // 
            // MenuItemHard
            // 
            this.MenuItemHard.Name = "MenuItemHard";
            this.MenuItemHard.Size = new System.Drawing.Size(100, 22);
            this.MenuItemHard.Text = "困难";
            this.MenuItemHard.Click += new System.EventHandler(this.MenuItemHard_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Slabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(598, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Slabel1
            // 
            this.Slabel1.ActiveLinkColor = System.Drawing.Color.SaddleBrown;
            this.Slabel1.BackColor = System.Drawing.Color.Transparent;
            this.Slabel1.Name = "Slabel1";
            this.Slabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // timerStart
            // 
            this.timerStart.Interval = 10;
            this.timerStart.Tick += new System.EventHandler(this.timerStart_Tick);
            // 
            // buttonHowToPlay
            // 
            this.buttonHowToPlay.BackColor = System.Drawing.Color.Transparent;
            this.buttonHowToPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHowToPlay.FlatAppearance.BorderSize = 0;
            this.buttonHowToPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHowToPlay.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHowToPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonHowToPlay.Image")));
            this.buttonHowToPlay.Location = new System.Drawing.Point(314, 260);
            this.buttonHowToPlay.Name = "buttonHowToPlay";
            this.buttonHowToPlay.Size = new System.Drawing.Size(150, 43);
            this.buttonHowToPlay.TabIndex = 1;
            this.buttonHowToPlay.TabStop = false;
            this.buttonHowToPlay.UseVisualStyleBackColor = false;
            this.buttonHowToPlay.MouseLeave += new System.EventHandler(this.buttonHowToPlay_MouseLeave);
            this.buttonHowToPlay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonHowToPlay_MouseMove);
            this.buttonHowToPlay.Click += new System.EventHandler(this.buttonHowToPlay_Click);
            // 
            // buttonNextLevel
            // 
            this.buttonNextLevel.BackColor = System.Drawing.Color.Transparent;
            this.buttonNextLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNextLevel.FlatAppearance.BorderSize = 0;
            this.buttonNextLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextLevel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextLevel.Image = global::XlonRun.Properties.Resources.下一关1;
            this.buttonNextLevel.Location = new System.Drawing.Point(109, 464);
            this.buttonNextLevel.Name = "buttonNextLevel";
            this.buttonNextLevel.Size = new System.Drawing.Size(150, 43);
            this.buttonNextLevel.TabIndex = 1;
            this.buttonNextLevel.TabStop = false;
            this.buttonNextLevel.UseVisualStyleBackColor = false;
            this.buttonNextLevel.Visible = false;
            this.buttonNextLevel.MouseLeave += new System.EventHandler(this.buttonNextLevel_MouseLeave);
            this.buttonNextLevel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonNextLevel_MouseMove);
            this.buttonNextLevel.Click += new System.EventHandler(this.buttonNextLevel_Click);
            // 
            // buttonLevel2Again
            // 
            this.buttonLevel2Again.BackColor = System.Drawing.Color.Transparent;
            this.buttonLevel2Again.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLevel2Again.FlatAppearance.BorderSize = 0;
            this.buttonLevel2Again.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLevel2Again.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLevel2Again.Image = ((System.Drawing.Image)(resources.GetObject("buttonLevel2Again.Image")));
            this.buttonLevel2Again.Location = new System.Drawing.Point(349, 587);
            this.buttonLevel2Again.Name = "buttonLevel2Again";
            this.buttonLevel2Again.Size = new System.Drawing.Size(150, 43);
            this.buttonLevel2Again.TabIndex = 1;
            this.buttonLevel2Again.TabStop = false;
            this.buttonLevel2Again.UseVisualStyleBackColor = false;
            this.buttonLevel2Again.Visible = false;
            this.buttonLevel2Again.MouseLeave += new System.EventHandler(this.buttonLevel2Again_MouseLeave);
            this.buttonLevel2Again.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonLevel2Again_MouseMove);
            this.buttonLevel2Again.Click += new System.EventHandler(this.buttonLevel2Again_Click);
            // 
            // buttonAgain
            // 
            this.buttonAgain.BackColor = System.Drawing.Color.Transparent;
            this.buttonAgain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAgain.FlatAppearance.BorderSize = 0;
            this.buttonAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgain.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgain.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgain.Image")));
            this.buttonAgain.Location = new System.Drawing.Point(348, 464);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(150, 43);
            this.buttonAgain.TabIndex = 1;
            this.buttonAgain.TabStop = false;
            this.buttonAgain.UseVisualStyleBackColor = false;
            this.buttonAgain.Visible = false;
            this.buttonAgain.MouseLeave += new System.EventHandler(this.buttonAgain_MouseLeave);
            this.buttonAgain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonAgain_MouseMove);
            this.buttonAgain.Click += new System.EventHandler(this.buttonAgain_Click);
            // 
            // buttonT
            // 
            this.buttonT.BackColor = System.Drawing.Color.Transparent;
            this.buttonT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonT.FlatAppearance.BorderSize = 0;
            this.buttonT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonT.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonT.Image = global::XlonRun.Properties.Resources.视频1;
            this.buttonT.Location = new System.Drawing.Point(47, 545);
            this.buttonT.Name = "buttonT";
            this.buttonT.Size = new System.Drawing.Size(150, 43);
            this.buttonT.TabIndex = 1;
            this.buttonT.TabStop = false;
            this.buttonT.UseVisualStyleBackColor = false;
            this.buttonT.Visible = false;
            this.buttonT.MouseLeave += new System.EventHandler(this.buttonT_MouseLeave);
            this.buttonT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonT_MouseMove);
            this.buttonT.Click += new System.EventHandler(this.buttonT_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.Color.Transparent;
            this.buttonReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReturn.FlatAppearance.BorderSize = 0;
            this.buttonReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturn.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.Image = ((System.Drawing.Image)(resources.GetObject("buttonReturn.Image")));
            this.buttonReturn.Location = new System.Drawing.Point(406, 545);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(150, 43);
            this.buttonReturn.TabIndex = 1;
            this.buttonReturn.TabStop = false;
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Visible = false;
            this.buttonReturn.MouseLeave += new System.EventHandler(this.buttonReturn_MouseLeave);
            this.buttonReturn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonReturn_MouseMove);
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.FlatAppearance.BorderSize = 0;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.Location = new System.Drawing.Point(135, 260);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(150, 43);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.TabStop = false;
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.MouseLeave += new System.EventHandler(this.buttonStart_MouseLeave);
            this.buttonStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonStart_MouseMove);
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 1101);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 646);
            this.Controls.Add(this.BGM);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonHowToPlay);
            this.Controls.Add(this.buttonNextLevel);
            this.Controls.Add(this.buttonLevel2Again);
            this.Controls.Add(this.buttonAgain);
            this.Controls.Add(this.buttonT);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "终极逃课王";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BGM)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonHowToPlay;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Timer timerPicMove;
        private AxWMPLib.AxWindowsMediaPlayer BGM;
        private System.Windows.Forms.Timer timerPlayerMove;
        private System.Windows.Forms.Timer timerHunterMove;
        private System.Windows.Forms.Timer TimerHunterShow;
        private System.Windows.Forms.Button buttonAgain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDifficutySetting;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEsay;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNormal;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHard;
        private System.Windows.Forms.Button buttonNextLevel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Slabel1;
        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.Timer timerSpeak;
        private System.Windows.Forms.Button buttonLevel2Again;
        private System.Windows.Forms.Button buttonT;
    }
}

