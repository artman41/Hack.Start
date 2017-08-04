using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionTransform {

    public static Transform FindDeepChild(this Transform aParent, string aName) {
        foreach (Transform child in aParent) {
            if (child.name == aName)
                return child;
            var result = child.FindDeepChild(aName);
            if (result != null)
                return result;
        }
        return null;
    }
}
