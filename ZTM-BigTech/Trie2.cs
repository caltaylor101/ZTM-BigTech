using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*A trie(pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. 
There are various applications of this data structure, such as autocomplete and spellchecker.

Implement the Trie class:

Trie() Initializes the trie object.
void insert(String word) Inserts the string word into the trie.
boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.*/


namespace ZTM_BigTech
{
    public class TrieNode
    {
        public bool isEnd = false;
        public Dictionary<char, TrieNode> characters = new Dictionary<char, TrieNode>();
    }
    public class Trie2
    {
        TrieNode root = new TrieNode();

        public void Insert(string word, TrieNode node = null)
        {
            if (node == null) node = root;
            if (word.Length == 0) return;
            node.characters.TryAdd(word[0], new TrieNode());
            Insert(word.Substring(1), node.characters[word[0]]);
            if (word.Length == 1) node.characters[word[0]].isEnd = true;
        }

        public bool Search(string word, TrieNode node = null)
        {
            if (node == null) node = root;
            if (word.Length == 1 && node.characters.ContainsKey(word[0]))
            {
                return node.characters[word[0]].isEnd ? true : false;
            }
            else if (!node.characters.ContainsKey(word[0])) return false;
            else return Search(word.Substring(1), node.characters[word[0]]);
        }

        public bool StartsWith(string prefix, TrieNode node = null)
        {
            if (node == null) node = root;
            if (prefix.Length == 0) return true;

            if (node.characters.ContainsKey(prefix[0])) return StartsWith(prefix.Substring(1), node.characters[prefix[0]]);
            else return false;
        }
    }
}
