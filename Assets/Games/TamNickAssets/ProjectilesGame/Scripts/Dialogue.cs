using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public AudioSource typeSound;
    public TextMeshProUGUI textDisplay;
    public string sentence;
    private int index;
    public int delayStartTime = 2;
    public float typingSpeed;
    public bool lockBool;

    private String uniString;
    private int i;
   // private AudioClip talkingAudioSource;


    void Awake()
    {
        uniString = "";
        lockBool = true;
        StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delayStartTime);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
       lockBool = true;
       i = 0;
       for (i = 0; i < sentence.Length; i++)
        {
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
            typeSound.Play();
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
    public void lockTyping(bool lock1)
    {
        lockBool = lock1;
    }
    public bool getLock()
    {
        return lockBool;
    }

}