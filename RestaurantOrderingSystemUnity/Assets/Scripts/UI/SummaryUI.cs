using System;
using UnityEngine;
using UnityEngine.UI;

namespace OrderingSystem.UI {

    [Serializable]
    public class SummaryUI {

        [SerializeField]
        private Text amountEarnedTxt, drinksServedTxt, foodServedTxt, drinksRevenueTxt, foodRevenueTxt;

        private OrderingSystem orderingSystem;

        public void Init(OrderingSystem system) {
            orderingSystem = system;
            system.onOrderPayed += UpdateUI;
        }

        public void UpdateUI() {
            OrderingSystemStats stats = orderingSystem.stats;
            amountEarnedTxt.text = stats.totalRevenue.ToString();
            drinksServedTxt.text = stats.drinksServed.ToString();
            foodServedTxt.text = stats.foodServed.ToString();
            drinksRevenueTxt.text = stats.drinksRevenue.ToString();
            foodRevenueTxt.text = stats.foodRevenue.ToString(); 
        }
    }
}