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
    public Text input, output;
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

    }
    void EnterAnswer()
    {
        switch(questionPart)
        {
            case 1:
                  if (uInput.text.Equals(VB.ToString()))
                  {
                  Debug.Log("Congrats :)");
                    questionPart++;
                  }
                  else
                  {
                    Debug.Log("sorry try again");
                  }
               break;
            case 2:
                if (uInput.text.Equals(acceleration.ToString()))
                {
                    Debug.Log("Congrats :), you have completed 2/3 parts for this question");
                    questionPart++;
                }
                else
                {
                    Debug.Log("sorry try again");
                }
                break;
            case 3:
                if (uInput.text.Equals(DTA.ToString()))
                {
                    Debug.Log("Congrats :), you have gotten all of the parts to this question correct");
                }
                else
                {

                    Debug.Log("sorry try again");
                }
                break;


        }
                
    }
    void StopAnimations()
    {

    }
    void StartCorrectAnimations()
    {

    }
    void StartWrongAnimations()
    {

    }
  //  IEnumerator TypeQuestion(string question)
  //  {

   // }
}
