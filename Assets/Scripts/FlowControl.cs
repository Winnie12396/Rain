using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class FlowControl : MonoBehaviour
{

    public VideoPlayer vid;
    public SoundController soundCtrl;
    public StarGroupControl starsCtrl;
    public GameObject camRig;
    public Animator camAnim;

    public GameObject VRcam;
    public GameObject mainCam;
    public GameObject normalCam;

    //public Canvas canvas;
    public GameObject canvas;
    public GameObject start;
    public GameObject paused;
    public GameObject video;
    public bool gameStarted = false;



    // stop game is written in the rig's animation event


    void Start()
    {
        VRcam.SetActive(false);
        normalCam.SetActive(true);
        canvas.SetActive(true);
        video.SetActive(true);
        start.SetActive(false);
        //start.SetActive(true);
        paused.SetActive(false);
        //camAnim = camRig.GetComponent<Animator>();
        camAnim.keepAnimatorStateOnDisable = false;
        camAnim.enabled = false;
        gameStarted = false;
        ResetGame();
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
            else
            {
                StartGame();
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            EndGame();
        }
            
    }

    public void StartGame()
    {
        camRig.transform.position = new Vector3(-49.9f, 0f, 34.8f);
        gameStarted = true;
        video.SetActive(false);
        canvas.SetActive(false);

        normalCam.SetActive(false);
        VRcam.SetActive(true);

        StartCoroutine(Wait(2f));
        camAnim.enabled = true;
        soundCtrl.PressedStart();
        //StartCoroutine(Wait(3f));
        //camAnim.Play("camMoveAlongRoute");

        //camAnim.Play("camMoveAlongRoute", -1, 0f);

    }

    public void StartWalking()  //after footprint
    {
        camAnim.Play("camMoveAlongRoute", -1, 0f);
    }

    public void ResetGame()
    {
        gameStarted = false;
        //camAnim.StopPlayback();
        camAnim.enabled = false;
        starsCtrl.ResetStars();
        soundCtrl.ResetSound();
        canvas.SetActive(true);
        video.SetActive(true);
        camRig.transform.position = new Vector3(-49.9f, 0f, 34.8f);
        VRcam.SetActive(false);
        mainCam.transform.localPosition = new Vector3(0, 0, 0);

        normalCam.SetActive(true);
        

    }


    public void EndGame()
    {
        gameStarted = false;
        SceneManager.LoadScene("Rain");

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
