﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whats_New_CSharp_6
{
    public class UserStorage : IEnumerable<User>
    {
        public UserStorage(int capacity = 128)
        {
            _capacity = capacity;
        }

        public IEnumerator<User> GetEnumerator()
        {
            var allUsers = _defaultUsers.Select(kvp => kvp.Value)
                .Concat(_users);
            return allUsers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Capacity { get; } = _capacity;

        public User Add(User newUser)
        {
            _users.Add(newUser);
            return newUser;
        }

        List<User> _users = new List<User>(_capacity);

        Dictionary<string, User> _defaultUsers
            = new Dictionary<string, User>()
            {
                ["admin"] = new User("admin"),
                ["guest"] = new User("guest")
            };
        private static int _capacity;
    }
}
