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
            camFollowPlayer();
            //lookAhead();
        }
	}

    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    void lookAhead()
    {
         Vector2 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y));
         
        // Vector newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z);
        if (cam.transform.position.x - player.transform.position.x > -10 && cam.transform.position.x + player.transform.position.x < 10)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, camPos, 10f);
        }

    //Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y, this.transform.position.z));
    // camPos.z = -10;
    // Vector3 dir = camPos - this.transform.position;
    //  Vector3 dir = camPos - player.transform.position;
     Debug.Log(camPos);
    // if (dir.x < 10 && dir.x > -10)
    //  {
    //      transform.Translate(dir * 1f * Time.deltaTime);
    // }
}
}
