using System;
using System.Collections.Generic;

namespace OrderingSystem {

    /// <summary>
    /// Class for keeping track of all necessary statistics
    /// </summary>
    [Serializable]
    public class OrderingSystemStats {

        public float totalRevenue, drinksServed, foodServed, drinksRevenue, foodRevenue;

        /// <summary>
        /// Update stats with order values
        /// </summary>
        /// <param name="order">The order who's values will be added to the stats</param>
        public void UpdateValues(Order order) {
            foreach(KeyValuePair<Product, int> item in order.productAmountBought) {
                totalRevenue += item.Key.price * item.Value;

                if(item.Key.GetType() == typeof(Drink)) {
                    drinksServed += item.Value;
                    drinksRevenue += item.Key.price * item.Value;
                } else if(item.Key.GetType() == typeof(Food)) {
                    foodServed += item.Value;
                    foodRevenue += item.Key.price * item.Value;
                }
            }
        }
    }
}