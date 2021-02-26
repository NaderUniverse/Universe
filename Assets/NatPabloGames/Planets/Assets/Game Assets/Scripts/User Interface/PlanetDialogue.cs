using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlanetDialogue : MonoBehaviour
{
    //public TextSound type;
    public AudioClip typewriter;
    public AudioSource type;
    public TextMeshProUGUI textDisplay;
    public string sentence;
    private int index;
    public int delayStartTime = 10;
    public float typingSpeed = 5;

    public bool showInput;
    private AudioSource sound;
    private String uniString;
   // private AudioClip talkingAudioSource;


    void Awake()
    {
        showInput = true;
        uniString = "";
        //StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delayStartTime);
        StartCoroutine(Type());
    }

   IEnumerator Type()
   {
     showInput = true;
     int i = 0;

     //foreach(char letter in sentence)
     for(i = 0; i < sentence.Length; i++)
     {
       //textDisplay.text += letter;

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
       showInput = false;
   }

   /*public void NextSentence(){
       continueButton.SetActive(false);
       if(index < sentences.Length -1){
           index++;
           textDisplay.text = "";
           StartCoroutine(Type());
       }
       else{
           textDisplay.text = "";
       }
   }
*/
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
