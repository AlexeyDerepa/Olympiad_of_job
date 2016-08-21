using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_the_list_of_cities
{
    class Node
    {
        static int count;
        public string Name { get; set; }
        public int Number { get; private set; }
        public Dictionary<Node,long> ChildrenDictionary { get; private set; }
        public long Weight { get; set; }
        public string From { get; set; }
        public Node(string name="")
        {
            Name = name;
            Number = ++count;
            ChildrenDictionary = new Dictionary<Node, long>();
        }

        public Node AddChildreDictionaryn(Node node, int cost)
        {
            ChildrenDictionary.Add(node,cost);
            return this;
        }

    }
}
