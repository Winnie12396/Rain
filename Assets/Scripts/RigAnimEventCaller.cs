using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigAnimEventCaller : MonoBehaviour
{
    public SoundController soundCtrl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlaySound(string item)
    {
        soundCtrl.PlaySpatial(item);
    }

}
