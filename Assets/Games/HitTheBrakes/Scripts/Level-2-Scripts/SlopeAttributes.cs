using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SlopeAttributes : MonoBehaviour
{
    public RandomNumberGenerator randomValues;
    public PhysicsMaterial2D ground;
    public TMP_Text frictionText;
    public const int SCALE = 3;
    public Transform spawn;
    public Transform end;
    public Transform text;
    public GameObject slope;

    // Start is called before the first frame update
    public void SetSlope()
    {
        // generate new random numbers
        randomValues.Generate();
        // make sure fontsize does not scale
        //frictionText.fontSize /= randomValues.getDistance() * SCALE;
        // tell user friction value
        frictionText.text = "Friction - " + Math.Round(randomValues.getMU(), 2);
        // set friction of ground
        ground.friction = randomValues.getMU();

        // increase the size of slope platform
        transform.localScale = new Vector3(randomValues.getDistance() * SCALE, 10, 0);
        float offset = spawn.position.x - end.position.x;
        transform.localScale = new Vector3(randomValues.getDistance() * SCALE + offset, 10, 0);

        // rotate platform based on theta
        transform.rotation = Quaternion.Euler(0, 0, -randomValues.getTheta());
        text.position = spawn.position - new Vector3(0, 1.5f, 0);
        text.rotation = Quaternion.Euler(0, 0, -randomValues.getTheta());
        // put car at spawn
        FindObjectOfType<CarMechanics>().setCar();
        // place catching platform
        FindObjectOfType<PlatformPosition>().setPlatform();
    }
}
