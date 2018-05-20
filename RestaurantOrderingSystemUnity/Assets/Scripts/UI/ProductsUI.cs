using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OrderingSystem.UI {

    [Serializable]
    public class ProductsUI {

        public GameObject productUIPrefab;
        public Transform productUIParent;

        private InputField[] inputFields;

        public void Initialize(OrderingSystem system) {
            system.onOrderPayed += ResetInputFields;
        }

        /// <summary>
        /// Instantiates productUI objects for every product
        /// </summary>
        /// <param name="products"></param>
        public void CreateProductInfoUI(Product[] products) {
            productUIParent.RemoveAllChildren();
            inputFields = new InputField[products.Length];

            for (int i = 0; i < products.Length; i++) {
                GameObject productInfo = GameObject.Instantiate(productUIPrefab, productUIParent);

                // bit of a hack because of the 'only 1 MonBehaviour rule':
                inputFields[i] = productInfo.GetComponentInChildren<InputField>();
                productInfo.GetComponentInChildren<Text>().text = products[i].name;
            }
        }

        /// <summary>
        /// Resets inputfields back te zero
        /// </summary>
        public void ResetInputFields() {
            foreach (InputField input in inputFields)
                input.text = 0.ToString();
        }

        /// <summary>
        /// Returns integer array with all inputField values
        /// </summary>
        /// <returns></returns>
        public int[] GetInputFieldValues() {
            int[] amount = new int[inputFields.Length];
            for (int i = 0; i < inputFields.Length; i++) {
                try {
                    int value = int.Parse(inputFields[i].text);
                    amount[i] = value;
                } catch (Exception exception) {
                    amount[i] = 0;
                    Debug.LogError(exception);
                    continue;
                }
            }
            return amount;
        }
    }
}