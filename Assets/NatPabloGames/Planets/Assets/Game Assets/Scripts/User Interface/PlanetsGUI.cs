using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class PlanetsGUI : MonoBehaviour
{
    private const int incorrect = 2;
    private const int correct = 1;

    public int stage = 0;
    public int randoMass = 0;
    public int randoVelocity = 0;
    public int randoDist = 0;
    public int randoAcceleration = 0;
    public int correctAns = 0;
    public int displayFireworks = 0;
    //public Rect buttonRect = new Rect(10, 10, 100, 50);
    //public Rect labelRect = new Rect(5, 225, 5, 5);
    public GUIStyle style;
    public string answerText = "0";
    public float actualAnswer = 0;
    public float KE = 1;
    public TextMeshProUGUI [] TextUI;
    public TextMeshProUGUI textBody;
    public TextMeshProUGUI congrats;
    bool flag = false;
    public SoundManager claps;
    public TMP_InputField user_ans;
    public int start = 0;
    public VisualEffect fireworks;
    //public ParticleSystem particleSystem;
    //public Button submitButton;
    // public Canvas quest;
    [SerializeField] private Canvas QuestCanvas;
    //public Button submitButton;


    // new
    public PlanetDialogue dialogue1;
    public PlanetDialogue mainDialogue;

    // Start is called before the first frame update
    public void Start()
    {
        randoMass = UnityEngine.Random.Range(200, 400);
        randoVelocity = UnityEngine.Random.Range(15000, 25000);
        randoDist = UnityEngine.Random.Range(6000, 7000);
        randoAcceleration = UnityEngine.Random.Range(4, 5);

        // Styling
        style.normal.textColor = Color.white;
        style.fontSize = 15;

        KE = (float)(0.5 * randoMass * Math.Pow((randoVelocity * ((float)1000/3600)), 2) / Math.Pow(10, 9));
        Debug.Log(KE);

        TextUI = FindObjectsOfType<TextMeshProUGUI>();

        //dialogue1 = GetComponent<Dialogue>();
        //dialogue1 = new Dialogue();
        //dialogue1 = gameObject.GetComponent("Correct Msj") as Dialogue;
        //if (dialogue1 == null)
        //Debug.Log("u o");

        //mainDialogue = gameObject.GetComponent("Quest") as Dialogue;
        //mainDialogue = new Dialogue();
        //mainDialogue = GameObject.Find("Quest").GetComponent<Dialogue>();

        // for (int i = 0; i < TextUI.Length; i++)
        //     Debug.Log("TMP Object name: " + TextUI[i].name + " index" + i);

        // Note: index for the body of the question is 0.
        textBody = TextUI[0];

        stage = 1;
        fireworks.Stop();
        //dialogue1.showInput = false;
    }

    // Update is called once per frame
    void Update()
    {
      // Button btn = submitButton.GetComponent<Button>();
      // btn.onClick.AddListener(stageUpdate());
      if (Input.GetKeyDown(KeyCode.Return) && !mainDialogue.showInput)
      {
          flag = false;
          answerText = user_ans.GetComponent<TMP_InputField>().text;
          actualAnswer = Convert.ToSingle(answerText);
          stage++;

          if((actualAnswer > (KE * 0.98)) && (actualAnswer < (KE * 1.02)))
          {
            displayFireworks = 1;
            correctAns = 1;
          }
      }

      if (stage == 1)
      {
        if (!flag)
          StartCoroutine(changeText());
      }

      if (stage == 2)
      {
        if (!flag)
          StartCoroutine(changeText());
      }


      if (stage == 3 && !dialogue1.showInput)
      {
          // If the user pressed enter, stop the fireworks for the next question.
          if (displayFireworks == 1)
            fireworks.Stop();

          dialogue1.setSentence(" ");
          stage = 1;
          correctAns = 0;
          displayFireworks = 0;

          randoMass = UnityEngine.Random.Range(200, 400);
          randoVelocity = UnityEngine.Random.Range(15000, 25000);
          randoDist = UnityEngine.Random.Range(6000, 7000);
          randoAcceleration = UnityEngine.Random.Range(4, 5);

          KE = (float)(0.5 * randoMass * Math.Pow((randoVelocity * ((float)1000/3600)), 2) / Math.Pow(10, 9));
          Debug.Log(KE);
      }
    }

    IEnumerator changeText()
    {
      // Keep track whether we entered this state before.
      flag = true;

      if (stage == 1)
      {
        /*
          //dialogue.setSentence(GUI.Label(new Rect(10, 225, 5, 5), "A satellite is placed " + randoDist + " km above the surface of the Earth with the following information:\n\n\tMass:\t" + randoMass + " kg\n\tAcceleration of gravity:\t" + randoAcceleration + " m/(s^2)\n\tOrbital speed:\t" + randoVelocity + " km/h\n\nDetermine the kinetic energy of the satellite.\n(Answer below in Gigajoules)", style));
          textBody.text ="A satellite is placed " + randoDist + " km above the surface of the Earth with the following information:\n\n" +
                                "\tMass:\t\t\t\t" + randoMass + " kg\n" +
                                "\tAcceleration of gravity:\t\t" + randoAcceleration + " m/(s^2)\n" +
                                "\tOrbital speed:\t\t\t" + randoVelocity + " km/h\n\n" +
                                "Determine the kinetic energy of the satellite.\n(Answer below in Gigajoules)";
*/

        mainDialogue.setSentence("A satellite is placed " + randoDist + " km above the surface of the Earth with the following information:\n\n" +
                              "\tMass:\t\t\t\t" + randoMass + " kg\n" +
                              "\tAcceleration of gravity:\t\t" + randoAcceleration + " m/s<sup>2</sup>\n" +
                              "\tOrbital speed:\t\t\t" + randoVelocity + " km/h\n\n" +
                              "Determine the kinetic energy of the satellite.\n(Answer below in Gigajoules)");

      }

      if (stage == 2 && !mainDialogue.showInput)
      {
        if (correctAns == 1)
        {
          mainDialogue.setSentence("");
          displayFireworks = 1;
          fireworks.Play();
          SoundManager.confirm = 1;
          // GUI.Label(new Rect(10, 225, 5, 5), "That's the right answer, congrats!\nClick \"Go\" to generate a new question!", style);
          textBody.text = "That's the right answer, congrats!\nPress enter to generate a new question!";

          int rando = UnityEngine.Random.Range(1,8);

          if (rando == 1)
          {
            dialogue1.setSentence(" THAT WAS CORRECT!");
            SoundManager.typeClip = 11;
          }

          else if (rando == 2)
          {
            dialogue1.setSentence("GREAT JOB!");
            SoundManager.typeClip = 8;
          }

          else if (rando == 3)
          {
            dialogue1.setSentence("AMAZING!");
            SoundManager.typeClip = 6;
          }

          else if (rando == 4)
          {
            dialogue1.setSentence("YES! THAT'S IT!");
            SoundManager.typeClip = 10;
          }

          else if (rando == 5)
          {
            dialogue1.setSentence("CONGRATS!");
            SoundManager.typeClip = 11;
          }

          else if (rando == 6)
          {
            dialogue1.setSentence("KEEP IT UP!");
            SoundManager.typeClip = 9;
          }

          else
          {
            dialogue1.setSentence("AWESOME!");
            SoundManager.typeClip = 10;
          }

          Debug.Log("yes");
        }

        else
        {
          //SoundManager.confirm = 2;
          SoundManager.confirm = incorrect;
          // GUI.Label(new Rect(10, 225, 5, 5), "Sorry, that's incorrect. Click \"Go\" to generate a new question.", style);
          //textBody.text = "Sorry, that's incorrect.\nPress enter to generate a new question.";
          mainDialogue.setSentence("Sorry, that's incorrect.\nPress enter to generate a new question.");
          dialogue1.setSentence(" ");
          //Debug.Log("no");
        }

        if (dialogue1.showInput)
        {
          yield return new WaitForSeconds(4);
        }

        // Wait for the congrats message to stop typing before attempting to press enter.
        //while (!dialogue1.showInput)
        //{
        //  ;
        //}
      }

      yield return null;
    }
}
