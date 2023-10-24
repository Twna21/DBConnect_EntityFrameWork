using DBConnect.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
     class Program
    {
        static void Main(string[] args)
        {
            MyStore1Context mystore = new MyStore1Context();

            var products = from p in mystore.Products
                           select new { p.ProductName, p.CategoryId }; 
        
        foreach (var p in products) {
                Console.WriteLine($"ProductName: {p.ProductName}, CategoryID: {p.CategoryId}");
            }

            Console.WriteLine("---------------------------------------------------------");

            IQueryable<Category> cats = mystore.Categories.Include(c => c.Products);
            foreach(Category c in cats)
            {
                Console.WriteLine($"CategoryID: {c.CategoryId} has {c.Products.Count} products");
            }

            Console.ReadLine();
        }
    }
}
