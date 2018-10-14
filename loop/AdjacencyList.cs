using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class AdjacencyList
    {
        public int V { get; set; }
        public int[] TasksArray { get; set; }
        public LinkedList<int>[] AdjListArray { get; set; }
        public bool[] Visited { get; set; }
        public bool IsDirected { get; set; }

        public AdjacencyList(int v, int[] items, bool isDirected = false)
        {
            V = v;
            AdjListArray = new LinkedList<int>[V];

            for (var i = 0; i < AdjListArray.Length; i++)
            {
                AdjListArray[i] = new LinkedList<int>();
            }

            Visited = new bool[V];
            IsDirected = isDirected;
            TasksArray = items;
        }

        public void Reset()
        {
            for (var i = 0; i < Visited.Length; i++)
            {
                Visited[i] = false;
            }
        }

        public void AddEdge(int src, int des)
        {
            int getSourceIndex = GetIndex(src);
            int getDestinationIndex = GetIndex(des);
            AdjListArray[getSourceIndex].AddLast(getDestinationIndex);
            if (!IsDirected)
            {
                AdjListArray[getDestinationIndex].AddLast(getSourceIndex);
            }

        }

        private int GetIndex(int value)
        {
            int position = 0;
            foreach (var item in TasksArray)
            {
                if (item == value)
                {
                    return position;
                }
                position++;
            }
            return -1;
        }

        public void DisplayGraphBFS()
        {
            bool[] visited = new bool[V];

            Queue<int> queue = new Queue<int>();
            Console.Write("Please enter the start point : ");
            int start = int.Parse(Console.ReadLine());
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int next = queue.Dequeue();
                Console.Write(next + " ");
                foreach (int i in AdjListArray[next])
                {
                    if (visited[i] != true)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        public void DisplayGraphDFS(int start)
        {
            Console.Write(start + " ");
            Visited[start] = true;

            foreach (int i in AdjListArray[start])
            {
                if (Visited[i] != true)
                {
                    DisplayGraphDFS(i);
                    Visited[i] = true;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < V; i++)
            {
                foreach (int item in AdjListArray[i])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
