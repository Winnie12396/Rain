using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class FlowControl : MonoBehaviour
{

    public VideoPlayer vid;
    public SoundController soundCtrl;
    public StarGroupControl starsCtrl;
    public GameObject camRig;
    public Animation camAnim;   //this doesn't work
    //public Canvas canvas;
    public GameObject canvas;
    public GameObject start;
    public GameObject paused;
    public GameObject video;
    public bool gameStarted = false;


    // stop game is written in the rig's animation event


    void Start()
    {
        canvas.SetActive(true);
        video.SetActive(true);
        start.SetActive(false);
        paused.SetActive(false);
        camAnim = camRig.GetComponent<Animation>();
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameStarted) {
                PauseGame();
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            ResetGame();
        }
            
    }

    public void StartGame()
    {
        gameStarted = true;
        canvas.SetActive(false);
    }

    public void StartWalking()  //after footprint
    {
        camAnim.Play();
    }

    public void ResetGame()
    {
        camAnim.Stop();
        starsCtrl.ResetStars();
        gameStarted = false;
        canvas.SetActive(true);
        video.SetActive(true);
    }

    public void PauseGame()
    {
        canvas.SetActive(true);
        paused.SetActive(true);
        camAnim.enabled = false;

    }

    public void ResumeGame()
    {
        canvas.SetActive(false);
        camAnim.enabled = true;
    }


}
