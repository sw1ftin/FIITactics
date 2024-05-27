using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyCard : MonoBehaviour
{
    [CanBeNull]
    public GameObject IsThereAnyCards()
    {
        var children = gameObject.GetComponentInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.GameObject().GetComponent<DisplayCard>() != null)
                return child.GameObject();
        }

        return null;
    }

    public void DestroyCardFromCardPlace()
    {
        if (Hammer.hammerActive)
        {
            try
            {
                Debug.Log("Trying to destroy card");
                GameObject cardForDestroy;

                cardForDestroy = IsThereAnyCards();
                cardForDestroy.transform.SetParent(cardForDestroy.transform.parent.parent.Find("SacrificedCards"));
                cardForDestroy.SetActive(false);

                gameObject.GetComponent<CardPlace>().isTaken = false;

                TurnSystem.currentBlood++;
                TurnSystem.currentMoney++;

                Hammer.hammerActive = false;
                Debug.Log("Successfully destroyed card");
            }
            catch
            {
                Debug.Log("There is no card");
            }
        }
    }
}