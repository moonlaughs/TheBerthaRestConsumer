using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBerthaRestConsumer
{
    public class Users
    {
        public Users(int id, string firstName, string lastName, string userName, string pass, int age, string gender, string typeOfUser)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Pass = pass;
            Age = age;
            Gender = gender;
            TypeOfUser = typeOfUser;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string TypeOfUser { get; set; }

        public Users()
        {

        }

        public override string ToString()
        {
            return Id + FirstName + LastName + TypeOfUser;
        }
    }
}
