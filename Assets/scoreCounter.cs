using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour {

    public Text scoreText;
    public BallController player1;
    public BallController player2;

    public Health HP1;
    public Health HP2;
    // Update is called once per frame


    private void Awake()
    {
        scoreText.text = player1.score.ToString() + " - " + player2.score.ToString();
    }

}
