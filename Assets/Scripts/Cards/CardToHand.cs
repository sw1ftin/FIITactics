using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject HandCard;

    public GameObject CardPlace1;
    public GameObject CardPlace2;
    public GameObject CardPlace3;
    public GameObject CardPlace4;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Hand");
        CardPlace1 = GameObject.Find("CardPlace1");
        CardPlace2 = GameObject.Find("CardPlace2");
        CardPlace3 = GameObject.Find("CardPlace3");
        CardPlace4 = GameObject.Find("CardPlace4");
    }

    // Update is called once per frame
    void Update()
    {
        if (!DragAndDrop.dragged)
        {
            if (HandCard.transform.parent != CardPlace1.transform &&
                HandCard.transform.parent != CardPlace2.transform &&
                HandCard.transform.parent != CardPlace3.transform &&
                HandCard.transform.parent != CardPlace4.transform)
            {
                HandCard.transform.SetParent(Hand.transform);
                HandCard.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                // Debug.Log(HandCard.transform.position);
                // HandCard.transform.eulerAngles = new Vector2(0, 0); 
            }
        }
    }
}