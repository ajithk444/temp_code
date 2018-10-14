       int[] taskIds = new int[] { 1000, 1001, 1002, 1003, 1004, 1005 };



            //Detected the cycle in the directed graph
            //Graph 1.0.2
            AdjacencyList adjacencyList = new AdjacencyList(taskIds.Length, taskIds,true);

            adjacencyList.AddEdge(1000, 1001);
            adjacencyList.AddEdge(1000, 1002);
            adjacencyList.AddEdge(1003, 1001);
            adjacencyList.AddEdge(1002, 1003);
