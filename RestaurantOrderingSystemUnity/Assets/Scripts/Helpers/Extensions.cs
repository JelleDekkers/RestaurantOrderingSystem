using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

    /// <summary>
    /// Removes all child transforms
    /// </summary>
    /// <param name="t"></param>
    public static void RemoveAllChildren(this Transform t) {
        foreach (Transform child in t.transform) {
            Object.Destroy(child.gameObject);
        }
    }

}
