using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    BoxCollider2D bc;

    float timer = 0;

	// Use this for initialization
	void Start () {
        bc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        transform.Translate(Vector2.right * Time.deltaTime * 20f );

     if (timer > 1.5)
        {
            Destroy(gameObject);
        }

	}

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", 10);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Building")
        {
            Debug.Log("building");
            Destroy(gameObject);
        }
    }

}
