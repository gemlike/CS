using System;
using System.Data.Common;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.Marshalling;
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

    public abstract class Product1
    {
        public Product1()
        {

        }

        public abstract void ShowName();

        public void ShowName1()
        {
            System.Console.WriteLine("Xin chao Product1");
        }
    }

    interface IProduct
    {
        public void ShowName();
    }
    interface IOrder
    {
        public void ShowName();
    }
    public class Product2 : Product1
    {
        public override void ShowName()
        {
            System.Console.WriteLine("Xin chao Product2");
        }
    }

    public class Product3 : IProduct,IOrder
    {
        public void ShowName()
        {

        }
    }
    public class Test
    {
        
        
        static void Main()
        {
            // Console.OutputEncoding = Encoding.UTF8;
            // Milk mk = new Milk();
            // Product pt = new Milk();
            // System.Console.WriteLine(pt.GetType());
            // pt.ProductInfo();
            // mk.ProductInfo();
            // Product2 pd2 = new Product2();
            // pd2.ShowName();
            try
            {
                try
                {
                    int k = 0;
                    // double m = 1/k;
                    throw new Exception("Một ngoại lệ đã xảy ra!");
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine("Ngoại lệ 1");
                    throw new Exception("Một ngoại lệ đã xảy ra!");
                }
                System.Console.WriteLine("Hihi");
            }
            catch(Exception e2)
            {
                System.Console.WriteLine(e2.Message);
            }
            finally
            {

            }
            
            Console.ReadKey();
        }
    }

}