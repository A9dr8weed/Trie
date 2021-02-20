using System;

using Trie.Model;

namespace Trie
{
    public static class Program
    {
        private static void Main()
        {
            Trie<int> trie = new Trie<int>();
            trie.Add("Hello", 50);
            trie.Add("Word", 100);
            trie.Add("Present", 200);
            trie.Add("Free", 200);
            trie.Add("Progect", 200);
            trie.Add("Flag", 200);
            trie.Add("Right", 200);
            trie.Add("Ring", 200);
            trie.Add("Hero", 200);
            trie.Add("Heroin", 200);

            trie.Remove("Free");
            trie.Remove("Heroin");

            Search(trie, "Hello");
            Search(trie, "Heroin");
        }

        private static void Search(Trie<int> trie, string word)
        {
            if (trie.TrySearch(word, out int value))
            {
                Console.WriteLine(word + " " + value);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}