using System;

namespace ConsoleApp.MySQL
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                var a = DateTime.Now;
                var b = DateTime.UtcNow;
                Console.WriteLine(" DateTime A - {0}, DateTime Kind - {1}", a, a.Kind);
                Console.WriteLine(" DateTime B - {0}, DateTime Kind - {1}", b, b.Kind);

                db.Blogs.Add(new Blog { String = "LocalTime", DateTime = DateTime.Now });
                db.Blogs.Add(new Blog { String = "UTCTime", DateTime = DateTime.UtcNow });
                db.SaveChanges();
            }

            using (var db = new BloggingContext())
            {
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" Title - {0}, DateTime - {1}, DateTime Kind: {2}", blog.String, blog.DateTime, blog.DateTime.Kind);
                }
            }
        }
    }
}