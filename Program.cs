using System;
using System.Diagnostics;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var context = new BlogDataContext();

            var user = new User
            {
                Bio = "abc",
                Email = "teste1@email.net",
                Github = "teste@github.com",
                Image = "https://",
                Name = "Teste",
                PasswordHash = "teste@123",
                Slug = "teste-1"
            };

            context.Users.Add(user);
            context.SaveChanges();

        }
    }
}
