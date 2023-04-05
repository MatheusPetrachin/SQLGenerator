using SQLGenerator.Models;

namespace SQLGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new SQLGenerator<Users>();
            generator.SQLGeneratorHandler();
        }
    }
}
