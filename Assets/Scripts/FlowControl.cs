using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class FlowControl : MonoBehaviour
{

    public SoundController soundCtrl;
    public StarGroupControl starsCtrl;
    public GameObject camRig;
    public Animator camAnim;

    public GameObject VRcam;
    public GameObject mainCam;
    public GameObject normalCam;

    public GameObject canvas, endCanvas;
    public GameObject start;
    public GameObject paused;
    public GameObject starGroup1, starGroup2, cityGroup;
    public bool gameStarted = false;

    //public FadeScreen fade;



    // stop game is written in the rig's animation event


    void Start()
    {
        VRcam.SetActive(false);
        normalCam.SetActive(true);
        canvas.SetActive(true);
        endCanvas.SetActive(false);
        start.SetActive(true);
        paused.SetActive(false);
        //camAnim = camRig.GetComponent<Animator>();
        camAnim.keepAnimatorStateOnDisable = false;
        camAnim.enabled = false;
        gameStarted = false;
        //ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("pressed left");
            if (gameStarted) {
                PauseGame();
            }
            else  // add start walking?
            {
                StartGame();
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            PressEndGame();
        }
            
    }

    public void StartGame()
    {
        camRig.transform.position = new Vector3(-49.9f, 0f, 34.8f);
        gameStarted = true;
        canvas.SetActive(false);

        normalCam.SetActive(false);
        VRcam.SetActive(true);
        //fade.FadeIn();

        StartCoroutine(Wait(2f));
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

        normalCam.SetActive(true);
        

    }


    public void PressEndGame()
    {
        gameStarted = false;
        SceneManager.LoadScene("Rain");

    }

    public void EndGame()
    {
        
        //fade.FadeOut();
        starGroup1.SetActive(false);
        starGroup2.SetActive(false);
        cityGroup.SetActive(false);
        endCanvas.SetActive(true);
        StartCoroutine(Wait(1f));
        //fade.FadeIn();
        gameStarted = false;
    }

    public void PauseGame()
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
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);

    }

}
