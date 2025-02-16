using System;

namespace PIS
{
    public class User
    {
        public string surname;
        public string name;
        public string fathers_name;
        public DateTime dateofbirth;
        public string email;
        public string phone;
        public string visitpurpose;
        public string password;

        public User(string surname, string name, string fathers_name, DateTime dateofbirth, string phone, string email, string visitpurpose, string password)
        {
            this.surname = surname;
            this.name = name;
            this.fathers_name = fathers_name;
            this.dateofbirth = dateofbirth;
            this.email = email;
            this.phone = phone;
            this.visitpurpose = visitpurpose;
            this.password = password;
        }
    }
}
