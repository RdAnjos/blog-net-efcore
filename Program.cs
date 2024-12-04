using System;
using System.Diagnostics;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            using var context = new BlogDataContext();

            var user = new User
            {
                Name = "Rodrigo",
                Bio = "Backend Developer",
                Email = "rodrigo@email.com",
                Image = "http:\\www.images.com",
                Slug = "anjosrodrigo",
                PasswordHash = "123456"
            };
            var category = new Category
            {
                Name = "Backend",
                Slug = "backend"
            };

            var post = new Post
            {
                Author = user,
                Category = category,
                Body = "<b>Title</b>",
                Slug = "starting-with-efcore",
                Summary = "In this article we will learn about EF Core",
                Title = "Starting with Entity Framework Core",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            context.Posts.Add(post);
            context.SaveChanges();

            /*
            using (var context = new BlogDataContext())
            {
                Console.Clear();
                // CREATE
                // var tag = new Tag { Name = ".NET", Slug = "dotnet" };
                // context.Tags.Add(tag);
                // context.SaveChanges();

                // var tag1 = new Tag { Name = "Angular", Slug = "angular" };
                // context.Tags.Add(tag1);
                // context.SaveChanges();

                // //UPDATE
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                // tag.Name = "ASP-NET Core";
                // tag.Slug = "asp-netcore";
                // context.Update(tag);
                // context.SaveChanges();

                // // DELETE
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                // context.Remove(tag);
                // context.SaveChanges();

                // var tags = context
                //         .Tags
                //         .AsNoTracking() // faz com que nao traga os METADADOS, traz ganho de performance nao recomendado para Delete ou Update
                //         .Where(x => x.Name.Contains(".net"))
                //         .ToList(); //boa pratica deixar list para final pois n pesquisara todo conteudo da base.

                // foreach (var tag in tags)
                // {
                //     System.Console.WriteLine($"{tag.Name}");
                // }

                // var tag = context
                //             .Tags
                //             .AsNoTracking()
                //             .FirstOrDefault(x => x.Id == 4);

                // System.Console.WriteLine(tag?.Name);

            }
            */
        }
    }
}
