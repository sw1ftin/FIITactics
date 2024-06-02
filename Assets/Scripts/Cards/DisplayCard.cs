using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new();
    public int displayId;
    public int id;
    public string name;
    public CostType type;
    public int cost;
    public int power;
    public int healthPoints;
    public string iconPath;

    public List<Enum> abilities = new();
    public Image ability1;
    public Image ability2;
    public Image ability3;


    public Sprite sacrifice;
    public Sprite money;

    public Text nameText;
    public Text costText;
    public Text damageText;
    public Text healthText;
    public Image typeImage;
    public Text multiplier;
    public Image iconImage;

    public bool cardBack;
    public static bool staticCardBack;
    public int placement;

    public GameObject Hand;
    public GameObject EnemyHand;
    public int numberOfCardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
        Hand = GameObject.Find("Hand");
        EnemyHand = GameObject.Find("EnemyHand");
        displayCard.Add(
            CardDatabase.cardList[displayId > 0 || displayId < CardDatabase.cardList.Count ? displayId : 0]);
    }


    public string GetAbilitySprite(Enum ability)
    {
        switch (ability)
        {
            case Ability.Buff.Volkov:
                return "Sprites/Abilities/Volkov";
            case Ability.Buff.Cancel:
                return "Sprites/Abilities/Cancel";
            case Ability.Buff.Retry:
                return "Sprites/Abilities/Retry";
            case Ability.Buff.Skip:
                return "Sprites/Abilities/Skip";
            case Ability.Buff.Grant:
                return "Sprites/Abilities/Grant";
            case Ability.Buff.Grow:
                return "Sprites/Abilities/Grow";

            case Ability.Debuff.Vlad:
                return "Sprites/Abilities/Vlad";
            case Ability.Debuff.Hunger:
                return "Sprites/Abilities/Hunger";
            case Ability.Debuff.Eloquence:
                return "Sprites/Abilities/Eloquence";
            case Ability.Debuff.NotEnoughSleep:
                return "Sprites/Abilities/NotEnoughSleep";
            case Ability.Debuff.RussianRoulette:
                return "Sprites/Abilities/RussianRoulette";
            case Ability.Debuff.Session:
                return "Sprites/Abilities/Session";
            default:
                return "";
        }
    }

    public void ChangeId(int displayId)
    {
        displayCard.Clear();
        displayCard.Add(CardDatabase.cardList[displayId]);
    }

// Update is called once per frame
    void Update()
    {
        if (displayCard.Count == 0)
        {
            displayCard.Add(
                CardDatabase.cardList[displayId > 0 || displayId < CardDatabase.cardList.Count ? displayId : 0]
            );
        }

        id = displayCard[0].id;
        name = displayCard[0].name;
        type = displayCard[0].type;
        placement = displayCard[0].placementOnDesk;
        if (displayCard[0].cost != 0)
        {
            cost = displayCard[0].cost;
            costText.text = cost.ToString();
            typeImage.sprite = type == CostType.Sacrifice ? sacrifice : money;
            multiplier.text = "X";

            typeImage.enabled = true;
            costText.enabled = true;
            multiplier.enabled = true;
        }
        else
        {
            typeImage.enabled = false;
            costText.enabled = false;
            multiplier.enabled = false;
        }

        abilities = displayCard[0].abilities;
        switch (abilities.Count)
        {
            case 1:
                ability2.sprite = Resources.Load<Sprite>(GetAbilitySprite(abilities[0]));
                break;
            case 2:
                ability1.sprite = Resources.Load<Sprite>(GetAbilitySprite(abilities[0]));
                ability3.sprite = Resources.Load<Sprite>(GetAbilitySprite(abilities[1]));
                break;
            case 3:
                ability1.sprite = Resources.Load<Sprite>(GetAbilitySprite(abilities[0]));
                ability2.sprite = Resources.Load<Sprite>(GetAbilitySprite(abilities[1]));
                ability3.sprite = Resources.Load<Sprite>(GetAbilitySprite(abilities[2]));
                break;
        }

        power = displayCard[0].power;
        if (healthPoints == 0)
            healthPoints = displayCard[0].healthPoints;
        iconPath = displayCard[0].iconPath;

        nameText.text = name;
        damageText.text = power.ToString();
        healthText.text = healthPoints.ToString();
        iconImage.sprite = Resources.Load<Sprite>(iconPath);


        try
        {
            if (transform.parent == EnemyHand.transform)
            {
                cardBack = false;
            }
        }
        catch (NullReferenceException)
        {
        }

        staticCardBack = cardBack;
        if (CompareTag("Clone"))
        {
            if (numberOfCardsInDeck > 0 && PlayerDeck.staticDeck.Count > 0)
                displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck--;
            PlayerDeck.deckSize--;
            cardBack = false;
            tag = "Untagged";
        }
    }
}