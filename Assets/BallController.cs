using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public int score;
    public Text scoreText;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        scoreText.text = "Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        rb.AddForce(move * speed * Time.deltaTime);
	}
}
