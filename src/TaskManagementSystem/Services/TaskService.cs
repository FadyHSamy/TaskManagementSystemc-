using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystemc_.src.TaskManagementSystem.Models;
using TaskManagementSystemc_.src.TaskManagementSystem.Repositories.Interfaces;
using TaskStatus = TaskManagementSystemc_.src.TaskManagementSystem.Models.TaskStatus;

namespace TaskManagementSystemc_.src.TaskManagementSystem.Services
{
    public class TaskService
    {
        private readonly IRepository<TaskModel> _taskRepository;
        private readonly IRepository<User> _userRepository;
        public event Action<TaskModel> TaskStatusChanged;

        public TaskService(IRepository<TaskModel> taskRepository, IRepository<User> userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public void AddTask(string title, string description, DateTime deadline)
        {
            TaskModel task = new TaskModel(0, title, description, deadline);
            _taskRepository.Add(task);
        }

        public void UpdatedTask(int id, string title, string description, DateTime deadline)
        {
            TaskModel taskModel = _taskRepository.GetById(id);
            _taskRepository.Update(taskModel);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public void AssignTask(int taskId, int userId)
        {
            TaskModel task = _taskRepository.GetById(taskId);
            User user = _userRepository.GetById(userId);
            task.AssignUser(user);
            _taskRepository.Update(task);
        }

        public void ChangeTaskStatus(int taskId, TaskStatus taskStatus)
        {
            TaskModel task = _taskRepository.GetById(taskId);
            task.UpdateStatus(taskStatus);
            _taskRepository.Update(task);
            TaskStatusChanged.Invoke(task);
        }
    }
}
