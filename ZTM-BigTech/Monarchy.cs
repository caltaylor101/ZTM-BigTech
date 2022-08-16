using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class Person
    {
        public string name;
        public bool isAlive = true;
        public List<Person> children = new List<Person>();
        public Person(string name)
        {
            this.name = name;
        }
    }
    internal class Monarchy
    {
        Person king;
        private Dictionary<string, Person> _successorDict = new Dictionary<string, Person>();
        public Monarchy(string kingName)
        {
            king = new Person(kingName);
            _successorDict.Add(kingName, king);
        }

        public void Birth(string childName, string parentName)
        {
            Person parent = _successorDict[parentName];
            Person newChild = new Person(childName);
            parent.children.Add(newChild);
            _successorDict.Add(childName, newChild);
        }

        public void Death(string name)
        {
            Person person;
            if(!_successorDict.TryGetValue(name, out person)) return;
            person.isAlive = false;
        }

        public List<string> GetOrderOfSuccession()
        {
            List<string> order = new List<string>();
            _dfs(king, order);
            return order;
        }

        private void _dfs(Person currentPerson, List<string> order)
        {
            if(currentPerson.isAlive)
            {
                order.Add(currentPerson.name);
            }

            for (int i = 0; i < currentPerson.children.Count; i++)
            {
                _dfs(currentPerson.children[i], order);
            }
        }
    }
}
