using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestFlowControl : MonoBehaviour
{


    public SoundController soundCtrl;
    public StarGroupControl starsCtrl;
    public GameObject camRig;
    public Animator camAnim;

    public GameObject VRcam;
    public GameObject mainCam;

    public GameObject canvas;
    public GameObject title, start;
    public GameObject starGroup1, starGroup2, cityGroup;
    public bool gameStarted = false;


    void Start()
    {
        VRcam.SetActive(true);
        canvas.SetActive(true);
        title.SetActive(true);
        start.SetActive(true);
        //camAnim = camRig.GetComponent<Animator>();
        camAnim.keepAnimatorStateOnDisable = false;
        camAnim.enabled = false;
        gameStarted = false;
        //ResetGame();
    }

    // Update is called once per frame


    public void StartGame()
    {
        camRig.transform.position = new Vector3(-49.9f, 0f, 34.8f);
        gameStarted = true;
        canvas.SetActive(false);
        title.SetActive(false);
        start.SetActive(false);

        StartCoroutine(Wait(3f));
        camAnim.enabled = true;
        soundCtrl.PressedStart();

    }


    public void ResetGame()
    {
        gameStarted = false;
        //camAnim.StopPlayback();
        camAnim.enabled = false;
        starsCtrl.ResetStars();
        soundCtrl.ResetSound();
        canvas.SetActive(true);
        camRig.transform.position = new Vector3(-49.9f, 0f, 34.8f);
        VRcam.SetActive(false);
        mainCam.transform.localPosition = new Vector3(0, 0, 0);

        //normalCam.SetActive(true);


    }


    /*public void PressEndGame()
    {
        gameStarted = false;
        SceneManager.LoadScene("Rain");

    }*/

    public void EndGame()
    {
        gameStarted = false;
        SceneManager.LoadScene("Rain");
    }

    /*public void PauseGame()
    {
        canvas.SetActive(true);
        paused.SetActive(true);
        soundCtrl.PauseSound();
        camAnim.speed = 0;

    }

    public void ResumeGame()
    {
        canvas.SetActive(false);
        soundCtrl.ResumeSound();
        camAnim.speed = 1;
    }*/

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);

    }

}


