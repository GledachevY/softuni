using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //Console.WriteLine("deleted");
            //context.Database.EnsureCreated();
            //Console.WriteLine( "Created");

            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoryXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoryProductXml = File.ReadAllText("../../../Datasets/categories-products.xml");


            //ImportUsers(context, usersXml);
            //Console.WriteLine("added users");
            //ImportProducts(context, productsXml);
            //Console.WriteLine("added products");
            //ImportCategories(context, categoryXml);
            //Console.WriteLine("added categories");


            //var result = ImportCategoryProducts(context, categoryProductXml);

            //Console.WriteLine(result);

            var result = GetCategoriesByProductsCount(context);
            Console.WriteLine(result);
        }

        // problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";
            var usersResult = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            List<User> users = new List<User>();

            foreach (var importUSerDto in usersResult)
            {
                var user = new User
                {
                    FirstName = importUSerDto.Firstname,
                    LastName = importUSerDto.LastName,
                    Age = importUSerDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productDtos = XMLConverter.Deserializer<ImportProductDto>(inputXml, rootElement);

            var products = productDtos.Select(p => new Product
            {
                Name = p.Name,
                Price = p.Price,
                BuyerId = p.BuyerId,
                SellerId = p.SellerId
            })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";

            var catDto = XMLConverter.Deserializer<IMportCategoryDt>(inputXml, rootElement);

            List<Category> categories = new List<Category>();

            foreach (var dto in catDto)
            {
                if (dto.Name == null)
                {
                    continue;
                }

                var category = new Category
                {
                    Name = dto.Name
                };

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "CategoryProducts ";

            var categoryProductDtos = XMLConverter.Deserializer<ImportCategoriesProductsDto>(inputXml, rootElement);

            //var categories = categoryProductDtos.Where(c=>).Select(cp => new CategoryProduct
            //{
            //    CategoryId = cp.CategoryId,
            //    ProductId = cp.Productid
            //})
            //    .ToArray();

            var categories = new List<CategoryProduct>();

            foreach (var dto in categoryProductDtos)
            {
                bool doesExists = context.Products.Any(x => x.Id == dto.Productid) &&
                    context.Categories.Any(x => x.Id == dto.CategoryId);

                if (!doesExists)
                {
                    continue;
                }

                var categoryProduct = new CategoryProduct
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.Productid
                };

                categories.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            string rootElement = "Products";
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var result = XMLConverter.Serialize(products, rootElement);

            return result;
        }

        // problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            string rootElement = "Users";
            var userProducts = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserSoldProductDto
                {
                    Firstname = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new UserProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })

                    .ToArray()
                })
                .OrderBy(l => l.LastName)
                .OrderBy(f => f.Firstname)
                .Take(5)
                .ToArray();

            var result = XMLConverter.Serialize(userProducts, rootElement);
            return result;
        }

        // problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            string rootElement = "Categories";
            var categories = context
                .Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    TotalRevenue = c.CategoryProducts.Select(x => x.Product).Sum(p => p.Price),
                    AveragePrice = c.CategoryProducts.Select(x => x.Product).Average(p => p.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(t => t.TotalRevenue)
                .ToArray();

            var result = XMLConverter.Serialize(categories, rootElement);
            return result;

        }

        // problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {

        }
    }
}