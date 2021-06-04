using Classes;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Paint : Form
    {
        Thread paintThread;

        public Bitmap bmp;

        Client_window parent;

        Point lastPoint = Point.Empty;//Point.Empty represents null for a Point object

        bool isMouseDown = new bool();//this is used to evaluate whether our mousebutton is down or not

        Color color = Color.Black;

        int size = 2;

        public Paint(Client_window parent_form)
        {
            parent = parent_form;
            InitializeComponent();

            paintBox.BackColor = Color.White;

            BLACK.BackColor = Color.Black;
            GREY.BackColor = Color.Gray;
            GREEN.BackColor = Color.PaleGreen;
            YELLOW.BackColor = Color.Gold;
            ORANGE.BackColor = Color.Orange;
            RED.BackColor = Color.Crimson;
            BLUE.BackColor = Color.DeepSkyBlue;
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = paintBox.PointToClient(Cursor.Position);

            isMouseDown = true;
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (isMouseDown)
                {
                    paintThread = new Thread(new ParameterizedThreadStart(delegate
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            var relativePoint = paintBox.PointToClient(Cursor.Position);
                            var relativeLastPoint = paintBox.PointToClient(lastPoint);
                            if (isMouseDown)
                            {
                                parent.SendPacket_UDP(new PaintPacket(lastPoint, relativePoint, color, size));
                            }

                            paintThread.Abort();
                        }));
                    }));

                    paintThread.Start();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void paintOnCanvas(Point e, Point last, Color c, int size)
        {
            try
            {
                if (last != null)//if our last point is not null, which in this case we have assigned above
                {
                    if (paintBox.Image == null)//if no available bitmap exists on the picturebox to draw on
                    {
                        // create a new bitmap
                        bmp = new Bitmap(paintBox.Width, paintBox.Height);

                        paintBox.Image = bmp;

                        // assign the picturebox.Image property to the bitmap created
                    }

                    using (Graphics g = Graphics.FromImage(paintBox.Image))
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            g.DrawLine(new Pen(c, size), last, e);
                            g.SmoothingMode = SmoothingMode.AntiAlias;

                            lastPoint = e;
                        }));
                    }

                    paintBox.Invalidate();//refreshes the picturebox
                }
            }
            catch (Exception ex)
            {
            }
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            paintThread.Abort();

            lastPoint = Point.Empty;

            bmp = new Bitmap(paintBox.Image);
        }

        void RED_Click(object sender, EventArgs e) => color = RED.BackColor;

        void BLUE_Click(object sender, EventArgs e) => color = BLUE.BackColor;

        void GREEN_Click(object sender, EventArgs e) => color = GREEN.BackColor;

        void YELLOW_Click(object sender, EventArgs e) => color = YELLOW.BackColor;

        void ORANGE_Click(object sender, EventArgs e) => color = ORANGE.BackColor;

        void BLACK_Click(object sender, EventArgs e) => color = BLACK.BackColor;

        void GREY_Click(object sender, EventArgs e) => color = GREY.BackColor;

        void Circle_Click(object sender, EventArgs e) => size = 5;

        void Square_Click(object sender, EventArgs e) => size = 2;

        void clear_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(paintBox.Width, paintBox.Height);

            parent.SendPacket_UDP(new PaintPacket(bmp));
        }

        public void SetImage(Bitmap bmp)
        {
            this.bmp = bmp;

            paintBox.Image = bmp;
        }

        void Paint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}