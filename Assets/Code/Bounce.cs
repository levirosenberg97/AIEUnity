using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody rb;
    public float bounce;
	// Use this for initialization
	void Start ()
    {
	  
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            rb.AddForce(Vector3.up * bounce, ForceMode.VelocityChange);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
