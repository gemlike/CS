﻿using System;
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
        public string name{get;set;}
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
            Milk mk = new Milk();

            System.Reflection.PropertyInfo[] mt = mk.GetType().GetProperties();
            foreach(var item in mt)
            {
                System.Console.WriteLine(item.Name.ToString());
            }
            System.Console.WriteLine("");
            
            Console.ReadKey();
        }
    }

}