using UnityEngine;

public class Hammer : MonoBehaviour
{
    public static bool hammerActive = false;

    public void SwitchDestroyMode()
    {
        hammerActive = !hammerActive;
        if(hammerActive)
            Debug.Log("DESTROY MODE: ACTIVE");
        else
            Debug.Log("DESTROY MODE: INACTIVE");
    }
}