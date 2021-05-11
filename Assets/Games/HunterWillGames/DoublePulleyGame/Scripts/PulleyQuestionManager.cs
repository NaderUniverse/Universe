using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using System;

//Question 1 Calculate final velocity of A and B after t = 1.0 - 3.0
public class PulleyQuestionManager : MonoBehaviour
{
    //TmpPro




    //Declarations
    //Int
    public int a, b;//A needs to be between 2-4 and B needs to be inbetween 5-7
    public int Score = 0;
    public int questionPart = 1;
    //float
    //distance is between 0.25m - 2.0m for part 2)xA,xB is distance traveled 
    public float t, distance, acceleration, xB,xA;//t is inbetween 1.0 - 3.0, for part 3) needs to be inbetween 2.0 - 3.0 could use two variables for this
    public float tmp, VB, VA, DTA;//DTA stands for distance traveled for A
    //Text/strings
    public TMP_Text input, output;
    public string question;
    private string answer;
    public TMP_InputField uInput;
    // Start is called before the first frame update
    void Start()
    {
        DisplayQuestion();

        t = Random.Range(1, 3);
        a = Random.Range(2, 4);
        b = Random.Range(5,7);
        xB = Random.Range((float)0.25, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Math();
        // if enter button is pressed enter question
        if (Input.GetButtonDown("Submit"))
        {   
            EnterAnswer();
        }
        if(questionPart == 3)
        {
            //if we are on the third question part we change the time between 2 to 3 seconds
            t = Random.Range(2, 3);
           
        }
    }
    void Math()
    {
        //first question
        tmp = (2 * xB) / t;
        VB = tmp;
        VA = -VB / 2;
        
        //Second question
        tmp = (2 * xB) / (t * t);
        acceleration = tmp;

        //Third question
        
        DTA = (float)(0.5 * acceleration * (t * t));
    }
    void DisplayQuestion()
    {
        string question = "";
        string question1 = "";

        question = "The king has been kidnapped and is being held hostage by an evil wizard, to save him.\n "
            + "you will have to answer 3 questions on double \n pulleys are you up for the task? ";

        question1 = "The Kings pulley system is released from rest, given that the king on the right weighs %d " +
            "and the king on the left weighs %d. Find the final velocity of the kings after %." +
            "1f seconds after releasing the system from rest.";
        if (Input.GetButtonDown("Submit"))
        {
            if(questionPart == 1)
            {
                StartCoroutine(TypeQuestion(question1));
            }
            
        }
        StartCoroutine(TypeQuestion(question));

    }
    void EnterAnswer()
    {
        string question1 = "";

        question1 = "The Kings pulley system is released from rest, given that the king on the right weighs \n " +
            "and the king on the left weighs \n " + a + " Find the final velocity of the kings after \n" + t
            +"seconds after releasing the system from rest.";
                 if (questionPart == 1)
                {
                    StartCoroutine(TypeQuestion(question1));
                }
        switch (questionPart)
        {
            case 1:
             
                if (uInput.text.Equals(VB.ToString()))
                  {
                   // output.text = "Congrats, you have solved my first question can you solve the second one though let us find out.";
                    questionPart++;
                  }
                  else
                  {
                   //output.text = "Try again maybe they should have sent someone else to save the king.";
                }
               break;
            case 2:
                if (uInput.text.Equals(acceleration.ToString()))
                {
                    output.text = "Wow, you really know your stuff on to the last and hardest of my questions.";
                    questionPart++;
                }
                else
                {
                    output.text = "Wrong!";
                }
                break;
            case 3:
                if (uInput.text.Equals(DTA.ToString()))
                {
                    output.text = "You have defeated me the king is yours; I greatly underestimated your knowledge in double pulleys.";
                }
                else
                {

                    output.text = "Wrong!";
                }
                break;


        }
                
    }
    void StopAnimations()
    {

        //stops all coroutines
        StopAllCoroutines();


    }
    void StartCorrectAnimations()
    {

    }
    void StartWrongAnimations()
    {

    }
    IEnumerator TypeQuestion(string question)
    {
        
        // create the empty text
        output.text = "";
        // for each letter in question
        foreach (char letter in question.ToCharArray())
        {
            //display one letter at a time
            output.text += letter;

            // wait 0.05 seconds between letters added
            yield return new WaitForSeconds(0.05f);
        }
       
    }//end of TypeQuestion
}
