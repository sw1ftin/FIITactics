using System;
using static Ability.Buff;

[System.Serializable]
public class Ability
{
    public enum Buff
    {
        Volkov,
        Cancel,
        Retry,
        Skip,
        Serega,
        Grant,
        Grow
    }

    public enum Debuff
    {
        Vlad,
        Hunger,
        Eloquence,
        NotEnoughSleep,
        RussianRoulette,
        Session
    }
}