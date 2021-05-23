using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
  public Rigidbody2D cueBall;
  public Rigidbody2D eightBall;
  public GameObject cue;

  public GameObject ball;
  public Animator _anim;
  public SpriteRenderer eball;
  public SpriteRenderer cball;

  Vector3 originalPos2;
  Vector3 originalPos1;

  private float forceConstant = -5000;
  public bool cueFlag = false;

  public void OnCollisionEnter2D(Collision2D other)
  {
      if (other.collider.tag == "Hole")
      {
        Debug.Log("trigger fade out");
        StartCoroutine(FadeEightBall());
      }

      if (other.collider.tag == "CueHole")
      {
        Debug.Log("trigger fade out");
        StartCoroutine(FadeCueBall());
      }
  }

  IEnumerator FadeCueBall()
  {
      cueBall.velocity = Vector2.zero;
      _anim.SetTrigger("StartFade");
      yield return new WaitForSeconds(.4f);
      cball.enabled = false;
  }

  IEnumerator FadeEightBall()
  {
      eightBall.velocity = Vector2.zero;
      _anim.SetTrigger("StartFade");
      yield return new WaitForSeconds(.9f);
      eball.enabled = false;
  }

  public void setVelocities()
  {
      cueBall.AddForce(transform.right * forceConstant);
      eightBall.AddForce(-transform.up * forceConstant);
  }

  void Start()
  {
    // If the balls are to be restarted in the same position, save the position at the start
    originalPos1 = new Vector3(cueBall.transform.position.x, cueBall.transform.position.y,
                              cueBall.transform.position.z);
    originalPos2 = new Vector3(eightBall.transform.position.x,eightBall.transform.position.y,
                              eightBall.transform.position.z);
  }

  public void restartMovement()
  {
      eball.enabled = true;
      cball.enabled = true;
      cueBall.velocity = Vector2.zero;
      eightBall.velocity = Vector2.zero;
      cueBall.angularVelocity = 0f;
      eightBall.angularVelocity = 0f;

      // Feel free to edit the next position of the balls when the question is restarted
      cueBall.transform.position = new Vector3(-22f, 37f, -4.26f);
      eightBall.transform.position = new Vector3(-5.9f, 21.8f, -4.26f);;

  }

  public void moveCue()
  {
    if (!cueFlag)
      cue.transform.position = new Vector3(originalPos2.x, originalPos2.y + -Mathf.PingPong(Time.time * 100, 50), originalPos2.z);
  }
}
