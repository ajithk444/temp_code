 private bool CheckIfCyclicDirectedGraph(int childTaskID, int parentTaskID)
        {
            bool isCyclic = false;
            Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();
           

            var tasks = taskHelper.TaskRepository.Get_TaskListByProjectID(CurrentUser.CurrentUSER.CurrentProjectID, true).ToList();

            //get all edges
            AdjacencyList adjacencyList = new AdjacencyList(Convert.ToInt32(tasks.Count * tasks.Count),true);
            foreach (var item in tasks)
            {
                //check in left (child) tree
                var parentTasks = taskHelper.TaskRepository.GetParentTasksByChildId(item.ID);
                foreach (var parentTask in parentTasks)
                {
                    adjacencyList.AddEdge(parentTask.ID, item.ID);
                }
                //check in  right (parent) tree
                var childTasks = taskHelper.TaskRepository.GetChildTasksByParentId(item.ID);
                foreach (var childItem in childTasks)
                {
                    adjacencyList.AddEdge(item.ID,childItem.ID);
                }
            }

            //add the new link to the list to check if it becomes a cyclic tree
            adjacencyList.AddEdge(parentTaskID,childTaskID);

            CycleDirectedGraph cycleDirectedGraph = new CycleDirectedGraph(adjacencyList);
            //cycleDirectedGraph.DetectCycle();
            isCyclic = cycleDirectedGraph.DetectCycleWithColor();
            return isCyclic;
        }
