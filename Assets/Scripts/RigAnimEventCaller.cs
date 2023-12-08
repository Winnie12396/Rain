using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigAnimEventCaller : MonoBehaviour
{
    public SoundController soundCtrl;
    public StarGroupControl starCtrl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaySound()
    {
        soundCtrl.PlaySpatial();
    }

    public void StarsFly()
    {
        starCtrl.RiseStars();
    }

}
