using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StageMover : MonoBehaviour
{
    // GameObjects
    public Dialogue TE;
    public GameObject inputBox;
    // public GameObject TargetBox;
    public TextMeshProUGUI textBody;
    //public TextMeshProUGUI SpringInfo;

    public MusicControl MC;
    public Victory VS;
    public CorrectSounds CS;
    public IncorrectSounds IS;
    public TextMeshProUGUI scoreText;
    public PushingForce PushF;

    public GameObject Target;

    // public VisualEffectsManager VEB;
    //public Target targetObject;



    //Spring Question Components:
    public float RodLength;

    public float objectMass;
    public float forceF;
    public float angularAccelerationRod;
    public float accelerationPointB;
    public float reactionAx;
    public float reactionAy;
    public float a; //Final answer



    public int stage;
    public int score = 0;

    // Answers
    public float answer;
    public bool Q1C = false;
    public bool Q2C = false;
    public bool Q3C = false;
    public bool Q4C = false;


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
        randFX = UnityEngine.Random.Range(0, 3);
        rando = UnityEngine.Random.Range(1, 8);
        wrongRando = UnityEngine.Random.Range(1, 8);


    }

    // 4 different functions to change Hint images
    public void SetImage1()
    {
        myImageComponent.sprite = myFirstSprite;
    }

    public void SetImage2()
    {
        myImageComponent.sprite = mySecondSprite;
    }

    public void SetImage3()
    {
        myImageComponent.sprite = myThirdSprite;
    }

    public void SetImage4()
    {
        myImageComponent.sprite = myFourthSprite;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !TE.getLock())
            changeStage();
    }

    private IEnumerator ChangeColor()
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

    private IEnumerator ChangeColor1()
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
        randFX = UnityEngine.Random.Range(0, 3);
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

        randFX = UnityEngine.Random.Range(0, 3);


        // CSound.Play();
        // randSound = UnityEngine.Random.Range(1,5);
    }

    // Generates answers. Asks the first question (velocity at max height)
    void Stage1()
    {

        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        SetImage1();



        forceF = UnityEngine.Random.Range(100f, 500f);
        forceF = Mathf.Round(forceF * 100.0f) * 0.01f;

        RodLength = UnityEngine.Random.Range(0.5f, 2f);
        RodLength = Mathf.Round(RodLength * 100.0f) * 0.01f;


        objectMass = UnityEngine.Random.Range(0.5f, 2.0f);
        objectMass = Mathf.Round(objectMass * 100.0f) * 0.01f;

        angularAccelerationRod = (3 * forceF) / (objectMass * RodLength);
        angularAccelerationRod = Mathf.Round(angularAccelerationRod * 100.0f) * 0.01f;

        accelerationPointB = (3 * forceF) / (objectMass);
        accelerationPointB = Mathf.Round(accelerationPointB * 100.0f) * 0.01f;

        a = (angularAccelerationRod * RodLength) / 2;
        reactionAx = objectMass * a;
        reactionAx = Mathf.Round(reactionAx * 100.0f) * 0.01f;

        reactionAy = (float)(objectMass * 9.81);
        reactionAy = Mathf.Round(reactionAy * 100.0f) * 0.01f;





        //  finalSpeed = Mathf.Sqrt((2*objectMass)* (PotentialEnergy + ElasticPotentialEnergy ));



        //  TE.setSentence("Force F strikes the hanging rod of mass "+objectMass+" kg"+" and Length "+RodLength+" m at point B with a force of " +forceF+" N. Calculate the angular acceleration of the rod and the acceleration at point B immediately after impact. Calculate the reactions Ax and Ay at point A."  );
        TE.setSentence("Force F strikes the hanging rod of mass " + objectMass + " kg" + " and Length " + RodLength + " m at point B with a force of " + forceF + " N. First, calculate the angular acceleration of the rod!");

    }
    void Stage2()   // Correctness of Q1
    {
        // Fade Checker, if already on, turn off
        if (PF.mFaded == false)
        {
            Debug.Log("Fade was deactivated!");
            PF.Fade();
        }
        //PF.resetAlpha();
        if (Q1C)
        {

            if (rando == 1)
            {
                TE.setSentence(" THAT WAS CORRECT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando == 2)
            {
                TE.setSentence("GREAT JOB!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando == 3)
            {
                TE.setSentence("AMAZING!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando == 4)
            {
                TE.setSentence("YES! THAT'S IT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando == 5)
            {
                TE.setSentence("CONGRATS!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando == 6)
            {
                TE.setSentence("KEEP IT UP!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("AWESOME!" + Environment.NewLine + "Press Enter to Continue");
            }
            //TE.setSentence("CORRECT! Off to a great start! Press enter to continue.");
        }
        else
        {

            // scoreText.text = "Score: " +  Convert.ToString(score) + "/4";
            // StartCoroutine(ChangeColor1());
            if (wrongRando == 1)
            {
                TE.setSentence("Correct answer: " + Math.Round(angularAccelerationRod, 2) + " m. Sorry bud, try again next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 2)
            {
                TE.setSentence("Correct answer: " + Math.Round(angularAccelerationRod, 2) + " m. I'm afarid that's not quite right. You'll get it next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 3)
            {
                TE.setSentence("Correct answer: " + Math.Round(angularAccelerationRod, 2) + " m. I’m afraid you’re mistaken. But don't lose hope!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 4)
            {
                TE.setSentence("Correct answer: " + Math.Round(angularAccelerationRod, 2) + " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 5)
            {
                TE.setSentence("Correct answer: " + Math.Round(angularAccelerationRod, 2) + " m. Sorry pal, we all make mistakes here and there! Don't give up!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 6)
            {
                TE.setSentence("Correct answer: " + Math.Round(angularAccelerationRod, 2) + " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("Incorrect. Correct answer: " + Math.Round(angularAccelerationRod, 2) + " m. But that's okay, you've got this! Press enter to continue.");
            }
            // TE.setSentence("Incorrect. Correct answer: "+Math.Round(VMaxHeight, 2)+" m. But that's okay, you've got this! Press enter to continue.");
        }
    }

    void Stage3()
    {
        // Fade Checker, if already on, turn off
        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        SetImage2();
        TE.setSentence("Now find the the acceleration at point B immediately after impact! Remember that the hanging rod of mass is " + objectMass + " kg" + " with a Length of " + RodLength + " m " + "The force was " + forceF + " N.");
    }
    void Stage4()   // Q2C?
    {
        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        if (Q2C)
        {
            //  TE.setSentence("CORRECT! Nice job! Press enter to continue.");
            if (rando1 == 1)
            {
                TE.setSentence(" THAT WAS CORRECT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando1 == 2)
            {
                TE.setSentence("GREAT JOB!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando1 == 3)
            {
                TE.setSentence("AMAZING!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando1 == 4)
            {
                TE.setSentence("YES! THAT'S IT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando1 == 5)
            {
                TE.setSentence("CONGRATS!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando1 == 6)
            {
                TE.setSentence("KEEP IT UP!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("AWESOME!" + Environment.NewLine + "Press Enter to Continue");
            }
        }
        else
        {
            if (wrongRando1 == 1)
            {
                TE.setSentence("Correct answer: " + Math.Round(accelerationPointB, 2) + " m. Sorry bud, try again next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando1 == 2)
            {
                TE.setSentence("Correct answer: " + Math.Round(accelerationPointB, 2) + " m. I'm afarid that's not quite right. You'll get it next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando1 == 3)
            {
                TE.setSentence("Correct answer: " + Math.Round(accelerationPointB, 2) + " m. I’m afraid you’re mistaken. But don't lose hope!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando1 == 4)
            {
                TE.setSentence("Correct answer: " + Math.Round(accelerationPointB, 2) + " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando1 == 5)
            {
                TE.setSentence("Correct answer: " + Math.Round(accelerationPointB, 2) + " m. Sorry pal, we all make mistakes here and there! Don't give up!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando1 == 6)
            {
                TE.setSentence("Correct answer: " + Math.Round(accelerationPointB, 2) + " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("Incorrect. Correct answer: " + Math.Round(accelerationPointB, 2) + " m. But that's okay, you've got this! Press enter to continue.");
            }
            //TE. setSentence("Incorrect. Correct answer: " +Math.Round(range,2) +" m. But that's okay, keep trying! Press enter to continue.");
        }
    }
    void Stage5()   // Asks the third question (Find time)
    {
        // Fade Checker, if already on, turn off
        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        // PF.resetAlpha();
        SetImage3();
        TE.setSentence("Next up is to find the reaction Ax at Point A! Remember that the hanging rod of mass is " + objectMass + " kg" + " with a Length of " + RodLength + " m " + "The force was " + forceF + " N.");
    }
    void Stage6()   //Q3C?
    {
        // Fade Checker, if already on, turn off
        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        if (Q3C)
        {
            //TE.setSentence("CORRECT! Way to go! Press enter to continue.");
            if (rando2 == 1)
            {
                TE.setSentence(" THAT WAS CORRECT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando2 == 2)
            {
                TE.setSentence("GREAT JOB!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando2 == 3)
            {
                TE.setSentence("AMAZING!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando2 == 4)
            {
                TE.setSentence("YES! THAT'S IT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando2 == 5)
            {
                TE.setSentence("CONGRATS!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando2 == 6)
            {
                TE.setSentence("KEEP IT UP!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("AWESOME!" + Environment.NewLine + "Press Enter to Continue");
            }
        }
        else
        {
            if (wrongRando2 == 1)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAx, 2) + " m. Sorry bud, try again next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando2 == 2)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAx, 2) + " m. I'm afarid that's not quite right. You'll get it next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando2 == 3)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAx, 2) + " m. I’m afraid you’re mistaken. But don't lose hope!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando2 == 4)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAx, 2) + " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando2 == 5)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAx, 2) + " m. Sorry pal, we all make mistakes here and there! Don't give up!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando2 == 6)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAx, 2) + " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("Incorrect. Correct answer: " + Math.Round(reactionAx, 2) + " m. But that's okay, you've got this! Press enter to continue.");
            }
            //TE.setSentence("Incorrect. Correct answer: " + Math.Round(deltaTime,2)+" s. Don't fret! Please, keep trying! Press enter to continue.");
        }
    }
    void Stage7()   // Asks the fourth question (Find max height)
    {
        // Fade Checker, if already on, turn off
        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        SetImage4();
        //PF.resetAlpha();
        TE.setSentence("Last but not least, find the reaction Ay at Point A! Remember that the hanging rod of mass is " + objectMass + " kg" + " with a Length of " + RodLength + " m " + "The force was " + forceF + " N.");
    }
    void Stage8()   // Q4C?
    {
        // Fade Checker, if already on, turn off
        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();

        if (Q4C)
        {
            //TE.setSentence("CORRECT! You are awesome! Press enter to continue.");
            if (rando3 == 1)
            {
                TE.setSentence(" THAT WAS CORRECT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando3 == 2)
            {
                TE.setSentence("GREAT JOB!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando3 == 3)
            {
                TE.setSentence("AMAZING!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando3 == 4)
            {
                TE.setSentence("YES! THAT'S IT!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando3 == 5)
            {
                TE.setSentence("CONGRATS!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (rando3 == 6)
            {
                TE.setSentence("KEEP IT UP!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("AWESOME!" + Environment.NewLine + "Press Enter to Continue");
            }
        }
        else
        {
            if (wrongRando3 == 1)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAy, 2) + " m. Sorry bud, try again next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando3 == 2)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAy, 2) + " m. I'm afarid that's not quite right. You'll get it next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando3 == 3)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAy, 2) + " m. I’m afraid you’re mistaken. But don't lose hope!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando3 == 4)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAy, 2) + " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando3 == 5)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAy, 2) + " m. Sorry pal, we all make mistakes here and there! Don't give up!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando3 == 6)
            {
                TE.setSentence("Correct answer: " + Math.Round(reactionAy, 2) + " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("Incorrect. Correct answer: " + Math.Round(reactionAy, 2) + " m. But that's okay, you've got this! Press enter to continue.");
            }
            //TE. setSentence("Incorrect. Correct answer: " +Math.Round(maxHeight,2) +" m. Press enter to continue.");
        }
    }
    void Stage9()
    {
        // Fade Checker, if already on, turn off
        if (PF.mFaded == false)
        {
            PF.Fade();
        }
        //PF.resetAlpha();
        if (Q1C && Q2C && Q3C && Q4C)    // All Correct
        {
            MC.pauseSong();
            VS.playRandom();
            //ballObject.on = true;
            TE.setSentence("FANTASTIC! You got everything correct! Press enter to keep practicing");
        }
        else if (!Q1C && Q2C && Q3C && Q4C)  // All but Q1 correct  
        {
            TE.setSentence("Almost! You only got question 1 wrong. Remember- angular acceleration is 3 times the force applied, then divided by the object's mass and the rod's length. Press enter to try again");
        }
        else if (Q1C && !Q2C && Q3C && Q4C)  // All but Q2 correct
        {
            TE.setSentence("Almost! You only got question 2 wrong. Refer to the angular acceleration formula, just tweak the denominator a little bit. Press enter to try again");
        }
        else if (Q1C && Q2C && !Q3C && Q4C) // All but Q3 correct
        {
            TE.setSentence("Almost! You only got question 3 wrong. Make sure you know what acceleration formula to use for that question. Press enter to try again");
        }
        else if (Q1C && Q2C && Q3C && !Q4C)  // All but Q4 correct
        {
            TE.setSentence("Almost! You only got question 4 wrong. The only thing you need to work on is using the formula for Weight since that's essentially reaction Ay . Press enter to try again");
        }
        else if (!Q1C && !Q2C && Q3C && Q4C) // Q1 and Q2 incorrect
        {
            TE.setSentence("Good try! You only got the questions about angular acceleration of the rod and the acceleration at Point B. Check your calculations and press enter to try again.");
        }
        else if (!Q1C && Q2C && !Q3C && Q4C)    // Q1 and Q3 incorrect
        {
            TE.setSentence("Good try! You only the questions about angular acceleration of the rod and reaction Ax. Check your calculations and press enter to try again.");
        }
        else if (!Q1C && Q2C && Q3C && !Q4C) // Q1 and Q4 incorrect
        {
            TE.setSentence("Good try! You only the questions about angular acceleration of the rod and reaction Ay. Check your calculations and press enter to try again.");
        }
        else if (Q1C && !Q2C && !Q3C && Q4C)   // Q2 and Q3 incorrect
        {
            TE.setSentence("Good try! You only got the acceleration at Point B and reaction Ax questions wrong. Check your calculations and press enter to try again.");
        }
        else if (Q1C && !Q2C && !Q3C && !Q4C)   // only Q1 correct
        {
            TE.setSentence("Good try! You got the angular acceleration question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if (!Q1C && Q2C && !Q3C && !Q4C)   // only Q2 correct
        {
            TE.setSentence("Good try! You got the acceleration at Point B question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if (!Q1C && !Q2C && Q3C && !Q4C)   // only Q3 correct
        {
            TE.setSentence("Good try! You got the reaction Ax question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if (!Q1C && !Q2C && !Q3C && Q4C)   // only Q4 correct
        {
            TE.setSentence("Good try! You got the reaction Ay question correct, but not the others. Review the formulas, check your calculations, and press enter to try again.");
        }
        else if (!Q1C && !Q2C && !Q3C && !Q4C)   // all wrong
        {
            TE.setSentence("Oh no! You didn't get any correct, but that's okay. Please review the angular acceleration and collision formulas again! Press enter to try again. You can do this!");
        }
    }
    // Activates upon user input. Concludes the current stage that the variable is set to
    void changeStage()
    {
        Debug.Log("changeStage() activated");
        if (stage == 0)  // Stage 0: Before game initially starts
        {
            Stage1();
        }
        if (stage == 1)  // Stage 1: Question 1
        {   //SetImage1(); 
            answer = getAnswer();
            if (answer >= angularAccelerationRod * 0.98 && answer <= angularAccelerationRod * 1.02)
            {
                Q1C = true;
                playEffects();
                CS.playAudio();
                score += score + 1;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor());
            }
            else
            {
                Q1C = false;
                IS.playAudio();
                score += 0;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor1());
            }


            Stage2();
        }
        else if (stage == 2)
        {
            Stage3();
        }
        else if (stage == 3) // Stage 2: Question 2
        {
            // SetImage2();
            answer = getAnswer();
            if (answer >= (accelerationPointB * 0.98) && answer <= (accelerationPointB * 1.02))
            {
                Q2C = true;
                playEffects();
                CS.playAudio();
                score = score + 1;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor());
            }
            else
            {
                Q2C = false;
                IS.playAudio();
                score += 0;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor1());
            }


            Stage4();
        }
        else if (stage == 4)
        {
            Stage5();
        }
        else if (stage == 5) // Stage 3: Question 3
        {
            // SetImage3();
            answer = getAnswer();
            if (answer >= (reactionAx * 0.98) && answer <= (reactionAx * 1.02))
            {
                Q3C = true;
                playEffects();
                CS.playAudio();
                score = score + 1;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor());
            }
            else
            {
                Q3C = false;
                IS.playAudio();
                score += 0;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor1());
            }


            Stage6();
        }
        else if (stage == 6)
        {
            Stage7();
        }
        else if (stage == 7)     // Stage 4: Question 4
        {
            // SetImage4();
            answer = getAnswer();
            if (answer >= (reactionAy * 0.98) && answer <= (reactionAy * 1.02))
            {
                Q4C = true;
                playEffects();
                CS.playAudio();
                score = score + 1;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor());
            }
            else
            {
                Q4C = false;
                IS.playAudio();
                score += 0;
                scoreText.text = "Score: " + Convert.ToString(score) + "/4";
                StartCoroutine(ChangeColor1());
            }

            Stage8();
        }
        else if (stage == 8)
        {
            Stage9();
        }
        else if (stage == 9) // Stage 5: Post game. Shows results
        {

            stage = 0;
            MC.unpauseSong();

            rando = UnityEngine.Random.Range(1, 8);
            rando1 = UnityEngine.Random.Range(1, 8);
            rando2 = UnityEngine.Random.Range(1, 8);
            rando3 = UnityEngine.Random.Range(1, 8);
            wrongRando = UnityEngine.Random.Range(1, 8);
            wrongRando1 = UnityEngine.Random.Range(1, 8);
            wrongRando2 = UnityEngine.Random.Range(1, 8);
            wrongRando3 = UnityEngine.Random.Range(1, 8);
            PushF.resetPosition();

            Stage1();
            score = 0;
            scoreText.text = "Score: " + Convert.ToString(score) + "/4";
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
