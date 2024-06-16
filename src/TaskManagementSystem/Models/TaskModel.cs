using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystemc_.src.TaskManagementSystem.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public User AssignedUser { get; set; }

        public TaskModel(int id, string title, string description, DateTime deadline)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Status = TaskStatus.Pending;
        }

        public void AssignUser(User user)
        {
            AssignedUser = user;
        }

        public void UpdateStatus(TaskStatus taskStatus)
        {
            Status = taskStatus;
        }

        public override string ToString()
        {
            return $"{Id} - {Title} (Status: {Status}, Assigned to: {(AssignedUser != null ? AssignedUser.Name : "None")})";
        }
    }
}
