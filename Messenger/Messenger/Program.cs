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

namespace Messenger
{
    class Program
    {
        const string url = "https://localhost:7143/";
        static List<string> ListOfFriends = new List<string>();
        

        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(Keys key);


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
                    ListOfFriends = await getFriendsAsync(username, password);
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

            var options = new RestClientOptions(url)
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

        static async Task<List<string>> getFriendsAsync(string username, string password)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/GetFriends?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' +

             @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            List<string> friends = new List<string>();
            if (!String.IsNullOrEmpty(response.Content))
            {
                string json = response.Content;
                json = json.Substring(1, response.Content.Length - 2).Replace("/", string.Empty).Replace(@"\", string.Empty);
                
                friends = JsonConvert.DeserializeObject<List<string>>(json);
                
            }
            
            return friends;
        }
        static async Task<Conversation> loadMessages(string username, string password, string friendsName)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/GetFriends?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' + ","
             + @"    ""friend"":" + '"' + friendsName + '"' +

             @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Conversation convo = new Conversation();
            convo = JsonConvert.DeserializeObject<Conversation>(response.Content);
            return convo;
        }
        

        static async void Menu(User user)
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
                    
                    await loadMessagesFuncAsync(user, currentTab);
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
        static async Task loadMessagesFuncAsync(User user, int currentTab)
        {
            Console.Clear();

            Conversation convo = new Conversation();
            convo = await loadMessages(user.user, user.password, ListOfFriends[currentTab]);
            foreach (Models.Message msg in convo.messages)
            {
                Console.WriteLine(msg.sender + " -> " + msg.content);
            }
        }
        static void enterConversation(int currentTab, User user)
        {
            Friends currentFriend = user.friends[currentTab];

        }

        

    }
}
