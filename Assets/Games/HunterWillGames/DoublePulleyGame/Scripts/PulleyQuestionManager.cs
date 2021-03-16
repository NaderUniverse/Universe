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

    //float
    //distance is between 0.25m - 2.0m for part 2)xA,xB is distance traveled 
    public float t, distance, acceleration, xB,xA;//t is inbetween 1.0 - 3.0, for part 3) needs to be inbetween 2.0 - 3.0 could use two variables for this
    private float tmp, VB, VA;
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
        // if enter button is pressed enter question
        if (Input.GetButtonDown("Submit"))
        {
            EnterAnswer();
        }
        Math();
    }
    void Math()
    {
        //first question
        tmp = (2 * xB) / t;
        VB = tmp;
        VA = -VB / 2;
        //Debug.Log("answer" + VB+ "VA == " + VA );
        //Second question
        tmp = (2 * xB) / (t * t);
        acceleration = tmp;
        //Debug.Log(" acceleration" + acceleration);
        //Third question

    }
    void DisplayQuestion()
    {

    }
    void EnterAnswer()
    {
        VB.ToString(answer);
       
        Debug.Log(VB);
        Debug.Log(uInput.text);
        if (uInput.text == answer)
        {
            Debug.Log("Congrats :)");
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
