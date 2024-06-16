using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystemc_.src.TaskManagementSystem.Models;
using TaskManagementSystemc_.src.TaskManagementSystem.Repositories.Interfaces;

namespace TaskManagementSystemc_.src.TaskManagementSystem.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(string name, string email)
        {
            User user = new User(0, name, email);
            _userRepository.Add(user);
        }

        public void UpdateUser(int id, string name, string email)
        {
            User updatedUser = _userRepository.GetById(id);
            updatedUser.Name = name;
            updatedUser.Email = email;
            _userRepository.Update(updatedUser);
        }

        public void DeletedUser(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
