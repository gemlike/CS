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
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace NgocThe

{
    public class Production
    {
        public int ID{get;set;}
        public string Name{get;set;}
        public double Price{get;set;}

        public string[] Colors{get;set;}
        public int Brand{get;set;}

        public Production(int id, string name, double price, string[] colors, int brand)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Colors = colors;
            this.Brand = brand;
        }

        public override string ToString()
        {
            return $"{ID} {Name} {Price} {string.Join(',',Colors)} {Brand}";
        }
    }

    public class Brand
    {
        public string Name{get;set;}
        public int ID{get;set;}
    }
    public class Test
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Production>()
            {
                new Production(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Production(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Production(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Production(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Production(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Production(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Production(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };

            var ketqua1 = from prodcut in products where prodcut.Price == 400
                            select prodcut;
            var ketqua2 = from prodcut in products where prodcut.Price == 400
                            select prodcut.Name;
            var ketqua3 = from product in products 
                            select new {
                                ten = product.Name,
                                mausac = string.Join(',', product.Colors)
                            };
            var ketqua4 = from pro in products
                            where(pro.Price > 400 && pro.Price < 600)
                            select pro;
            var ketqua5 = from pro in products
                            where pro.Price >= 500
                            where pro.Name.StartsWith("Giường")
                            select pro;

            var ketqua6 = from pro1 in products
                            from color in pro1.Colors
                            where pro1.Price < 500
                            where color == "Vàng"
                            select pro1;
            var ketqua7 = from pro in products
                        orderby pro.Price ascending
                        select pro;
            var ketqua8 = from pro in products
                            where pro.Price >= 400 
                            group pro by pro.Price into gr
                            select gr;

            var ketqua9 = from pro in products
                            group pro by pro.Price into gr
                            let count = gr.Count()
                            select new {
                                price = gr.Key,
                                num_product = count
                            };
            var ketqua10 = from pro in products
                            join br in brands on pro.Brand equals br.ID
                            select new {
                                name = pro.Name,
                                brand = br.Name,
                                price = pro.Price
                            };
            var ketqua11 = from p in products
                            join br in brands on p.Brand equals br.ID into t
                            from br in t.DefaultIfEmpty()
                            select new {
                                name = p.Name,
                                brand = (br == null)? "No brand":br.Name,
                                price = p.Price
                            };
            foreach(var p in ketqua11)
            {
                
                Console.WriteLine($"{p.name}-{p.brand}-{p.price}");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }

}