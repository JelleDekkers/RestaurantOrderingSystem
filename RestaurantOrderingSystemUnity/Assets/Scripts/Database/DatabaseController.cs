using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OrderingSystem.Serializaion {

    public class DatabaseController : MonoBehaviour {

        public const string productRetrievalUrl = "http://studenthome.hku.nl/~jelle.dekkers/RestaurantOrderingSystem/GetProducts.php";

        public ProductData[] products;

        private void Start() {
            StartCoroutine(GetProducts());
        }

        private IEnumerator GetProducts() {
            using (WWW request = new WWW(productRetrievalUrl)) {
                yield return request;
                products = CreateArrayFromJson(JsonHelper.FixJsonString(request.text));
            }
            Debug.Log("Done retrieving products");
        }

        public ProductData[] CreateArrayFromJson(string jsonArray) {
            return JsonHelper.FromJson<ProductData>(jsonArray);
        }
    }
}