using SQLGenerator.Models;

namespace SQLGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new SQLGenerator<Users>();

            Users users = new Users(
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                0
            );

            generator.SQLGeneratorHandler(users);
        }
    }
}
