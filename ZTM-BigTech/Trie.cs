using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    //Tries aren't very common in interview questions, because data structure is simple. 
    //Implementing one from scratch or utilizing one efficiently. 
    //How to implement and modify. 
    //Can we implement helper classes/objects? 
    

    public class TrieNode
    {
        public bool isEnd { get; set; }
        public Dictionary<char, TrieNode> characters { get; set; }

        public TrieNode()
        {
            this.isEnd = false;
            this.characters = new Dictionary<char, TrieNode>();
        }
    }

    internal class Trie
    {
        TrieNode root;

        public Trie(TrieNode head)
        {
            root = new TrieNode();
        }

        public void Insert(string word, TrieNode node = null)
        {
            if (node == null) node = root;

            if (word.Length == 0)
            {
                node.isEnd = true;
            }
            else if (!node.characters.ContainsKey(word[0]))
            {
                node.characters[word[0]] = new TrieNode();
                Insert(word.Substring(1), node.characters[word[0]]);
            }
            else
            {
                Insert(word.Substring(1), node.characters[word[0]]);
            }

            if (node is null)
            {
                throw new ArgumentNullException(nameof(node));
            }
        }

        public bool Search(string word, TrieNode node = null)
        {
            if (node == null) node = root;
            if (word.Length == 0 && node.isEnd) return true;
            else if (word.Length == 0) return false;
            else if (!node.characters.ContainsKey(word[0])) return false;
            else
            {
                return Search(word.Substring(1), node.characters[word[0]]);
            }

        }

        public bool StartsWith(string prefix, TrieNode node = null)
        {
            if (node == null) node = root;
            if (prefix.Length == 0) return true;
            else if (!node.characters.ContainsKey(prefix[0])) return false;
            else
            {
                return StartsWith(prefix.Substring(1), node.characters[prefix[0]]);
            }

        }
    }
}
