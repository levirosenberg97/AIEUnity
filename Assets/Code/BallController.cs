using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    
    public int playerNumber;
    
    public float speed = 12f;
    public float turnSpeed = 180f;
    public int score;
    
  

    private string movementAxisName;
    private string turnAxisName;
    public Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;

    // Use this for initialization
    private void Awake ()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
       
        
	}

    private void OnEnable()
    {
        rb.isKinematic = false;

        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    private void OnDisable()
    {
        rb.isKinematic = true;
    }

    private void Start()
    {
        movementAxisName = "Vertical" + playerNumber;
        turnAxisName = "Horizontal" + playerNumber;
    }

    private void Update()
    {
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 movement = transform.right * movementInputValue * speed * Time.deltaTime;

        

        rb.MovePosition(rb.position + movement);
    }
    
    void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
