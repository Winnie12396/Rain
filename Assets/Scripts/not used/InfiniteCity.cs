using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCity : MonoBehaviour
{
    public RoadBlock[] blocks = new RoadBlock[14];
    public float moveVelocity = 5f;
    int roadLength = 10;
    float blockWidth = 12f;
    float newZPos = 72f;
    int picked = 0;
    int wanted = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        wanted = roadLength;
        picked = 0;
        float j = newZPos / blockWidth;
        while (wanted > picked)
        {
            int index = Random.Range(0, blocks.Length);
            //Debug.Log(index);
            if (blocks[index].moving) { continue; }
            else
            {
                blocks[index].TurnOn(0);  // j * blockWidth);
                j--;
                picked++;
            }
        }

        

        //StartCoroutine(ResetCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private IEnumerator ResetCoroutine()
    {
        while (true)
        {
            int on = 0;
            foreach (var block in blocks)
            {
                if (block.moving) { on++; }
            }
            if (on < roadLength)
            {
                wanted = roadLength - on;
                picked = 0;
                float j = newZPos / blockWidth;
                while (wanted > picked)
                {
                    int index = Random.Range(0, blocks.Length);
                    if (blocks[index].moving) { continue; }
                    else
                    {
                        blocks[index].TurnOn();
                        j--;
                        picked++;
                    }
                }
            }
            Debug.Log("checked once");

            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);

    }
}
