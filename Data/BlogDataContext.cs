using System;
using System.Runtime.InteropServices;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433; Database=Blog-efcore;TrustServerCertificate=true;User ID=sa; Password= @Password24#");
            options.LogTo(Console.WriteLine);
        }
    }
}