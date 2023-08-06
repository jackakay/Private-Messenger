using Messenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Specialized;
using RestSharp;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Messenger
{
    class Program
    {
        
        static List<string> ListOfFriends = new List<string>();
        const int WIDTH = 60;
        const int HEIGHT = 40;

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(Keys key);


        static async Task Main()
        {

            Console.SetWindowSize(WIDTH, HEIGHT);
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("USERNAME: ");
                string username = Console.ReadLine();
                
                Console.Write("PASSWORD: ");
                string password = Console.ReadLine();
                Models.User user = new Models.User(username, password);
                loggedIn = await API.loginAsync(username, password);
                if (loggedIn)
                {
                    ListOfFriends = await API.getFriendsAsync(username, password);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] SUCCESS");
                    Thread.Sleep(1000);
                    
                    await Menu(user);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[-] FAILURE");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }
            }
            
            
        }

        
        

        static async Task Menu(User user)
        {
            int currentTab = 0;
            Console.ForegroundColor = ConsoleColor.White;
            updateMenu(user, 0);
            while (true)
            {

                if (GetAsyncKeyState(Keys.Up)){
                    if (currentTab > 0)
                    {
                        currentTab--;
                        updateMenu(user, currentTab);
                    }
                    else if (currentTab == 0)
                    {

                    }
                    
                    //up arrow
                }else if (GetAsyncKeyState(Keys.Down))
                {
                    //down arrow
                    if (currentTab < ListOfFriends.Count - 1)
                    {
                        currentTab++;
                    }else if(currentTab == ListOfFriends.Count - 1) {
                        currentTab = 0;
                    }
                    updateMenu(user, currentTab);
                }else if (GetAsyncKeyState(Keys.Right))
                {
                    //right arrow
                    //key
                    Conversation convo = new Conversation();
                    convo = await API.loadMessages(user.user, user.password, ListOfFriends[currentTab]);
                    LoadConvo(convo, user, ListOfFriends[currentTab]);
                    //Console.ReadKey();
                    
                }
                else
                {
                    Thread.Sleep(100);
                }
                Thread.Sleep(30);
                
            }
        }

       

        static void updateMenu(User user, int currentTab)
        {
            Console.Clear();
            int count = 0;
            foreach (string friend in ListOfFriends)
            {
                if (count == currentTab)
                {
                    Console.WriteLine(">" + friend);
                }
                else
                {
                    Console.WriteLine(friend);
                }
                count++;
            }
            


        }


        static void LoadConvo(Conversation convo, User user, string friendName)
        {
            Console.Clear();
            foreach (Models.Message msg in convo.messages)
            {
                Console.WriteLine(msg.sender + " -> " + msg.content);
            }

            Console.SetCursorPosition(0, HEIGHT);
            Console.Write("-> ");
            while (!Program.GetAsyncKeyState(Keys.Escape))
            {
                string message = Console.ReadLine();
                message msg = new message { content = message, friend = friendName, username = user.user, password = user.password };
                if (!String.IsNullOrEmpty(message) && GetAsyncKeyState(Keys.Enter))
                {

                }
            }

        }

        static void enterConversation(int currentTab, User user)
        {
            Friends currentFriend = user.friends[currentTab];

        }

        

    }
}
