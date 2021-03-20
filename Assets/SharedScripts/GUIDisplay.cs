using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.VFX;
using UnityEditor.VFX;
//using UnityEditor.Experimental.Rendering.HDPipeline;
using UnityEditor.VFX.UI;

public class GUIDisplay : MonoBehaviour
{
    public float[] actualAnswer = new float [5];
    //public float[] answer = new float [5];
    public int KE = 0;
    public int aR = 0;
    public int bR = 0;
    public int cR = 0;
    public float aAV = 0;
    public float abAV = 0;
    public float cAV = 0;
    public int answered1Right = 0;
    public int answered2Right = 0;
    public int flag = 1;
    public static int correctConfetti = 0;
    public static int correctChecks = 0;
    public static int incorrectChecks = 0;
    public static int fireworkChecks =0;
    public static float time = 0;
    public static float timeFlag = 0;
    public int i;
    public int state = 0;
    public int correctVal;
    public float answer;
    public string answerString;
    bool isCoroutineStarted = false;
    public int rando;
    public int rando1;
    public int wrongRando;
    public int wrongRando1;
    public int CorrectRNG;
    public TextMeshProUGUI [] TextUI;
    public TextMeshProUGUI textBody;
    private GameObject someObject;
    public PlayButtonSound button;
    public CorrectSound CSound;
    public IncorrectSound ISound;
    public VictorySound VSound;
    public ReplaySound RSound;
    public ApplauseSound applause;
    public Dialogue TE; 
    public GameObject FireworkEffect;
    public GameObject check1;
    public GameObject check2;
    public GameObject x1;
    public GameObject x2;


    //public TextMeshProUGUI textBody = applauseObject.GetComponent<AudioSource>();



    // Start is called before the first frame update
    void Start()
    {
         
        someObject = GameObject.Find("InputField");
        button = GetComponent<ButtonSound>();
        applause = GetComponent<ApplauseSound>();
        TE = GetComponent<Dialogue>(); 
        CSound = GetComponent<CorrectSound>();
        ISound = GetComponent<IncorrectSound>();
        VSound = GetComponent<VictorySound>();
        RSound = GetComponent<ReplaySound>();
        FireworkEffect = GameObject.Find("fireworks");

        check1=GameObject.Find("check1");
        check2=GameObject.Find("check2");
        x1= GameObject.Find("x1");
        x2= GameObject.Find("x2");

        rando = UnityEngine.Random.Range(1,8);
        rando1 = UnityEngine.Random.Range(1,8);
        wrongRando = UnityEngine.Random.Range(1,8);
        wrongRando1 = UnityEngine.Random.Range(1,8);

        CorrectRNG = UnityEngine.Random.Range(1,4);
        aR = UnityEngine.Random.Range(8, 12);
        bR = UnityEngine.Random.Range(18, 22);
        cR = UnityEngine.Random.Range(28, 32);

        aAV = ((float)SmallGear.randoAV * (float)Math.PI) / 180;
        aAV = Mathf.Round(aAV* 100.0f) * 0.01f;

        abAV = (float)((aAV * (aR * 0.01)) / (bR * 0.01));
        abAV= Mathf.Round(abAV* 100.0f) * 0.01f;

        cAV = (float)((aAV * (aR * 0.01)) / (bR * 0.01 * cR * 0.01));
        cAV = Mathf.Round(cAV * 100.0f) * 0.01f;

        RSound.RPreRandom1();
        RSound.RPplayAudio();
        RSound.RPreRandom1();

        check1.SetActive(false);
        check2.SetActive(false);
        x1.SetActive(false);
        x2.SetActive(false);

        FireworkEffect.SetActive(false);

        
        Debug.Log(fireworkChecks);

        TextUI = FindObjectsOfType<TextMeshProUGUI>();
        
       
        
        textBody = TextUI[2];
      

        //t1 = TextUI[1];
        //t2 = TextUI[0];
        //t3 = TextUI[1];
        //textUpdater = gameObject.AddComponent(typeof(UpdateText)) as UpdateText;

        //style.normal.textColor = Color.black;
        //style.fontSize = 15;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !TE.getLock())
        {
            isCoroutineStarted = false;
            
            if (state == 2)
            {
                answerString = someObject.GetComponent<TMP_InputField>().text;
                answer = Convert.ToSingle(answerString);

                if ((answer >= (abAV * 0.98)) && (answer <= (abAV * 1.02)))
                {
                    answered1Right = 1;
                
                Debug.Log("Correct!");
                CSound.playAudio();
                check1.SetActive(true);
               
                //CSound.reRandom(); 
                  //  Debug.Log("Answer 1: " + answer + " correct answer: " + abAV + "  answeredRight registers as " + answered1Right);
                }
                else
                {
                    ISound.playAudio();
                    
                    x1.SetActive(true);
                   
                  //  ISound.reRandom1(); 
                    Debug.Log("Incorrect Answer");
                }
            }
            if (state == 4)
            {
                answerString = someObject.GetComponent<TMP_InputField>().text;
                answer = Convert.ToSingle(answerString);

                if ((answer >= (cAV * 0.98)) && (answer <= (cAV * 1.02)))
                {
                    answered2Right = 1;
                  //  Debug.Log(answered2Right);
                    
                Debug.Log("Correct!");
                
                check2.SetActive(true);
        
                 CSound.playAudio2();
                // CSound.reRandom();  
                 //   Debug.Log("Answer 1: " + answer + " correct answer: " + cAV + "  answeredRight registers as " + answered2Right);

                }
                else
                {
                  
                    x2.SetActive(true);
                    ISound.playAudio2();
                  //  ISound.reRandom1();
                    Debug.Log("Incorrect Answer");
                }
            }
            button.playAudio();
            state++;
        }

        if(state == 1)
        {
            //Debug.Log("abAV: " + abAV);
           // Debug.Log("cAV: " + cAV);

            if (!isCoroutineStarted)
                StartCoroutine(changeText());
        }
        if(state == 2)
        {
            if (!isCoroutineStarted)
                StartCoroutine(changeText());

           /* if(answered1Right == 1){
                 StartCoroutine(changeText());
                Debug.Log("Correct!");
            } */
        }
        if(state == 3)
        {

            if (!isCoroutineStarted)
                StartCoroutine(changeText());

             /* if(answered2Right == 1){
                  StartCoroutine(changeText());
                Debug.Log("Correct!");
            } */
        }
           if(state == 4)
        {

            if (!isCoroutineStarted)
                StartCoroutine(changeText());

             /* if(answered2Right == 1){
                  StartCoroutine(changeText());
                Debug.Log("Correct!");
            } */
        }

          if(state == 5)
        {

            if (!isCoroutineStarted)
                StartCoroutine(changeText());
                //BOTH CORRECT
                if(answered1Right ==1 && answered2Right ==1){
                    VSound.playAudio();
                }

                //BOTH INCORRECT
                else if(answered1Right !=1 && answered2Right !=1){
                    ISound.playAudio3();
                }

                //FIRST CORRECT AND SECOND INCORRECT
                else if(answered1Right ==1 && answered2Right !=1){
                    ISound.playAudio3();
                }

                //FIRST INCORRECT AND SECOND CORRECT
                else if(answered1Right !=1 && answered2Right ==1){
                    ISound.playAudio3();
                }
            
        }
        if(state == 6)
        {           
            if(answered1Right == 1 && answered2Right == 1)
            {
                //applause.playSound();
               // VSound.playAudio();
               // Debug.Log("BothCorrect");
                correctVal = 1;
                if (!isCoroutineStarted)
                    StartCoroutine(changeText());
                if(CorrectRNG==1 || CorrectRNG==4 )
                correctConfetti = 1;
               
                else if ( CorrectRNG ==2 || CorrectRNG==5)
                {
                   correctChecks = 1;
                }

                 else if ( CorrectRNG ==3 || CorrectRNG==6)
                {
                  FireworkEffect.SetActive(true);
                   fireworkChecks = 1;
                }
                
            }
            else if(answered1Right == 1 && answered2Right != 1)
            {
                correctVal = 2;
                if (!isCoroutineStarted)
                    StartCoroutine(changeText());
                    incorrectChecks =1;
            }
            else if(answered1Right != 1 && answered2Right == 1)
            {
                correctVal = 3;
                if (!isCoroutineStarted)
                    StartCoroutine(changeText());  
                    incorrectChecks =1;
            }
            else
            {
                correctVal = 4;
                if (!isCoroutineStarted)
                    StartCoroutine(changeText());
                    incorrectChecks =1;
            }
        }
        if(state > 6)
        {
           VSound.StopAudio();
            correctConfetti = 0;
            incorrectChecks = 0;
           correctChecks = 0;
           fireworkChecks =0;
            correctVal = 0;
            answered1Right = 0;
            answered2Right = 0;
            CSound.reRandom();
            ISound.reRandom1();
            VSound.VreRandom();


            RSound.RPplayAudio();
            RSound.RPreRandom1();
            FireworkEffect.SetActive(false);

            // Generate the new question values
            aR = UnityEngine.Random.Range(8, 12);
            bR = UnityEngine.Random.Range(18, 22);
            cR = UnityEngine.Random.Range(28, 32);

            rando = UnityEngine.Random.Range(1,8);
            rando1 = UnityEngine.Random.Range(1,8);
            wrongRando = UnityEngine.Random.Range(1,8);
            wrongRando1 = UnityEngine.Random.Range(1,8);
            CorrectRNG = UnityEngine.Random.Range(1,4);

            check1.SetActive(false);
            check2.SetActive(false);
             x1.SetActive(false);
             x2.SetActive(false);

            aAV = ((float)SmallGear.randoAV * (float)Math.PI) / 180;
            aAV = Mathf.Round(aAV* 100.0f) * 0.01f;
            abAV = (aAV * aR) / bR;
            abAV= Mathf.Round(abAV* 100.0f) * 0.01f;
            cAV = (aAV * aR) / cR;
            cAV = Mathf.Round(cAV * 100.0f) * 0.01f;

            if (time > 2)
            {
                SmallGear.randoAV = UnityEngine.Random.Range(30, 60);
            }
            state = 1;

        }
    }

    IEnumerator changeText()
    {
        isCoroutineStarted = true;
        if (state == 1)
        {
            //textBody.SetText("A small gear S is driving a combo of gears SM and large gear L. S radius: " + aR + "mm, medium gear M radius: " + bR + "mm, L radius: " + cR + "mm. S angular velocity: " + aAV + " rad/s. Press enter to continue.");
            TE.setSentence("A small blue gear (S) is driving a combo of green and orange gears (SM) and large pink gear (L).  The blue gear (S) radius: " + aR + "mm, green gear (M) radius: " + bR + "mm, pink gear (L) radius: " + cR + "mm. Blue gear (S) angular velocity: " + aAV + " rad/s. Press enter to continue.");
           //  typing = false;
        }
        else if(state == 2)
        {
            //textBody.SetText("Small gear S radius " + aR + "mm, medium gear M radius " + bR + "mm, large gear L radius " + cR + "mm. S angular velocity: " + aAV + " rad/s. \nDetermine the angular velocity of the Gear Combo SM.");
            TE.setSentence("Small blue gear (S) radius " + aR + "mm, medium green gear (M) radius " + bR + "mm, pink gear (L) radius " + cR + "mm. Small blue gear (S) angular velocity: " + aAV + " rad/s. \nDetermine the angular velocity of the green and orange Gear Combo (SM).");
           // typing = false;
        }
         else if(state ==3 && answered1Right ==1)
        {
            //textBody.SetText("Small gear S radius " + aR + "mm, medium gear M radius " + bR + "mm, large gear L radius " + cR + "mm. S angular velocity: " + aAV + " rad/s. \n Determine the angular velocity of L.");
           // TE.setSentence("Correct!");
            // CSound.playAudio();
            // typing = false;
            if (rando == 1)
          {
            TE.setSentence(" THAT WAS CORRECT!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando == 2)
          {
            TE.setSentence("GREAT JOB!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando == 3)
          {
            TE.setSentence("AMAZING!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando == 4)
          {
            TE.setSentence("YES! THAT'S IT!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando == 5)
          {
           TE.setSentence("CONGRATS!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando == 6)
          {
           TE.setSentence("KEEP IT UP!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
            TE.setSentence("AWESOME!"+ Environment.NewLine + "Press Enter to Continue");
          }
        }
         else if(state ==3 && answered1Right !=1)
        {
            //textBody.SetText("Small gear S radius " + aR + "mm, medium gear M radius " + bR + "mm, large gear L radius " + cR + "mm. S angular velocity: " + aAV + " rad/s. \n Determine the angular velocity of L.");
           // TE.setSentence("Sorry you got it incorrect!");
            if (wrongRando == 1)
          {
            TE.setSentence(" Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 2)
          {
            TE.setSentence("I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 3)
          {
            TE.setSentence("I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 4)
          {
            TE.setSentence("Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 5)
          {
           TE.setSentence("Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 6)
          {
           TE.setSentence("You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
             TE.setSentence("Sorry you got it incorrect!"+ Environment.NewLine + "Press Enter to Continue");
          }
            
        }
        else if(state == 4)
        {
            //textBody.SetText("Small gear S radius " + aR + "mm, medium gear M radius " + bR + "mm, large gear L radius " + cR + "mm. S angular velocity: " + aAV + " rad/s. \n Determine the angular velocity of L.");
            TE.setSentence("Small blue gear (S) radius " + aR + "mm, medium green gear (M) radius " + bR + "mm, large pink gear (L) radius " + cR + "mm. Small blue gear (S) angular velocity: " + aAV + " rad/s. \n Determine the angular velocity of the large pink gear (L).");
            // typing = false;
        }
        else if(state ==5 & answered2Right ==1)
        {
            //textBody.SetText("Small gear S radius " + aR + "mm, medium gear M radius " + bR + "mm, large gear L radius " + cR + "mm. S angular velocity: " + aAV + " rad/s. \n Determine the angular velocity of L.");
            //TE.setSentence("Great Job!");
            if (rando1 == 1)
          {
            TE.setSentence(" THAT WAS CORRECT!" + Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando1 == 2)
          {
            TE.setSentence("GREAT JOB!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando1 == 3)
          {
            TE.setSentence("AMAZING!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando1 == 4)
          {
            TE.setSentence("YES! THAT'S IT!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando1 == 5)
          {
           TE.setSentence("CONGRATS!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando1 == 6)
          {
           TE.setSentence("KEEP IT UP!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
            TE.setSentence("AWESOME!"+ Environment.NewLine + "Press Enter to Continue");
          }
         
        }
         else if(state ==5 & answered2Right !=1)
        {
            //textBody.SetText("Small gear S radius " + aR + "mm, medium gear M radius " + bR + "mm, large gear L radius " + cR + "mm. S angular velocity: " + aAV + " rad/s. \n Determine the angular velocity of L.");
           // TE.setSentence("Wrong Answer!");
           if (wrongRando1 == 1)
          {
            TE.setSentence(" Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 2)
          {
            TE.setSentence("I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 3)
          {
            TE.setSentence("I’m afraid you’re mistaken. But the greatest successes come from learning from your mistakes!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 4)
          {
            TE.setSentence("Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 5)
          {
           TE.setSentence("Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 6)
          {
           TE.setSentence("Don't worry! Even the greatest people make mistakes."+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
             TE.setSentence("Sorry you got it incorrect!"+ Environment.NewLine + "Press Enter to Continue");
          }
        }
        else if(state == 6)
        {
            if (correctVal == 1)
            {
                //textBody.SetText("Congrats, you got both parts right! Press enter to generate a new question!");
                TE.setSentence("Congrats, you got both parts right! Press enter to generate a new question!");

               //  typing = false;
            }
            else if (correctVal == 2)
            {
                //textBody.SetText("You only got part 1 right, but don't worry, keep trying! Press enter to generate a new question!");
                TE.setSentence("You only got part 1 right, but don't worry, keep trying! Press enter to generate a new question!");
            
               // typing = false;
            }
            else if(correctVal == 3)
            {
                //textBody.SetText("You only got part 2 right, but don't worry, keep trying! Press enter to generate a new question!");
                TE.setSentence("You only got part 2 right, but don't worry, keep trying! Press enter to generate a new question!");
            
              //   typing = false;
            }
            else if(correctVal == 4)
            {
                //textBody.SetText("Sorry, you got both parts wrong. Keep trying! Press enter to generate a new question.");
                TE.setSentence("Sorry, you got both parts wrong. Keep trying! Press enter to generate a new question.");

               //  typing = false;
            }
        }
        yield return null;
    }

    
}

