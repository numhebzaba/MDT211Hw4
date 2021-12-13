using System;

namespace MDt211Hw4
{
    public struct Node
    {
        public string Name;
        public int Distance;
    }

    //ใช้ class Node แล้ว error
    //class Node ref ของพี่ท้อดดี้
    //{
    //    public Node Next;

    //    public string Name;
    //    public int Distance;

    //    public Node(string nameValue, int distanceValue)
    //    {
    //        Name = nameValue;
    //        Distance = distanceValue;
    //    }

    //    public override string ToString()
    //    {
    //        return string.Format("({0},{1})", Name, Distance);
    //    }
    //}

    class Program
    {
        static int minDistance(int[] distance, bool[] shortestPath,int arraySize)
        {
            int min = int.MaxValue, min_index = -1;

            for(int i = 0; i < arraySize; i++)
            {
                if(shortestPath[i] == false && distance[i] <= min)
                {
                    min = distance[i];
                    min_index = i;
                }
            }
            return min_index;
        }
        static void printSolution(int[] distance, int arraySize)
        {
            Console.Write("Order of node     Distance "
                          + "from root node\n");
            for (int i = 0; i < arraySize; i++)
                Console.Write(i + " \t\t\t\t " + distance[i] + "\n");
        }
        static void dijkstraalgorithm(Node[,] graph, int rootNode, int arraySize)
        {
            int[] distance= new int[arraySize]; 
            bool[] ShortestPath = new bool[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                distance[i] = int.MaxValue;
                ShortestPath[i] = false;
            }

            distance[rootNode] = 0;
            
            for (int count = 0; count < arraySize - 1; count++)
            {
              
                int u = minDistance(distance, ShortestPath, arraySize);

                ShortestPath[u] = true;

                
                for (int v = 0; v < arraySize; v++)

                    
                    if (!ShortestPath[v] && graph[u, v].Distance != 0 &&
                         distance[u] != int.MaxValue && distance[u] + graph[u, v].Distance < distance[v])
                        distance[v] = distance[u] + graph[u, v].Distance;
            }

            
            printSolution(distance, arraySize);
        }
        static void Main(string[] args)
        {
            Console.Write("Number of Nodes : ");
            int NumberOfNodes = int.Parse(Console.ReadLine());

            Node [,] NodeArray = new Node[NumberOfNodes, NumberOfNodes];

            Console.WriteLine("Name of each node");
            for (int i = 0; i < NumberOfNodes; i++) 
            {
                string NodeName = Console.ReadLine();
                NodeArray[i,0].Name = NodeName;
                NodeArray[0,i].Name = NodeName;

            }

            Console.WriteLine("The distance of each pair of nodes,if the two nodes are linked");
            Console.WriteLine("Ps.type \"0\" for the two nodes are not linked");
            Console.WriteLine(NodeArray[0,0].Name);

            for (int i = 0; i < NumberOfNodes; i++)
            {
                for (int j = 0; j < NumberOfNodes; j++)
                {
                    Console.WriteLine("{0} and {1}",NodeArray[i,0].Name,NodeArray[0,j].Name);
                    // ลองใส่แค่ 3 array สามหลี่ยมล่างแล้ว error ไม่หาค่า min
                    NodeArray[i, j].Distance = int.Parse(Console.ReadLine());
                }
            }
            dijkstraalgorithm(NodeArray,0,NumberOfNodes); // 0 ลำดับของ root node

             //ref https://www.geeksforgeeks.org/csharp-program-for-dijkstras-shortest-path-algorithm-greedy-algo-7/
        }
    }
}
