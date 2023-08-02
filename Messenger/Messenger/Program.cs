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

namespace Messenger
{
    class Program
    {
        const string url = "https://localhost:5001/";

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(int vKey);


        static async Task Main()
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
                loggedIn = await loginAsync(username, password);
                if (loggedIn)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] SUCCESS");
                    Thread.Sleep(1000);
                    Menu(user);

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

        static async Task<bool> loginAsync(string username, string password)
        {
            //API request to check if username exists

            var options = new RestClientOptions("https://localhost:7143")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/login?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""username"":" + '"' + username + '"' + "," 
 + "\n" + 
            @"    ""password"":" + '"' + password + '"' + 

            @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            if (response.Content == @"""Success""")
            {
                return true;
            }
            else
            {
                return false;
            }
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
