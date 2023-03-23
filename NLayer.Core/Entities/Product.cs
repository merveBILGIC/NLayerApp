using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stok { get; set; }
        public decimal Price { get; set; }
        public int CatogoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
    }
}
