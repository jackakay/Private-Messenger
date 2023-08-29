using Messenger.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger_GUI
{
    public partial class Main : Form
    {
        List<string> friends;
        private int textboxlength = 0;
        public Main()
        {
            InitializeComponent();

        }

        private async void Main_Load(object sender, EventArgs e)
        {
            friends = await API.getFriendsAsync(Program.user, Program.pass);

            foreach (string friend in friends)
            {

                listBox1.Items.Add(friend);
            }
            panel2.Hide();



        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool first = true;
            string friend = friends[listBox1.SelectedIndex];

            int index = listBox1.SelectedIndex;

            Thread thread = new Thread(delegate ()
            {
                LoadMessages(friend);
            });
            thread.Start();
            Conversation convo = new Conversation();
            convo = await API.loadMessages(Program.user, Program.pass, friend);
            listBox2.Items.Add(convo.user1);
            listBox2.Items.Add(convo.user2);



        }

        private async void LoadMessages(string friend)
        {
            bool first = true;
            Conversation convo = new Conversation();
            convo = await API.loadMessages(Program.user, Program.pass, friend);
            string lastMessage = convo.messages.Last().content;
            string previouslastmessage = lastMessage;
            Conversation lastconvo = convo;
            while (true)
            {
                if (lastMessage != previouslastmessage || first)
                {

                    first = false;
                    richTextBox1.Invoke(() => richTextBox1.SelectionStart = textboxlength);
                    richTextBox1.Invoke(() => richTextBox1.ScrollToCaret());

                    convo = await API.loadMessages(Program.user, Program.pass, friend);
                    richTextBox1.Invoke(() => richTextBox1.Text = "");
                    foreach (Messenger.Models.Message msg in convo.messages)
                    {
                        richTextBox1.Invoke(() => richTextBox1.Text += msg.sender + " -> " + msg.content + "\n");

                    }
                    richTextBox1.Invoke(() => richTextBox1.ScrollToCaret());

                    richTextBox1.Invoke(() => richTextBox1.SelectionStart = textboxlength);
                    richTextBox1.Invoke(() => richTextBox1.ScrollToCaret());

                    previouslastmessage = lastMessage;
                }
                else
                {
                    convo = await API.loadMessages(Program.user, Program.pass, friend);
                    lastMessage = convo.messages.Last().content;
                }

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool sent = await API.SendMessage(Program.user, Program.pass, textBox1.Text, friends[listBox1.SelectedIndex]);
            textBox1.Clear();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            if (!friends.Contains(textBox2.Text))
            {
                listBox1.Items.Clear();
                bool success = await API.AddFriend(Program.user, Program.pass, textBox2.Text);
                if (!success) MessageBox.Show("Failure to add friend. Incorrect name or user doesnt exist.");
                else
                {
                    friends.Add(textBox2.Text);
                    bool firstMessage = await API.SendMessage(Program.user, Program.pass, "Hello! I just started this chat!", textBox2.Text);
                }
                foreach (string friend in friends)
                {

                    listBox1.Items.Add(friend);
                }
            }
            else
            {
                MessageBox.Show("You already have " + textBox2.Text + " as a friend.");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                bool sent = await API.SendMessage(Program.user, Program.pass, textBox1.Text, friends[listBox1.SelectedIndex]);
                textBox1.Clear();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textboxlength = richTextBox1.Text.Length;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            friends = await API.getFriendsAsync(Program.user, Program.pass);

            foreach (string friend in friends)
            {

                listBox1.Items.Add(friend);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            panel2.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //join group
        }
    }
}
