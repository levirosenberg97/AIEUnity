using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

    public int scoreAdded;
    public float rotationSpeed;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(rotationSpeed, 0, rotationSpeed / 3);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var playerController = other.GetComponent<BallController>();
            if (playerController != null)
            {
                playerController.score += scoreAdded;
                playerController.scoreText.text = "Score: " + playerController.score.ToString();
                Destroy(gameObject);
            }
        }
    }
}
