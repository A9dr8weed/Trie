using System;
using System.Collections.Generic;

namespace Trie.Model
{
    /// <summary>
    /// Trie element.
    /// </summary>
    /// <typeparam name="T"> Data type. </typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Key.
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Pointer - that word.
        /// </summary>
        public bool IsWord { get; set; }

        /// <summary>
        /// Prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// A collection of subtries.
        /// </summary>
        public Dictionary<char, Node<T>> SubNodes { get; set; }

        /// <summary>
        /// Node constructor.
        /// </summary>
        /// <param name="symbol"> Word symbol. </param>
        /// <param name="data"> Data. </param>
        /// <param name="prefix"> Components of letters. </param>
        public Node(char symbol, T data, string prefix)
        {
            Data = data;
            Symbol = symbol;
            SubNodes = new Dictionary<char, Node<T>>();
            Prefix = prefix;
        }

        /// <summary>
        /// Checks if such a key is in the dictionary list.
        /// </summary>
        /// <param name="symbol"> Each letter. </param>
        /// <returns> If the key is in the dictionary return value, else - null </returns>
        public Node<T> TryFind(char symbol)
        {
            return SubNodes.TryGetValue(symbol, out Node<T> value) ? value : null;
        }

        public override bool Equals(object obj) => obj is Node<T> node && Data.Equals(node);

        public override string ToString()
        {
            return $"{Data} [{SubNodes.Count}] ({Prefix})";
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Symbol);
        }
    }
}