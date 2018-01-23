using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerLabel;
    public BallController player;
    public float timeLeft;

    public Text speedometerLabel;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
    }


    private void Update()
    {
      

        timeLeft -= Time.deltaTime;

        var min = timeLeft / 60;

        var sec = timeLeft % 60;

        var fractions = (timeLeft * 100) % 100;

        timerLabel.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, fractions);

        if (timeLeft <= 0)
        {
            var playerAlive = player.GetComponent<Health>();
            playerAlive.Death();
        }

        Vector3 groundVec = playerRigidbody.velocity;
        groundVec.y = 0.0f;

        speedometerLabel.text = (int)groundVec.magnitude + "m/s";
    }

}
