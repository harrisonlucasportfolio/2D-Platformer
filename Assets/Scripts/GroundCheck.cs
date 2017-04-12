using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Remoting.Services;

public class GroundCheck : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () 
    {
        player = gameObject.GetComponentInParent<PlayerController>();

	}
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        print("Enter2d");
        player.grounded = true;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        print("Stay2d");
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        print("Exit2d");
        player.grounded = false;
    }
}
