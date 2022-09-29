using Napa.Models;

namespace Napa.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>
                    {
                        new Product()
                        {
                            Title = "HDD 1Tb",
                            Quantiy = 55,
                            Price = 74.09
                        },
                        new Product()
                        {
                            Title = "HDD SSD 512GB",
                            Quantiy = 102,
                            Price = 190.99,
                        },
                        new Product()
                        {
                            Title = "RAM DDR4 16GB",
                            Quantiy = 47,
                            Price = 80.32
                        }
                    });
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>
                    {
                        new User()
                        {
                            Username = "Admin",
                            Password = "12345"
                        },
                        new User()
                        {
                            Username = "User1",
                            Password = "123456"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
