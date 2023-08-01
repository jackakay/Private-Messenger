using System.Collections.Generic;

namespace Messenger.Models
{
    public  class Friends
    {

        public string username { get; set; }
        public List<Message> messages { get; set; }

        public int id { get; set; }

        public Friends(string user) {
            username = user;
            messages = getMessages(id);
        }

        private List<Message> getMessages(int id)
        {
            List<Message> messages = new List<Message>();
            return messages;
        }
    }
}