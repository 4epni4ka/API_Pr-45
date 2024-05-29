using API_Леготкин.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Леготкин.Context
{
    public class UsersContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;" +
                "uid=root;" +
                "pwd=root;" +
                "database=TaskManager",
                new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
