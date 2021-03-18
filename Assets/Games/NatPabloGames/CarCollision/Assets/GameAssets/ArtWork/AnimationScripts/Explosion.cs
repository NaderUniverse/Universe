using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
  public Image explosion;
  public static bool explosionOn;
  public Text message;
  public Text messageShadow;
  public AudioSource crash;
  public static bool activated = false;
  public carMotion car;

    // Start is called before the first frame update
    public void hideExplosion()
    {
      explosion.enabled = false;
      explosionOn = false;
      message.text = "";
      messageShadow.text = "";
    }

    // Update is called once per frame
    public void showExplosion()
    {
      Vector3 position = car.transform.position;
      position.x += 80.26f;
      explosion.transform.position = position;
      explosion.enabled = true;
      explosionOn = true;
      message.text = "BANG!";
      messageShadow.text = "BANG!";
      crash.Play();
      activated = true;
    }

    void Start()
    {
      hideExplosion();
    }

    void Update()
    {
      if (explosionOn == true && activated == false)
      {
        StartCoroutine(Wait());
      }
    }

    IEnumerator Wait()
    {
      showExplosion();
      yield return new WaitForSeconds(0.75f);   //Wait
      hideExplosion();
    }
}
