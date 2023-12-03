using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource BGM, spMachine, spFirework, spChildren;


    void Start()
    {
        BGM.gameObject.SetActive(false);
        spChildren.gameObject.SetActive(false);
        spFirework.gameObject.SetActive(false);
        spMachine.gameObject.SetActive(false);
    }

    public void PressedStart()
    {
        BGM.gameObject.SetActive(true);
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(94f);
        spMachine.gameObject.SetActive(true);

        yield return new WaitForSeconds(129f);
        spFirework.gameObject.SetActive(true);

        yield return new WaitForSeconds(61f);
        spChildren.gameObject.SetActive(true);

        yield break;
    }

}
