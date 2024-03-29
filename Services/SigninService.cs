﻿using devTalksASP.Interfaces;
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
        private IRepository<Topic> _topicRepository;
        private IRepository<Message> _messageRepository;
        public int? UserId { get => _accessor.HttpContext.Session.GetInt32("id"); }
        public User CurrentUser { get => _userRepository.FinById((int)UserId); }
       

        public SigninService(IRepository<User> userRepository, IHttpContextAccessor accessor, IRepository<Topic> topicRepository, IRepository<Message> messageRepository)
        {
            _userRepository = userRepository;
            _accessor = accessor;
            _topicRepository = topicRepository;
            _messageRepository = messageRepository;
        }

        public bool Login(string email,string pw)
        {
            Endpoint e = _accessor.HttpContext.GetEndpoint();
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

        public IEnumerable<Topic> GetCreatedTopics(int id)
        {
            id = id == 0 ? (int)UserId : id;
            IEnumerable <Topic> topics = default(IEnumerable<Topic>);
            topics = _topicRepository.Search(t => t.Author.Id == id).ToList();
            return topics;
        }

        public User GetUser(int id)
        {
            id = id == 0 ? (int)UserId : id;
            return _userRepository.FinById(id);
        }

    }
}
