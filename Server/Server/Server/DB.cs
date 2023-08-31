using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Server
{/*
    public class DB
    {
        public Root root = new Root();
        public DB(string filename)
        {
            bool test = false;
            if (File.Exists(filename))
            {
                string db = File.ReadAllText(filename);

                root = JsonConvert.DeserializeObject<Root>(db);
                Console.WriteLine("Success");
            }
            else
            {
                
                //populating the db
                root.users = new List<User>();
                for(int i = 0; i< 5; i++){

                    List<Conversation> conservations = new List<Conversation>();
                    for(int j = 0; j < 5; j++)
                    {
                        
                        List<Message> messages = new List<Message>();
                        for (int k = 0; k < 5; k++)
                        {
                            Message message = new Message { sender = "testuser", content = "content", reciever="reciever" };
                            messages.Add(message);
                        }
                        Conversation conversation = new Conversation {messages=messages, user1="testuser", user2="reciever" };
                        conservations.Add(conversation);
                        
                    }
                    
                    User user1 = new User { 
                        user = "testuser", friends = new List<string>(),
                        conversations = conservations,
                        id = i,
                        password= "password"
                    };
                    root.users.Add(user1);
                    
                    

                }
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                Console.WriteLine(json);
               
               
                File.WriteAllText(filename, json);
                
            }
            
            
        }
    }
    public class Root {
        public List<User> users = new List<User>();
    }

    public class Conversation
    {
        public List<Message> messages { get; set; }
        public string user1 { get; set; }
        public string user2 { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
        public string sender { get; set; }
        public string reciever { get; set; }
    }

    

    public class User
    {
        public string user { get; set; }
        public string password { get; set; }
        public int id { get; set; }
        public List<string> friends { get; set; }
        public List<Conversation> conversations { get; set; }
        
    }
    */

    public class Conversation
    {
        public List<Message> messages { get; set; }
        public string user1 { get; set; }
        public string user2 { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
        public string sender { get; set; }
        public string reciever { get; set; }
    }

    public class Root
    {
        public List<User>? users { get; set; }
        public List<Conversation>? conversations { get; set; }
        public List<Groups>? groups { get; set; }
    }

    public class User
    {
        public string user { get; set; }
        public string password { get; set; }
        public List<string> friends { get; set; }
    }

    public class loginClass
    {
        public string username { get; set; }
        public string password { get; set; }
        public string friend { get; set; }
    }

    public class getgroup
    {
        public string username { get; set; }
        public string password { get; set; }
        public string groupName { get; set; }
    }
    public class message
    {
        public string username { get; set; }
        public string password { get; set; }
        public string content { get; set; }
        public string friend { get; set; }
    }

    public class Groups
    {
        public List<Message>? messages { get; set; }
        public List<string> users { get; set; }
        public string name { get; set; } 
    }
}
