
namespace TestApp.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DrinksDbContext context)
        {
            
            context.Database.EnsureCreated();
        }
    }
}
