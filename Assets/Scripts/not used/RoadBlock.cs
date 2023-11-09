using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    public bool moving = false;
    float moveVelocity = 5f;
    public Renderer rend;
    float endZPos = -48f;  //-36f;
    float newZPos = 72f;
    //float blockWidth = 12f;


    // Start is called before the first frame update
    void Start()
    {
        rend.enabled = false;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Move();
        }
    }

    public void TurnOn()
    {
        ResetPos();
        rend.enabled = true;
        moving = true;
    }

    public void TurnOn(float pos)
    {
        transform.localPosition = new Vector3(0, 0, pos);
        rend.enabled = true;
        moving = true;
    }

    void Move()
    {
        transform.localPosition -= Vector3.forward * moveVelocity * Time.deltaTime;
        if (transform.localPosition.z < endZPos)
        {
            rend.enabled = false;
            moving= false;
        }
        
    }

    void ResetPos()
    {
        transform.localPosition = new Vector3(0, 0, newZPos);
        rend.enabled = true;
        moving = true;
    }
}
