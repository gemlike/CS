using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgocThe
{
    public class ShopContext  : DbContext
    {
        public DbSet<Product> products{get;set;}

        private const string connectionString = @"Data Source=DESKTOP-UQ748Q0\SQLEXPRESS;Initial Catalog=The1;Integrated Security=True;TrustServerCertificate=True";

        // Cấu hình chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Tạo ILoggerFactory
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            optionsBuilder.UseSqlServer(connectionString)            // thiết lập làm việc với SqlServer
                          .UseLoggerFactory(loggerFactory);     // thiết lập logging
        }

        // Tạo database
        public async Task CreateDatabase()
        {
            String databasename = Database.GetDbConnection().Database;

            Console.WriteLine("Tạo " + databasename);
            bool result = await Database.EnsureCreatedAsync();
            string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
            Console.WriteLine($"CSDL {databasename} : {resultstring}");
        }

        // Xóa Database
        public async Task DeleteDatabase()
        {
            String databasename = Database.GetDbConnection().Database;
            Console.Write($"Có chắc chắn xóa {databasename} (y) ? ");
             string input = Console.ReadLine();

            // // Hỏi lại cho chắc
            if (input.ToLower() == "y")
            {
                bool deleted = await Database.EnsureDeletedAsync();
                string deletionInfo = deleted ? "đã xóa" : "không xóa được";
                Console.WriteLine($"{databasename} {deletionInfo}");
            }
        }

        // Chèn dữ liệu mẫu
        public async Task InsertSampleData()
        {
                // Thêm 2 danh mục vào Category
                var cate1 = new Category() {Name = "Cate1", Description = "Description1"};
                var cate2 = new Category() {Name = "Cate2", Description = "Description2"};
                await AddRangeAsync(cate1, cate2);
                await SaveChangesAsync();

                // Thêm 5 sản phẩm vào Products
                await  this.AddRangeAsync(
                    new Product()  {Name = "Sản phẩm 1",    Price=12, Category = cate2},
                    new Product()  {Name = "Sản phẩm 2",    Price=11, Category = cate2},
                    new Product()  {Name = "Sản phẩm 3",    Price=33, Category = cate2},
                    new Product()  {Name = "Sản phẩm 4(1)", Price=323, Category = cate1},
                    new Product()  {Name = "Sản phẩm 5(1)", Price=333, Category = cate1}

                );
                await SaveChangesAsync();
                // Các sản phầm chèn vào
                foreach (var item in products)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append($"ID: {item.ProductId}");
                    stringBuilder.Append($"tên: {item.Name}");
                    stringBuilder.Append($"Danh mục {item.CategoryId}({item.Category.Name})");
                    Console.WriteLine(stringBuilder);
                }

                // ID: 1tên: Sản phẩm 2Danh mục 2(Cate2)
                // ID: 2tên: Sản phẩm 1Danh mục 2(Cate2)
                // ID: 3tên: Sản phẩm 3Danh mục 2(Cate2)
                // ID: 4tên: Sản phẩm 4(1)Danh mục 1(Cate1)
                // ID: 5tên: Sản phẩm 5(1)Danh mục 1(Cate1)

        }

        public async Task<Product> FindProduct(int id) 
        {

            var p =  await (from c  in products where c.ProductId == id select c).FirstOrDefaultAsync(); 
            await  Entry(p)                    // lấy DbEntityEntry liên quan đến p
                   .Reference(x => x.Category) // lấy tham chiếu, liên quan đến thuộc tính Category
                   .LoadAsync();               // nạp thuộc tính từ DB
            return  p;
        }
    }
}