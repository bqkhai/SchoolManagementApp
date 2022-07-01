﻿using Microsoft.EntityFrameworkCore;

namespace SchoolManagementApp.Models
{
    public class SchoolManagementDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<School> schools { get; set; }
        public DbSet<Department> departments { get; set; }

        private readonly String connectionString = @"
            Data Source=KHAIBQ3-D8\SQLEXPRESS;
            Initial Catalog=SchoolManagementDB;
            User ID=admin;
            Password=1234;";

        ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API
            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("schools");
                entity.HasKey(p => p.SchoolID);

            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");
                entity.HasKey(p => p.DepartmentId);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("classes");
                entity.HasKey(p => p.ClassId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(p => p.UserId);
            });
        }
    }
}
