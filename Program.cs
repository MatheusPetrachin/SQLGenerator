using SQLGenerator.Models;

namespace SQLGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generatorUsers = new SQLGenerator<Users>();
            generatorUsers.SQLGeneratorHandler();

            var generatorProfiles = new SQLGenerator<Profiles>();
            generatorProfiles.SQLGeneratorHandler();
        }
    }
}
