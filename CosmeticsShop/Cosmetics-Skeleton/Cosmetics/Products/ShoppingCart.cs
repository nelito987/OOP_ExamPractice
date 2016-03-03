
using System;
using System.Collections.Generic;
using System.Linq;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> cart;

        public ShoppingCart()
        {
            this.cart = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.cart.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.cart.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.cart.Contains(product);
        }

        public decimal TotalPrice()
        {
            var totalPrice = this.cart
                .Sum(x => x.Price);

            return totalPrice;
        }
    }
}
