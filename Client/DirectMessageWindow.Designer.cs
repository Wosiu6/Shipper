namespace Client
{
    partial class DirectMessageWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectMessageWindow));
            this.Message_txt = new System.Windows.Forms.TextBox();
            this.Send_btn = new System.Windows.Forms.Button();
            this.messages_listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Message_txt
            // 
            this.Message_txt.BackColor = System.Drawing.Color.Aquamarine;
            this.Message_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Message_txt.Location = new System.Drawing.Point(12, 243);
            this.Message_txt.Name = "Message_txt";
            this.Message_txt.Size = new System.Drawing.Size(236, 20);
            this.Message_txt.TabIndex = 0;
            this.Message_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Message_txt_KeyDown);
            this.Message_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Message_txt_KeyPress);
            // 
            // Send_btn
            // 
            this.Send_btn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Send_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send_btn.Image = ((System.Drawing.Image)(resources.GetObject("Send_btn.Image")));
            this.Send_btn.Location = new System.Drawing.Point(254, 243);
            this.Send_btn.Margin = new System.Windows.Forms.Padding(0);
            this.Send_btn.Name = "Send_btn";
            this.Send_btn.Size = new System.Drawing.Size(22, 20);
            this.Send_btn.TabIndex = 1;
            this.Send_btn.UseVisualStyleBackColor = false;
            this.Send_btn.Click += new System.EventHandler(this.Send_btn_Click);
            // 
            // messages_listBox
            // 
            this.messages_listBox.BackColor = System.Drawing.Color.Aquamarine;
            this.messages_listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messages_listBox.FormattingEnabled = true;
            this.messages_listBox.Location = new System.Drawing.Point(12, 12);
            this.messages_listBox.Name = "messages_listBox";
            this.messages_listBox.Size = new System.Drawing.Size(264, 223);
            this.messages_listBox.TabIndex = 2;
            this.messages_listBox.SelectedIndexChanged += new System.EventHandler(this.messages_listBox_SelectedIndexChanged);
            // 
            // DirectMessageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(288, 273);
            this.Controls.Add(this.messages_listBox);
            this.Controls.Add(this.Send_btn);
            this.Controls.Add(this.Message_txt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DirectMessageWindow";
            this.Text = "nickname";
            this.Load += new System.EventHandler(this.DirectMessageWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Message_txt;
        private System.Windows.Forms.Button Send_btn;
        private System.Windows.Forms.ListBox messages_listBox;
    }
}