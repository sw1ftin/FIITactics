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

    public static List<int> cardTurns = new();

    public GameObject CardPlace1;
    public GameObject CardPlace2;
    public GameObject CardPlace3;
    public GameObject CardPlace4;

    public GameObject EnemyCardPlace1;
    public GameObject EnemyCardPlace2;
    public GameObject EnemyCardPlace3;
    public GameObject EnemyCardPlace4;

    public GameObject SacrificedCards;

    public GameObject CardPrefab;


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
        // Debug.Log(cardTurns.Count);
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
        card.transform.SetParent(SacrificedCards.transform);
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

    public void MakeEnemyMoves()
    {
        if (EnemyCardPlace1.transform.childCount == 2)
        {
            var card1 = CardPlace1.GetComponentInChildren<DisplayCard>();
            var enemyCard1 = EnemyCardPlace1.GetComponentInChildren<DisplayCard>();
            if (enemyCard1 != null)
            {
                if (card1 == null)
                {
                    opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard1.power).ToString();
                }
                else
                {
                    if (card1.healthPoints < enemyCard1.power)
                    {
                        opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard1.power - card1.healthPoints)
                            .ToString();
                        DestroyCard(card1.GameObject());
                        CardPlace1.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else if (enemyCard1.power == card1.healthPoints)
                    {
                        DestroyCard(card1.GameObject());
                        CardPlace1.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else
                    {
                        card1.healthPoints -= enemyCard1.power;
                    }
                }
            }
        }

        if (EnemyCardPlace2.transform.childCount == 2)
        {
            var card2 = CardPlace2.GetComponentInChildren<DisplayCard>();
            var enemyCard2 = EnemyCardPlace2.GetComponentInChildren<DisplayCard>();
            if (enemyCard2 != null)
            {
                if (card2 == null)
                {
                    opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard2.power).ToString();
                }
                else
                {
                    if (card2.healthPoints < enemyCard2.power)
                    {
                        opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard2.power - card2.healthPoints)
                            .ToString();
                        DestroyCard(card2.GameObject());
                        CardPlace2.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else if (enemyCard2.power == card2.healthPoints)
                    {
                        DestroyCard(card2.GameObject());
                        CardPlace2.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else
                    {
                        card2.healthPoints -= enemyCard2.power;
                    }
                }
            }
        }

        if (EnemyCardPlace3.transform.childCount == 2)
        {
            var card3 = CardPlace3.GetComponentInChildren<DisplayCard>();
            var enemyCard3 = EnemyCardPlace3.GetComponentInChildren<DisplayCard>();
            if (enemyCard3 != null)
            {
                if (card3 == null)
                {
                    opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard3.power).ToString();
                }
                else
                {
                    if (card3.healthPoints < enemyCard3.power)
                    {
                        opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard3.power - card3.healthPoints)
                            .ToString();
                        DestroyCard(card3.GameObject());
                        CardPlace3.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else if (enemyCard3.power == card3.healthPoints)
                    {
                        DestroyCard(card3.GameObject());
                        CardPlace3.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else
                    {
                        card3.healthPoints -= enemyCard3.power;
                    }
                }
            }
        }

        if (EnemyCardPlace4.transform.childCount == 2)
        {
            var card4 = CardPlace4.GetComponentInChildren<DisplayCard>();
            var enemyCard4 = EnemyCardPlace4.GetComponentInChildren<DisplayCard>();
            if (enemyCard4 != null)
            {
                if (card4 == null)
                {
                    opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard4.power).ToString();
                }
                else
                {
                    if (card4.healthPoints < enemyCard4.power)
                    {
                        opponentScore.text = (Int32.Parse(opponentScore.text) + enemyCard4.power - card4.healthPoints)
                            .ToString();
                        DestroyCard(card4.GameObject());
                        CardPlace4.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else if (enemyCard4.power == card4.healthPoints)
                    {
                        DestroyCard(card4.GameObject());
                        CardPlace4.GetComponent<CardPlace>().isTaken = false;
                        AddMoney();
                    }
                    else
                    {
                        card4.healthPoints -= enemyCard4.power;
                    }
                }
            }
        }
    }

    public void AddMoney()
    {
        currentMoney++;
    }

    public void EndYourTurn()
    {
        // You can end your turn only after taking 1 card or squirrel
        if (gotCard)
        {
            MakeMoves();

            MakeEnemyMoves();

            if (EnemyCardPlace1.transform.childCount == 1)
            {
                var card = Instantiate(CardPrefab,
                    transform.position,
                    transform.rotation
                );
                card.transform.SetParent(EnemyCardPlace1.transform);
                card.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                var displayId = EnemyCards.nextMoves[0].Dequeue();
                card.SetActive(displayId != 0);
            }

            if (EnemyCardPlace2.transform.childCount == 1)
            {
                var card = Instantiate(CardPrefab,
                    transform.position,
                    transform.rotation
                );
                card.transform.SetParent(EnemyCardPlace2.transform);
                card.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                var displayId = EnemyCards.nextMoves[0].Dequeue();
                card.SetActive(displayId != 0);
            }

            if (EnemyCardPlace3.transform.childCount == 1)
            {
                var card = Instantiate(CardPrefab,
                    transform.position,
                    transform.rotation
                );
                card.transform.SetParent(EnemyCardPlace3.transform);
                card.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                var displayId = EnemyCards.nextMoves[0].Dequeue();
                card.SetActive(displayId != 0);
            }

            if (EnemyCardPlace4.transform.childCount == 1)
            {
                var card = Instantiate(CardPrefab,
                    transform.position,
                    transform.rotation
                );
                card.transform.SetParent(EnemyCardPlace4.transform);
                card.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                var displayId = EnemyCards.nextMoves[0].Dequeue();
                card.SetActive(displayId != 0);
            }

            gotCard = false;
        }
    }
}