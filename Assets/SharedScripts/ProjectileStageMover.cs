using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProjectileStageMover : MonoBehaviour
{
    // GameObjects
    public Dialogue TE;
    public GameObject inputBox;
   // public GameObject TargetBox;
    public TextMeshProUGUI textBody;
    public Cannonball ballObject;
    public MusicControl MC;
    public VictorySound VS;
     public CorrectSounds CS;
    public IncorrectSounds IS;
    public TextMeshProUGUI scoreText;
    public BreakableBox BB;
   // public VisualEffectsManager VEB;
    //public Target targetObject;

    // Problem components
    public float vInitial;
    public float theta;
    public float thetaR;
    public float vMaxHeight;
    public float range;
    public float deltaTime;
    public float maxHeight;

    public int stage;
    public int score = 0;

    // Answers
    public float answer;
    public bool Q1C = false;
    public bool Q2C = false;
    public bool Q3C = false;
    public bool Q4C = false ;

    //Random Numbers for Variation
    public int rando;
    public int rando1;
    public int rando2;
    public int rando3;
    public int wrongRando;
    public int wrongRando1;
    public int wrongRando2;
    public int wrongRando3;
    public int randFX;
    

    //Particle Effects
    public ParticleSystem particle;

    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public ParticleSystem particle4;
    public ParticleSystem particle5;
    public ParticleSystem particle6;

    //Hint Images;
    public PanelFader PF;
    public Image myImageComponent;
    public Sprite myFirstSprite;
    public Sprite mySecondSprite;
    public Sprite myThirdSprite;
    public Sprite myFourthSprite;


    

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        Debug.Log("Main script running");
        inputBox = GameObject.Find("InputField");
        TE = GetComponent<Dialogue>();
        randFX = UnityEngine.Random.Range(0,3);
        rando = UnityEngine.Random.Range(1,8);
        rando1 = UnityEngine.Random.Range(1,8);
        rando2 = UnityEngine.Random.Range(1,8);
        rando3 = UnityEngine.Random.Range(1,8);
        wrongRando = UnityEngine.Random.Range(1,8);
        wrongRando1 = UnityEngine.Random.Range(1,8);
        wrongRando2 = UnityEngine.Random.Range(1,8);
        wrongRando3 = UnityEngine.Random.Range(1,8);

    }

    // 4 different functions to change Hint images
    public void SetImage1() 
    {
      myImageComponent.sprite = null;
         myImageComponent.sprite = myFirstSprite;
     }

      public void SetImage2()
    {
      myImageComponent.sprite = null;
         myImageComponent.sprite = mySecondSprite;
     }

     public void SetImage3()
    {
      myImageComponent.sprite = null;
         myImageComponent.sprite = myThirdSprite;
     }

     public void SetImage4()
    {
      myImageComponent.sprite = null;
         myImageComponent.sprite = myFourthSprite;
     }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !TE.getLock())
            changeStage();
    }

     private IEnumerator ChangeColor ()
    {
       // birthdaySpark = 1;
        //correctChecks = 1;
         scoreText.color = Color.green;
         //birthdaySpark = 0;
        // yield return new WaitForSeconds(0.005f);
         yield return new WaitForSeconds(0.2f);
         //birthdaySpark = 0;
       //  correctChecks = 0;
         scoreText.color = Color.black;
         //birthdaySpark = 0;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.green;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.black;
          
         
    }

    private IEnumerator ChangeColor1 ()
    {
         scoreText.color = Color.red;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.black;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.red;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.black;
         
    }
     public void playEffects()
    {
         //int randFX;
         //randFX = UnityEngine.Random.Range(0,3);
         //randFX = randFX + 1;

         if (randFX == 1)
          {
            particle.Play();
            particle1.Play();
          }

          else if (randFX == 2)
          {
              particle2.Play();
              particle3.Play();
              particle4.Play();

          }
           

           else
          {
              particle5.Play();
              particle6.Play();
          }

          randFX = UnityEngine.Random.Range(0,3);
         

       // CSound.Play();
       // randSound = UnityEngine.Random.Range(1,5);
    }

    // Generates answers. Asks the first question (velocity at max height)
    void Stage1()
    {
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
        SetImage1();
        vInitial = UnityEngine.Random.Range(50F,100F);
        theta = UnityEngine.Random.Range(20F,60F);
        thetaR = theta * Mathf.PI / 180;
        Debug.Log("VInitial type: "+vInitial.GetType());
        Debug.Log("theta type: "+theta.GetType());

        vMaxHeight = vInitial * Mathf.Cos(thetaR);

        Debug.Log("vMaxHeight : "+vMaxHeight +" type: "+ vMaxHeight.GetType());

        range = (float)(((vInitial * vInitial) * (Mathf.Sin(thetaR * 2))) / 9.8);
        deltaTime = (float)(range / (vInitial * Mathf.Cos(thetaR)));
        maxHeight = (float)(Math.Pow(vInitial,2) * Math.Pow(Mathf.Sin(thetaR),2) / (2 * 9.8));

        TE.setSentence("When firing, the cannonball moves at an initial velocity of " +Math.Round(vInitial, 2) +" m/s at a "+Math.Round(theta, 2)+" degree angle. Use g = -9.8 m/s<sup>2</sup>. Find the velocity at the max height in m/s.");
    }
   void Stage2()   // Correctness of Q1
    {
        // Fade Checker, if already on, turn off
        if(PF.mFaded == false)
        {
            Debug.Log("Fade was deactivated!");
            PF.Fade();
        }
        //PF.resetAlpha();
        if (Q1C)
        {
          
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
            //TE.setSentence("CORRECT! Off to a great start! Press enter to continue.");
        }
        else
        {
          
         // scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
         // StartCoroutine(ChangeColor1());
           if (wrongRando == 1)
          {
            TE.setSentence("Correct answer: "+Math.Round(vMaxHeight, 2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(vMaxHeight, 2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(vMaxHeight, 2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(vMaxHeight, 2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(vMaxHeight, 2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(vMaxHeight, 2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
                        TE.setSentence("Incorrect. Correct answer: "+Math.Round(vMaxHeight, 2)+" m. But that's okay, you've got this! Press enter to continue.");
          }
           // TE.setSentence("Incorrect. Correct answer: "+Math.Round(VMaxHeight, 2)+" m. But that's okay, you've got this! Press enter to continue.");
        }
    }
    // Asks the second question (Find range)
    void Stage3()
    {
        // Fade Checker, if already on, turn off
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        SetImage2();
        TE.setSentence("Find the distance from the cannon to the target. (Initial velocity " +Math.Round(vInitial,2)+" m/s at "+Math.Round(theta,2)+ " degree angle)");
    }
    void Stage4()   // Q2C?
    {
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        if (Q2C)
        {
         //  TE.setSentence("CORRECT! Nice job! Press enter to continue.");
          if (rando1 == 1)
          {
            TE.setSentence(" THAT WAS CORRECT!"+ Environment.NewLine + "Press Enter to Continue");
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
        else
        {
             if (wrongRando1 == 1)
          {
            TE.setSentence("Correct answer: "+Math.Round(range, 2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(range, 2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(range, 2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(range, 2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(range, 2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(range, 2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
                        TE.setSentence("Incorrect. Correct answer: "+Math.Round(range, 2)+" m. But that's okay, you've got this! Press enter to continue.");
          }
            //TE. setSentence("Incorrect. Correct answer: " +Math.Round(range,2) +" m. But that's okay, keep trying! Press enter to continue.");
        }
    }
    void Stage5()   // Asks the third question (Find time)
    {
        // Fade Checker, if already on, turn off
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
       // PF.resetAlpha();
        SetImage3();
        TE.setSentence("Find the time it takes for the cannonball to hit the target. (Initial velocity " +Math.Round(vInitial,2)+" m/s at "+Math.Round(theta,2)+ " degree angle)" );
    }
    void Stage6()   //Q3C?
    {
        // Fade Checker, if already on, turn off
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        if (Q3C)
        {
            //TE.setSentence("CORRECT! Way to go! Press enter to continue.");
             if (rando2 == 1)
          {
            TE.setSentence(" THAT WAS CORRECT!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando2 == 2)
          {
            TE.setSentence("GREAT JOB!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando2 == 3)
          {
            TE.setSentence("AMAZING!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando2 == 4)
          {
            TE.setSentence("YES! THAT'S IT!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando2 == 5)
          {
           TE.setSentence("CONGRATS!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando2 == 6)
          {
           TE.setSentence("KEEP IT UP!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
            TE.setSentence("AWESOME!"+ Environment.NewLine + "Press Enter to Continue");
          }
        }
        else
        {
             if (wrongRando2 == 1)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime, 2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime, 2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime, 2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime, 2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(deltaTime, 2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(deltaTime, 2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
                        TE.setSentence("Incorrect. Correct answer: "+Math.Round(deltaTime, 2)+" m. But that's okay, you've got this! Press enter to continue.");
          }
            //TE.setSentence("Incorrect. Correct answer: " + Math.Round(deltaTime,2)+" s. Don't fret! Please, keep trying! Press enter to continue.");
        }
    }
    void Stage7()   // Asks the fourth question (Find max height)
    {
        // Fade Checker, if already on, turn off
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
        SetImage4();
        //PF.resetAlpha();
        TE.setSentence("Finally, find the max height of the cannonball. (Initial velocity " +Math.Round(vInitial,2)+" m/s at "+Math.Round(theta,2)+ " degree angle)");
    }
    void Stage8()   // Q4C?
    {
        // Fade Checker, if already on, turn off
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        
        if (Q4C)
        {
            //TE.setSentence("CORRECT! You are awesome! Press enter to continue.");
             if (rando3 == 1)
          {
            TE.setSentence(" THAT WAS CORRECT!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando3 == 2)
          {
            TE.setSentence("GREAT JOB!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando3 == 3)
          {
            TE.setSentence("AMAZING!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando3 == 4)
          {
            TE.setSentence("YES! THAT'S IT!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando3 == 5)
          {
           TE.setSentence("CONGRATS!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (rando3 == 6)
          {
           TE.setSentence("KEEP IT UP!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
            TE.setSentence("AWESOME!"+ Environment.NewLine + "Press Enter to Continue");
          }
        }
        else
        {
             if (wrongRando3 == 1)
          {
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
                        TE.setSentence("Incorrect. Correct answer: "+Math.Round(maxHeight, 2)+" m. But that's okay, you've got this! Press enter to continue.");
          }
            //TE. setSentence("Incorrect. Correct answer: " +Math.Round(maxHeight,2) +" m. Press enter to continue.");
        }
    }
    void Stage9()
    {
        // Fade Checker, if already on, turn off
         if(PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        if(Q1C && Q2C && Q3C && Q4C)    // All Correct
        {
            MC.pauseSong();
            VS.playRandom();
            ballObject.on = true;
            TE.setSentence("FANTASTIC! You got everything correct! Press enter to keep practicing");
        }
        else if(!Q1C && Q2C && Q3C && Q4C)  // All but Q1 correct  
        {
            TE.setSentence("Almost! You only got question 1 wrong. Remember- the velocity at the max height is the x component of initial velocity. Press enter to try again");
        }
        else if(Q1C && !Q2C && Q3C && Q4C)  // All but Q2 correct
        {
            TE.setSentence("Almost! You only got question 2 wrong. Refer to the projectile range formula. Press enter to try again");
        }
        else if(Q1C && Q2C && !Q3C && Q4C) // All but Q3 correct
        {
            TE.setSentence("Almost! You only got question 3 wrong. Refer to the formula that involves time t, and solve for it. Press enter to try again");
        }
        else if(Q1C && Q2C && Q3C && !Q4C)  // All but Q4 correct
        {
            TE.setSentence("Almost! You only got question 4 wrong. The only thing you work on is using the formula for max height. Press enter to try again");
        }
        else if(!Q1C && !Q2C && Q3C && Q4C) // Q1 and Q2 incorrect
        {
            TE.setSentence("Good try! You only the questions about max height velocity and total range wrong. Check your calculations and press enter to try again.");
        }
        else if(!Q1C && Q2C && !Q3C && Q4C)    // Q1 and Q3 incorrect
        {
            TE.setSentence("Good try! You only the questions about max height velocity and total elapsed time wrong. Check your calculations and press enter to try again.");
        }
        else if(!Q1C && Q2C && Q3C && !Q4C) // Q1 and Q4 incorrect
        {
            TE.setSentence("Good try! You only the questions about max height distance and velocity wrong. Check your calculations and press enter to try again.");
        }
        else if(Q1C && !Q2C && !Q3C && Q4C)   // Q2 and Q3 incorrect
        {
            TE.setSentence("Good try! You only got the range and elapsed time questions wrong. Check your calculations and press enter to try again.");
        }
        else if(Q1C && !Q2C && !Q3C && !Q4C)   // only Q1 correct
        {
            TE.setSentence("Good try! You got the max height velocity question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if(!Q1C && Q2C && !Q3C && !Q4C)   // only Q2 correct
        {
            TE.setSentence("Good try! You got the range question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if(!Q1C && !Q2C && Q3C && !Q4C)   // only Q3 correct
        {
            TE.setSentence("Good try! You got the elapsed time question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if(!Q1C && !Q2C && !Q3C && Q4C)   // only Q4 correct
        {
            TE.setSentence("Good try! You got the max height question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if(!Q1C && !Q2C && !Q3C && !Q4C)   // all wrong
        {
            TE.setSentence("Oh no! You didn't get any correct, but that's okay. Review the projectile formulas and press enter to try again. You can do this!");
        }
    }

    // Activates upon user input. Concludes the current stage that the variable is set to
    void changeStage()
    {   
        Debug.Log("changeStage() activated");
        if(stage == 0)  // Stage 0: Before game initially starts
        {
            Stage1();
        }
        if(stage == 1)  // Stage 1: Question 1
        {   //SetImage1(); 
            answer = getAnswer();
            if(answer >= vMaxHeight * 0.98 && answer <= vMaxHeight * 1.02)
               { 
                   Q1C = true;
                    playEffects();
                    CS.playAudio();
                    score += score + 1;
                    scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                    StartCoroutine(ChangeColor());
               }
            else 
                {
                  Q1C = false;
                  IS.playAudio();
                  score += 0;
                  scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                  StartCoroutine(ChangeColor1());
                }


            Stage2();
        }
        else if(stage == 2)
        {
            Stage3();
        }
        else if(stage == 3) // Stage 2: Question 2
        {
           // SetImage2();
            answer = getAnswer();
            if(answer >= (range * 0.98) && answer <= (range * 1.02))
              { 
                   Q2C = true;
                    playEffects();
                    CS.playAudio();
                    score = score + 1;
                    scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                    StartCoroutine(ChangeColor());
               }
            else 
                 {
                  Q2C = false;
                  IS.playAudio();
                  score += 0;
                  scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                  StartCoroutine(ChangeColor1());
                }

            
            Stage4();
        }
        else if(stage == 4)
        {
            Stage5();
        }
        else if(stage == 5) // Stage 3: Question 3
        {
           // SetImage3();
            answer = getAnswer();
            if(answer >= (deltaTime * 0.98) && answer <= (deltaTime * 1.02))
               { 
                   Q3C = true;
                    playEffects();
                    CS.playAudio();
                    score = score + 1;
                    scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                    StartCoroutine(ChangeColor());
               }
            else 
                 {
                  Q3C = false;
                  IS.playAudio();
                  score += 0;
                  scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                  StartCoroutine(ChangeColor1());
                }


            Stage6();
        }
        else if(stage == 6)
        {
            Stage7();
        }
        else if(stage == 7)     // Stage 4: Question 4
        {
           // SetImage4();
            answer = getAnswer();
            if(answer >= (maxHeight * 0.98) && answer <= (maxHeight * 1.02))
               { 
                   Q4C = true;
                   playEffects();
                    CS.playAudio();
                    score = score + 1;
                    scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                    StartCoroutine(ChangeColor());
               }
            else 
                 {
                  Q4C = false;
                  IS.playAudio();
                  score += 0;
                  scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
                  StartCoroutine(ChangeColor1());
                }

            Stage8();
        }
        else if(stage == 8)
        {
            Stage9();
        }
        else if(stage == 9) // Stage 5: Post game. Shows results
        {
            //TargetBox.enabled = true;
            BB.ResetTarget();
            //ballObject.enabled = true;
            stage = 0;
            MC.unpauseSong();
            ballObject.resetPosition();
            rando = UnityEngine.Random.Range(1,8);
        rando1 = UnityEngine.Random.Range(1,8);
        rando2 = UnityEngine.Random.Range(1,8);
        rando3 = UnityEngine.Random.Range(1,8);
        wrongRando = UnityEngine.Random.Range(1,8);
        wrongRando1 = UnityEngine.Random.Range(1,8);
        wrongRando2 = UnityEngine.Random.Range(1,8);
        wrongRando3 = UnityEngine.Random.Range(1,8);

            Stage1();
            score = 0;
            scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
        }
        stage++;
    }
    public float getAnswer()
    {
        String answerString = inputBox.GetComponent<TMP_InputField>().text;
        inputBox.GetComponent<TMP_InputField>().text = "";
        return (Convert.ToSingle(answerString));
    }
}
