﻿using Messenger.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger_GUI
{
    public static class API
    {
        //public const string url = "https://serverapi123.azurewebsites.net/";
        public const string url = "https://localhost:7143";
        //public const string url = "https://dc18-81-103-198-207.ngrok.io";


        public static async Task<bool> loginAsync(string username, string password)
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

            if (response.Content == @"""Success""")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<List<string>> getFriendsAsync(string username, string password)
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
        public static async Task<Conversation> loadMessages(string username, string password, string friendsName)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/LoadMessages?Content-Type=Application/json", Method.Post);
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
            string json = response.Content;
            json = json.Substring(1, response.Content.Length - 2).Replace("/", string.Empty).Replace(@"\", string.Empty);
            convo = JsonConvert.DeserializeObject<Conversation>(json);
            return convo;
        }

        public static async Task<bool> SendMessage(string username, string password, string content, string friend)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/SendMessage?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' + ","
             + @"    ""friend"":" + '"' + friend + '"' + "," +
             @"""content"":" + '"' + content + '"' +

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

        public static async Task<bool> AddFriend(string username, string password, string friend)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/Friend?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' + ","
             + @"    ""friend"":" + '"' + friend + '"' + 
             

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
        public static async Task<bool> CreateUser(string username, string password)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/UserCreate?Content-Type=Application/json", Method.Post);
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


        public static async Task<groups> GetGroup(string username, string password, string name)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/GetGroup?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' + ","
              + "\n" +
             @"    ""name"":" + '"' + name + '"' + 


             @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            if (response.Content != @"""Fail""")
            {
                string json = response.Content;
                json = json.Substring(1, response.Content.Length - 2).Replace("/", string.Empty).Replace(@"\", string.Empty);
                groups groups = JsonConvert.DeserializeObject<groups>(json);
                
                return groups;
            }
            else
            {
                return null;
            }
        }
        public static async Task<List<groups>> GetGroups(string username, string password)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/GetGroups?Content-Type=Application/json", Method.Post);
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
            if (response.Content != @"""Fail""")
            {


                string json = response.Content;
                json = json.Substring(1, response.Content.Length - 2).Replace("/", string.Empty).Replace(@"\", string.Empty);
                List<groups> group = JsonConvert.DeserializeObject<List<groups>>(json);
                return group;
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool> AddUserToGroup(string username, string password,string friend, string groupName)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/AddFriendToGroup?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' + "," +
             @"    ""message"":" + '"' + friend + '"' +
             @"    ""groupName"":" + '"' + groupName + '"' +


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
        public static async Task<bool> SendGroupMessage(string username, string password, string msg, string group)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/SendGroupMessage?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' + "," +
             @"    ""message"":" + '"' + msg + '"' + "," +
             @"    ""groupName"":" + '"' + group + '"' +


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
        public static async Task<bool> RemoveFriendFromGroup(string username, string password, string friend, string group)
        {
            var options = new RestClientOptions(url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/RemoveFriendFromGroup?Content-Type=Application/json", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
             @"    ""username"":" + '"' + username + '"' + ","
  + "\n" +
             @"    ""password"":" + '"' + password + '"' + "," +
             @"    ""message"":" + '"' + friend + '"' +
             @"    ""groupName"":" + '"' + group + '"' +


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
    }
}
