using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ClickBehaviour : MonoBehaviour {

    [SerializeField]
    public UnityEvent MouseDown;
    [SerializeField]
    public UnityEvent MouseUp;

    void OnMouseDown() => MouseDown.Invoke();
    void OnMouseUp() => MouseUp.Invoke();
}
