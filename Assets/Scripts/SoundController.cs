using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource BGM, spMachine, spFirework, spChildren;


    void Start()
    {
        BGM.gameObject.SetActive(true);
        spChildren.gameObject.SetActive(false);
        spFirework.gameObject.SetActive(false);
        spMachine.gameObject.SetActive(false);
    }

    public void PressedStart()
    {
        BGM.Play();
        StartCoroutine(PlaySound());
    }

    public void ResetSound()
    {
        BGM.Stop();
        StopAllCoroutines();
        spChildren.gameObject.SetActive(false);
        spFirework.gameObject.SetActive(false);
        spMachine.gameObject.SetActive(false);
    }

    // pause coroutine & pause sound?


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
