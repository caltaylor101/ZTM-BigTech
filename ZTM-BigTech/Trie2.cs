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
    //Create a node that can be traversed. 
    public class TrieNode
    {
        //We need to know if the word has ended.
        //app shouldn't be true if apple is inserted. 
        public bool isEnd = false;
        //The dictionary will hold our nodes with the characters associated. 
        public Dictionary<char, TrieNode> characters = new Dictionary<char, TrieNode>();
    }

    //Recursive Approach
    public class Trie2
    {
        //Initialize the root on Trie creation.
        TrieNode root = new TrieNode();

        //Add our node as null to the Insert function. 
        public void Insert(string word, TrieNode node = null)
        {
            //If the node is null assign it the root.
            //It will never be null once this function starts.
            if (node == null) node = root;
            //Once our word is 0 we end the function.
            if (word.Length == 0) return;
            //We try to add the character to the dictionary with a new TrieNode.
            //Regardless if this works or not, we still do the same thing after.
            node.characters.TryAdd(word[0], new TrieNode());
            //We call the function again by removing the first character. 
            //Then we traverse to the node in our dictionary from the character we just processed.
            Insert(word.Substring(1), node.characters[word[0]]);
            //Once the function ends, we mark the node that has a word length of 1 as the end. 
            if (word.Length == 1) node.characters[word[0]].isEnd = true;
        }

        public bool Search(string word, TrieNode node = null)
        {
            if (node == null) node = root;
            //If the word only has 1 letter left, then we return the isEnd boolean as long as the character exists.
            if (word.Length == 1 && node.characters.ContainsKey(word[0])) return node.characters[word[0]].isEnd;
            //If the letter doesnt exist, then return false.
            else if (!node.characters.ContainsKey(word[0])) return false;
            //Otherwise, search the next letter in the string with the next node. 
            else return Search(word.Substring(1), node.characters[word[0]]);
        }

        
        public bool StartsWith(string prefix, TrieNode node = null)
        {
            if (node == null) node = root;
            if (prefix.Length == 0) return true;
            //This one we keep calling the function till there are no letters left. 
            //As long as each character exists, this returns true. 
            if (node.characters.ContainsKey(prefix[0])) return StartsWith(prefix.Substring(1), node.characters[prefix[0]]);
            else return false;
        }
    }
    
    public class Trie3
    {
        TrieNode root = new TrieNode();

        public void Insert(string word, TrieNode node = null)
        {
            if (node == null) node = root;
            //A variable to limit the if calculation in the for loop.
            int wordLength = word.Length - 1;

            //This loop replaces the previous recursive function.
            for (int i = 0; i < word.Length; i++)
            {
                //Try to add the character with a new node.
                node.characters.TryAdd(word[i], new TrieNode());
                //Traverse to the node.
                node = node.characters[word[i]];
                //If we are on the last letter, mark the node as the end. 
                if (i == wordLength) node.isEnd = true;
            }
        }

        public bool Search(string word, TrieNode node = null)
        {
            if (node == null) node = root;
            int wordLength = word.Length - 1;
            for (int i = 0; i < word.Length; i++)
            {
                //If we reached the last letter, and it exists in our dictionary, we can return isEnd. 
                if (i == wordLength && node.characters.ContainsKey(word[i])) return node.characters[word[i]].isEnd;
                //Otherwise, we traverse to the next node if our character exists.
                else if (node.characters.ContainsKey(word[i])) node = node.characters[word[i]];
                //Return false if it doesn't.
                else return false;
            }
            return true;
        }

        public bool StartsWith(string prefix, TrieNode node = null)
        {
            if (node == null) node = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                //See if this chain exists. 
                if (!node.characters.ContainsKey(prefix[i])) return false;
                node = node.characters[prefix[i]];
            }
            return true;
        }
    }
}
