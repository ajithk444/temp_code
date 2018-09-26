using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PullPlan.Web.HtmlHelpers
{
    public class AdjacencyList
    {
        public int V { get; set; }
        public LinkedList<int>[] AdjListArray { get; set; }
        public bool[] Visited { get; set; }
        public bool IsDirected { get; set; }

        public AdjacencyList(int v, bool isDirected = false)
        {
            V = v;
            AdjListArray = new LinkedList<int>[V];

            for (var i = 0; i < AdjListArray.Length; i++)
            {
                AdjListArray[i] = new LinkedList<int>();
            }

            Visited = new bool[V];
            IsDirected = isDirected;
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
            AdjListArray[src].AddLast(des);
            if (!IsDirected)
            {
                AdjListArray[des].AddLast(src);
            }

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
        
    }
}