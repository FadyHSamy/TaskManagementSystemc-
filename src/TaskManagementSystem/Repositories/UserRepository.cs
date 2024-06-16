using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystemc_.src.TaskManagementSystem.Models;
using TaskManagementSystemc_.src.TaskManagementSystem.Repositories.Interfaces;

namespace TaskManagementSystemc_.src.TaskManagementSystem.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly List<User> users = new List<User>();
        private int nextId = 1;

        public void Add(User user)
        {
            user.GetType().GetProperty("Id").SetValue(user, nextId++);
            users.Add(user);
        }

        public void Update(User user)
        {
            User selectedUser =
                GetById(user.Id) ?? throw new KeyNotFoundException("User Not Found");
            selectedUser.GetType().GetProperty("Name").SetValue(selectedUser, user.Name);
            selectedUser.GetType().GetProperty("Email").SetValue(selectedUser, user.Email);
        }

        public void Delete(int id)
        {
            User userToBeDeleted = GetById(id) ?? throw new KeyNotFoundException("");
            users.Remove(userToBeDeleted);
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }
    }
}
