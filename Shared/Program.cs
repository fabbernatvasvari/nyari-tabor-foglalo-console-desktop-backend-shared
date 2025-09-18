using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyApp.Shared.Models;

namespace MyApp.Shared
{
    internal class Program
    {

        static void Main(string[] args)
        {

            User[] users = new User[4]{
             new User( "Adam", 18, "Adam@gmail.com", "adam" ),
            new User(  "Bob", 17, "bob@gmail.com",  "bob"),
            new User("kutya", 6, "kutya@gmail.com",  "kutya"),
            new User(  "allat", 3, "allat@gmail.com",  "allat"),
            };

            string host = "localhost";
            int PORT = 3000;
            App app = new App();


            Server server = new Server(host, PORT);
            server.Start();

            Child child = new Child("Gipsz Jákob", new DateOnly(2017, 5, 15));
            Console.WriteLine(child);
        }
    }
}
