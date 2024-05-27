using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject CardPlace1;
    public GameObject CardPlace2;
    public GameObject CardPlace3;
    public GameObject CardPlace4;

    public static bool dragged;

    private Transform parentToReturnTo;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (TurnSystem.gotCard)
        {
            CardPlace1 = GameObject.Find("CardPlace1");
            CardPlace2 = GameObject.Find("CardPlace2");
            CardPlace3 = GameObject.Find("CardPlace3");
            CardPlace4 = GameObject.Find("CardPlace4");

            dragged = true;
            parentToReturnTo = transform.parent;
            transform.SetParent(transform.parent.parent);
            transform.localScale = Vector3.one;
            // Debug.Log(transform.position);
            // Debug.Log(Screen.width);
            // Debug.Log(Screen.height);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (TurnSystem.gotCard)
        {
            transform.localPosition = new Vector2(
                eventData.position.x - Screen.width / 2,
                eventData.position.y - Screen.height / 2
            );
            transform.localScale = Vector3.one;
            transform.eulerAngles = new Vector2(0, 0);
            // Debug.Log($"Drag to pos {eventData.position}");
            // Debug.Log($"Now on {transform.position} pos");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (TurnSystem.gotCard)
        {
            var collided = false;

            // Debug.Log(CardPlace1.transform.position);
            // Debug.Log(CardPlace2.transform.position);
            // Debug.Log(CardPlace3.transform.position);
            // Debug.Log(CardPlace4.transform.position);
            // Debug.Log(transform.position);

            var card = gameObject.GetComponents<DisplayCard>()[0];
            Debug.Log(card);

            if (Vector3.Distance(CardPlace1.transform.position, transform.position) < 10)
            {
                if (!CardPlace1.GetComponent<CardPlace>().isTaken)
                {
                    collided = PlayCard.PlaceCard(CardPlace1, card);
                    if (collided)
                        transform.SetParent(CardPlace1.transform);
                }
            }
            else if (Vector3.Distance(CardPlace2.transform.position, transform.position) < 10)
            {
                if (!CardPlace2.GetComponent<CardPlace>().isTaken)
                {
                    collided = PlayCard.PlaceCard(CardPlace2, card);
                    if (collided)
                        transform.SetParent(CardPlace2.transform);
                }
            }
            else if (Vector3.Distance(CardPlace3.transform.position, transform.position) < 10)
            {
                if (!CardPlace3.GetComponent<CardPlace>().isTaken)
                {
                    collided = PlayCard.PlaceCard(CardPlace3, card);
                    if (collided)
                        transform.SetParent(CardPlace3.transform);
                }
            }
            else if (Vector3.Distance(CardPlace4.transform.position, transform.position) < 10)
            {
                if (!CardPlace4.GetComponent<CardPlace>().isTaken)
                {
                    collided = PlayCard.PlaceCard(CardPlace4, card);
                    if (collided)
                        transform.SetParent(CardPlace4.transform);
                }
            }

            if (!collided)
            {
                transform.SetParent(parentToReturnTo);
            }

            transform.localScale = new Vector3(0.8f, 0.8f, 1);
            dragged = false;
        }
    }
}