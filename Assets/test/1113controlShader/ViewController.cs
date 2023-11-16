using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public Material outlineMat;
    float alpha = 1;

    // Start is called before the first frame update
    void Start()
    {
        UpdateView(alpha);
        StartCoroutine(TimerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateView(float a)
    {
        outlineMat.SetFloat("_Opacity", a);
    }

    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            alpha -= 0.05f;

            if (alpha >= 0)
            {
                UpdateView(alpha);
                Debug.Log(alpha);
            }
            else
            {
                Debug.Log("stopped");
                yield break;
            }
        }




    }

}
