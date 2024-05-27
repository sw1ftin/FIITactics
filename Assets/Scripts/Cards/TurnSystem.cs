using System;
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

    public GameObject CardPlace1;
    public GameObject CardPlace2;
    public GameObject CardPlace3;
    public GameObject CardPlace4;

    public GameObject EnemyCardPlace1;
    public GameObject EnemyCardPlace2;
    public GameObject EnemyCardPlace3;
    public GameObject EnemyCardPlace4;


    void Start()
    {
        CardPlace1 = GameObject.Find("CardPlace1");
        CardPlace2 = GameObject.Find("CardPlace2");
        CardPlace3 = GameObject.Find("CardPlace3");
        CardPlace4 = GameObject.Find("CardPlace4");

        EnemyCardPlace1 = GameObject.Find("CardPlace 1");
        EnemyCardPlace2 = GameObject.Find("CardPlace 2");
        EnemyCardPlace3 = GameObject.Find("CardPlace 3");
        EnemyCardPlace4 = GameObject.Find("CardPlace 4");

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

    void Update()
    {
        moneyText.text = currentMoney.ToString();
        if (!gotCard)
            currentBlood = 0;
        bloodText.text = currentBlood.ToString();
    }

    public void DestroyCard(GameObject card)
    {
        card.transform.SetParent(card.transform.parent.parent.Find("SacrificedCards"));
        card.SetActive(false);
    }
    
    public void MakeMoves()
    {
        if (CardPlace1.transform.childCount == 2)
        {
            var card1 = CardPlace1.GetComponentInChildren<DisplayCard>();
            var enemyCard1 = EnemyCardPlace1.GetComponentInChildren<DisplayCard>();
            if (enemyCard1 == null)
            {
                yourScore.text = (Int32.Parse(yourScore.text) + card1.power).ToString();
            }
            else
            {
                if (enemyCard1.healthPoints < card1.power)
                {
                    yourScore.text = (Int32.Parse(yourScore.text) + card1.power - enemyCard1.healthPoints).ToString();
                    DestroyCard(enemyCard1.GameObject());
                }
                else if (enemyCard1.healthPoints == card1.power)
                {
                    DestroyCard(enemyCard1.GameObject());
                }
                else
                {
                    enemyCard1.healthPoints -= card1.power;
                }
            }
        }

        if (CardPlace2.transform.childCount == 2)
        {
            var card2 = CardPlace2.GetComponentInChildren<DisplayCard>();
            var enemyCard2 = EnemyCardPlace2.GetComponentInChildren<DisplayCard>();
            if (enemyCard2 == null)
            {
                yourScore.text = (Int32.Parse(yourScore.text) + card2.power).ToString();
            }
            else
            {
                if (enemyCard2.healthPoints < card2.power)
                {
                    yourScore.text = (Int32.Parse(yourScore.text) + card2.power - enemyCard2.healthPoints).ToString();
                    DestroyCard(enemyCard2.GameObject());
                }
                else if (enemyCard2.healthPoints == card2.power)
                {
                    DestroyCard(enemyCard2.GameObject());
                }
                else
                {
                    enemyCard2.healthPoints -= card2.power;
                }
            }
        }

        if (CardPlace3.transform.childCount == 2)
        {
            var card3 = CardPlace3.GetComponentInChildren<DisplayCard>();
            var enemyCard3 = EnemyCardPlace3.GetComponentInChildren<DisplayCard>();
            if (enemyCard3 == null)
            {
                yourScore.text = (Int32.Parse(yourScore.text) + card3.power).ToString();
            }
            else
            {
                if (enemyCard3.healthPoints < card3.power)
                {
                    yourScore.text = (Int32.Parse(yourScore.text) + card3.power - enemyCard3.healthPoints).ToString();
                    DestroyCard(enemyCard3.GameObject());
                }
                else if (enemyCard3.healthPoints == card3.power)
                {
                    DestroyCard(enemyCard3.GameObject());
                }
                else
                {
                    enemyCard3.healthPoints -= card3.power;
                }
            }
        }

        if (CardPlace4.transform.childCount == 2)
        {
            var card4 = CardPlace4.GetComponentInChildren<DisplayCard>();
            var enemyCard4 = EnemyCardPlace4.GetComponentInChildren<DisplayCard>();
            if (enemyCard4 == null)
            {
                yourScore.text = (Int32.Parse(yourScore.text) + card4.power).ToString();
            }
            else
            {
                if (enemyCard4.healthPoints < card4.power)
                {
                    yourScore.text = (Int32.Parse(yourScore.text) + card4.power - enemyCard4.healthPoints).ToString();
                    DestroyCard(enemyCard4.GameObject());
                }
                else if (enemyCard4.healthPoints == card4.power)
                {
                    DestroyCard(enemyCard4.GameObject());
                }
                else
                {
                    enemyCard4.healthPoints -= card4.power;
                }
            }
        }
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

            MakeMoves();

            gotCard = false;
        }
    }
}