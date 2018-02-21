using System;
using System.Collections.Generic;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable ht = new HashTable(10);

            string b = "Banana";
            ht.Add(b);
            ht.Add("Apple");
            ht.Add("Xamarin");

            foreach(LinkedList<string> x in ht.GetHashtable())
                if(x != null) foreach(string s in x) Console.WriteLine(s);
            
            Console.ReadLine();
        }
    }

    public class HashTable
    {
        private static int _size;
        private LinkedList<string>[] _hashtable;

        public HashTable(int size)
        {
            _size = size;
            _hashtable = new LinkedList<string>[size];
        }

        public void Add(string value)
        {
            int hash = Math.Abs(value.GetHashCode()) % _size;
            if (_hashtable[hash] == null)
            {
                _hashtable[hash] = new LinkedList<string>();
            }
            LinkedList<String> bucket = _hashtable[hash];
            bucket.AddLast(value);
        }

        public LinkedList<string>[] GetHashtable()
        {
            return _hashtable;
        }
    }
}
