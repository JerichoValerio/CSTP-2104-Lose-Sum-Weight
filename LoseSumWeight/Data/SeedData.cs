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
            //Look for any movies.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            //Reset the db
            //context.Products.RemoveRange(context.Products);

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
                    Name = "Gatorade Water Bottle",
                    Price = "$15",
                    ImagePath = "https://media-www.canadiantire.ca/product/playing/exercise/exercise-accessories/1840630/gatorade-32oz-bottle-a65392ed-4ea2-4cfd-b23d-3a960c283ba7.png?imdensity=1&imwidth=1244",
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
                    Name = "Dumbbell set",
                    Price = "$250",
                    ImagePath = "https://www.gearforfit.com//dat/products/759/5-25-dumbbbels.jpg",
                    LeftInStock = 12
                },
                new Products
                 {
                  Name = "Gym Pant",
                  Price = "$60",
                  ImagePath = "https://w7.pngwing.com/pngs/93/953/png-transparent-leggings-tights-adidas-fashion-pants-black-clothes-fashion-adidas-abdomen.png",
                  LeftInStock = 25
                 },
                new Products
                {
                 Name = "Gym Short",
                 Price = "$40",
                 ImagePath = "https://w7.pngwing.com/pngs/442/288/png-transparent-gym-shorts-adidas-running-shorts-sportswear-adidas-zipper-white-adidas-thumbnail.png",
                 LeftInStock = 28
                },
                new Products
                {
                 Name = "Weightlifting Gloves",
                 Price = "$20",
                 ImagePath = "https://cdn.imgbin.com/18/25/6/imgbin-weightlifting-gloves-weight-training-exercise-fitness-centre-others-eFcyd0m8jzY49s2vG5UV6SV5C.jpg",
                 LeftInStock = 44
                },
                new Products
                 {
                     Name = "Running Shoes",
                     Price = "$80",
                     ImagePath = "https://w7.pngwing.com/pngs/820/94/png-transparent-shoe-nike-air-max-sneakers-running-running-shoes-orange-outdoor-shoe-converse-thumbnail.png",
                     LeftInStock = 37
                 }



            );
            context.SaveChanges();
        }
    }
}