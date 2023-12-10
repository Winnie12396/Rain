using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGroupControl : MonoBehaviour
{
    public GameObject visibleGroup;
    public GameObject hiddenGroup;
    public GameObject group2;
    bool movingUp = false;
    private Vector3 target;
    // Adjust the speed for the application.
    public float speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        movingUp = false;
        target = new Vector3(0.0f, 99f, 0.0f);
        visibleGroup.SetActive(true);
        hiddenGroup.SetActive(false);
        group2.SetActive(false);
        //StartCoroutine(Wait(220f));   //Wait(215f)

    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }

    public void ResetStars()
    {
        movingUp = false;
        transform.position = new Vector3(0, 0, 0);
        visibleGroup.SetActive(true);
        hiddenGroup.SetActive(false);
    }

    public void RiseStars()
    {
        movingUp = true;
        group2.SetActive(true);
    }


    /*IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        hiddenGroup.SetActive(true);
        movingUp = true;
    }*/
}
