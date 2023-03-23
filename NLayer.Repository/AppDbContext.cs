using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        //gerçek dünya da productfeature yanlızca bir product üzerinden eklenebilir.! kapatılır yani
        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //burada ihiyyaç duyulan ayarlar.
            //Bestpratis ayarları merkezi yapmaktır.
            //burayı şişirmemek için ayrı claslarda yapılır.


            //IEntityTypeConfiguration<T> reflaktion yaparak implemente eden tüm clasları buluyor.
            // Assembly.GetExecutingAssembly() => çalışmış olduğum Assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature() 
            {
                Id=1,
                Color="Kırmızı",
                Height=100,
                Width=200,
                ProductId=1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Height = 10,
                Width = 20,
                ProductId = 2
            });
        }
    }
}
