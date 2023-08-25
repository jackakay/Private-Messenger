using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    public static class Cryptography
    {
        

        public static string Encrypt(string item, string key)
        {
            string encryptedMessage = "";
            string newkey = key;
            string newitem = item;
            if(item == GetLargest(item, key))
            {
                for(int j = 0; j < item.Length-key.Length; j++)
                {
                    newkey += " ";
                }
            }
            else
            {
                for (int j = 0; j < key.Length - item.Length; j++)
                {
                    newitem += " ";
                }
            }
            for (int i = 0; i < item.Length; i++){
                char newChar = (char)((int)newitem[i] + newkey[i]);
                encryptedMessage += newChar;
            }
            return encryptedMessage;
        }
        private static string GetLargest(string one, string two)
        {
            if (one.Length > two.Length) return one;
            else return two;
        }
        
    }
}
