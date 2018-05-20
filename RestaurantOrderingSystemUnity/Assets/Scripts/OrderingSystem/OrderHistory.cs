using System;
using System.Collections.Generic;
using UnityEngine;

namespace OrderingSystem {

    public class OrderHistory {

        public List<Order> Orders { get; private set; }

        public OrderHistory() {
            Orders = new List<Order>();
        }

        public void AddNewOrder(Order order) {
            Orders.Add(order);
        }

        /// <summary>
        /// Prints a summary of all orders
        /// </summary>
        public void PrintSummary() {
            for (int i = 0; i < Orders.Count; i++) {
                Debug.LogFormat("Order Date {0}: ", Orders[i].date);
                foreach (KeyValuePair<Product, int> product in Orders[i].productAmountBought) {
                    Debug.LogFormat("{0} {1}" + '\n', product.Value, product.Key.name);
                }
            }
        }
    }
}