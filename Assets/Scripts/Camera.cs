using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject player;


    private Vector2 velocity;
    public float smoothXFactor;
    public float smoothYFactor;

    private Vector3 offset;

	// Use this for initialization
	void Start () 
    {
        
        //player = GameObject.FindGameObjectWithTag("Player");	
        offset = transform.position - player.transform.position;
	}
	/*
    void FixedUpdate()
    {
        float x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothXFactor);
        float y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothYFactor);

        // Move the camera to new position
        transform.position = new Vector3(x, y, transform.position.z);
    }
    */
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
