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
    public float jumpForce = 7;
    public SphereCollider col;
   

	// Use this for initialization
	void Start ()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor" && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
