using System;
using System.Collections.Generic;
using System.Text;

namespace Whats_New_CSharp_6
{
    public static class UserStorageExtensions
    {
        // use 'this' since it is extending UserStorage
        public static User Add(this UserStorage store, User newUser)
        {
            // uses the Insert method from the 'API' we wrote
            // that we're pretending we cant control and had no
            // Add writen for it
            store.Insert(newUser);
            return newUser;
        }
    }
}
