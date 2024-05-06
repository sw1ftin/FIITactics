using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeck : MonoBehaviour
{
    public static int deckSize = 40;
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

    public void GetCard()
    {
        StartCoroutine(Draw(1));
        TurnSystem.gotCard = true;
    }

    public void GetSquirrel()
    {
        deck.Add(CardDatabase.cardList[1]);
        GetCard();
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
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

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
}