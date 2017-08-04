using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtendWindow : MonoBehaviour, IDragHandler {

    public RectTransform m_Transform;
    public float transformWidth, transformHeight;
    public Canvas canvas;

    // Use this for initialization
    void Start() {
        m_Transform = GetComponent<RectTransform>();
        canvas = transform.parent.GetComponent<Canvas>();
        transformWidth = m_Transform.rect.width * canvas.scaleFactor;
        transformHeight = m_Transform.rect.height * canvas.scaleFactor;
    }

    public void OnDrag(PointerEventData eventData) {
        Rect trans = new Rect(Camera.main.ScreenToWorldPoint(new Vector3(m_Transform.rect.position.x, m_Transform.rect.position.y)).ToVector2(), new Vector2(transformWidth, transformHeight));
        Rect topLeft, topRight, top;
        //Assets.Scripts.Misc.Logging.Debug.Log("On drag called");
        topLeft = new Rect(trans.xMin, trans.yMin - 10f, 10f, 10f);
        topRight = new Rect(trans.xMax - 10f, trans.yMin - 10f, 10f, 10f);
        //Assets.Scripts.Misc.Logging.Debug.Log($"topright | posX: {m_Transform.rect.xMax}, width: {transformWidth}, posY: {m_Transform.rect.yMin}, localScaleY: {transformHeight}");
        top = new Rect(trans.xMin, trans.yMin, trans.width, 10f);
        if (eventData.button == PointerEventData.InputButton.Right) {
            if (topLeft.Contains(eventData.position)) {
                Assets.Scripts.Misc.Logging.Debug.Log("TopLeft Bounds");
                //get current pos of bottom right corner
                //move to cursor
                //get current pos of bottom right corner
                //get displacement of two
                //add the difference to scale

                var prevPos = new Vector2(m_Transform.position.x + m_Transform.localScale.x, m_Transform.position.y + m_Transform.localScale.y);
                m_Transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
                var newPos = new Vector2(m_Transform.position.x + m_Transform.localScale.x, m_Transform.position.y + m_Transform.localScale.y);
                var displacement = newPos - prevPos;
                m_Transform.localScale += new Vector3(displacement.x, displacement.y);
            }
            else if(topRight.Contains(eventData.position)) {
                Assets.Scripts.Misc.Logging.Debug.Log("TopRight Bounds");

                var prevPos = new Vector2(m_Transform.position.x, m_Transform.position.y + m_Transform.localScale.y);
                m_Transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
                var newPos = new Vector2(m_Transform.position.x, m_Transform.position.y + m_Transform.localScale.y);
                var displacement = newPos - prevPos;
                m_Transform.localScale += new Vector3(displacement.x, displacement.y);
            } else if (top.Contains(eventData.position)) {
                Assets.Scripts.Misc.Logging.Debug.Log("Top Bounds");

                var prevPos = new Vector2(m_Transform.position.x, m_Transform.position.y);
                m_Transform.position += new Vector3(0, eventData.delta.y);
                var newPos = new Vector2(m_Transform.position.x, m_Transform.position.y);
                var displacement = newPos - prevPos;
                m_Transform.localScale += new Vector3(displacement.x, displacement.y);
            } else {
                Assets.Scripts.Misc.Logging.Debug.Log($"Out of Bounds {eventData.position} out of possible {topLeft}, {topRight}, {top}");
            }

            // magic : add zone clamping if's here.
        }
    }
}
