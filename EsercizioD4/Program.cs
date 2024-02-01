namespace EsercizioD4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("alfred", "password");
            User.CreateUser(user);
            User user1 = new User("omar", "spendaccione");
            User.CreateUser(user1);
            User user2 = new User("hachim", "nienteblackdesert");
            User.CreateUser(user2);
            User user3 = new User("armando", "armadillo");
            User.CreateUser(user3);
            User.CreateUser(new User("pizza", "margherita"));


            User.Menu();
        }
    }
}
