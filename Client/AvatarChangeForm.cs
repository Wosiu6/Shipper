using System;
using System.Windows.Forms;

namespace Client
{
    public partial class AvatarChangeForm : Form
    {
        Client_window parent;
        public AvatarChangeForm(Client_window parent_form)
        {
            parent = parent_form;

            InitializeComponent();

            avatars_listv.SmallImageList = avatarImageList;

            for (int i = 0; i < avatarImageList.Images.Count; i++)
            {
                avatars_listv.BeginUpdate();

                var item = new ListViewItem(avatarImageList.Images.Keys[i], i);
                avatars_listv.Items.Add(item);

                // clients_Listbox = new ListView();
                avatars_listv.EndUpdate();
            }
        }

        void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void button1_Click(object sender, EventArgs e)
        {
            if (avatars_listv.SelectedItems.Count != 1)
            {
                MessageBox.Show("You need to choose one Avatar to do this");
                return;
            }

            parent.UpdateAvatar(avatars_listv.SelectedItems[0].Index, parent.nickname);
            MessageBox.Show("Avatar changed!");
            Dispose();
        }

        void label1_Click(object sender, EventArgs e)
        {
        }

        void avatars_listv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                parent.UpdateAvatar(avatars_listv.SelectedItems[0].Index, parent.nickname);
                MessageBox.Show("Avatar changed!");
                Dispose();
            }
            catch (Exception ex)
            {
            }
        }
    }
}