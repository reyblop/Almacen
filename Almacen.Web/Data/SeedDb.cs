namespace Almacen.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Helpers;
    using Entities;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("jzuluaga55@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Reinaldo",
                    LastName = "Barco",
                    Email = "reyblop@gmail.com",
                    UserName = "reyblop@gmail.com",
                    PhoneNumber = "3007754871"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("Huawei P10", user);
                this.AddProduct("LG Z8", user);
                this.AddProduct("Air Dots", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
