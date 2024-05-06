using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new();

    void Awake()
    {
        cardList.Add(new Card(0, "None", CostType.Money, 0, 0, 0,
            new(),
            "",
            false));
        cardList.Add(new Card(1, "Белка", CostType.Money, 0, 0, 1,
            new(),
            "Sprites/Cards/Squirrel",
            false));
        cardList.Add(new Card(2, "Серега", CostType.Money, 2, 2, 2,
            new() { Ability.Buff.Serega, Ability.Debuff.Vlad },
            "Sprites/Cards/Serega",
            true));
        cardList.Add(new Card(3, "Волков", CostType.Sacrifice, 1, 1, 2,
            new() { Ability.Buff.Volkov, Ability.Debuff.RussianRoulette },
            "Sprites/Cards/Volkov",
            true));
        cardList.Add(new Card(4, "Влад", CostType.Sacrifice, 1, 1, 1,
            new(),
            "Sprites/Cards/Vlad",
            true));
        cardList.Add(new Card(5, "SkyWhy", CostType.Money, 3, 4, 2,
            new(),
            "Sprites/Cards/Antonchik",
            true));
        cardList.Add(new Card(6, "Literally me", CostType.Sacrifice, 3, 7, 4,
            new(),
            "Sprites/Cards/Ryan",
            true));
        cardList.Add(new Card(7, "Гейн младший", CostType.Sacrifice, 2, 1, 2,
            new() { Ability.Buff.Grow },
            "Sprites/Cards/GeynJr",
            true));
        cardList.Add(new Card(8, "Гейн старший", CostType.Money, 0, 5, 5,
            new(),
            "Sprites/Cards/GeynSr",
            false));
    }
}