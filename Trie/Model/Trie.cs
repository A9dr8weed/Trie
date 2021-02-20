using System;
using System.Collections.Generic;
using System.Text;

namespace Trie.Model
{
    /// <summary>
    /// Prefix trie.
    /// </summary>
    /// <typeparam name="T"> Data type. </typeparam>
    public class Trie<T>
    {
        /// <summary>
        /// Tree root.
        /// </summary>
        public Node<T> Root;

        /// <summary>
        /// Constructor with an empty root.
        /// </summary>
        public Trie()
        {
            Root = new Node<T>('\0', default, "");
        }

        public void Add(string key, T data)
        {
            AddNode(key, data, Root);
        }

        /// <summary>
        /// Add node.
        /// </summary>
        /// <param name="key"> Word. </param>
        /// <param name="data"> Added data. </param>
        /// <param name="node"> Symbol of the word. </param>
        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                // If there is no word.
                if (!node.IsWord)
                {
                    // Assign data.
                    node.Data = data;
                    node.IsWord = true;
                }
            }
            else
            {
                // The first letter of the word.
                char symbol = key[0];

                // Look for such a character in the key list.
                Node<T> subNode = node.TryFind(symbol);

                // If the character is in the key dictionary
                if (subNode != null)
                {
                    // Recursively call the method, go deeper.
                    AddNode(key.Substring(1), data, subNode);
                }
                else
                {
                    // new node with the first character.
                    Node<T> newNode = new Node<T>(key[0], data, node.Prefix + key[0]);

                    // Add data to the dictionary.
                    node.SubNodes.Add(key[0], newNode);

                    // Recursively call the method.
                    AddNode(key.Substring(1), data, newNode);
                }
            }
        }

        public void Remove(string key)
        {
            RemoveNode(key, Root);
        }

        /// <summary>
        /// Remove node.
        /// </summary>
        /// <param name="key"> Word. </param>
        /// <param name="node"> Symbol of the word. </param>
        private void RemoveNode(string key, Node<T> node)
        {
            // If there is no word.
            if (string.IsNullOrEmpty(key))
            {
                // Find word.
                if (node.IsWord)
                {
                    // Reset the pointer, delete word.
                    node.IsWord = false;
                }
            }
            else
            {
                // Check if there is a first character in the key dictionary.
                Node<T> subNode = node.TryFind(key[0]);

                // If the word is.
                if (subNode != null)
                {
                    // Recursively call the method.
                    RemoveNode(key.Substring(1), subNode);
                }
            }
        }

        public bool TrySearch(string key, out T value)
        {
            return SearchNode(key, Root, out value);
        }

        /// <summary>
        /// Search node.
        /// </summary>
        /// <param name="key"> Word. </param>
        /// <param name="node"> Symbol of the word. </param>
        /// <param name="value"> Data. </param>
        /// <returns> Value of data. </returns>
        private bool SearchNode(string key, Node<T> node, out T value)
        {
            value = default;
            bool result = false;

            // If there is no word.
            if (string.IsNullOrEmpty(key))
            {
                // found the word
                if (node.IsWord)
                {
                    // Return the data
                    value = node.Data;

                    result = true;
                }
            }
            else
            {
                // Check if there is a first character in the key dictionary.
                Node<T> subNode = node.TryFind(key[0]);

                // If the word is.
                if (subNode != null)
                {
                    // Recursively call the method.
                    result = SearchNode(key.Substring(1), subNode, out value);
                }
            }

            return result;
        }
    }
}