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

        //if a character has entered the collider and is pressing E
        if (allowedToOpen && Input.GetKeyDown(KeyCode.E)) {

            Debug.Log("Pressed E");

            //Inside house, door is open inward.  Close door.
            if (isInside() && anim.GetBool("openDoorInward"))
            {
                Debug.Log("Inside house, door is open inward.  Close door.");
                anim.SetBool("openDoorInward", false);
                anim.SetBool("openDoorOutward", false);
                anim.SetBool("isInside", true);
            }
            //Inside house, door is closed.  Open outward.
            else if (isInside() && !anim.GetBool("openDoorOutward") && !anim.GetBool("openDoorInward"))
            {
                Debug.Log("Inside house, door is closed.  Open outward.");
                anim.SetBool("openDoorInward", false);
                anim.SetBool("openDoorOutward", true);
                anim.SetBool("isInside", true);
            }
            //Inside house, door is open outward.  Close door.
            else if (isInside() && anim.GetBool("openDoorOutward") && !anim.GetBool("openDoorInward"))
            {
                Debug.Log("Inside house, door is open outward.  Close door.");
                anim.SetBool("openDoorInward", false);
                anim.SetBool("openDoorOutward", false);
                anim.SetBool("isInside", true);
            }
            //Outside house, door is open outward.  Close door.
            else if (!isInside() && anim.GetBool("openDoorOutward"))
            {
                Debug.Log("Outside house, door is open outward.  Close door.");
                anim.SetBool("openDoorInward", false);
                anim.SetBool("openDoorOutward", false);
                anim.SetBool("isInside", false);
            }
            //Outside house, door is closed.  Open Inward.
            else if (!isInside() && !anim.GetBool("openDoorOutward") && !anim.GetBool("openDoorInward"))
            {
                Debug.Log("Outside house, door is closed.  Open Inward.");
                anim.SetBool("openDoorInward", true);
                anim.SetBool("openDoorOutward", false);
                anim.SetBool("isInside", true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            allowedToOpen = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        allowedToOpen = false;
    }

    private bool isInside ()
    {
        return roof.GetComponent<HideRoof>().isPlayerInside();
    }
}
