public ActionResult Link(int ChildrenTaskID, int ParentTaskID)
        {
            ActionResult result = null;

            try
            {
                var TaskArray = new List<TaskModel>();
                var childTask = taskHelper.TaskRepository.Get_TaskByID(ChildrenTaskID, true);

                if (!childTask.ParentTasks.Any(x => x.ID == ParentTaskID))
                {
                    var parentTask = taskHelper.TaskRepository.Get_TaskByID(ParentTaskID, true);

                    if (!parentTask.ParentTasks.Any(x => x.ID == ChildrenTaskID))
                    {
                        if (!CheckIfCyclic(ChildrenTaskID, ParentTaskID))
                        {
                            //childTask.ParentTaskID = ParentTaskID;
                            TaskArray.Add(childTask);

                            taskHelper.TaskRepository.Link_Task(ChildrenTaskID, ParentTaskID, CurrentUser.CurrentUSER.UserID,
                                CurrentUser.CurrentUSER.CurrentProjectID, false);

                            var parentMilestoneTaskId = taskHelper.TaskRepository.Task_GetParentMilestone(ChildrenTaskID);
                    var childMilestoneTaskId = taskHelper.TaskRepository.Task_GetChildrenMilestone(ParentTaskID);

                    var parentMilestoneID = parentMilestoneTaskId.HasValue ? parentMilestoneTaskId.Value : 0;
                    var childMilestoneID = childMilestoneTaskId.HasValue ? childMilestoneTaskId.Value : 0;

                    //: parentTask.LockStartDate ? parentTask.ID : 0;
                    // Dont recalculate the whole tasks chain if milestone task exists next to the target task
                    var changeResult = true;
                    if (childMilestoneID != 0)
                    {
                        // Move to locked child
                        changeResult = RecalculateMilestoneDates(childMilestoneID);
                    }
                    else if(parentMilestoneID != 0)
                    {
                        // Move child to parent
                        //CalculateStartDate(ChildrenTaskID, ParentTaskID);
                        changeResult = RecalculateMilestoneDates(parentMilestoneID);
                    }
                    else
                    {
                        // Move parent to child
                        changeResult = RecalculateMilestoneDates(ChildrenTaskID);
                    }

                    if (!changeResult)
                    {

                       result = this.Json(new { success = false, message = "MilestoneError" },JsonRequestBehavior.AllowGet);
                       taskHelper.TaskRepository.Link_Task(childTask.ID, ParentTaskID, CurrentUser.CurrentUSER.UserID,
                                                        CurrentUser.CurrentUSER.CurrentProjectID, true);
                    }
                    else
                    {
                                result = this.Json(new { success = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                     }

                            TaskArray.Add(new TaskModel { ID = ChildrenTaskID, ParentTaskID = ParentTaskID });

                            //Memento
                            mementoHelper.AddToMemento(new MementoRecord
                            {
                                UserID = CurrentUser.CurrentUSER.UserID,
                                Entity = TaskArray,
                                UndoMethod = Undo_Link,
                                RedoMethod = Redo_Link
                            });
                        }
                        else
                        {
                            result = this.Json(new { success = false, message = "RecursiveLinkError" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        result = this.Json(new { success = false, message = "RecursiveLinkError" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    result = this.Json(new { success = false, message = "RecursiveLinkError" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                errorLogHelper.CatchError(ex, ref  result, CurrentUser.CurrentUSER.UserID);
            }

            return result;
        }
