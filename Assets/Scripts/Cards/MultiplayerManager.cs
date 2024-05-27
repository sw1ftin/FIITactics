using Mirror;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR;

public class MultiplayerManager : NetworkBehaviour
{
    public void SendData()
    {
        var handSize = GameObject.Find("Hand").transform.childCount;
        var cardId1 = GameObject.Find("CardPlace1").transform.childCount == 2
            ? GameObject.Find("CardPlace1").GetComponentInChildren<DisplayCard>().displayId
            : (int?)null;
        var cardId2 = GameObject.Find("CardPlace2").transform.childCount == 2
            ? GameObject.Find("CardPlace2").GetComponentInChildren<DisplayCard>().displayId
            : (int?)null;
        var cardId3 = GameObject.Find("CardPlace3").transform.childCount == 2
            ? GameObject.Find("CardPlace3").GetComponentInChildren<DisplayCard>().displayId
            : (int?)null;
        var cardId4 = GameObject.Find("CardPlace4").transform.childCount == 2
            ? GameObject.Find("CardPlace4").GetComponentInChildren<DisplayCard>().displayId
            : (int?)null;
        CmdSendCardData(handSize, cardId1, cardId2, cardId3, cardId4);
    }

    [Command]
    void CmdSendCardData(int handSize, int? cardId1, int? cardId2, int? cardId3, int? cardId4)
    {
        RpcReceiveCardData(handSize, cardId1, cardId2, cardId3, cardId4);
    }

    [ClientRpc]
    void RpcReceiveCardData(int handSize, int? cardId1, int? cardId2, int? cardId3, int? cardId4)
    {
        Debug.Log("Received data: Hand Size - " + handSize + ", Card IDs: " + cardId1 + ", " + cardId2 + ", " +
                  cardId3 + ", " + cardId4);
    }
}