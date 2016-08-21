using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_the_list_of_cities
{
    class Search
    {
        private List<string> listGoal;
        private List<Node> listNode;
        private bool limitWasReached;

        public void Start()
        {
            Console.WriteLine("Input:");
            int quantityTests = InputQuantity("Enter quantity tests");
            int quantityGoals;
            for (int i = 0; i < quantityTests; i++)
            {
                Console.WriteLine("Test number {0}",i+1);
                InputQuantityNodes();

                for (int j = 0; j < listNode.Count; j++)
                {
                    InputNodeData(j);
                }
                quantityGoals = InputQuantity("Enter quantity goals");
                listGoal = new List<string>();
                for (int j = 0; j < quantityGoals; j++)
                {
                    InputGoalInList();
                }
                Console.WriteLine("Output:");
                ProcessitgRequest();
            }

        }
        public void TestProject()//method for quickly test the my of project
        {

            Node n1 = new Node("gdansk");
            Node n2 = new Node("bydgoszcz");
            Node n3 = new Node("torun");
            Node n4 = new Node("warszawa");
            Node n5 = new Node("eeee");
            Node n6 = new Node("gggg");

            n1.AddChildreDictionaryn(n2, 1);
            n1.AddChildreDictionaryn(n3, 3);

            n2.AddChildreDictionaryn(n1, 1);
            n2.AddChildreDictionaryn(n3, 1);
            n2.AddChildreDictionaryn(n4, 4);

            n3.AddChildreDictionaryn(n1, 3);
            n3.AddChildreDictionaryn(n2, 1);
            n3.AddChildreDictionaryn(n4, 1);

            n4.AddChildreDictionaryn(n2, 4);
            n4.AddChildreDictionaryn(n3, 1);

            n5.AddChildreDictionaryn(n6, 5);

            n6.AddChildreDictionaryn(n5, 5);

            listNode = new List<Node>();

            listNode.Add(n1);
            listNode.Add(n2);
            listNode.Add(n3);
            listNode.Add(n4);
            listNode.Add(n5);
            listNode.Add(n6);

            listGoal = new List<string>();

            listGoal.Add("gdansk warszawa");
            listGoal.Add("bydgoszcz warszawa");
            listGoal.Add("bydgoszcz gggg");
            listGoal.Add("bydgoszcz eeee");
            listGoal.Add("eeee gggg");
            ProcessitgRequest();

        }

        private void ProcessitgRequest()//processing of entered data
        {
            Node nodeStart = new Node();
            Node nodeFinish = new Node();
            foreach (string goalCityes in listGoal)
            {
                Initializer(ref nodeStart,ref nodeFinish, goalCityes);

                SearchPath(nodeStart,nodeFinish);

                if (limitWasReached)
                {
                    Console.WriteLine(goalCityes + " -> " + nodeFinish.Weight);
                }
                else
                {
                    Console.WriteLine("Path {0} does not exist", goalCityes);
                }
            }
        }

        private void Initializer(ref Node nodeStart, ref Node nodeFinish, string goalCityes)//Initialization of data
        {
            foreach (Node item in listNode)//reset
            {
                item.Weight = long.MaxValue;
                item.From = "-";
            }

            limitWasReached = false;

            nodeStart = listNode.FirstOrDefault(x => x.Name == goalCityes.Split(' ')[0]);//find node by name
            nodeFinish = listNode.FirstOrDefault(x => x.Name == goalCityes.Split(' ')[1]);//find node by name

            nodeStart.From = "-";
            nodeStart.Weight = 0;

        }

        private void SearchPath(Node nodeStart, Node nodeFinish)//search by the method of Dijkstra
        {
            if (nodeStart == nodeFinish) //end of search
            {
                limitWasReached = true;
                return; 
            }
            long weight;
            foreach (var item in nodeStart.ChildrenDictionary)
            {
                weight = item.Value + nodeStart.Weight;
                if (item.Key.Weight > weight)
                {
                    item.Key.Weight = weight;
                    item.Key.From = nodeStart.Name;
                    SearchPath(item.Key, nodeFinish);
                }
            }
        }

        private void InputGoalInList()
        {
            
            string goalCityes;
            Node node;
            Node node2;
            bool flag;
            do
            {
                goalCityes = InputNamesTwoCitys();
                node = listNode.FirstOrDefault(x => x.Name == goalCityes.Split(' ')[0]);
                node2 = listNode.FirstOrDefault(x => x.Name == goalCityes.Split(' ')[1]);
                if(node == null || node2 == null)
                {
                    flag = true;
                    Console.WriteLine("You made mistake in the Name of City");
                }
                else
                {
                    flag = false;
                }
            } while (flag);
            listGoal.Add(goalCityes);
        }


        private void InputNodeData(int numberNode)
        {
            listNode[numberNode].Name = InputNameOfCity();
            int quantityChildren = InputOneNumber();
            string twoNumber;
            for (int i = 0; i < quantityChildren; i++)
            {
                twoNumber = InputTwoNumbers();

                Node node = listNode.FirstOrDefault(x => x.Number == int.Parse(twoNumber.Split(' ')[0]));

                if (node != null)
                {
                    listNode[numberNode].AddChildreDictionaryn(node, int.Parse(twoNumber.Split(' ')[1]));
                }
                else
                    Console.WriteLine("This node does not exist");
            }

        }
        private int InputQuantity(string note)
        {
            Console.WriteLine(note);
            return InputOneNumber();
        }
        public void InputQuantityNodes()
        {
            int quantity;
            quantity = InputQuantity("Enter quantity nodes");
            listNode = new List<Node>();
            for (int i = 0; i < quantity; i++)
                listNode.Add(new Node());
        }
        private string InputNameOfCity()
        {
            string city;
            do
            {
                Console.Write("Enter name of city: ");
                city = Console.ReadLine();
            } while (city.Trim().Length <= 2);

            return city;
        }
        private string InputNamesTwoCitys()
        {
            string city;
            bool flag;
            do
            {
                Console.WriteLine("Enter two cityes");
                city = Console.ReadLine().Trim();
                if (city.Split(' ').Length == 2)
                {
                    flag = ((city.Split(' ')[0].Length > 2 && city.Split(' ')[1].Length > 2) ? false : true);
                }
                else
                    flag = true;
            } while (flag);

            return city;
        }
        private int InputOneNumber()
        {
            int number;
            do
            {
                Console.Write("N = ");
                int.TryParse(Console.ReadLine(), out number);
            } while (number <= 0);
            return number;
        }
        private string InputTwoNumbers()
        {
            string twoNumbers;
            bool flag;
            do
            {
                Console.WriteLine("Enter two numbers");
                twoNumbers = Console.ReadLine().Trim();
                if (twoNumbers.Split(' ').Length == 2)
                {
                    try
                    {
                        int.Parse(twoNumbers.Split(' ')[0]);
                        int.Parse(twoNumbers.Split(' ')[1]);
                        flag = false; 
                    }
                    catch (Exception ex)
                    {
                        flag = true; 
                    }
                }
                else
                    flag = true;
            } while (flag);

            return twoNumbers;
        }

    }
}
