namespace Client
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.paintBox = new System.Windows.Forms.PictureBox();
            this.RED = new System.Windows.Forms.Button();
            this.BLUE = new System.Windows.Forms.Button();
            this.GREEN = new System.Windows.Forms.Button();
            this.YELLOW = new System.Windows.Forms.Button();
            this.ORANGE = new System.Windows.Forms.Button();
            this.BLACK = new System.Windows.Forms.Button();
            this.GREY = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).BeginInit();
            this.SuspendLayout();
            // 
            // paintBox
            // 
            this.paintBox.Location = new System.Drawing.Point(12, 50);
            this.paintBox.Name = "paintBox";
            this.paintBox.Size = new System.Drawing.Size(567, 360);
            this.paintBox.TabIndex = 0;
            this.paintBox.TabStop = false;
            this.paintBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.paintBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.paintBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // RED
            // 
            this.RED.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RED.Location = new System.Drawing.Point(262, 3);
            this.RED.Name = "RED";
            this.RED.Size = new System.Drawing.Size(44, 41);
            this.RED.TabIndex = 1;
            this.RED.UseVisualStyleBackColor = true;
            this.RED.Click += new System.EventHandler(this.RED_Click);
            // 
            // BLUE
            // 
            this.BLUE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BLUE.Location = new System.Drawing.Point(312, 3);
            this.BLUE.Name = "BLUE";
            this.BLUE.Size = new System.Drawing.Size(44, 41);
            this.BLUE.TabIndex = 2;
            this.BLUE.UseVisualStyleBackColor = true;
            this.BLUE.Click += new System.EventHandler(this.BLUE_Click);
            // 
            // GREEN
            // 
            this.GREEN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GREEN.Location = new System.Drawing.Point(112, 3);
            this.GREEN.Name = "GREEN";
            this.GREEN.Size = new System.Drawing.Size(44, 41);
            this.GREEN.TabIndex = 3;
            this.GREEN.UseVisualStyleBackColor = true;
            this.GREEN.Click += new System.EventHandler(this.GREEN_Click);
            // 
            // YELLOW
            // 
            this.YELLOW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.YELLOW.Location = new System.Drawing.Point(162, 3);
            this.YELLOW.Name = "YELLOW";
            this.YELLOW.Size = new System.Drawing.Size(44, 41);
            this.YELLOW.TabIndex = 4;
            this.YELLOW.UseVisualStyleBackColor = true;
            this.YELLOW.Click += new System.EventHandler(this.YELLOW_Click);
            // 
            // ORANGE
            // 
            this.ORANGE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ORANGE.Location = new System.Drawing.Point(212, 3);
            this.ORANGE.Name = "ORANGE";
            this.ORANGE.Size = new System.Drawing.Size(44, 41);
            this.ORANGE.TabIndex = 5;
            this.ORANGE.UseVisualStyleBackColor = true;
            this.ORANGE.Click += new System.EventHandler(this.ORANGE_Click);
            // 
            // BLACK
            // 
            this.BLACK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BLACK.Location = new System.Drawing.Point(12, 3);
            this.BLACK.Name = "BLACK";
            this.BLACK.Size = new System.Drawing.Size(44, 41);
            this.BLACK.TabIndex = 6;
            this.BLACK.UseVisualStyleBackColor = true;
            this.BLACK.Click += new System.EventHandler(this.BLACK_Click);
            // 
            // GREY
            // 
            this.GREY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GREY.Location = new System.Drawing.Point(62, 3);
            this.GREY.Name = "GREY";
            this.GREY.Size = new System.Drawing.Size(44, 41);
            this.GREY.TabIndex = 7;
            this.GREY.UseVisualStyleBackColor = true;
            this.GREY.Click += new System.EventHandler(this.GREY_Click);
            // 
            // Square
            // 
            this.Square.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Square.Image = ((System.Drawing.Image)(resources.GetObject("Square.Image")));
            this.Square.Location = new System.Drawing.Point(472, 3);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(44, 41);
            this.Square.TabIndex = 8;
            this.Square.UseVisualStyleBackColor = true;
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Circle
            // 
            this.Circle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Circle.Image = global::Client.Properties.Resources.square_shape_shadow;
            this.Circle.Location = new System.Drawing.Point(422, 3);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(44, 41);
            this.Circle.TabIndex = 9;
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // clear
            // 
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear.Image = ((System.Drawing.Image)(resources.GetObject("clear.Image")));
            this.clear.Location = new System.Drawing.Point(535, 3);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(44, 41);
            this.clear.TabIndex = 10;
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(591, 422);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.GREY);
            this.Controls.Add(this.BLACK);
            this.Controls.Add(this.ORANGE);
            this.Controls.Add(this.YELLOW);
            this.Controls.Add(this.GREEN);
            this.Controls.Add(this.BLUE);
            this.Controls.Add(this.RED);
            this.Controls.Add(this.paintBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Paint";
            this.Text = "Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Paint_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox paintBox;
        private System.Windows.Forms.Button RED;
        private System.Windows.Forms.Button BLUE;
        private System.Windows.Forms.Button GREEN;
        private System.Windows.Forms.Button YELLOW;
        private System.Windows.Forms.Button ORANGE;
        private System.Windows.Forms.Button BLACK;
        private System.Windows.Forms.Button GREY;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button clear;
    }
}