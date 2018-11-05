using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour {

    public GameObject text;

    Color color;

	// Use this for initialization
	void Start () {
        StartCoroutine("FadeIn");
        Debug.Log("시작");
        //color = text.GetComponent<Text>().color;
	}
	
	// Update is called once per frame
	void Update () {
	}


    IEnumerator FadeIn()
    {
        StopCoroutine("FadeOut");
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            Color color = new Vector4(text.GetComponent<Text>().color.r, text.GetComponent<Text>().color.g, text.GetComponent<Text>().color.b, i);
            text.GetComponent<Text>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        StopCoroutine("FadeIn");
        for (float i = 0f; i <= 1; i += 0.1f)
        {
            Color color = new Vector4(text.GetComponent<Text>().color.r, text.GetComponent<Text>().color.g, text.GetComponent<Text>().color.b, i);
            text.GetComponent<Text>().color = color;
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine("FadeIn");
    }

    /*IEnumerator TextFadeOut()
    {
        Color color = text.color;

        while(color.a < 1f)
        {
            color.a = Mathf.Lerp(1f, 0f, 0.1f);
            text.color = color;
        }

        StartCoroutine("TextFadeIn");
        
        yield return null;
    }

    IEnumerator TextFadeIn()
    {
        Color color = text.color;

        while (color.a > 0f)
        {
            color.a = Mathf.Lerp(0f, 1f, 0.1f);
            text.color = color;
        }

        StartCoroutine("TextFadeOut");

        yield return null;
    }*/

    IEnumerator ShowReady()
    {
        int count = 0;
        while (count < 3)
        {
            text.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            text.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
}
