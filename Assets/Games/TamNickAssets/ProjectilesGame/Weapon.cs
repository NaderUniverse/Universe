using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    // public Transform firePoint;
    // public GameObject bulletPrefab;

    public KeyCode shootKey = KeyCode.F;
    public GameObject projectile;
    public float shootForce;

    // Update is called once per frame
    void Update () {
        /*if(Input.GetKeyDown("left shift"));
        {
            Shoot();
        } */
     /*   float projectileAngle = FindObjectOfType<PlayerAnimation>().getDirection();
        

        if (Input.GetKeyDown (shootKey)) {
            GameObject shot = GameObject.Instantiate (projectile, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180 + projectileAngle)));
            shot.GetComponent<Rigidbody2D> ().AddForce (transform.forward * shootForce);
        }

    } */

    /* void Shoot(){
Instantiate(bulletPrefab, firePoint.position,firePoint.rotation );
    } */
}}