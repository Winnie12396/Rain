using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public float fadeDuration = 5;
    public Color fadeColor = Color.black;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
    }


    public void FadeOut()  //scene fade out
    {
        StartCoroutine(FadeCoroutine(0, 1, 6));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCoroutine(1, 0, 2));
    }

    public IEnumerator FadeCoroutine(float alphaIn, float alphaOut, float duration)
    {
        float timer = 0;
        while (timer <= duration)
        {
            Color newCol = fadeColor;
            newCol.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);
            rend.material.SetColor("_Color", newCol);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newCol2 = fadeColor;
        newCol2.a = alphaOut;
        rend.material.SetColor("_Color", newCol2);
    }
}
