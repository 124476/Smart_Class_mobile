using Microsoft.EntityFrameworkCore;
using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Object = Mobile.Models.Object;

namespace Mobile
{
    public class DBContext : DbContext
    {
        public virtual DbSet<Object> Objects { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Subsection> Subsections { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "db.db");

            if (!File.Exists(dbPath))
            {
                //using var ms = FileSystem.OpenAppPackageFileAsync("db.db").Result;
                using var fileStream = File.Create(dbPath);
                //ms.CopyTo(fileStream);
            }

            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
