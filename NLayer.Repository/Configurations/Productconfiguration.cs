using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class Productconfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            //hiçbir şey belirtmezsen 1 1 artar 
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stok).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            //dbsettte ki yapıyı alır belirtmezsen
            builder.ToTable("Product");


            //Fluent Api ile BİRE ÇOK ilişkinin oluşturulması 
            //--------------------
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CatogoryId);
        }
    }
}
