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
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId {set; get;}

        [StringLength(100)]
        public string Name {set; get;}

        [Column(TypeName="ntext")]                  // Cột (trường) kiểu ntext trong SQL Server
        public string Description {set; get;}
    }
}