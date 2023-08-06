using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class Message
    {
        public string content { get; set; }
        public string sender { get; set; }
        public string reciever { get; set; }

    }
    public class Conversation
    {
        public List<Message> messages { get; set; }
        public string user1 { get; set; }
        public string user2 { get; set; }
    }

    public class message
    {
        public string username { get; set; }
        public string password { get; set; }
        public string content { get; set; }
        public string friend { get; set; }
    }

}
