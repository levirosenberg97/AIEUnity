﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    public int healing;
    public float rotationSpeed;
    // Use this for initialization
    void Start ()
    {
        transform.Rotate(rotationSpeed, 3, rotationSpeed / 3);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var playerController = other.GetComponent<Health>();
            playerController.currentHealth += healing;

            playerController.healthSlider.value = playerController.currentHealth;
            Destroy(gameObject);
        }
    }


}
