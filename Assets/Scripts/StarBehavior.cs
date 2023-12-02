using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public float initialJumpSpeed = 5;
    public float gravityScale = 3;
    public bool activeState = false;

    // Start is called before the first frame update
    void Start()
    {
        activeState = true;
        StartCoroutine(CountDown());
        StartCoroutine(JumpControl());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            RandomRoll();
        }*/
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * Random.Range(1, 5), ForceMode.Impulse);
        // rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        //StartCoroutine(Wait(Random.Range(3, 10)));
        /*if (activeState)
        {
            Jump();
        }*/
    }

    /*public void JumpTwice(float speed1) //, float speed2)
    {
        rb.AddForce(Vector3.up * speed1, ForceMode.Impulse);
        StartCoroutine(Wait(1f));
        rb.AddForce(Vector2.up * speed1, ForceMode.Impulse);
        StartCoroutine(Wait(1f));
    }*/

    public void Fly()
    {
        rb.AddForce(Vector3.up * 100, ForceMode.Impulse);
        StartCoroutine(Wait(2.5f));
        gameObject.SetActive(false);

    }

    public void RandomRoll() // to be tested
    {
        rb.AddForce(new Vector3(Random.Range(-5, 5), 0.1f, Random.Range(-5, 5)), ForceMode.Impulse);
    }



    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);

    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(90f);
        activeState = false;

    }

    IEnumerator JumpControl()
    {
        yield return new WaitForSeconds(Random.Range(1, 9));
        if (activeState)
        {
            Jump();
        }
        else
        {
            yield break;
        }

    }


}
