namespace BotLauncherBeta
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Background = new System.Windows.Forms.Panel();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SendText = new System.Windows.Forms.TextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.IdInfo = new System.Windows.Forms.TextBox();
            this.IdTitle = new System.Windows.Forms.TextBox();
            this.StoryTable = new System.Windows.Forms.DataGridView();
            this.reloadButton = new System.Windows.Forms.Button();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.InfoTitle = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statPictActiv = new System.Windows.Forms.PictureBox();
            this.statusInfo = new System.Windows.Forms.TextBox();
            this.statPictSleep = new System.Windows.Forms.PictureBox();
            this.statusBotText = new System.Windows.Forms.TextBox();
            this.UpPanel = new System.Windows.Forms.Panel();
            this.AppName = new System.Windows.Forms.TextBox();
            this.playButton = new System.Windows.Forms.Button();
            this.PlayImageList = new System.Windows.Forms.ImageList(this.components);
            this.settingsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.IdPanel = new System.Windows.Forms.Panel();
            this.ClientsButton = new System.Windows.Forms.Button();
            this.IdTable = new System.Windows.Forms.DataGridView();
            this.BotImageList = new System.Windows.Forms.ImageList(this.components);
            this.selectAllButton = new System.Windows.Forms.Button();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Background.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StoryTable)).BeginInit();
            this.RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statPictActiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statPictSleep)).BeginInit();
            this.UpPanel.SuspendLayout();
            this.IdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Background.Controls.Add(this.MessagePanel);
            this.Background.Controls.Add(this.RightPanel);
            this.Background.Controls.Add(this.UpPanel);
            this.Background.Controls.Add(this.IdPanel);
            this.Background.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(800, 450);
            this.Background.TabIndex = 0;
            // 
            // MessagePanel
            // 
            this.MessagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.MessagePanel.Controls.Add(this.buttonSend);
            this.MessagePanel.Controls.Add(this.SendText);
            this.MessagePanel.Controls.Add(this.LoadButton);
            this.MessagePanel.Controls.Add(this.IdInfo);
            this.MessagePanel.Controls.Add(this.IdTitle);
            this.MessagePanel.Controls.Add(this.StoryTable);
            this.MessagePanel.Location = new System.Drawing.Point(251, 48);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(366, 395);
            this.MessagePanel.TabIndex = 6;
            // 
            // buttonSend
            // 
            this.buttonSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSend.Enabled = false;
            this.buttonSend.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.buttonSend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSend.Image")));
            this.buttonSend.Location = new System.Drawing.Point(299, 333);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(61, 52);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            this.buttonSend.MouseEnter += new System.EventHandler(this.buttonSend_MouseEnter);
            this.buttonSend.MouseLeave += new System.EventHandler(this.buttonSend_MouseLeave);
            // 
            // SendText
            // 
            this.SendText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.SendText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SendText.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold);
            this.SendText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(106)))));
            this.SendText.Location = new System.Drawing.Point(7, 333);
            this.SendText.Multiline = true;
            this.SendText.Name = "SendText";
            this.SendText.Size = new System.Drawing.Size(286, 52);
            this.SendText.TabIndex = 5;
            this.SendText.TextChanged += new System.EventHandler(this.SendText_TextChanged);
            this.SendText.MouseEnter += new System.EventHandler(this.SendText_MouseEnter);
            this.SendText.MouseLeave += new System.EventHandler(this.SendText_MouseLeave);
            // 
            // LoadButton
            // 
            this.LoadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadButton.Enabled = false;
            this.LoadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.LoadButton.FlatAppearance.BorderSize = 0;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold);
            this.LoadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.LoadButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadButton.Image")));
            this.LoadButton.Location = new System.Drawing.Point(264, 20);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(96, 30);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            this.LoadButton.MouseEnter += new System.EventHandler(this.LoadButton_MouseEnter);
            this.LoadButton.MouseLeave += new System.EventHandler(this.LoadButton_MouseLeave);
            // 
            // IdInfo
            // 
            this.IdInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.IdInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IdInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IdInfo.Font = new System.Drawing.Font("Ebrima", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.IdInfo.Location = new System.Drawing.Point(52, 21);
            this.IdInfo.Name = "IdInfo";
            this.IdInfo.Size = new System.Drawing.Size(206, 29);
            this.IdInfo.TabIndex = 3;
            this.IdInfo.TextChanged += new System.EventHandler(this.IdInfo_TextChanged);
            this.IdInfo.MouseEnter += new System.EventHandler(this.IdInfo_MouseEnter);
            this.IdInfo.MouseLeave += new System.EventHandler(this.IdInfo_MouseLeave);
            // 
            // IdTitle
            // 
            this.IdTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.IdTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IdTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.IdTitle.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Bold);
            this.IdTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.IdTitle.Location = new System.Drawing.Point(13, 20);
            this.IdTitle.Name = "IdTitle";
            this.IdTitle.ReadOnly = true;
            this.IdTitle.Size = new System.Drawing.Size(33, 30);
            this.IdTitle.TabIndex = 5;
            this.IdTitle.TabStop = false;
            this.IdTitle.Text = "ID:";
            // 
            // StoryTable
            // 
            this.StoryTable.AllowUserToAddRows = false;
            this.StoryTable.AllowUserToDeleteRows = false;
            this.StoryTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.StoryTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StoryTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(191)))), ((int)(((byte)(152)))));
            this.StoryTable.Location = new System.Drawing.Point(7, 66);
            this.StoryTable.Name = "StoryTable";
            this.StoryTable.ReadOnly = true;
            this.StoryTable.RowHeadersVisible = false;
            this.StoryTable.RowTemplate.ReadOnly = true;
            this.StoryTable.Size = new System.Drawing.Size(353, 252);
            this.StoryTable.TabIndex = 11;
            // 
            // reloadButton
            // 
            this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.reloadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reloadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reloadButton.FlatAppearance.BorderSize = 0;
            this.reloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reloadButton.Image = ((System.Drawing.Image)(resources.GetObject("reloadButton.Image")));
            this.reloadButton.Location = new System.Drawing.Point(127, 6);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(53, 53);
            this.reloadButton.TabIndex = 0;
            this.reloadButton.UseVisualStyleBackColor = false;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            this.reloadButton.MouseEnter += new System.EventHandler(this.reloadButton_MouseEnter);
            this.reloadButton.MouseLeave += new System.EventHandler(this.reloadButton_MouseLeave);
            // 
            // RightPanel
            // 
            this.RightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.RightPanel.Controls.Add(this.InfoBox);
            this.RightPanel.Controls.Add(this.InfoTitle);
            this.RightPanel.Controls.Add(this.panel1);
            this.RightPanel.Controls.Add(this.statPictActiv);
            this.RightPanel.Controls.Add(this.statusInfo);
            this.RightPanel.Controls.Add(this.statPictSleep);
            this.RightPanel.Controls.Add(this.statusBotText);
            this.RightPanel.Location = new System.Drawing.Point(623, 48);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(177, 395);
            this.RightPanel.TabIndex = 1;
            // 
            // InfoBox
            // 
            this.InfoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.InfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.InfoBox.Font = new System.Drawing.Font("Corbel", 16F, System.Drawing.FontStyle.Bold);
            this.InfoBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(106)))));
            this.InfoBox.Location = new System.Drawing.Point(4, 183);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ReadOnly = true;
            this.InfoBox.Size = new System.Drawing.Size(169, 206);
            this.InfoBox.TabIndex = 6;
            this.InfoBox.TabStop = false;
            // 
            // InfoTitle
            // 
            this.InfoTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.InfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.InfoTitle.Font = new System.Drawing.Font("Corbel", 19F, System.Drawing.FontStyle.Bold);
            this.InfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.InfoTitle.Location = new System.Drawing.Point(4, 146);
            this.InfoTitle.Name = "InfoTitle";
            this.InfoTitle.ReadOnly = true;
            this.InfoTitle.Size = new System.Drawing.Size(169, 31);
            this.InfoTitle.TabIndex = 5;
            this.InfoTitle.TabStop = false;
            this.InfoTitle.Text = "Информация";
            this.InfoTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(191)))), ((int)(((byte)(152)))));
            this.panel1.Location = new System.Drawing.Point(0, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 10);
            this.panel1.TabIndex = 4;
            // 
            // statPictActiv
            // 
            this.statPictActiv.Image = ((System.Drawing.Image)(resources.GetObject("statPictActiv.Image")));
            this.statPictActiv.Location = new System.Drawing.Point(4, 58);
            this.statPictActiv.Name = "statPictActiv";
            this.statPictActiv.Size = new System.Drawing.Size(48, 48);
            this.statPictActiv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statPictActiv.TabIndex = 3;
            this.statPictActiv.TabStop = false;
            this.statPictActiv.Visible = false;
            // 
            // statusInfo
            // 
            this.statusInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.statusInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.statusInfo.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Bold);
            this.statusInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(106)))));
            this.statusInfo.Location = new System.Drawing.Point(52, 77);
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.ReadOnly = true;
            this.statusInfo.Size = new System.Drawing.Size(121, 30);
            this.statusInfo.TabIndex = 2;
            this.statusInfo.TabStop = false;
            // 
            // statPictSleep
            // 
            this.statPictSleep.Image = global::BotLauncherBeta.Properties.Resources.BotSleepGreen;
            this.statPictSleep.Location = new System.Drawing.Point(4, 58);
            this.statPictSleep.Name = "statPictSleep";
            this.statPictSleep.Size = new System.Drawing.Size(48, 48);
            this.statPictSleep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.statPictSleep.TabIndex = 1;
            this.statPictSleep.TabStop = false;
            // 
            // statusBotText
            // 
            this.statusBotText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.statusBotText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusBotText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.statusBotText.Font = new System.Drawing.Font("Corbel", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusBotText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.statusBotText.Location = new System.Drawing.Point(4, 7);
            this.statusBotText.Multiline = true;
            this.statusBotText.Name = "statusBotText";
            this.statusBotText.ReadOnly = true;
            this.statusBotText.Size = new System.Drawing.Size(169, 44);
            this.statusBotText.TabIndex = 0;
            this.statusBotText.TabStop = false;
            this.statusBotText.Text = "Статус бота";
            this.statusBotText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UpPanel
            // 
            this.UpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.UpPanel.Controls.Add(this.AppName);
            this.UpPanel.Controls.Add(this.playButton);
            this.UpPanel.Controls.Add(this.settingsButton);
            this.UpPanel.Controls.Add(this.exitButton);
            this.UpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpPanel.Location = new System.Drawing.Point(0, 0);
            this.UpPanel.Name = "UpPanel";
            this.UpPanel.Size = new System.Drawing.Size(800, 48);
            this.UpPanel.TabIndex = 0;
            this.UpPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpPanel_MouseDown);
            this.UpPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UpPanel_MouseMove);
            // 
            // AppName
            // 
            this.AppName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.AppName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AppName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AppName.Font = new System.Drawing.Font("Corbel", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.AppName.Location = new System.Drawing.Point(6, 4);
            this.AppName.Name = "AppName";
            this.AppName.ReadOnly = true;
            this.AppName.Size = new System.Drawing.Size(187, 36);
            this.AppName.TabIndex = 3;
            this.AppName.TabStop = false;
            this.AppName.Text = "Bot Launcher ";
            this.AppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ImageIndex = 1;
            this.playButton.ImageList = this.PlayImageList;
            this.playButton.Location = new System.Drawing.Point(623, 4);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(40, 40);
            this.playButton.TabIndex = 6;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_MouseEnter);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_MouseLeave);
            // 
            // PlayImageList
            // 
            this.PlayImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PlayImageList.ImageStream")));
            this.PlayImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.PlayImageList.Images.SetKeyName(0, "pauseButton.png");
            this.PlayImageList.Images.SetKeyName(1, "playButton1.png");
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.Location = new System.Drawing.Point(689, 4);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(40, 40);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            this.settingsButton.MouseEnter += new System.EventHandler(this.settingsButton_MouseEnter);
            this.settingsButton.MouseLeave += new System.EventHandler(this.settingsButton_MouseLeave);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(756, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 40);
            this.exitButton.TabIndex = 8;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            // 
            // IdPanel
            // 
            this.IdPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.IdPanel.Controls.Add(this.selectAllButton);
            this.IdPanel.Controls.Add(this.ClientsButton);
            this.IdPanel.Controls.Add(this.reloadButton);
            this.IdPanel.Controls.Add(this.IdTable);
            this.IdPanel.Location = new System.Drawing.Point(0, 48);
            this.IdPanel.Name = "IdPanel";
            this.IdPanel.Size = new System.Drawing.Size(244, 395);
            this.IdPanel.TabIndex = 5;
            // 
            // ClientsButton
            // 
            this.ClientsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.ClientsButton.FlatAppearance.BorderSize = 0;
            this.ClientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientsButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold);
            this.ClientsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(111)))), ((int)(((byte)(95)))));
            this.ClientsButton.Image = ((System.Drawing.Image)(resources.GetObject("ClientsButton.Image")));
            this.ClientsButton.Location = new System.Drawing.Point(6, 6);
            this.ClientsButton.Name = "ClientsButton";
            this.ClientsButton.Size = new System.Drawing.Size(115, 53);
            this.ClientsButton.TabIndex = 1;
            this.ClientsButton.Text = "Клиенты";
            this.ClientsButton.UseVisualStyleBackColor = false;
            this.ClientsButton.Click += new System.EventHandler(this.ClientsButton_Click);
            this.ClientsButton.MouseEnter += new System.EventHandler(this.ClientsButton_MouseEnter);
            this.ClientsButton.MouseLeave += new System.EventHandler(this.ClientsButton_MouseLeave);
            // 
            // IdTable
            // 
            this.IdTable.AllowUserToAddRows = false;
            this.IdTable.AllowUserToDeleteRows = false;
            this.IdTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.IdTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IdTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(191)))), ((int)(((byte)(152)))));
            this.IdTable.Location = new System.Drawing.Point(6, 66);
            this.IdTable.Name = "IdTable";
            this.IdTable.ReadOnly = true;
            this.IdTable.RowHeadersVisible = false;
            this.IdTable.RowTemplate.ReadOnly = true;
            this.IdTable.Size = new System.Drawing.Size(230, 319);
            this.IdTable.TabIndex = 2;
            this.IdTable.SelectionChanged += new System.EventHandler(this.IdTable_SelectionChanged);
            // 
            // BotImageList
            // 
            this.BotImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BotImageList.ImageStream")));
            this.BotImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.BotImageList.Images.SetKeyName(0, "BotActiveGreen.png");
            this.BotImageList.Images.SetKeyName(1, "BotSleepGreen.png");
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.selectAllButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.selectAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectAllButton.FlatAppearance.BorderSize = 0;
            this.selectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllButton.Image = ((System.Drawing.Image)(resources.GetObject("selectAllButton.Image")));
            this.selectAllButton.Location = new System.Drawing.Point(183, 6);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(53, 53);
            this.selectAllButton.TabIndex = 3;
            this.selectAllButton.UseVisualStyleBackColor = false;
            this.selectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            this.selectAllButton.MouseEnter += new System.EventHandler(this.SelectAllButton_MouseEnter);
            this.selectAllButton.MouseLeave += new System.EventHandler(this.SelectAllButton_MouseLeave);
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(BotLauncherBeta.MainForm);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(191)))), ((int)(((byte)(152)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Background.ResumeLayout(false);
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StoryTable)).EndInit();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statPictActiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statPictSleep)).EndInit();
            this.UpPanel.ResumeLayout(false);
            this.UpPanel.PerformLayout();
            this.IdPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IdTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Background;
        private System.Windows.Forms.Panel UpPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ImageList PlayImageList;
        private System.Windows.Forms.TextBox statusBotText;
        private System.Windows.Forms.TextBox statusInfo;
        private System.Windows.Forms.PictureBox statPictSleep;
        private System.Windows.Forms.ImageList BotImageList;
        private System.Windows.Forms.PictureBox statPictActiv;
        private System.Windows.Forms.TextBox InfoTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox InfoBox;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.TextBox IdTitle;
        private System.Windows.Forms.Panel IdPanel;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox IdInfo;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox SendText;
        private System.Windows.Forms.TextBox AppName;
        private System.Windows.Forms.Button ClientsButton;
        private System.Windows.Forms.DataGridView StoryTable;
        private System.Windows.Forms.DataGridView IdTable;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
        private System.Windows.Forms.Button selectAllButton;
    }
}

