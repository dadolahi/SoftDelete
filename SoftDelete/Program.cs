using SoftDelete.Data;
using System;
using System.Linq;

namespace SoftDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftDeleteDbContext db = new SoftDeleteDbContext();

            InitialData(db);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                foreach (var item in db.Products.ToList())
                {
                    Console.WriteLine($"Id:{item.Id}, Title:{item.Title}, Price:{item.Price}");
                }
                Console.WriteLine($"==============================================");

                Console.WriteLine("if you want delete please enter ProductId. or type exit. ");
                var command = Console.ReadLine();
                if (int.TryParse(command, out int id))
                {
                    DeleteProduct(db, id);
                    Console.Clear();
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine($"The Product With Id={id} is deleted?");
                    Console.ReadKey();
                }

                

                else if (command.ToLower().Trim() == "exit")
                    break;
            }
        }

        private static void InitialData(SoftDeleteDbContext db)
        {
            if (!db.Products.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var product = new Models.Product { Title = $"Title {new Random().Next(1, 2000)}" };
                    db.Products.Add(product);
                }
                db.SaveChanges();
            }
        }

        private static  void DeleteProduct(SoftDeleteDbContext db, int id)
        {
            var prodcut = db.Products.SingleOrDefault(x => x.Id == id);
            if (prodcut != null)
            {
                Guid guid = Guid.NewGuid();
                prodcut.IsDeleted = true;
                prodcut.Title = $"{guid}@{prodcut.Title}";
                db.SaveChanges();
            }
        }
    }
}
