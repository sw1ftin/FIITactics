using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCards : MonoBehaviour
{
    public static List<Queue<int>> nextMoves;
    public static int wavesCount = 0;

    private void Start()
    {
        nextMoves = new();
        for (var i = 0; i < 4; i++)
        {
            nextMoves.Add(new());
        }

        GenerateNextMoves();
        GenerateNextMoves();
        GenerateNextMoves();
    }

    public List<int> GenerateRandomCards(int count = 4)
    {
        var cards = new List<int>();
        var chanceOfCard = wavesCount < 5 ? 1 : wavesCount < 10 ? 2 : 3;
        var maxCardId = Math.Min(wavesCount + 3, 8);
        for (var i = 0; i < count; i++)
        {
            if (Random.Range(0, chanceOfCard + 1) != 0)
                cards.Add(Random.Range(1, maxCardId + 1));
            else
                cards.Add(0);
        }

        return cards;
    }


    public void GenerateNextMoves()
    {
        var randomCards = GenerateRandomCards();
        for (var i = 0; i < 4; i++)
        {
            nextMoves[i].Enqueue(randomCards[i]);
        }
    }
}