using System;

namespace RandomStuff
{
    public class HashTableScratch
    {
        public static void Program()
        {
            HashT table = new HashT(10);
            table.Add("Hi");
        }

    }

    public class HashT
    {
        private int tableSize; 

        public int TableSize()
        {
            return tableSize;
        }

        public HashT(int tSize)
        {
            tableSize = tSize;
        }

        public void Add(string value)
        {
            Hash(value);
        }

        private void Store(int key)
        {
            var remainder = key % tableSize;

        }

        private int Hash(string value)
        {
            int hashVal = 0;
            int vSize = value.Length;
            int[] keyVals = new int[vSize];

            for (int i = 0; i < vSize; i++)
            {
                keyVals[i] = (Int32)value[i];
            }

            hashVal = CreateHashKey(keyVals);


            return hashVal;
        }

        private int CreateHashKey(int[] keyVals)
        {
            int key = 0;
            for (int i = 0; i < keyVals.Length; i++)
            {
                key += keyVals[i];
            }

            return key;
        }

    }
}
