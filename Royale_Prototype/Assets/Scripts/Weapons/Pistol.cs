using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapons {

    public Transform shotSpawn;

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
		
=======

	// Use this for initialization
	void Start () {
        
>>>>>>> parent of 763eb22... animation updates, weapons script update, particles, uzi
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
<<<<<<< HEAD
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
=======
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation );
>>>>>>> parent of 763eb22... animation updates, weapons script update, particles, uzi
        }
	}
}
