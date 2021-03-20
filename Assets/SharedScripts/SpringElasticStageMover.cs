using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpringElasticStageMover : MonoBehaviour
{
    // GameObjects
    public Dialogue TE;
    public GameObject inputBox;
    // public GameObject TargetBox;
    public TextMeshProUGUI textBody;
    //public TextMeshProUGUI SpringInfo;

    public MusicControl MC;
    public VictorySound VS;
    public CorrectSounds CS;
    public IncorrectSounds IS;
    public TextMeshProUGUI scoreText;

    // public VisualEffectsManager VEB;
    //public Target targetObject;



    //Spring Question Components:
    public float originalLength;
    public float springConstant;
    public float extendedLengthPointA;
    public float objectMass;
    public float extendedLengthPointB;
    public float finalSpeed;
    public float xSubA;
    public float xSubB;
    public float heightSpring;
    public float PotentialEnergy;
    public float ElasticPotentialEnergy;


    public int stage;
    public int score = 0;

    // Answers
    public float answer;
    public bool Q1C = false;


    //Random Numbers for Variation
    public int rando;

    public int wrongRando;

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

        originalLength = UnityEngine.Random.Range(0.25f, 0.40f);
        originalLength = Mathf.Round(originalLength * 100.0f) * 0.01f;

        springConstant = UnityEngine.Random.Range(1f, 5f);
        springConstant = Mathf.Round(springConstant * 100.0f) * 0.01f;

        extendedLengthPointA = UnityEngine.Random.Range(0.5f, 0.75f);
        extendedLengthPointA = Mathf.Round(extendedLengthPointA * 100.0f) * 0.01f;

        objectMass = UnityEngine.Random.Range(0.25f, 1.0f);
        objectMass = Mathf.Round(objectMass * 100.0f) * 0.01f;

        extendedLengthPointB = UnityEngine.Random.Range(0.40f, 0.55f);
        extendedLengthPointB = Mathf.Round(extendedLengthPointB * 100.0f) * 0.01f;

        xSubA = extendedLengthPointA - originalLength;
        xSubB = extendedLengthPointB - originalLength;
        heightSpring = 1;
        PotentialEnergy = (float)(objectMass * 9.81 * heightSpring);
        ElasticPotentialEnergy = (float)0.5 * springConstant * ((xSubA * xSubA) - (xSubB * xSubB));


        finalSpeed = Mathf.Sqrt((2 * objectMass) * (PotentialEnergy + ElasticPotentialEnergy));



        TE.setSentence("A spring with an original length " + originalLength + "m" + " and spring constant k= " + springConstant + "kN/m is in its extended position with the mass at position A with an extended length of " + extendedLengthPointA + "m." + " If the collar has mass of " + objectMass + "kg, what is the speed of the collar just before reaching position B, given that the extended spring length at position B is " + extendedLengthPointB + "m.");

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
                TE.setSentence("Correct answer: " + Math.Round(finalSpeed, 2) + " m. Sorry bud, try again next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 2)
            {
                TE.setSentence("Correct answer: " + Math.Round(finalSpeed, 2) + " m. I'm afraid that's not quite right. You'll get it next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 3)
            {
                TE.setSentence("Correct answer: " + Math.Round(finalSpeed, 2) + " m. I’m afraid you’re mistaken. But don't lose hope!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 4)
            {
                TE.setSentence("Correct answer: " + Math.Round(finalSpeed, 2) + " m. Darn, you must've made a small mistake somewhere! Check and see if you can find out what it was!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 5)
            {
                TE.setSentence("Correct answer: " + Math.Round(finalSpeed, 2) + " m. Sorry pal, we all make mistakes here and there! Don't give up!" + Environment.NewLine + "Press Enter to Continue");
            }

            else if (wrongRando == 6)
            {
                TE.setSentence("Correct answer: " + Math.Round(finalSpeed, 2) + " m. You may've made a calculation error, but I have complete faith in your ability to figure it out next time!" + Environment.NewLine + "Press Enter to Continue");
            }

            else
            {
                TE.setSentence("Incorrect. Correct answer: " + Math.Round(finalSpeed, 2) + " m. But that's okay, you've got this! Press enter to continue.");
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
        if (Q1C)    // All Correct
        {
            MC.pauseSong();
            VS.playRandom();

            TE.setSentence("FANTASTIC! You got everything correct! Press ENTER to keep practicing!");
        }
        else if (!Q1C)  // Q1 was wrong 
        {
            TE.setSentence("Almost! You only got question 1 wrong.  Press ENTER to try again");
        }

    }

    // Activates upon user input. Concludes the current stage that the variable is set to
    void changeStage()
    {
        Debug.Log("changeStage() activated");
        if (stage == 0)  // Stage 0: Before game initially starts
        {
            randFX = UnityEngine.Random.Range(0, 3);
            Stage1();
        }
        if (stage == 1)  // Stage 1: Question 1
        {   //SetImage1(); 
            answer = getAnswer();
            if (answer >= finalSpeed * 0.98 && answer <= finalSpeed * 1.02)
            {
                Q1C = true;
                playEffects();
                CS.playAudio();
                score += score + 1;
                scoreText.text = "Score: " + Convert.ToString(score) + "/1";
                StartCoroutine(ChangeColor());
            }
            else
            {
                Q1C = false;
                IS.playAudio();
                score += 0;
                scoreText.text = "Score: " + Convert.ToString(score) + "/1";
                StartCoroutine(ChangeColor1());
            }


            Stage2();
        }
        else if (stage == 2)
        {
            Stage3();
        }


        else if (stage == 3) // Stage 3: Post game. Shows results
        {

            stage = 0;
            MC.unpauseSong();
            rando = UnityEngine.Random.Range(1, 8);

            wrongRando = UnityEngine.Random.Range(1, 8);


            Stage1();
            randFX = UnityEngine.Random.Range(0, 3);
            score = 0;
            scoreText.text = "Score: " + Convert.ToString(score) + "/1";
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
