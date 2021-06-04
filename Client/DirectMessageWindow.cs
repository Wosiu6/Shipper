using Classes;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class DirectMessageWindow : Form
    {
        Client_window parent_form;
        public DirectMessageWindow(Client_window parent_form, string nickname)
        {
            this.parent_form = parent_form;
            InitializeComponent();
            Text = nickname;
        }

        void Send_btn_Click(object sender, EventArgs e)
        {
            if (parent_form.TCPConnected)
                if (InvokeRequired)
                    Invoke(new MethodInvoker(delegate
                    {
                        Send_btn_Click(sender, e);
                    }));
                else
                {
                    parent_form.SendPacket(new DirectMessagePacket(Text, Message_txt.Text));

                    messages_listBox.BeginUpdate();
                    messages_listBox.Items.Add(parent_form.nickname + " >> " + Message_txt.Text);
                    messages_listBox.EndUpdate();

                    Message_txt.Clear();
                }
        }

        void DirectMessageWindow_Load(object sender, EventArgs e)
        {
        }

        void messages_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void DisplayMessage(string msg, string who)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                {
                    DisplayMessage(msg, who);
                }));
            else
            {
                messages_listBox.BeginUpdate();

                messages_listBox.Items.Add(who + " >> " + msg);

                messages_listBox.EndUpdate();

                messages_listBox.SelectedIndex = messages_listBox.Items.Count - 1;
                messages_listBox.SelectedIndex = -1;
            }
        }

        public void DisplayMessageNOTCONNECTED(string receiverID)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                {
                    DisplayMessageNOTCONNECTED(receiverID);
                }));
            else
            {
                messages_listBox.BeginUpdate();

                messages_listBox.Items.Add("Client not Connected");

                messages_listBox.EndUpdate();

                messages_listBox.SelectedIndex = messages_listBox.Items.Count - 1;
                messages_listBox.SelectedIndex = -1;
            }
        }

        void Message_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        void Message_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Send_btn_Click(sender, e);
        }
    }
}