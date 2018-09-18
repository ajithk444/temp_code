    StartDate =  string.Format("{0:yyyy-MM-dd hh:mm:ss}", task.StartDate),
                    ActualStartDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", task.ActualStartDate),
                    ActualEndDate = task.IsComplete ? string.Format("{0:yyyy-MM-dd hh:mm:ss}", task.ActualEndDate) : string.Empty,
