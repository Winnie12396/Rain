using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigAnimEventCaller : MonoBehaviour
{
    public SoundController soundCtrl;
    public StarGroupControl starCtrl;
    public FlowControl flowCtrl;


    public void PlaySound()
    {
        soundCtrl.PlaySpatial();
    }

    public void StarsFly()
    {
        starCtrl.RiseStars();
    }

    public void EndingCall()
    {
        flowCtrl.EndGame();

    }

}
