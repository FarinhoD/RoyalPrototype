using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    GameObject player;
    PlayerMovement pm;
    bool followPlayer = true;
    Camera cam;

	// Use this for initialization
	void Start ()
    {
        pm = GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (followPlayer == true)
        {
            //camFollowPlayer();
            lookAhead();
        }
	}

    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    void lookAhead()
    {

        Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y, this.transform.position.z));

        camPos.z = -10f;
        Vector3 dir = camPos - this.transform.position;
        
        float distanceX = cam.transform.position.x - player.transform.position.x;
        float distanceY = cam.transform.position.y - player.transform.position.y;

        
        if (distanceX > -5 )
        {
            transform.Translate(dir/2 * .5f * Time.deltaTime);
        }
        else
        {
            cam.transform.position = new Vector3(player.transform.position.x - 4.9999f, this.transform.position.y, this.transform.position.z);
        }
        if (distanceX < 5)
        {
            transform.Translate(dir/2 * .5f * Time.deltaTime);
        }
        else
        {
            cam.transform.position = new Vector3(player.transform.position.x + 4.9999f, this.transform.position.y, this.transform.position.z);
        }
        if (distanceY > -5)
        {
            transform.Translate(dir/2 * .5f * Time.deltaTime);
        }
        else
        {
            cam.transform.position = new Vector3(this.transform.position.x, player.transform.position.y - 4.9999f, this.transform.position.z);
        }
        if (distanceY < 5)
        {
            transform.Translate(dir/2 * .5f * Time.deltaTime);
        }
        else
        {
            cam.transform.position = new Vector3(this.transform.position.x, player.transform.position.y + 4.9999f, this.transform.position.z);
        }

    }
}
