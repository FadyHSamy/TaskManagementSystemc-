using TaskManagementSystemc_.src.TaskManagementSystem.Models;
using TaskManagementSystemc_.src.TaskManagementSystem.Repositories;
using TaskManagementSystemc_.src.TaskManagementSystem.Repositories.Interfaces;
using TaskManagementSystemc_.src.TaskManagementSystem.Services;
using TaskStatus = TaskManagementSystemc_.src.TaskManagementSystem.Models.TaskStatus;

class Program
{
    static void Main(string[] args)
    {
        IRepository<User> userRepository = new UserRepository();
        IRepository<TaskModel> taskRepository = new TaskRepository();
        UserService userService = new UserService(userRepository);
        TaskService taskService = new TaskService(taskRepository, userRepository);
        while (true)
        {
            Console.WriteLine("\nTask Management System");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. List Users");
            Console.WriteLine("5. Add Task");
            Console.WriteLine("6. Update Task");
            Console.WriteLine("7. Delete Task");
            Console.WriteLine("8. List Tasks");
            Console.WriteLine("9. Assign Task");
            Console.WriteLine("10. Change Task Status");
            Console.WriteLine("11. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter user name: ");
                    string userName = Console.ReadLine();
                    Console.Write("Enter user email: ");
                    string userEmail = Console.ReadLine();
                    userService.AddUser(userName, userEmail);
                    break;

                case 2:
                    Console.Write("Enter user ID: ");
                    int userId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new name: ");
                    userName = Console.ReadLine();
                    Console.Write("Enter new email: ");
                    userEmail = Console.ReadLine();
                    userService.UpdateUser(userId, userName, userEmail);
                    break;

                case 3:
                    Console.Write("Enter user ID to delete: ");
                    userId = int.Parse(Console.ReadLine());
                    userService.DeletedUser(userId);
                    break;

                case 4:
                    var users = userService.GetAllUsers();
                    foreach (var user in users)
                    {
                        Console.WriteLine(user);
                    }
                    break;

                case 5:
                    Console.Write("Enter task title: ");
                    string taskTitle = Console.ReadLine();
                    Console.Write("Enter task description: ");
                    string taskDescription = Console.ReadLine();
                    Console.Write("Enter task deadline (yyyy-mm-dd): ");
                    DateTime taskDeadline = DateTime.Parse(Console.ReadLine());
                    taskService.AddTask(taskTitle, taskDescription, taskDeadline);
                    break;

                case 6:
                    Console.Write("Enter task ID: ");
                    int taskId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new title: ");
                    taskTitle = Console.ReadLine();
                    Console.Write("Enter new description: ");
                    taskDescription = Console.ReadLine();
                    Console.Write("Enter new deadline (yyyy-mm-dd): ");
                    taskDeadline = DateTime.Parse(Console.ReadLine());
                    taskService.UpdatedTask(taskId, taskTitle, taskDescription, taskDeadline);
                    break;

                case 7:
                    Console.Write("Enter task ID to delete: ");
                    taskId = int.Parse(Console.ReadLine());
                    taskService.DeleteTask(taskId);
                    break;

                case 8:
                    var tasks = taskService.GetAllTasks();
                    foreach (var task in tasks)
                    {
                        Console.WriteLine(task);
                    }
                    break;

                case 9:
                    Console.Write("Enter task ID to assign: ");
                    taskId = int.Parse(Console.ReadLine());
                    Console.Write("Enter user ID to assign: ");
                    userId = int.Parse(Console.ReadLine());
                    taskService.AssignTask(taskId, userId);
                    break;

                case 10:
                    Console.Write("Enter task ID: ");
                    taskId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Select status: 1. Pending 2. InProgress 3. Completed");
                    int statusChoice = int.Parse(Console.ReadLine());
                    TaskStatus status;
                    switch (statusChoice)
                    {
                        case 1:
                            status = TaskStatus.Pending;
                            break;
                        case 2:
                            status = TaskStatus.InProgress;
                            break;
                        case 3:
                            status = TaskStatus.Completed;
                            break;
                        default:
                            return;
                    }
                    taskService.ChangeTaskStatus(taskId, status);
                    break;

                case 11:
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
