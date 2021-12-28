using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Models
{
    public class User
    {
        private int id;
        private string firstName, lastName, email, password;
        private bool isAdmin, isLogged;
        public enum StateEnum
        {
            Waiting,
            Accept,
            Ban
        }

        public User()
        {
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public StateEnum StateUser { get; set; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public bool IsLogged { get => isLogged; set => isLogged = value; }
    }
}

