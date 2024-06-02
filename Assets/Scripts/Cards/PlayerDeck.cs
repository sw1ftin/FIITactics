using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeck : MonoBehaviour
{
    public static int deckSize;
    public static int handSizeOnStart = 6;
    public int x;
    public List<Card> deck = new();
    public static List<Card> staticDeck = new();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject squirrelPrefab;

    public GameObject CardToHand;
    public GameObject[] Clones;
    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        deckSize = 40;
        int maxIndex = CardDatabase.cardList.Count;
        for (int i = 0; i < deckSize; i++)
        {
            while (true)
            {
                x = Random.Range(0, maxIndex);
                if (CardDatabase.cardList[x].isAble)
                {
                    deck.Add(CardDatabase.cardList[x]);
                    break;
                }
            }
        }

        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;

        if (deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }

        if (deckSize < 15)
        {
            cardInDeck2.SetActive(false);
        }

        if (deckSize < 5)
        {
            cardInDeck3.SetActive(false);
        }

        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }
    }

    public void GetCard(bool isSquirrel = false)
    {
        if (!TurnSystem.gotCard)
        {
            StartCoroutine(Draw(1, isSquirrel));
            TurnSystem.gotCard = true;
        }
    }

    public void GetSquirrel()
    {
        // deck.Add(CardDatabase.cardList[1]);
        GetCard(true);
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i < handSizeOnStart - 1; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            var temp = deck[i];
            var randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    IEnumerator Draw(int x, bool isSquirrel = false)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0);
            var card = Instantiate(isSquirrel ? squirrelPrefab : CardToHand,
                transform.localPosition,
                transform.rotation
            );
            card.transform.SetParent(Hand.transform);
            card.transform.localScale = new Vector3(0.8f, 0.8f, 1);
            // card.transform.eulerAngles = new Vector2(0, 0);
        }
    }
}