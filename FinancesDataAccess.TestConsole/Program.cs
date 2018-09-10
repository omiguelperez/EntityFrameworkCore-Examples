namespace FinancesDataAccess.TestConsole
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            #region AddingGraphOfEntities
            using (var context = new BloggingContext())
            {
                var blog = new Blog
                {
                    Url = "http://blogs.msdn.com/dotnet",
                    Posts = new List<Post>
                    {
                        new Post { Title = "Intro to C#" },
                        new Post { Title = "Intro to VB.NET" },
                        new Post { Title = "Intro to F#" }
                    }
                };

                context.Blogs.Add(blog);
                context.SaveChanges();
            }
            #endregion

            #region GettingRelatedData
            using (var context = new BloggingContext())
            {
                var blogs = context.Blogs.Include(b => b.Posts);
                foreach (var blog in blogs)
                {
                    Console.WriteLine($"{blog.BlogId} - {blog.Url}");
                }
                Console.ReadKey();
            }
            #endregion
        }

    }
}
