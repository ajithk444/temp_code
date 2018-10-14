using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test;

namespace Test.Algorithm
{
    public class CycleDirectedGraph
    {
        public AdjacencyList AdjList { get; set; }

        public CycleDirectedGraph(AdjacencyList adjList)
        {
            AdjList = adjList;
        }

        public void DetectCycle()
        {
            if (HasCycle())
            {
                Console.WriteLine("There is a cyle");
            }
            else
            {
                Console.WriteLine("No cycle");
            }

        }

        public bool HasCycle()
        {
            int v = AdjList.V;
            bool[] inStack = new bool[v];
            for (int i = 0; i < v; i++)
            {
                if (!AdjList.Visited[i] && DFSUtil(i, inStack))
                {
                    return true;
                }

            }
            return false;
        }

        private bool DFSUtil(int i, bool[] inStack)
        {
            AdjList.Visited[i] = true;
            inStack[i] = true;

            foreach (int child in AdjList.AdjListArray[i])
            {
                if (inStack[child])
                {
                    return true;
                }

                if (!AdjList.Visited[child] && DFSUtil(child, inStack))
                {
                    return true;
                }
            }

            inStack[i] = false;
            return false;
        }

        //WHITE : Vertex is not processed yet.Initially
        //    all vertices are WHITE.

        //    GRAY : Vertex is being processed(DFS for this
        //vertex has started, but not finished which means
        //    that all descendants (ind DFS tree) of this vertex
        //    are not processed yet (or this vertex is in function
        //    call stack)

        //BLACK : Vertex and all its descendants are processed.

        public enum Color
        {
            White,
            Gray,
            Black
        }

        public bool DetectCycleWithColor()
        {
            if (HasCycleWithColor())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool HasCycleWithColor()
        {
            int v = AdjList.V;
            Color[] colors = new Color[v];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.White;
            }

            for (int i = 0; i < v; i++)
            {
                if (colors[i] == Color.White && DFSUtilWithColor(i, colors))
                {
                    return true;
                }

            }
            return false;
        }

        private bool DFSUtilWithColor(int i, Color[] colors)
        {
            colors[i] = Color.Gray;

            foreach (int child in AdjList.AdjListArray[i])
            {
                if (colors[child] == Color.Gray)
                {
                    return true;
                }

                if (colors[child] == Color.White && DFSUtilWithColor(child, colors))
                {
                    return true;
                }
            }

            colors[i] = Color.Black;
            return false;
        }
    }
}
