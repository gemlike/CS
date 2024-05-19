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
using System.Threading.Tasks;

namespace NgocThe
{
    [Table("Product")]                         // Ánh xạ bảng Product 
    public class Product
    {
        [Key]                                  // Là Primary key
        public int ProductId {set; get;}

        [Required]                              // Cột trong DB, Not Null
        [StringLength(50)]                      // nvarchar(50)
        public string Name {set; get;}

        [Column(TypeName="Money")]              // cột kiểu Money trong SQL Server (tương ứng decimal trong Model C#)
        public decimal Price {set; get;}

        // Sinh FK (CategoryID ~ Cateogry.CategoryID) ràng buộc đến PK key của Category
        public Category Category {set; get;}
        public int? CategoryId {set; get;} 

    }
}