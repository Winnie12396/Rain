using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotationToSpeed : MonoBehaviour
{
    public GameObject cam;
    public int interval = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Time.frameCount % interval == 0)
        {
            Debug.Log(cam.transform.eulerAngles.y);

        }*/
        Debug.Log(Time.frameCount);
    }
}
