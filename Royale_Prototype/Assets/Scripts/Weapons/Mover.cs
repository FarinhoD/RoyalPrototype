using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public LayerMask LM;

    BoxCollider2D bc;
    public bool stop;
    float timer = 0;

    // Use this for initialization
    private void FixedUpdate()
    {
        Vector2 fwd = transform.TransformDirection(Vector2.up);


        stop = Physics2D.Raycast(this.transform.position, fwd);



    }

    void Start () {

        bc = GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {

        if (stop == true)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;

        transform.Translate(Vector2.up * Time.deltaTime * 20f );

     if (timer > 1.5)
        {
            Destroy(gameObject);
        }

	}



}
