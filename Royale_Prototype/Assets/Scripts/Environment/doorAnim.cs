using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnim : MonoBehaviour {

    Animator anim;
    bool allowedToOpen = false;
    public GameObject roof;

	// Use this for initialization
	void Start () {
        //get animator on door
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!anim.GetBool("openDoor"))
        {
            if (Input.GetKeyDown(KeyCode.E) && allowedToOpen)
            {
                anim.SetBool("openDoor", true);
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.E) && allowedToOpen)
            {
                anim.SetBool("openDoor", false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Can open door");
        if (other.gameObject.tag == "Player")
            allowedToOpen = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Can no longer open");
        allowedToOpen = false;
    }

    private bool isInside ()
    {
        return roof.isInside();
    }
}
