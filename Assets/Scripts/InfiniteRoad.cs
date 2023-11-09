using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject star, meteors;
    public GameObject[] roadBlocks = new GameObject[14];
    //public RoadBlock[] blocks = new RoadBlock[14];
    public int[] roadBlockState = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public float moveVelocity = 4f;
    public bool moving = true;
    float blockWidth = 24f;
    float resetZPos;  // = blockWidth * (-3);  //-36f;
    float newZPos;  // = blockWidth * 6;
    
    int picked = 0;
    int wanted = 0;

    // Start is called before the first frame update
    void Start()
    {
        resetZPos = blockWidth * (-4);
        newZPos = blockWidth * 5;
        foreach (GameObject block in roadBlocks)
        {
            block.SetActive(false);
        }

        for (int i = 0; i < roadBlockState.Length; i++)
        {
            roadBlockState[i] = 0;
        }

        wanted = 10;
        picked = 0;
        float j = newZPos / blockWidth;
        while (wanted > picked)
        {
            int index = Random.Range(0, roadBlocks.Length);
            if (roadBlockState[index] == 1) { continue; }
            else
            {
                roadBlockState[index] = 1;
                roadBlocks[index].SetActive(true);
                roadBlocks[index].transform.localPosition = new Vector3(0, 0, j * blockWidth);
                //blocks[index].TurnOn(j * blockWidth);
                j--;
                picked++;
            }
        }

        if (moving)
        {
            StartCoroutine(ResetCoroutine());
        }

        StartCoroutine(ChangeModeCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            for (int i = 0; i < roadBlocks.Length; i++)
            {
                // move
                if (roadBlockState[i] == 1)
                {
                    roadBlocks[i].transform.localPosition -= Vector3.forward * moveVelocity * Time.deltaTime;
                }
            }

        }
        /*if (OVRInput.Get(OVRInput.Button.One))
        {
            moving = false;
            star.transform.localPosition = new Vector3(0.15f, 10.03f, 0.33f);
            star.SetActive(true);
        }
        else if (OVRInput.Get(OVRInput.Button.Two))
        {
            moving = true;
            star.SetActive(false);
        }*/
    }

    void Renew()
    {
        for (int i = 0; i < roadBlocks.Length; i++)
        {
            Debug.Log("enter");
            if (roadBlocks[i].transform.localPosition.z < resetZPos)
            {
                roadBlocks[i].SetActive(false);
                roadBlockState[i] = 0;

                int on = 0;
                for (int j = 0; j < roadBlockState.Length; j++)
                {
                    if (roadBlockState[j] == 1) { on++; }
                }

                if (on < 10)
                {
                    wanted = 1;
                    picked = 0;
                    while (wanted > picked)
                    {
                        int index = Random.Range(0, roadBlocks.Length);
                        if (roadBlockState[index] == 1) { continue; }
                        else
                        {
                            roadBlockState[index] = 1;
                            roadBlocks[index].SetActive(true);
                            roadBlocks[index].transform.localPosition = new Vector3(0, 0, newZPos);
                            picked++;
                        }
                    }
                }
            }
        }
    }

    private IEnumerator ChangeModeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            if (moving)
            {
                moving = false;
                star.transform.localPosition = new Vector3(0.15f, 10.03f, 0.33f);
                star.SetActive(true);
                meteors.SetActive(true);
            }
            else
            {
                moving = true;
                star.SetActive(false);
                meteors.SetActive(false);
            }
        }
    }

    private IEnumerator ResetCoroutine()
    {
        while (true)
        {
            if (moving) { Renew(); }

            yield return new WaitForSeconds(3f);
        }
    }
}
