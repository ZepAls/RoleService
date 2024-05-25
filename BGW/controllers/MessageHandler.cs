using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGW.controllers
{
    internal class MessageHandler
    {
        public void IdentifyMessage(string message) 
        { 
            //check for messages and link to method to execute fuction
            if (message.Contains("deleted userId: "))
            {
                int id = Int32.Parse(message.Substring(16, message.Length - 16));
                this.RemoveRole(id);
            }
            else
            {
                Console.WriteLine("could not identify message");
            }
        }

        public void RemoveRole(int UserId)
        {
            //remove all roles with that user ID
            Console.WriteLine("removing role with user ID: " + UserId);
        }
    }
}
