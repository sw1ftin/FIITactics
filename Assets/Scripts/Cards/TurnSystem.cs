using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int isOpponentTurn;

    public static int maxMoney = -1;
    public static int currentMoney;
    public static int currentBlood;
    public Text moneyText;
    public Text bloodText;

    public static bool gotCard;

    public Text yourScore;
    public Text opponentScore;

    public List<int> cardTurns;

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        isOpponentTurn = 0;
        Debug.Log(cardTurns.Count);
        if (cardTurns.Count != 4)
            cardTurns = new List<int> { 0, 0, 0, 0 };

        for (int i = 0; i < 3; i++)
        {
            cardTurns[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = currentMoney.ToString();
        if (!gotCard)
            currentBlood = 0;
        bloodText.text = currentBlood.ToString();
    }

    public void EndYourTurn()
    {
        if (isYourTurn)
        {
            isYourTurn = false;
            isOpponentTurn++;
            for (int i = 0; i < 3; i++)
            {
                cardTurns[i] = 0;
            }

            gotCard = false;
        }
    }
}