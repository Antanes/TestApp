﻿
namespace TestApp.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            
            context.Database.EnsureCreated();
        }
    }
}
