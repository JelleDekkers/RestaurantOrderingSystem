﻿using System;
using UnityEngine;

public static class JsonHelper {

    public static string FixJsonString(string json) {
        json = "{\"Items\":" + json + "}";
        return json;
    }

    public static T[] FromJson<T>(string json) {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        Debug.Log(json);
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