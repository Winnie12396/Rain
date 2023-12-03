using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCall : MonoBehaviour
{
    public FlowControl manager;

    public void EndGame()
    {
        manager.ResetGame();
    }

}
