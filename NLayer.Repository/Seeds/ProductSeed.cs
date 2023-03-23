using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData( new Product
            {
                Id = 1,
                CatogoryId= 1,
                Name = "Kalem1",
                Price=100,
                Stok=200,
                CreatedDate= DateTime.Now
            } ,
            new Product
            {
                Id = 2,
                CatogoryId = 1,
                Name = "Kalem2",
                Price = 100,
                Stok = 200,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 3,
                CatogoryId = 1,
                Name = "Kalem3",
                Price = 100,
                Stok = 200,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 4,
                CatogoryId = 2,
                Name = "Kitap1",
                Price = 100,
                Stok = 200,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 5,
                CatogoryId = 2,
                Name = "Kitap2",
                Price = 100,
                Stok = 200,
                CreatedDate = DateTime.Now
            });
        }
    }
}
