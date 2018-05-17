using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    float timer;

    public AudioClip footSteps;
    AudioSource ad;

    private void Awake()
    {
        ad = GetComponent<AudioSource>();   
    }

    private void Update()
    {
       // timer += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        timer += Time.deltaTime;
        movement();
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            if(timer > .5)
            {          
                ad.PlayOneShot(footSteps);
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            if (timer > .5)
            {
                ad.PlayOneShot(footSteps);
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            if (timer > .5)
            {
                ad.PlayOneShot(footSteps);
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            if (timer > .5)
            {
                ad.PlayOneShot(footSteps);
                timer = 0;
            }
        }
    }
}
