using UnityEngine;
using UnityEngine.UI;

public class PlayCard : MonoBehaviour
{
    public static bool PlaceCard(GameObject CardPlace, DisplayCard Card)
    {
        if (Card.type == CostType.Money)
        {
            Debug.Log(TurnSystem.currentMoney);
            if (TurnSystem.currentMoney >= Card.cost)
            {
                CardPlace.GetComponent<CardPlace>().isTaken = true;
                TurnSystem.currentMoney -= Card.cost;
                return true;
            }

            return false;
        }

        if (Card.type == CostType.Sacrifice)
        {
            // Debug.Log(TurnSystem.currentBlood);
            if (TurnSystem.currentBlood >= Card.cost)
            {
                CardPlace.GetComponent<CardPlace>().isTaken = true;
                TurnSystem.currentBlood -= Card.cost;
                return true;
            }

            return false;
        }

        return false;
    }
}