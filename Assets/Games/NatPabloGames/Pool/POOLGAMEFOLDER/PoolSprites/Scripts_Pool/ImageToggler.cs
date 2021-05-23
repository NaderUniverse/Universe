using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ImageToggler : MonoBehaviour
{
    public Image image;
    public bool mFaded = false;
    public float Duration = 0.4f;
/*
    void Start()
    {
      StartCoroutine(waitForIt());
      StartCoroutine(waitForIt());
      StartCoroutine(waitForIt());
      StartCoroutine(waitForIt());
      StartCoroutine(waitForIt());
    }
    */

    /*
    void Update()
    {
      //Fade();
      StartCoroutine(waitForIt());
    }
    */

    public IEnumerator waitForIt()
    {
      //yield WaitForSeconds(7);
      Fade();
      yield return new WaitForSeconds(2);
    }

    public void Fade()
    {
      var canvGroup = GetComponent<CanvasGroup>();

      //Toggle the end value depending on the faded state
      StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 :0));
      //Toggle faded state
      mFaded = !mFaded;

    }

  /*public void resetAlpha()
  {
      var canvGroup = GetComponent<CanvasGroup>();
      canvGroup.alpha = 0;
  } */

  public IEnumerator DoFade (CanvasGroup canvGroup, float start, float end)
  {
     float counter = 0f;
     while(counter<Duration)
     {
      counter += Time.deltaTime;
      canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

      yield return null;

    }
  }
}
