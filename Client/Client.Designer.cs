namespace Client
{
    partial class Client_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_window));
            this.login_Btn = new System.Windows.Forms.Button();
            this.nickname_txtBox = new System.Windows.Forms.TextBox();
            this.userMessage_txtBox = new System.Windows.Forms.TextBox();
            this.send_Btn = new System.Windows.Forms.Button();
            this.nickname_label = new System.Windows.Forms.Label();
            this.allMessages_listBox = new System.Windows.Forms.ListBox();
            this.welcomeMessage_label = new System.Windows.Forms.Label();
            this.active_clients_lbl = new System.Windows.Forms.Label();
            this.avatarImageList = new System.Windows.Forms.ImageList(this.components);
            this.clients_Listbox = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAvatarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LittlePictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LittlePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // login_Btn
            // 
            resources.ApplyResources(this.login_Btn, "login_Btn");
            this.login_Btn.BackColor = System.Drawing.Color.Turquoise;
            this.login_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_Btn.Name = "login_Btn";
            this.login_Btn.UseVisualStyleBackColor = false;
            this.login_Btn.Click += new System.EventHandler(this.login_Btn_Click);
            // 
            // nickname_txtBox
            // 
            resources.ApplyResources(this.nickname_txtBox, "nickname_txtBox");
            this.nickname_txtBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.nickname_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nickname_txtBox.Name = "nickname_txtBox";
            // 
            // userMessage_txtBox
            // 
            resources.ApplyResources(this.userMessage_txtBox, "userMessage_txtBox");
            this.userMessage_txtBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.userMessage_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userMessage_txtBox.Name = "userMessage_txtBox";
            // 
            // send_Btn
            // 
            resources.ApplyResources(this.send_Btn, "send_Btn");
            this.send_Btn.BackColor = System.Drawing.Color.Turquoise;
            this.send_Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_Btn.Name = "send_Btn";
            this.send_Btn.UseVisualStyleBackColor = false;
            this.send_Btn.Click += new System.EventHandler(this.send_Btn_Click);
            // 
            // nickname_label
            // 
            resources.ApplyResources(this.nickname_label, "nickname_label");
            this.nickname_label.Name = "nickname_label";
            // 
            // allMessages_listBox
            // 
            resources.ApplyResources(this.allMessages_listBox, "allMessages_listBox");
            this.allMessages_listBox.BackColor = System.Drawing.Color.Aquamarine;
            this.allMessages_listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.allMessages_listBox.FormattingEnabled = true;
            this.allMessages_listBox.Name = "allMessages_listBox";
            // 
            // welcomeMessage_label
            // 
            resources.ApplyResources(this.welcomeMessage_label, "welcomeMessage_label");
            this.welcomeMessage_label.Name = "welcomeMessage_label";
            // 
            // active_clients_lbl
            // 
            resources.ApplyResources(this.active_clients_lbl, "active_clients_lbl");
            this.active_clients_lbl.Name = "active_clients_lbl";
            // 
            // avatarImageList
            // 
            this.avatarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("avatarImageList.ImageStream")));
            this.avatarImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.avatarImageList.Images.SetKeyName(0, "adam.jpg");
            this.avatarImageList.Images.SetKeyName(1, "anjali.jpg");
            this.avatarImageList.Images.SetKeyName(2, "arjun.jpg");
            this.avatarImageList.Images.SetKeyName(3, "boy.jpg");
            this.avatarImageList.Images.SetKeyName(4, "boy-1.jpg");
            this.avatarImageList.Images.SetKeyName(5, "girl.jpg");
            this.avatarImageList.Images.SetKeyName(6, "girl-1.jpg");
            this.avatarImageList.Images.SetKeyName(7, "jorge.jpg");
            this.avatarImageList.Images.SetKeyName(8, "man.jpg");
            this.avatarImageList.Images.SetKeyName(9, "man-1.jpg");
            this.avatarImageList.Images.SetKeyName(10, "man-2.jpg");
            this.avatarImageList.Images.SetKeyName(11, "man-3.jpg");
            this.avatarImageList.Images.SetKeyName(12, "man-4.jpg");
            this.avatarImageList.Images.SetKeyName(13, "maya.jpg");
            this.avatarImageList.Images.SetKeyName(14, "rahul.jpg");
            this.avatarImageList.Images.SetKeyName(15, "sadona.jpg");
            this.avatarImageList.Images.SetKeyName(16, "sandy.jpg");
            this.avatarImageList.Images.SetKeyName(17, "sid.jpg");
            this.avatarImageList.Images.SetKeyName(18, "steve.jpg");
            // 
            // clients_Listbox
            // 
            resources.ApplyResources(this.clients_Listbox, "clients_Listbox");
            this.clients_Listbox.BackColor = System.Drawing.Color.Aquamarine;
            this.clients_Listbox.HideSelection = false;
            this.clients_Listbox.Name = "clients_Listbox";
            this.clients_Listbox.UseCompatibleStateImageBehavior = false;
            this.clients_Listbox.View = System.Windows.Forms.View.List;
            this.clients_Listbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.clients_Listbox_MouseDoubleClick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.CadetBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.gamesToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeAvatarToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            // 
            // changeAvatarToolStripMenuItem
            // 
            resources.ApplyResources(this.changeAvatarToolStripMenuItem, "changeAvatarToolStripMenuItem");
            this.changeAvatarToolStripMenuItem.Name = "changeAvatarToolStripMenuItem";
            this.changeAvatarToolStripMenuItem.Click += new System.EventHandler(this.changeAvatarToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            resources.ApplyResources(this.connectToolStripMenuItem, "connectToolStripMenuItem");
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            resources.ApplyResources(this.disconnectToolStripMenuItem, "disconnectToolStripMenuItem");
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            resources.ApplyResources(this.quitToolStripMenuItem, "quitToolStripMenuItem");
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // gamesToolStripMenuItem
            // 
            resources.ApplyResources(this.gamesToolStripMenuItem, "gamesToolStripMenuItem");
            this.gamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paintToolStripMenuItem});
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            // 
            // paintToolStripMenuItem
            // 
            resources.ApplyResources(this.paintToolStripMenuItem, "paintToolStripMenuItem");
            this.paintToolStripMenuItem.Name = "paintToolStripMenuItem";
            this.paintToolStripMenuItem.Click += new System.EventHandler(this.PaintToolStripMenuItem_Click);
            // 
            // LittlePictureBox
            // 
            resources.ApplyResources(this.LittlePictureBox, "LittlePictureBox");
            this.LittlePictureBox.Name = "LittlePictureBox";
            this.LittlePictureBox.TabStop = false;
            // 
            // Client_window
            // 
            this.AcceptButton = this.send_Btn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Controls.Add(this.LittlePictureBox);
            this.Controls.Add(this.clients_Listbox);
            this.Controls.Add(this.active_clients_lbl);
            this.Controls.Add(this.welcomeMessage_label);
            this.Controls.Add(this.allMessages_listBox);
            this.Controls.Add(this.nickname_label);
            this.Controls.Add(this.send_Btn);
            this.Controls.Add(this.userMessage_txtBox);
            this.Controls.Add(this.nickname_txtBox);
            this.Controls.Add(this.login_Btn);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Client_window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_window_FormClosing);
            this.Load += new System.EventHandler(this.Client_window_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Client_window_MouseDoubleClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LittlePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_Btn;
        private System.Windows.Forms.TextBox nickname_txtBox;
        private System.Windows.Forms.TextBox userMessage_txtBox;
        private System.Windows.Forms.Button send_Btn;
        private System.Windows.Forms.Label nickname_label;
        private System.Windows.Forms.ListBox allMessages_listBox;
        private System.Windows.Forms.Label welcomeMessage_label;
        private System.Windows.Forms.Label active_clients_lbl;
        private System.Windows.Forms.ImageList avatarImageList;
        private System.Windows.Forms.ListView clients_Listbox;
        private System.Windows.Forms.PictureBox LittlePictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeAvatarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paintToolStripMenuItem;
    }
}