using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextSound type;
    public TextMeshProUGUI textDisplay;
    public string sentence;
    private int index;
    public int delayStartTime = 2;
    public float typingSpeed;
    public bool lockBool;
    private AudioSource sound;

   
   // private AudioClip talkingAudioSource;


    void Awake()
    {
        type = GetComponent<TextSound>();
        lockBool = true;
        StartCoroutine(DelayedStart());
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delayStartTime);
        StartCoroutine(Type());
    }

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
