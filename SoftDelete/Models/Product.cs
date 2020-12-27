using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftDelete.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public decimal Price { set; get; }
        public bool IsDeleted { set; get; }
    }
}
