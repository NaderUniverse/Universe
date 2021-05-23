using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Dialogue_NP : MonoBehaviour
{
    public AudioSource type;
    public TextMeshProUGUI textDisplay;
    public string sentence;
    private int index;
    public int delayStartTime = 0;
    public float typingSpeed = 0.05f;

    public bool lockBool;
    private String uniString;

    void Awake()
    {
        lockBool = true;
        uniString = "";
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delayStartTime);
        StartCoroutine(Type());
    }

   IEnumerator Type()
   {
     lockBool = true;
     int i = 0;

     for(i = 0; i < sentence.Length; i++)
     {
       if (type != null)
         type.Play();

        if(sentence[i] == '<')
         {
           uniString += sentence[i];
           i++;
           while(sentence[i] != '>')
           {
              uniString += sentence[i];
              i++;
           }
             uniString += sentence[i];
             textDisplay.text += uniString;
             uniString = "";
         }

        else
        {
          textDisplay.text += sentence[i];
        }
       yield return new WaitForSeconds(typingSpeed);
     }
       lockBool = false;
   }

    public void setSentence(string sentence1)
    {
        textDisplay.text = "";
        sentence = sentence1;
        StartCoroutine(Type());
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }


}
