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

            // context.Users.Add(new User
            // {
            //     Name = "Rodrigo Oliveira",
            //     Email = "rodrigo147@gmail.com",
            //     Bio = "Software developer",
            //     Image = "image.com/rodrigo",
            //     PasswordHash = "pw1234",
            //     Slug = "roa"
            // });
            var user = context.Users
                        .FirstOrDefault(x => x.Id == 4);
            var category = new Category
            {
                Name = "APIs",
                Slug = "apis"
            };

            var post = new Post
            {
                Author = user,
                Category = category,
                Title = "Fluent API",
                Summary = "Learning about how to do Fluent API",
                Body = "<b>fluent-api</b>",
                Slug = "fluent-api",
                CreateDate = DateTime.Now.ToUniversalTime()
                //LastUpdateDate = DateTime.Now.ToUniversalTime(),
                //Tags = null
            };
            context.Posts.Add(post);
            context.SaveChanges();

        }
    }
}
