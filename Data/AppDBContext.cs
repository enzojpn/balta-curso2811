using Microsoft.EntityFrameworkCore;
using Todo2811.Models;

namespace Todo2811.Data
{
    public class AppDBContext : DbContext
    {

        public DbSet<TodoModel> Todos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlite("DataSource=app.db;Cache=Shared");

    }
}