using System;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace NgocThe

{

    public class Product {
        protected double price = 0;

        // Phương thức ảo ProductInfo
        public virtual void ProductInfo() {
            Console.WriteLine($"Giá sản phẩm {price}");
        }

        public void TestProduct()
        {
            this.ProductInfo();
        }
    }

    public class Milk:Product
    {
        public override void ProductInfo() {
            Console.WriteLine($"Giá sản sữa {price}");
        }
    }

    public class Test
    {
        
        
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Milk mk = new Milk();
            Product pt = new Product();
            pt.ProductInfo();
            mk.ProductInfo();
            Console.ReadKey();
        }
    }

}