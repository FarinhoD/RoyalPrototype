using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : Weapons {

    public Transform shotSpawn;
    Animator an;

    public Text ammoText;

    void Awake()
    {
        //source = GetComponent<AudioSource>();
        ammoLeft = ammoAmount;
        ammoClipLeft = ammoClipSize;
    }

    // Use this for initialization
    void Start () {
        an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        ammoText.text = ammoClipLeft + " / " + ammoLeft;

        if (Input.GetButton("Fire1") && Time.time > nextFire && isReloading == false && ammoClipLeft > 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation );
            ammoClipLeft--;
            an.SetBool("isShooting", true);
            if (ammoClipLeft == 0)
            {
                an.SetBool("isShooting", false);
            }
        }
        else if (ammoClipLeft <= 0 && isReloading == false)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            Reload();
        }

        if (Input.GetMouseButtonUp(0))
        {
            an.SetBool("isShooting", false);
        }

	}

    void Reload()
    {
        int bulletsToReload = ammoClipSize - ammoClipLeft;
        if (ammoLeft >= bulletsToReload)
        {
            StartCoroutine("ReloadWeapon");
            ammoLeft -= bulletsToReload;
            ammoClipLeft = ammoClipSize;
        }
        else if (ammoLeft < bulletsToReload && ammoLeft > 0)
        {
            StartCoroutine("ReloadWeapon");
            ammoClipLeft += ammoLeft;
            ammoLeft = 0;
        }
        else if (ammoLeft <= 0)
        {
            //source.PlayOneShot(emptyGunSound);
        }
    }

    IEnumerator ReloadWeapon()
    {
        isReloading = true;
        //source.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(2);
        isReloading = false;
    }


}
