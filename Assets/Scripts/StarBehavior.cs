using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public float initialJumpSpeed = 10;
    public float gravityScale = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(5f));
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump(float speed)
    {
        rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        // rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        StartCoroutine(Wait(0.4f));
    }

    public void JumpTwice(float speed1) //, float speed2)
    {
        rb.AddForce(Vector3.up * speed1, ForceMode.Impulse);
        StartCoroutine(Wait(0.3f));
        rb.AddForce(Vector2.up * speed1, ForceMode.Impulse);
        StartCoroutine(Wait(1f));
    }

    public void Fly()
    {
        rb.AddForce(Vector3.up * 100, ForceMode.Impulse);
        StartCoroutine(Wait(2.5f));
        gameObject.SetActive(false);

    }

    public void RandomRoll() // to be tested
    {
        rb.AddForce(new Vector3(Random.Range(0, 5), 0, 3), ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            Debug.Log("encounter light");
            JumpTwice(0.5f);
            StartCoroutine(Wait(1f));
        }
        else if (other.tag == "Ground")
        {
            //Debug.Log("encounter light");
            JumpTwice(0.5f);
            StartCoroutine(Wait(1f));
        }
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);

    }

}
