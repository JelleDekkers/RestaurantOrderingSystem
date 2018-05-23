using System;
using UnityEngine;

namespace OrderingSystem.Serializaion {

    public static class JsonHelper {

        /// <summary>
        /// Converts php json to a usable c# json
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string FixJsonString(string json, string concat = "Items") {
            json = "{\"" + concat + "\":" + json + "}";
            return json;
        }

        public static T[] FromJson<T>(string json) {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array) {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        [Serializable]
        private class Wrapper<T> {
            public T[] Items;
        }
    }
}