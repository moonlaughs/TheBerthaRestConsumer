using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer
{
    public class Users
    {
        public Users(int id2, string firstName2, string lastName2, string userName2, string pass2, int age2, string gender2, string typeOfUser2)
        {
            id = id2;
            firstName = firstName2;
            lastName = lastName2;
            userName = userName2;
            pass = pass2;
            age = age2;
            gender = gender2;
            typeOfUser = typeOfUser2;
        }

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string pass { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string typeOfUser { get; set; }

        public Users()
        {

        }

        public override string ToString()
        {
            return id + firstName + lastName + typeOfUser;
        }
    }
}
