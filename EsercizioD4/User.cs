using System;
using System.Collections.Generic;

namespace EsercizioD4
{
    internal class User
    {
        private static int count = 0;
        private int id;
        private static int currentId = -1;
        private string username;
        private string password;
        private bool isLoggedIn = false;
        private DateTime lastLogin;
        private static HashSet<User> users = new HashSet<User>();
        private static List<string> logs = new List<string>();

        public User() { }
        public User(string username, string password)
        {
            this.id = count++;
            this.username = username;
            this.password = password;
        }

        public static void Menu()
        {
            Console.WriteLine("\n===============OPERAZIONI==============" +
                "\nScegli l'operazione da effettuare:" +
                "\n1.: Login" +
                "\n2.: Logout" +
                "\n3.: Verifica ora e data di login" +
                "\n4.: Lista degli accessi" +
                "\n5.: Esci");
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Logout();
                    break;
                case "3":
                    CheckMyLogs();
                    break;
                case "4":
                    CheckAllLogs();
                    break;
                case "5":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Input non valido.");
                    Menu();
                    break;
            }

        }

        public static void CreateUser(User user)
        {
            users.Add(user);
        }

        public static void Login()
        {
            if (currentId == -1)
            {
                Console.Write("Username: ");
                string inputUsername = Console.ReadLine();
                Console.Write("Password: ");
                string inputPassword = Console.ReadLine();
                foreach (User user in users)
                {
                    if (inputUsername != "" && inputPassword != "" && user.username == inputUsername && user.password == inputPassword)
                    {
                        Console.WriteLine($"Login effettuato con successo. Bentornato, {inputUsername}!");
                        user.isLoggedIn = true;
                        currentId = user.id;
                        Console.WriteLine($"{currentId}");
                        User currentUser = FindUserById();
                        logs.Add($"Login: {currentUser.username} in data {new DateTime()}");
                        currentUser.lastLogin = DateTime.Now;
                        Menu();
                    }
                }
                Console.WriteLine("Username e password non sono corretti.");
                Menu();
            }
            else
            {
                Console.WriteLine("Login già effettuato!");
                Menu();
            }
        }

        public static void Logout()
        {
            if (currentId == -1)
            {
                Console.WriteLine("Impossibile effettuare il logout: nessun accesso effettuato.");
                Menu();
            }
            else
            {
                User currentUser = FindUserById();
                logs.Add($"Logout: {currentUser.username} in data {DateTime.Now}");
                currentUser.isLoggedIn = false;
                currentId = -1;
                Console.WriteLine($"Logout effettuato con successo! A presto, {currentUser.username}!");
                Menu();
            }
        }

        public static User FindUserById()
        {
            foreach (User user in users)
            {
                if (user.isLoggedIn && user.id == currentId)
                {
                    return user;
                }
            }
            return null;
        }

        public static void CheckMyLogs()
        {
            if (currentId > -1)
            {
                User currentUser = FindUserById();
                Console.WriteLine($"Last login: {currentUser.lastLogin}");
                Menu();
            }
            else
            {
                Console.WriteLine("Non sei ancora loggato in nessun profilo!");
                Menu();
            }
        }

        public static void CheckAllLogs()
        {
            if (currentId > -1)
            {
                foreach (string log in logs)
                {
                    Console.WriteLine(log);
                }
                Menu();
            }
            else
            {
                Console.WriteLine("Impossibile visualizzare gli accessi, devi prima effettuare il login!");
                Menu();
            }
        }

        public static void Exit()
        {
            Console.WriteLine("Ciao!");
            Environment.Exit(0);
        }

    }
}
