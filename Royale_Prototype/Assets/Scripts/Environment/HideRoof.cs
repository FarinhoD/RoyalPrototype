using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRoof : MonoBehaviour {

    Collider cd;
    SpriteRenderer sr;
    GameObject player;
    float transparency = 1f;
    float timer = 1.0f;
    public float duration;

    private bool roofHidden = false;

	// Use this for initialization
	void Start () {

        sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        //Calls roof methods in order to obtain smooth interpolation
        if (roofHidden)
            hideRoof();
        else
            displayRoof();

    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            timer = 0;
            roofHidden = true;
        }
    }
    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            timer = 0;
            roofHidden = false;
        }
    }

    //Will result in transparency value going from 1 -> 0.  Speed is dependent on duration.
    private void hideRoof()
    {
        if (timer > 1)
        {
            transparency = 0f;
        }
        else
        {
            transparency = 1-timer * duration;
            sr.color = new Color(1f, 1f, 1f, transparency);
        }
    }

    //Will result in transparency value going from 0 -> 1.  Speed is dependent on duration.
    private void displayRoof()
    {
        if (timer > 1)
        {
            transparency = 1f;
        }
        else
        {
            transparency = timer * duration;
            sr.color = new Color(1f, 1f, 1f, transparency);
        }
    }
}
