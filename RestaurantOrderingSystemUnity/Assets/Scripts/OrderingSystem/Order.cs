using System;
using System.Collections.Generic;

namespace OrderingSystem {

    public class Order {

        public DateTime date;
        public Dictionary<Product, int> productAmountBought = new Dictionary<Product, int>();

        public Order() {
            date = DateTime.Now;
        }

        public Order(Dictionary<Product, int> productsBought) {
            date = DateTime.Now;
            productAmountBought = productsBought;
        }

        /// <summary>
        /// Adds product to the order
        /// </summary>
        /// <param name="product">The product that was bought</param>
        /// <param name="amount">The amount of the product that was bought</param>
        public void AddProduct(Product product, int amount) {
            productAmountBought.Add(product, amount);
        }
    }
}