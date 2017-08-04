using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler {
    public RectTransform m_transform = null;

    // Use this for initialization
    void Start() {
        m_transform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData) {
        //Assets.Scripts.Misc.Logging.Debug.Log("On drag called");
        if (eventData.button == PointerEventData.InputButton.Left) {
            m_transform.position += new Vector3(eventData.delta.x, eventData.delta.y);

            // magic : add zone clamping if's here.
        }
    }
}