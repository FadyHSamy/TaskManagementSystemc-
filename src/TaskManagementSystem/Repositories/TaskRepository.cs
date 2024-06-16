using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystemc_.src.TaskManagementSystem.Models;
using TaskManagementSystemc_.src.TaskManagementSystem.Repositories.Interfaces;

namespace TaskManagementSystemc_.src.TaskManagementSystem.Repositories
{
    public class TaskRepository : IRepository<TaskModel>
    {
        private readonly List<TaskModel> tasks = new List<TaskModel>();
        private int nextId = 1;

        public void Add(TaskModel task)
        {
            task.GetType().GetProperty("Id").SetValue(task, nextId++);
            tasks.Add(task);
        }

        public void Delete(int id)
        {
            TaskModel selectedTask =
                GetById(id) ?? throw new KeyNotFoundException("Task Not Found");
            tasks.Remove(selectedTask);
        }

        public IEnumerable<TaskModel> GetAll()
        {
            return tasks;
        }

        public TaskModel GetById(int id)
        {
            return tasks.FirstOrDefault(task => task.Id == id);
        }

        public void Update(TaskModel task)
        {
            TaskModel selectedTask =
                GetById(task.Id) ?? throw new KeyNotFoundException("Task Not Found");
            selectedTask.GetType().GetProperty("Title").SetValue(selectedTask, task.Title);
            selectedTask
                .GetType()
                .GetProperty("Description")
                .SetValue(selectedTask, task.Description);
            selectedTask.GetType().GetProperty("Deadline").SetValue(selectedTask, task.Deadline);
            selectedTask.GetType().GetProperty("Status").SetValue(selectedTask, task.Status);
            selectedTask
                .GetType()
                .GetProperty("AssignedUser")
                .SetValue(selectedTask, task.AssignedUser);
        }
    }
}
