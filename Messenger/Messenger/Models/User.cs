using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class User
    {
        public string user { get; set; }
        private string password { get; set; }

        public int id { get; set; }
        public List<Friends> friends { get; set; }

        public User(string username, string pass) {
            user = username;
            password = pass;
            friends = GetFriends();
        }

        private List<Friends> GetFriends()
        {
            //access api and db to find all friends
            List<Friends> friends = new List<Friends>();
            //test to populate friends
            for(int i = 0; i < 5; i++)
            {
                friends.Add(new Friends("test"));  
                
            }
            return friends;
        }
    }
    
}
