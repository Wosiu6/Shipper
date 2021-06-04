namespace Client
{
    partial class AvatarChangeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvatarChangeForm));
            this.avatars_listv = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.change_ctn = new System.Windows.Forms.Button();
            this.avatarImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // avatars_listv
            // 
            this.avatars_listv.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.avatars_listv.BackColor = System.Drawing.Color.Aquamarine;
            this.avatars_listv.HideSelection = false;
            this.avatars_listv.Location = new System.Drawing.Point(12, 25);
            this.avatars_listv.Name = "avatars_listv";
            this.avatars_listv.Size = new System.Drawing.Size(234, 350);
            this.avatars_listv.TabIndex = 0;
            this.avatars_listv.UseCompatibleStateImageBehavior = false;
            this.avatars_listv.View = System.Windows.Forms.View.SmallIcon;
            this.avatars_listv.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.avatars_listv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.avatars_listv_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 9.75F);
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose a new avatar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // change_ctn
            // 
            this.change_ctn.BackColor = System.Drawing.Color.Turquoise;
            this.change_ctn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.change_ctn.Font = new System.Drawing.Font("OCR A Extended", 9.75F);
            this.change_ctn.Location = new System.Drawing.Point(167, 381);
            this.change_ctn.Name = "change_ctn";
            this.change_ctn.Size = new System.Drawing.Size(75, 23);
            this.change_ctn.TabIndex = 2;
            this.change_ctn.Text = "Choose";
            this.change_ctn.UseVisualStyleBackColor = false;
            this.change_ctn.Click += new System.EventHandler(this.button1_Click);
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
            // AvatarChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(254, 412);
            this.Controls.Add(this.change_ctn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.avatars_listv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AvatarChangeForm";
            this.Text = "AvatarChangeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView avatars_listv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button change_ctn;
        private System.Windows.Forms.ImageList avatarImageList;
    }
}