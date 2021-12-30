using devTalksASP.Interfaces;
using devTalksASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace devTalksASP.Services
{
    public class SigninService
    {
        private IRepository<User> _userRepository;
        private IHttpContextAccessor _accessor;
        public string FirstName { get => _accessor.HttpContext.Session.GetString("firstname"); }
        public string LastName { get => _accessor.HttpContext.Session.GetString("lastname"); }
        public int? UserId { get => _accessor.HttpContext.Session.GetInt32("id"); }


        public SigninService(IRepository<User> userRepository, IHttpContextAccessor accessor)
        {
            _userRepository = userRepository;
            _accessor = accessor;
        }

        public bool Login(string email,string pw)
        {
            User u = _userRepository.SearchOne(u => u.Email == email && u.Password == pw);
            if (u != null)
            {
                _accessor.HttpContext.Session.SetString("isLogged", "true");
                _accessor.HttpContext.Session.SetString("firstname", u.FirstName);
                _accessor.HttpContext.Session.SetString("lastname", u.LastName);
                _accessor.HttpContext.Session.SetInt32("id", u.Id);
                return true;
            }
            return false;
        }

        public bool IsExist(string email)
        {
            User u = _userRepository.SearchOne(u => u.Email == email);
            if (u != null)
                return true;
            return false;
        }

        public bool IsLogged()
        {
            
            if (bool.TryParse(_accessor.HttpContext.Session.GetString("isLogged"), out bool isLogged))
            {
                if (isLogged)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Logout()
        {
            _accessor.HttpContext.Session.Clear();
            if (_accessor.HttpContext.Session == null)
                return true;
            return false;
        }
    }
}
