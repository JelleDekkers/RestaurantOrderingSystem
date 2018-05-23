using System;
using System.Collections.Generic;
using UnityEngine;
using OrderingSystem.UI;

namespace OrderingSystem {

    public class OrderingSystem : MonoBehaviour {

        public Product[] products;
        public OrderHistory orderHistory;
        public ProductsUI systemUI;
        public SummaryUI summaryUI;
        public Action onOrderPayed;
        public OrderingSystemStats stats;

        private void Start() {
            orderHistory = new OrderHistory();
            systemUI.Initialize(this);
            systemUI.CreateProductInfoUI(products);
            summaryUI.Initialize(this);
        }

        /// <summary>
        /// Pay order and save it
        /// </summary>
        public void PayOrder() {
            Order order = new Order();
            int[] amountBought = systemUI.GetInputFieldValues();

            for (int i = 0; i < amountBought.Length; i++) {
                if (amountBought[i] > 0) {
                    Product product = products[i];
                    int amount = amountBought[i];
                    order.AddProduct(product, amount);
                }
            }

            if (order.productAmountBought.Count <= 0)
                return;

            orderHistory.AddNewOrder(order);
            stats.UpdateValues(order);

            if (onOrderPayed != null)
                onOrderPayed.Invoke();
        }

        /// <summary>
        /// Show summary 
        /// </summary>
        public void ShowSummary() {
            orderHistory.PrintSummary();
        }
    }
}