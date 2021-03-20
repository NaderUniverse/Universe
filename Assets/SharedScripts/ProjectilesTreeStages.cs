using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectilesTreeStages : MonoBehaviour
{
    // GameObjects
    public Dialogue TE;
    public MusicControl MC;
    public VictorySound VS;
    public CorrectSounds CS;
    public IncorrectSounds IS;
    public GameObject inputBox;
    public TextMeshProUGUI textBody;
    public TextMeshProUGUI scoreText;
    public Stone stoneObject;
    public Coconut coconutObject;
    


    // Problem components
    public float vInitial;
    public float theta;
    public float thetaR;
    public float vMaxHeight;
    public float range;
    public float deltaTime;
    public float maxHeight;
    public float timeMaxHeight;
    public float coconutHeight;
    public static int correctConfetti = 0;

    public int stage;
    public int score = 0;

    // Answers
    public float answer;
    public bool Q1C= false;
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

    // Int values for Effects
    public static int birthdaySpark = 0;
    public static int correctChecks = 0;
    public static int incorrectChecks = 0;

      //Hint Images;
      public PanelFader PF;
      public Image myImageComponent;
      public Sprite myFirstSprite;
      public Sprite mySecondSprite;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main script running");
        inputBox = GameObject.Find("InputField");
        //scoreText = GameObject.Find("scoreText");
        //TE = GetComponent<Dialogue>();
        stage = 0;
        rando = UnityEngine.Random.Range(1,8);
        rando1 = UnityEngine.Random.Range(1,8);
        rando2 = UnityEngine.Random.Range(1,8);
        rando3 = UnityEngine.Random.Range(1,8);
        wrongRando = UnityEngine.Random.Range(1,8);
        wrongRando1 = UnityEngine.Random.Range(1,8);
        wrongRando2 = UnityEngine.Random.Range(1,8);
        wrongRando3 = UnityEngine.Random.Range(1,8);

    }

     private IEnumerator ChangeColor ()
    {
       // birthdaySpark = 1;
        correctChecks = 1;
         scoreText.color = Color.green;
         //birthdaySpark = 0;
        // yield return new WaitForSeconds(0.005f);
         yield return new WaitForSeconds(0.2f);
         //birthdaySpark = 0;
         correctChecks = 0;
         scoreText.color = Color.white;
         //birthdaySpark = 0;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.green;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.white;
          
         
    }

    private IEnumerator ChangeColor1 ()
    {
         scoreText.color = Color.red;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.white;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.red;
         yield return new WaitForSeconds(0.2f);
         scoreText.color = Color.white;
         
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !TE.getLock())
            changeStage();
    }

    // Generates answers. Asks the first question (velocity at max height)
    void Stage1()
    {   
        SetImage1();
        // Generate random initial values
        vInitial = UnityEngine.Random.Range(10F,30F);
        theta = UnityEngine.Random.Range(20F,60F);
        thetaR = theta * Mathf.PI / 180;
        range = UnityEngine.Random.Range(10F, 30F);
        score = 0;

        // Q1 answer: max height of projectile
        maxHeight = (float)(Math.Pow(vInitial,2) * Math.Pow(Mathf.Sin(thetaR),2) / (2 * 9.8));
        
        // Q2 answer: time to reach max height
        timeMaxHeight = (float)(vInitial * Mathf.Sin(thetaR) / 9.8);
        // Q3 answer: given same range, find the time it takes to hit the coconut
        deltaTime = (float)(range / (vInitial * Mathf.Cos(thetaR)));
        // Q4 answer: coconut height given range
        coconutHeight = (float)(0.5 * 9.8 * Math.Pow(deltaTime,2) + vInitial * (deltaTime));

        TE.setSentence("You throw the rock at velocity " + Math.Round(vInitial, 2) +" m/s at a "+Math.Round(theta, 2)+" degree angle. Use g = -9.8 m/s<sup>2</sup>. What is the maximum height of the trajectory?");
    }
    void Stage2()   // Correctness of Q1
    { 

        if(PF.mFaded == false)
        {
          Debug.Log("Fade was deactivated!");
          PF.Fade();
        }
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
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(maxHeight, 2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
                        TE.setSentence("Incorrect. Correct answer: "+Math.Round(maxHeight, 2)+" m. But that's okay, you've got this! Press enter to continue.");
          }
           // TE.setSentence("Incorrect. Correct answer: "+Math.Round(maxHeight, 2)+" m. But that's okay, you've got this! Press enter to continue.");
        }
    }
    void Stage3()   // Q2
    {
        SetImage2();
        TE.setSentence("How long does it take for the rock to reach the maximum height? (Initial velocity " +Math.Round(vInitial, 2)+" m/s at "+Math.Round(theta, 2)+ " degree angle)");
    }
    void Stage4()   // Q2C?
    {
        if(PF.mFaded == false)
        {
          Debug.Log("Fade was deactivated!");
          PF.Fade();
        }
        if (Q2C)
        {
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
           //TE.setSentence("CORRECT! Nice job! Press enter to continue."); 
        }
        else
        {
          
          //scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
         // StartCoroutine(ChangeColor1());
            if (wrongRando1 == 1)
          {
            TE.setSentence("Correct answer: "+Math.Round(timeMaxHeight, 2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(timeMaxHeight, 2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(timeMaxHeight, 2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(timeMaxHeight, 2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(timeMaxHeight, 2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando1 == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(timeMaxHeight, 2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
            TE. setSentence("Incorrect. Correct answer: "+Math.Round(timeMaxHeight, 2)+" s. But that's okay, keep trying! Press enter to continue.");
          }
            //TE. setSentence("Incorrect. Correct answer: "+Math.Round(timeMaxHeight, 2)+" s. But that's okay, keep trying! Press enter to continue.");
        }
    }
    void Stage5()   // Q3
    {
        TE.setSentence("If the tree is " + Math.Round(range, 2) + " meters away, find the time it takes to impact the coconut (Initial velocity " +Math.Round(vInitial, 2)+" m/s at "+Math.Round(theta, 2)+ " degree angle)" );
    }
    void Stage6()   // Q3C?
    {
      
        if (Q3C)
        {
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
           // TE.setSentence("CORRECT! Way to go! Press enter to continue.");
        }
        else
        {
          
          //scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
          //StartCoroutine(ChangeColor1());
             if (wrongRando2 == 1)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime,2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime,2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime,2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(deltaTime,2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(deltaTime,2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando2 == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(deltaTime,2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
            TE. setSentence("Incorrect. Correct answer: "+Math.Round(deltaTime,2)+" s. But that's okay, keep trying! Press enter to continue.");
          }
            //TE.setSentence("Incorrect. Correct answer: "+Math.Round(deltaTime,2)+" s. Don't fret! Please, keep trying! Press enter to continue.");
        }
    }
    void Stage7()   // Q4
    {
        TE.setSentence("Finally, find the height of the coconut from the ground. (Range: " + Math.Round(range, 2) + " m, Initial velocity "+Math.Round(vInitial, 2)+" m/s at "+Math.Round(theta, 2)+ " degree angle)");
    }
    void Stage8()   // Q4C?
    {
      
        if (Q4C)
        {
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
            //TE.setSentence("CORRECT! You are awesome! Press enter to continue.");
        }
        else
        {
          
         // scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
         // StartCoroutine(ChangeColor1());
            if (wrongRando3 == 1)
          {
            TE.setSentence("Correct answer: "+Math.Round(coconutHeight,2)+ " m. Sorry bud, try again next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 2)
          {
            TE.setSentence("Correct answer: "+Math.Round(coconutHeight,2)+ " m. I'm afarid that's not quite right. You'll get it next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 3)
          {
            TE.setSentence("Correct answer: "+Math.Round(coconutHeight,2)+ " m. I’m afraid you’re mistaken. But don't lose hope!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 4)
          {
            TE.setSentence("Correct answer: "+Math.Round(coconutHeight,2)+ " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 5)
          {
           TE.setSentence("Correct answer: "+Math.Round(coconutHeight,2)+ " m. Sorry pal, we all make mistakes here and there! Don't give up!"+ Environment.NewLine + "Press Enter to Continue");
          }

          else if (wrongRando3 == 6)
          {
           TE.setSentence("Correct answer: "+Math.Round(coconutHeight,2)+ " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!"+ Environment.NewLine + "Press Enter to Continue");
          }

           else
          {
            TE. setSentence("Incorrect. Correct answer: "+Math.Round(coconutHeight,2)+" s. But that's okay, keep trying! Press enter to continue.");
          }
           // TE. setSentence("Incorrect. Correct answer: "+Math.Round(coconutHeight,2)+" m. Press enter to continue.");
        }
    }
    void Stage9()   // Final results
    {
        if(Q1C && Q2C && Q3C && Q4C)    // All Correct
        {
            stoneObject.on = true;
            TE.setSentence("FANTASTIC! You got everything correct! Press enter to keep practicing.");
            MC.pauseSong();
            VS.playRandom();
        }
        else
        {
            TE.setSentence("Oh no! You missed one or more questions, but that's okay. Please keep trying, you can do this! Press enter to try again.");
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
        {    
            answer = getAnswer();
            if(answer >= maxHeight * 0.98 && answer <= maxHeight * 1.02)
                {
                  Q1C = true;
                 // correctChecks = 1;
                  CS.playAudio();
                  //birthdaySpark = 1;
              score += score + 1;
              correctChecks = 1;
              scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
               StartCoroutine(ChangeColor());
               correctChecks = 0;
                  //birthdaySpark = 0;
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
        else if (stage == 2)
        {
            Stage3();
        }
        else if(stage == 3) // Stage 3: Question 2
        {
            answer = getAnswer();
            if(answer >= (timeMaxHeight * 0.98) && answer <= (timeMaxHeight * 1.02))
               {
                  Q2C = true;
                  CS.playAudio();
                score = score + 1;
                 correctChecks = 1;
              scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
               StartCoroutine(ChangeColor());
               correctChecks = 0;
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
        else if(stage == 5) // Stage 5: Question 3
        {
            answer = getAnswer();
            if(answer >= (deltaTime * 0.98) && answer <= (deltaTime * 1.02))
                {
                  Q3C = true;
                  CS.playAudio();
                score = score + 1;
                 correctChecks = 1;
              scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
               StartCoroutine(ChangeColor());
               correctChecks = 0;
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
        else if(stage == 7)     // Stage 7: Question 4
        {
            answer = getAnswer();
            if(answer >= (coconutHeight * 0.98) && answer <= (coconutHeight * 1.02))
               { 
                 Q4C = true;
                 CS.playAudio();
                score = score + 1;
                correctChecks = 1;
              scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
               StartCoroutine(ChangeColor());
               correctChecks = 0;
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
            
            stage = 0;
            MC.unpauseSong();
            stoneObject.resetPosition();
            coconutObject.resetPosition();
            rando = UnityEngine.Random.Range(1,8);
            rando1 = UnityEngine.Random.Range(1,8);
            rando2 = UnityEngine.Random.Range(1,8);
            rando3 = UnityEngine.Random.Range(1,8);
            wrongRando = UnityEngine.Random.Range(1,8);
            wrongRando1 = UnityEngine.Random.Range(1,8);
            wrongRando2 = UnityEngine.Random.Range(1,8);
            wrongRando3 = UnityEngine.Random.Range(1,8);
            Stage1();
            //MC.pauseSong();
            score = 0;
            scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
        }
        stage++;
    }
    // Returns the user input from text box
    public float getAnswer()
    {
        String answerString = inputBox.GetComponent<TMP_InputField>().text;
        inputBox.GetComponent<TMP_InputField>().text = "";
        return (Convert.ToSingle(answerString));
    }
}
