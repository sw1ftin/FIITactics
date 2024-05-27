using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CostType
{
    Sacrifice,
    Money
}

public class Card
{
    public int id;
    public string name;
    public CostType type;
    public int cost;
    public int power;
    public int healthPoints;
    public string iconPath;
    public List<Enum> abilities;
    public bool isAble;

    public int placementOnDesk;

    public Card()
    {
    }

    public Card(int Id, string Name, CostType Type, int Cost, int Power, int HealthPoints, List<Enum> Abilities,
        string IconPath, bool IsAble)
    {
        id = Id;
        name = Name;
        type = Type;
        cost = Cost;
        power = Power;
        healthPoints = HealthPoints;
        iconPath = IconPath;
        abilities = Abilities;
        isAble = IsAble;
        placementOnDesk = 0;
    }
}