using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : Weapons {

    public Transform shotSpawn;
    Animator an;
    AudioSource ad;
    public AudioClip clip01;
    public AudioClip clip02;
    public AudioClip clip03;
    

    public Text ammoText;

    void Awake()
    {
        ad = GetComponent<AudioSource>();
        an = GetComponent<Animator>();
        ammoLeft = ammoAmount;
        ammoClipLeft = ammoClipSize;
    }

    // Use this for initialization
    void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {

        ammoText.text = ammoClipLeft + " / " + ammoLeft;

        if (Input.GetButton("Fire1") && Time.time > nextFire && isReloading == false && ammoClipLeft > 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation );
            ammoClipLeft--;
            ad.PlayOneShot(clip01);
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
        if (ammoClipLeft == ammoClipSize)
        {

        }
        else if (ammoLeft >= bulletsToReload)
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
            if (Input.GetMouseButtonDown(0))
            {
                ad.PlayOneShot(clip03);
            }

        }
    }

    IEnumerator ReloadWeapon()
    {
        isReloading = true;
        ad.PlayOneShot(clip02);
        yield return new WaitForSeconds(2);
        isReloading = false;
    }


}
