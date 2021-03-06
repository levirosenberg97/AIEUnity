﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {

    public Text gameText;
    public Canvas hudCanvas;
    public Canvas gameOverCanvas;
    public BallController player1;
    public BallController player2;
    public int roundNumber = 1;
  
  
  
      
    public Button mainMenuButton;
    public Button nextRoundButton;
    

    //public Image darken;

    // Update is called once per frame

    
    void FixedUpdate ()
    {
        var playerAlive1 = player1.GetComponent<Health>();
        var playerAlive2 = player2.GetComponent<Health>();


        if (player1.score == 3)
        {
            Time.timeScale = 0;  
            hudCanvas.gameObject.SetActive(false);
            gameText.text = "Player 1 Wins";
            mainMenuButton.gameObject.SetActive(true);
            nextRoundButton.gameObject.SetActive(false);
            gameOverCanvas.enabled = true;
        }

        if (player2.score == 3)
        {
            Time.timeScale = 0;
            hudCanvas.gameObject.SetActive(false);
            gameText.text = "Player 2 Wins";
            mainMenuButton.gameObject.SetActive(true);
            nextRoundButton.gameObject.SetActive(false);
            gameOverCanvas.enabled = true;
        }

        if (playerAlive1.isDead == true)
        {
            Time.timeScale = 0;
            hudCanvas.gameObject.SetActive(false);
            gameText.text = "Player 2 Wins Round " + roundNumber;
            gameOverCanvas.enabled = true;           
        }


        if (playerAlive2.isDead == true)
        {
            Time.timeScale = 0;
            hudCanvas.gameObject.SetActive(false);
            gameText.text = "Player 1 Wins Round " + roundNumber;
            gameOverCanvas.enabled = true;
        }
    }
}
