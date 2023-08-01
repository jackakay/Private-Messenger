using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Server
{
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
                root.users = new Users();
                for(int i = 0; i< 5; i++){

                    List<Conversation> conservations = new List<Conversation>();
                    for(int j = 0; j < 5; j++)
                    {
                        
                        List<Message> messages = new List<Message>();
                        for (int k = 0; k < 5; k++)
                        {
                            Message message = new Message { sender = "testuser", content = "content" };
                            messages.Add(message);
                        }
                        Conversation conversation = new Conversation {messages=messages };
                        conservations.Add(conversation);
                        
                    }
                    
                    User user1 = new User { 
                        user = "testuser", friends = new List<string>(),
                        conversations = conservations,
                        id = i
                    };
                    root.users.users.Add(user1);
                    
                    

                }
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                Console.WriteLine(json);
                //File.Create(filename);
                File.WriteAllText(filename, json);
            }
            
            
        }
    }
    public class Users {
        public List<User> users = new List<User>();
    }

    public class Conversation
    {
        public List<Message> messages { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
        public string sender { get; set; }
    }

    public class Root
    {
        public Users? users { get; set; }
    }

    public class User
    {
        public string user { get; set; }
        public int id { get; set; }
        public List<string> friends { get; set; }
        public List<Conversation> conversations { get; set; }
        public List<User> users { get; set; }
    }
}
