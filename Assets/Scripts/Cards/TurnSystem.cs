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

    public int maxMoney = -1;
    public int currentMoney;
    public Text moneyText;

    public static bool gotCard;
        
    public Text yourScore;
    public Text opponentScore;

    public List<int> cardTurns = new(4);

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        isOpponentTurn = 0;
        for (int i = 0; i < 3; i++)
        {
            cardTurns[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = currentMoney.ToString();
    }
    
    public void GetSquirrel()
    {
        // var squirrelInstance = Instantiate(squirrelPrefab, transform.position, transform.rotation);
        // deck.Add(squirrelInstance.GetComponent<Card>());
        gotCard = true;
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