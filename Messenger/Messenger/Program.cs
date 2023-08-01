using Messenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Messenger
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);


        static void Main()
        {

            Console.SetWindowSize(60, 40);
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("USERNAME: ");
                string username = Console.ReadLine();
                
                Console.Write("PASSWORD: ");
                string password = Console.ReadLine();
                Models.User user = new Models.User(username, password);
                if (login(username, password))
                {
                    loggedIn = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] SUCCESS");
                    Thread.Sleep(1000);
                    Menu(user);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[-] FAILURE");
                    Thread.Sleep(1000);
                }
            }
            
            
        }

        static bool login(string username, string password)
        {
            //API request to check if username exists
            return true;
        }
        static void Menu(User user)
        {
            int currentTab = 0;
            Console.ForegroundColor = ConsoleColor.White;
            updateMenu(user, 0);
            while (true)
            {

                if (GetAsyncKeyState(38)){
                    if (currentTab > 0)
                    currentTab--;
                    updateMenu(user, currentTab);
                    //down arrow
                }else if (GetAsyncKeyState(40))
                {
                    //up arrow
                    if(currentTab < user.friends.Count - 1)
                    currentTab++;
                    updateMenu(user, currentTab);
                }else if (GetAsyncKeyState(108))
                {
                    //enter key

                }
                else
                {
                    Thread.Sleep(100);
                }
                Thread.Sleep(20);
                
            }
        }
        static void updateMenu(User user, int currentTab)
        {
            Console.Clear();
            int count = 0;
            foreach (Friends friend in user.friends)
            {
                if (count == currentTab)
                {
                    Console.WriteLine(">" + friend.username);
                }
                else
                {
                    Console.WriteLine(friend.username);
                }
                count++;
            }
        }
        static void enterConversation(int currentTab, User user)
        {
            Friends currentFriend = user.friends[currentTab];

        }

    }
}
