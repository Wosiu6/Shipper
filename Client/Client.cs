using Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Client_window : Form
    {
        Thread clientTCPthread;
        Thread clientUDPthread;

        ArrayList dmWindowsList = new ArrayList();
        AvatarChangeForm AvatarForm;
        Paint paintWindow;

        bool moveRight, moveUp;
        Point ShipDestination, startLocation;

        Thread swimmingBoatThread;
        public string nickname { get; private set; }
        readonly TcpClient clientSocket = new TcpClient();
        readonly UdpClient UDPSocket = new UdpClient();
        public bool TCPConnected;
        public bool UDPConnected;

        NetworkStream serverStream = default;

        string readMessage;

        SortedDictionary<string, int> avatarList = new SortedDictionary<string, int>();

        // Bitmap avatar;

        int avatarID;

        public Client_window()
        {
            InitializeComponent();

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Interval = 20;
            timer2.Tick += new EventHandler(timer2_Tick);

            startLocation = LittlePictureBox.Location;
            Focus();
        }

        Packet ReadTCPPackets()
        {
            serverStream = clientSocket.GetStream();

            byte[] inStream = new byte[4096];
            _ = serverStream.Read(inStream, 0, inStream.Length);

            var newPacket = (Packet)Packet.Desirialize(inStream);

            return newPacket;
        }

        void GetPackets_TCP()
        {
            try
            {
                var newPacket = ReadTCPPackets();

                if (!(newPacket == null))
                    switch (newPacket.Type)
                    {
                        case PacketType.AVATAR:
                            {
                                UpdateAvatar(avatarID, nickname);
                                break;
                            }

                        case PacketType.MESSAGEPACKET:
                            {
                                DisplayMessage(newPacket);
                                break;
                            }
                        case PacketType.NICKNAMEPACKET:
                            {
                                try
                                {
                                    CloseClient_msg("Nickname is already taken, try again by reopening the application");
                                }
                                catch (Exception e)
                                {
                                }

                                break;
                            }


                        case PacketType.LISTOFCLIENTS:
                            {
                                UpdateListOfClients(newPacket);
                                break;
                            }
                        case PacketType.IMAGE:
                            {
                                Swim(newPacket);

                                break;
                            }
                        case PacketType.CLEANIMAGE:
                            {
                                swimmingBoatThread.Abort();
                                swimmingBoatThread = null;

                                break;
                            }
                        case PacketType.DIRECTMESSAGE:
                            {
                                var dm = OpenWindowIfNeeded((DirectMessagePacket)newPacket);
                                DisplayDirectMessage((DirectMessagePacket)newPacket, dm);
                                break;
                            }
                        case PacketType.NOTCONNECTEDDIRECTMESSAGE:
                            {
                                MessageBox.Show("Client Not connected, try again later!");
                                break;
                            }
                        case PacketType.ENDPOINT:
                            {
                                StartUDP(newPacket);

                                break;
                            }
                    }
            }
            catch (Exception e)
            {
                SendPacket(new ClientClosePacket());

                Dispose();
            }
        }

        void StartUDP(Packet newPacket)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                {
                    StartUDP(newPacket);
                }));
            else
            {
                UDPSocket.Client.Connect(((EndPointPacket)newPacket).EndPoint);
                allMessages_listBox.Items.Add("Connected UDP");

                clientUDPthread = new Thread(ClientUDPThreadMethod);

                UDPConnected = true;

                clientUDPthread.Start();
            }
        }

        public void UpdateAvatar(int avatarID, string nickname)
        {
            SendPacket(new AvatarChangePacket(avatarID));
        }

        void Swim(Packet newPacket)
        {
            if (timer1.Enabled) timer1.Dispose();
            if (timer2.Enabled) timer2.Dispose();

            var currentLocation = LittlePictureBox.Location;
            ShipDestination = ((ImagePacket)newPacket).direction;

            if (currentLocation.X > ((ImagePacket)newPacket).direction.X)
                moveRight = false;
            else
                moveRight = true;
            if (currentLocation.Y > ((ImagePacket)newPacket).direction.Y)
                moveUp = false;
            else
                moveUp = true;

            if (swimmingBoatThread == null)
            {
                swimmingBoatThread = new Thread(new ParameterizedThreadStart(MoveImage));

                swimmingBoatThread.Start(newPacket);
            }
            else
            {
                swimmingBoatThread.Abort();

                swimmingBoatThread = null;

                swimmingBoatThread = new Thread(new ParameterizedThreadStart(MoveImage));

                swimmingBoatThread.Start(newPacket);
            }
        }

        public void DisplayDirectMessageNotPresent(DirectMessagePacket newPacket, DirectMessageWindow child)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                {
                    DisplayDirectMessage(newPacket, child);
                }));
            else
            {
                child.DisplayMessageNOTCONNECTED(newPacket.receiverID);
                Invoke(new MethodInvoker(child.Show));
            }
        }

        public void DisplayDirectMessage(DirectMessagePacket newPacket, DirectMessageWindow child)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                {
                    DisplayDirectMessage(newPacket, child);
                }));
            else
            {
                child.DisplayMessage(newPacket.msg, newPacket.receiverID);
                Invoke(new MethodInvoker(child.Show));
            }
        }

        public DirectMessageWindow OpenWindowIfNeeded(DirectMessagePacket newPacket)
        {
            var found = false;
            foreach (DirectMessageWindow o in dmWindowsList)
            {
                if (o.Text.Equals(newPacket.receiverID))
                {
                    found = true;
                    return o;
                }
            }

            if (!found)
            {
                var w = new DirectMessageWindow(this, newPacket.receiverID);
                dmWindowsList.Add(w);
                return w;
            }

            return null;
        }

        public static byte[] GetSerialisedImage(Bitmap bm)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        public static Bitmap GetDesarialisedImage(byte[] serialisedImage)
        {
            using (MemoryStream ms = new MemoryStream(serialisedImage))
                return new Bitmap(ms);
        }

        void MoveImage(object newPacket)
        {
            if (InvokeRequired)

                Invoke(new MethodInvoker(delegate
                {
                    MoveImage(newPacket);
                }));
            else
            {
                LittlePictureBox.Image = GetDesarialisedImage(((ImagePacket)newPacket).bitmap);

                var temp = LittlePictureBox.Location;

                LittlePictureBox.Show();

                timer1.Start();
            }
        }

        public void SendPacket(object newPacket)
        {
            try
            {
                serverStream = clientSocket.GetStream();

                byte[] outStream = Packet.Serialize(newPacket);

                serverStream.Write(outStream, 0, outStream.Length);

                serverStream.Flush();
            }
            catch (Exception e)
            {
                Dispose();
                Application.Exit();
            }
        }

        void DisplayMessage(Packet newPacket)
        {
            if (InvokeRequired)

                Invoke(new MethodInvoker(delegate
                {
                    DisplayMessage(newPacket);
                }));

            else
            {
                allMessages_listBox.BeginUpdate();
                allMessages_listBox.Items.Add(Environment.NewLine + " >> " + ((MessagePacket)newPacket).msg);
                allMessages_listBox.EndUpdate();

                allMessages_listBox.SelectedIndex = allMessages_listBox.Items.Count - 1;
                allMessages_listBox.SelectedIndex = -1;
            }
            // messages_richTextBox.Text = messages_richTextBox.Text + Environment.NewLine + " >> " + readData;
        }

        void Client_window_Load(object sender, EventArgs e)
        {
        }

        void UpdateListOfClients(object newPacket)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                {
                    UpdateListOfClients(newPacket);
                }
                ));
            else
            {
                try
                {
                    clients_Listbox.Items.Clear();

                    avatarList = ((ListOfClientsPacket)newPacket).ListOfClients;

                    var i = 0;

                    foreach (KeyValuePair<string, int> c in ((ListOfClientsPacket)newPacket).ListOfClients)
                    {
                        clients_Listbox.SmallImageList = avatarImageList;

                        clients_Listbox.BeginUpdate();

                        var item = new ListViewItem(c.Key, c.Value);
                        clients_Listbox.Items.Add(item);

                        // clients_Listbox = new ListView();
                        clients_Listbox.EndUpdate();

                        i++;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception occured whilst trying to update list of clients (Client Side)" + e.Message);
                }
            }
        }

        void login_Btn_Click(object sender, EventArgs e)
        {
            var validation = ValidateNickname();

            if (!validation) return;

            try
            {
                login();
            }
            catch (Exception exc)
            {
                // MessageBox.Show("Exception occured during login" + exc.Message);
            }
        }

        void connectUDP()
        {
            UDPSocket.Client.Connect("127.0.0.1", 8888);

            SendPacket(new EndPointPacket(UDPSocket.Client.LocalEndPoint));

            UDPConnected = UDPSocket.Client.Connected;
        }

        public void SendPacket_UDP(Packet newPacket)
        {
            UDPSocket.Client.Send(Packet.Serialize(newPacket));
        }

        public void CloseClient_msg(string msg)
        {
            MessageBox.Show(msg);
            Invoke(new MethodInvoker(Dispose));
            Application.Exit();
        }

        void login()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                {
                    login();
                }));
            readMessage = "Conected to Chat Server... \n Welcome: " + nickname_txtBox.Text;
            try
            {
                if (!clientSocket.Connected)
                    clientSocket.Connect("127.0.0.1", 8888);

                serverStream = clientSocket.GetStream();
            }
            catch (Exception e)
            {
                CloseClient_msg("Server is not running, try again later!");
            }

            nickname = nickname_txtBox.Text;

            if (avatarID == 0)
                avatarID = new Random().Next(0, avatarImageList.Images.Count - 1);

            // avatar = avatarImageList.Images[avatarID];

            SendPacket(new NicknamePacket(nickname, avatarID));

            nickname_txtBox.Enabled = false;

            login_Btn.Enabled = false;

            login_Btn.Hide();

            userMessage_txtBox.Enabled = true;

            menuToolStripMenuItem.Enabled = true;

            disconnectToolStripMenuItem.Enabled = true;

            send_Btn.Enabled = true;

            TCPConnected = true;

            gamesToolStripMenuItem.Enabled = true;

            nickname_label.ForeColor = Color.Gray;

            welcomeMessage_label.Text = "Welcome " + nickname;

            welcomeMessage_label.Show();

            clientTCPthread = new Thread(ClientTCPThreadMethod);

            clientTCPthread.Start();
        }

        void ClientTCPThreadMethod()
        {
            while (true)
                GetPackets_TCP();
        }

        void ClientUDPThreadMethod()
        {
            while (true)
                GetPackets_UDP();
        }

        void GetPackets_UDP()
        {
            Packet newPacket = null;
            try
            {
                newPacket = ReadUDPPackets();

                if (!(newPacket == null))
                    switch (newPacket.Type)
                    {
                        case PacketType.MESSAGEPACKET:
                            {
                                DisplayMessage(newPacket);
                                break;
                            }
                        case PacketType.PAINT:
                            {
                                OpenPaintWindow();

                                PaintThisPacket(newPacket);
                                break;
                            }
                        case PacketType.CHANGEPAINT:
                            {
                                OpenPaintWindow();

                                ChangeThisPaint(newPacket);
                                break;
                            }
                        case PacketType.REQUESTPAINT:
                            {
                                SendPacket_UDP(new PaintPacket(paintWindow.bmp));
                                break;
                            }
                    }
            }
            catch (Exception e)
            {
                newPacket = null;
            }
        }

        void ChangeThisPaint(Packet newPacket) => paintWindow.SetImage(((PaintPacket)newPacket).bmp);

        void PaintThisPacket(Packet newPacket)
        {
            var newPaintPacket = (PaintPacket)newPacket;

            paintWindow.paintOnCanvas(newPaintPacket.currentPoint, newPaintPacket.point, newPaintPacket.col, newPaintPacket.size);
        }

        void OpenPaintWindow()
        {
            if (paintWindow == null)
            {
                paintWindow = new Paint(this);
            }
            else
            {
            }
        }

        Packet ReadUDPPackets()
        {
            byte[] inStream = new byte[4096];

            _ = UDPSocket.Client.Receive(inStream);

            var newPacket = (Packet)Packet.Desirialize(inStream);

            return newPacket;
        }

        bool ValidateNickname()
        {
            var regex = new Regex(@"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$");

            var valid = regex.IsMatch(nickname_txtBox.Text);

            var errorMessage = valid ? string.Empty : "Please enter valid name";

            if (valid)
                errorMessage = "Successfully logged in!";
            else
            {
                MessageBox.Show(errorMessage);

                nickname_txtBox.Text = "";
            }

            return valid;
        }

        void send_Btn_Click(object sender, EventArgs e)
        {
            if (userMessage_txtBox.Text.Length < 1)
            {
                MessageBox.Show("Your message cannot be empty");
                return;
            }
            else
                SendPacket(new MessagePacket(userMessage_txtBox.Text));

            userMessage_txtBox.Text = "";
            allMessages_listBox.SelectedIndex = allMessages_listBox.Items.Count - 1;
            allMessages_listBox.SelectedIndex = -1;
        }

        void Client_window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TCPConnected)
            {
                if (!(paintWindow == null || paintWindow.IsDisposed))
                {
                    paintWindow.Dispose();
                }

                foreach (DirectMessageWindow dm in dmWindowsList)
                {
                    if (!(dm == null || dm.IsDisposed))
                    {
                        Invoke(new MethodInvoker(dm.Dispose));
                    }
                }

                if (!(AvatarForm == null || AvatarForm.IsDisposed))
                {
                    AvatarForm.Dispose();
                }

                SendPacket(new ClientClosePacket());
                TCPConnected = false;
            }

            Thread.Sleep(100);

            Dispose();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            var x = LittlePictureBox.Location.X;
            var y = LittlePictureBox.Location.Y;

            if (x == ShipDestination.X)
            {
                timer2.Start();
                timer1.Stop();
            }
            else
            {
                if (moveRight)
                    LittlePictureBox.Location = new Point(x + 1, y);
                else
                    LittlePictureBox.Location = new Point(x - 1, y);
            }
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            var x = LittlePictureBox.Location.X;
            var y = LittlePictureBox.Location.Y;

            if (y == ShipDestination.Y) timer2.Stop();
            else if (moveUp)
                LittlePictureBox.Location = new Point(x, y + 1);
            else
                LittlePictureBox.Location = new Point(x, y - 1);
        }

        void clients_Listbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var item = clients_Listbox.SelectedItems[0];
                foreach (DirectMessageWindow o in dmWindowsList)
                {
                    if (o.Text.Equals(item.Text))
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            o.Hide();
                            o.Show();
                        }));
                        return;
                    }
                }

                if (item.Text.Equals(nickname))
                {
                    MessageBox.Show("Cannot message yourself");
                }
                else
                {
                    var dm = new Thread(new ParameterizedThreadStart(DirectMessagingMethod));

                    dm.Start(item.Text);
                }
            }
            catch (Exception ex)
            {
            }
        }

        void changeAvatarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AvatarForm == null || AvatarForm.IsDisposed)
            {
                AvatarForm = new AvatarChangeForm(this);
                AvatarForm.Show();
            }
            else
            {
                AvatarForm.Hide();
                AvatarForm.Show();
            }
        }

        void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(paintWindow == null || paintWindow.IsDisposed))
                {
                    paintWindow.Dispose();
                }

                foreach (DirectMessageWindow dm in dmWindowsList)
                {
                    if (!(dm == null || dm.IsDisposed))
                    {
                        Invoke(new MethodInvoker(dm.Dispose));
                    }
                }

                if (!(AvatarForm == null || AvatarForm.IsDisposed))
                {
                    AvatarForm.Dispose();
                }

                SendPacket(new ClientClosePacket());
                Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TCPConnected = false;
                disconnectToolStripMenuItem.Enabled = false;
                welcomeMessage_label.Hide();
                clients_Listbox.Clear();
                connectToolStripMenuItem.Enabled = true;
                changeAvatarToolStripMenuItem.Enabled = false;
                send_Btn.Enabled = false;
                gamesToolStripMenuItem.Enabled = false;
                userMessage_txtBox.Enabled = false;
                allMessages_listBox.Items.Add("Disconnected");
                if (timer1.Enabled) timer1.Dispose();
                if (timer2.Enabled) timer2.Dispose();
                LittlePictureBox.Visible = false;
                LittlePictureBox.Hide();
                if (!(paintWindow == null || paintWindow.IsDisposed))
                {
                    paintWindow.Dispose();
                }

                foreach (DirectMessageWindow dm in dmWindowsList)
                {
                    if (!(dm == null || dm.IsDisposed))
                    {
                        Invoke(new MethodInvoker(dm.Dispose));
                    }
                }

                if (!(AvatarForm == null || AvatarForm.IsDisposed))
                {
                    AvatarForm.Dispose();
                }

                SendPacket(new RequestDisconnectPacket());
            }
            catch (Exception ex)
            {
                SendPacket(new RequestDisconnectPacket());
            }
        }

        void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TCPConnected = true;
                disconnectToolStripMenuItem.Enabled = true;
                login_Btn.Enabled = false;
                welcomeMessage_label.Show();
                connectToolStripMenuItem.Enabled = false;
                changeAvatarToolStripMenuItem.Enabled = true;
                send_Btn.Enabled = true;
                gamesToolStripMenuItem.Enabled = true;
                userMessage_txtBox.Enabled = true;

                SendPacket(new RequestConnectPacket());
            }
            catch (Exception ex)
            {
                SendPacket(new RequestConnectPacket());
            }
        }

        void PaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (paintWindow == null || paintWindow.IsDisposed)
                paintWindow = new Paint(this);
            paintWindow.Hide();
            paintWindow.Show();
            if (!UDPConnected) connectUDP();
        }

        void sendUDPTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacket_UDP(new MessagePacket("WORKS"));
        }

        void DirectMessagingMethod(object nickname)
        {
            Form dmWindow = new DirectMessageWindow(this, (string)nickname);
            dmWindowsList.Add(dmWindow);
            dmWindow.ShowDialog();
        }

        void Client_window_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TCPConnected)
            {
                var relativePoint = PointToClient(Cursor.Position);

                relativePoint.X -= 10;
                relativePoint.Y -= 10;

                SendPacket(new ImagePacket(relativePoint));
            }
        }
    }
}