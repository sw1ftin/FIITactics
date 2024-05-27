using System;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject CardPlace1;
    public GameObject CardPlace2;
    public GameObject CardPlace3;
    public GameObject CardPlace4;

    public List<DisplayCard> yourSide;

    void Start()
    {
        CardPlace1 = GameObject.Find("CardPlace1");
        CardPlace2 = GameObject.Find("CardPlace2");
        CardPlace3 = GameObject.Find("CardPlace3");
        CardPlace4 = GameObject.Find("CardPlace4");

        yourSide.Add(null);
        yourSide.Add(null);
        yourSide.Add(null);
        yourSide.Add(null);
    }

    void Update()
    {
        if (CardPlace1.GetComponent<CardPlace>().isTaken)
        {
            Debug.Log(1);
        }
        if (CardPlace2.GetComponent<CardPlace>().isTaken)
        {
            Debug.Log(2);
        }
        if (CardPlace3.GetComponent<CardPlace>().isTaken)
        {
            Debug.Log(3);
        }
        if (CardPlace4.GetComponent<CardPlace>().isTaken)
        {
            Debug.Log(4);
        }
    }
}