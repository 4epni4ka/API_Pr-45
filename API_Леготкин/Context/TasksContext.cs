﻿using Microsoft.EntityFrameworkCore;
using API_Леготкин.Model;
using System;

namespace API_Леготкин.Context
{
    public class TasksContext:DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;" +
                "uid=root;" +
                "pwd=root;" +
                "database=TaskManager",
                new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
