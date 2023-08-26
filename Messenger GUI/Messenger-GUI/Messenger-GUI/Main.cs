﻿using Messenger.Models;
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
        public Main()
        {
            InitializeComponent();

        }

        private async void Main_Load(object sender, EventArgs e)
        {
            friends = await API.getFriendsAsync(Program.user, Program.pass);





            
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


                    convo = await API.loadMessages(Program.user, Program.pass, friend);
                    richTextBox1.Invoke(() => richTextBox1.Text = "");
                    foreach (Messenger.Models.Message msg in convo.messages)
                    {
                        richTextBox1.Invoke(() => richTextBox1.Text += msg.sender + " -> " + msg.content + "\n");

                    }
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string friend in friends)
            {

                listBox1.Items.Add(friend);
            }
        }
    }
}
