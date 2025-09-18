using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Shared.Models;
using Thunder.Collections.Extensions;
using Thunder.Web;

namespace MyApp.Shared.Controllers
{
    internal class UserController
    {
        private ArrayList<User> users;

        public UserController()
        {
            users = new User[]
            {
                new User("Alice", 30, "alice@gmail.com", "alice"),
            };
        }

        public UserController(User[] users)
        {
            this.users = users;
        }

        public User[] Users { get => users; set => users = value; }

        public void Add(User user)
        {
            Array.Add(users, user);
        }

        public static void Get(string endPoint, HttpRequest req, HttpResponse res)
        {
            if (endPoint == "/")
            {
            res.Status = 200;
            res.Send("<h1>Hello World!</h1><a href='/users'>Go to users</a>");
            } else if (endPoint == "users")
            {
                res.Status = 200;
                res.Json(users);
            } else if (endPoint == "users/:id")
            {

            } else
            {

            }
        }
    }
}
