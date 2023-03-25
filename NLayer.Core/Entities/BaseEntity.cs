using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entities

{
    /// <summary>
    /// BaseEntity clası  base bit yapıda olduğu için new anahtar kelimesi ile türetilmesin istiyoruz. 
    /// Abstractlar soyut yapı bu nedenle newlenmez
    /// </summary>
    public abstract class BaseEntity

    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
