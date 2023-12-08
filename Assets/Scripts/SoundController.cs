using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource[] spatials;
    int playIndex = 0;


    void Start()
    {
        BGM.gameObject.SetActive(true);
        playIndex = 0;
        
    }

    public void PressedStart()
    {
        BGM.Play();
        //StartCoroutine(PlaySound());
    }

    public void PlaySpatial()
    {
        spatials[playIndex].Play();
        playIndex++;

    }

    public void PauseSound()
    {
        BGM.Pause();

        for (int i = 0; i < spatials.Length; i++)
        {
            spatials[i].Pause();
        }
        
    }

    public void ResumeSound()
    {
        BGM.UnPause();

        for (int i = 0; i < spatials.Length; i++)
        {
            spatials[i].UnPause();
        }

    }

    public void ResetSound()
    {
        BGM.Stop();
        
    }



}
