using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapons {

    public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
        }
	}
}
