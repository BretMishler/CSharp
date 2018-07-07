using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace RandomStuff
{
    struct UserInfo
    {
        public int userId;
        public string userName;
        public UserInfo(int id, string name)
        {
            userId = id;
            userName = name;
        }
    }

    public class HashTableDemo
    {
        static Hashtable userInfoHash;
        static List<UserInfo> userInfoList;
        static Stopwatch sw;

        public static void Program()
        {
            userInfoHash = new Hashtable();
            userInfoList = new List<UserInfo>();
            sw = new Stopwatch();

            // Adding
            for (int i = 0; i < 4000000; i++)
            {
                // first param is key
                // it can be any object val
                userInfoHash.Add(i, "user: " + i);

                userInfoList.Add(new UserInfo(i, "user: " + i));

                if (i % 1000000 == 0)
                {
                    Console.WriteLine("Made "+i+" objects.");
                }
            }

            // Removing - example where we want to remove 0
            if (userInfoHash.ContainsKey(0))
            {
                userInfoHash.Remove(0);
            }

            // Setting - ex modify key at 1
            if (userInfoHash.Contains(1))
            {
                userInfoHash[1] = "new string";
            }

            // Looping
            //foreach(DictionaryEntry entry in userInfoHash)
            //{
            //    Console.WriteLine("Key: " + entry.Key + ", Value: " + entry.Value);
            //}

            // Access
            Random randomUserGen = new Random();
            int randomUser = -1;

            sw.Start();
            float startTime = 0;
            float endTime = 0;
            float deltaTime = 0;

            int cycles = 5;
            int cycle = 0;
            string userName = string.Empty;

            while(cycle < cycles)
            {
                randomUser = randomUserGen.Next(3000000, 3999999);
               
                startTime = sw.ElapsedMilliseconds;
                // access from list
                userName = GetUserFromList(randomUser);

                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine("Time taken to retrieve" + userName + " from list took" + string.Format("{0:0.##}", deltaTime) + "ms");

                startTime = sw.ElapsedMilliseconds;
                // access from hashtable
                userName = (string)userInfoHash[randomUser];

                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine("Time taken to retrieve" + userName + " from hash took" + string.Format("{0:0.##}", deltaTime) + "ms");

                cycle++;
            }
        }

        public static string GetUserFromList(int userId)
        {
            for (int i = 0; i < userInfoList.Count; i++)
            {
                if (userInfoList[i].userId == userId)
                {
                    return userInfoList[i].userName;
                }
            }

            return String.Empty;
        }
    }
}
