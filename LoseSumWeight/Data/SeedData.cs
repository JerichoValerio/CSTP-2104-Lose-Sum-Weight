using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LoseSumWeight.Data;
using System;
using System.Linq;

namespace LoseSumWeight.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new LoseSumWeightContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<LoseSumWeightContext>>()))
        {
            // Look for any movies.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }
            context.Products.AddRange(
                new Products
                {
                    Name = "Gym Top",
                    Price = "$50",
                    ImagePath = "https://tomboyx.com/cdn/shop/products/Compression_Top_Black_1_fe0253c3-81fa-4a46-a546-7171bc00314e_1800x1800.jpg?v=1635281791",
                    LeftInStock = 20
                },
                new Products
                {
                    Name = "Gaterade Water Bottle",
                    Price = "$20",
                    ImagePath = "https://m.media-amazon.com/images/I/51W88P1bjGL._AC_SL1200_.jpg",
                    LeftInStock = 50

                },
                new Products
                {
                    Name = "Portable Bench",
                    Price = "$120",
                    ImagePath = "https://m.media-amazon.com/images/I/61uYt-GUYDL._AC_SL1500_.jpg",
                    LeftInStock = 6
                },
                new Products
                {
                    Name = "Dumbell set",
                    Price = "$250",
                    ImagePath = "https://www.gearforfit.com//dat/products/759/5-25-dumbbbels.jpg",
                    LeftInStock = 12
                }
            );
            context.SaveChanges();
        }
    }
}