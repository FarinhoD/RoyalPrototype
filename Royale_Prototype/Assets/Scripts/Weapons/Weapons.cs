using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public GameObject projectile;

    public bool isProjectile;
    public bool isMelee;
    public bool isThrown;
    public bool isReloading;

    public int ammoAmount;
    public int ammoClipSize;
    public int ammoLeft;
    public int ammoClipLeft;

    public float damage;
    public float range;
    public float projectileSpeed;
    public float fireRate;
    public float nextFire;
    public float reloadTime;


}
