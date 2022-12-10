using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) 
        {
            
        }
        
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
    }
}