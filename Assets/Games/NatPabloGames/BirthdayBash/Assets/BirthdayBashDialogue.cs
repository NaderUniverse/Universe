using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirthdayBashDialogue : MonoBehaviour
{

  //public TextSound type;
  public AudioClip typewriter;
  public AudioSource type;
  public TextMeshProUGUI textDisplay;
  public string sentence;
  private int index;
  public int delayStartTime = 10;
  public float typingSpeed = 5;

  public bool lockBool;
  private AudioSource sound;
  private String uniString;
  /*
    public TextSound type;
    public TextMeshProUGUI textDisplay;
    public string sentence;
    private int index;
    public int delayStartTime = 2;
    public float typingSpeed;
    public bool lockBool;
    private AudioSource sound;
    */


   // private AudioClip talkingAudioSource;

/*
    void Awake()
    {
        type = GetComponent<TextSound>();
        lockBool = true;
        //StartCoroutine(DelayedStart());
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    /*
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delayStartTime);
        StartCoroutine(Type());
    }
    */
/*
   IEnumerator Type()
   {
       lockBool = true;

       foreach(char letter in sentence){
           textDisplay.text += letter;
           type.playAudio();

           yield return new WaitForSeconds(typingSpeed);
       }
       lockBool = false;
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
/*
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
    */


    void Awake()
    {
        lockBool = true;
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
     lockBool = true;
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
       lockBool = false;
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
