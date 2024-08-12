using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int BookeId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

        //Foreign Key Shopping cat

        public int ShoppingcartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
