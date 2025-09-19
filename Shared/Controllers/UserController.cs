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
                new User(  "Bob", 17, "bob@gmail.com",  "bob"),
                new User("kutya", 6, "kutya@gmail.com",  "kutya"),
                new User(  "allat", 3, "allat@gmail.com",  "allat"),
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

        // GET
        public static void Get(string endPoint, HttpRequest req, HttpResponse res)
        {
            if (endPoint == "/")
            {
                res.Status = 200;
                res.Send("<h1>Hello World!</h1><a href='/users'>Go to users</a>");
            }
            else if (endPoint == "/users")
            {
                res.Status = 200;
                res.Json(users);
            }
            else if (endPoint == "/users/:id")
            {
                try
                {
                    var userId = int.Parse(req.Params.Id);
                }
                catch (NumberFormatException nfe)
                {
                    Console.Error.WriteLine("Illegal number format:" + nfe);
                }
                var user = users.FirstOrDefault(u => u.Id == userId);
                res.Status = 200;
                res.Json(user);
            }
            else
            {
                res.Status = 404;
            }
        }

        // POST
        public static void Post(string endPoint, HttpRequest req, HttpResponse res)
        {
            if (endPoint == "/users")
            {
                if (req.Body.Name == null || req.Body.Age == 0 || req.Body.Email == null || req.Body.Password == null)
                {
                    res.Status = 400;
                    res.Send("Missing required fields");
                    return;
                }
                User newUser = new User(req.Body.Name, req.Body.Age, req.Body.Email, req.Body.Password);
                users.Add(newUser);
                res.Status = 201;
                res.Json(newUser);
            }
        }

        // PUT
        public static void Put(string endPoint, HttpRequest req, HttpResponse res)
        {
            if (endPoint == "/users/:id")
            {
                int userId = 0;
                try
                {
                    userId = int.Parse(req.Params.Id);
                }
                catch (NumberFormatException nfe)
                {
                    Console.Error.WriteLine("Illegal number format:" + nfe);
                }

                var user = users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.Name = req.Body.Name ?? user.Name;
                    // user.BirthDate = req.Body.BirthDate ?? user.BirthDate; // BirthDate nem módosítható
                    user.Email = req.Body.Email ?? user.Email;
                    user.Password = req.Body.Password ?? user.Password;
                    res.Status = 200;
                    res.Json(user);
                }
                else
                {
                    res.Status = 404;
                    res.Send("User not found");
                }
            }
        }

        // DELETE
        public static void Delete(string endPoint, HttpRequest req, HttpResponse res)
        {
            if (endPoint == "/users/:id")
            {
                try
                {
                    var userId = int.Parse(req.Params.Id);
                }
                catch (NumberFormatException nfe)
                {
                    Console.Error.WriteLine("Illegal number format:" + nfe);
                }

                var user = users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    users.Remove(user);
                    res.Status = 200;
                    res.Send("User deleted");
                }
                else
                {
                    res.Status = 404;
                    res.Send("User not found");
                }
            }
        }

        // PATCH
        public static void Patch(string endPoint, HttpRequest req, HttpResponse res)
        {
            if (endPoint == "/users/:id")
            {
                try
                {
                    var userId = int.Parse(req.Params.Id);
                }
                catch (NumberFormatException nfe)
                {
                    Console.Error.WriteLine("Illegal number format:" + nfe);
                }

                var user = users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.Name = req.Body.Name ?? user.Name;
                    // user.BirthDate = req.Body.BirthDate ?? user.BirthDate; // BirthDate nem módosítható
                    user.Email = req.Body.Email ?? user.Email;
                    user.Password = req.Body.Password ?? user.Password;
                    res.Status = 200;
                    res.Json(user);
                }
                else
                {
                    res.Status = 404;
                    res.Send("User not found");
                }
            }
        }
    }
}
