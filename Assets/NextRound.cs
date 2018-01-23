using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRound : MonoBehaviour
{
    public gameOver gameOverHud;
    public Text scoreText;


    public void nextRound()
    {
        gameOverHud.player1.transform.position = new Vector3(-26.10959f, 1, -6.6f);
        gameOverHud.player2.transform.position = new Vector3(16, 1, -6.6f);



        var player1Alive = gameOverHud.player1.GetComponent<Health>();
        var player2Alive = gameOverHud.player2.GetComponent<Health>();

        if (player1Alive.isDead == true)
        {
            player1Alive.isDead = false;
            player1Alive.gameObject.SetActive(true);
            gameOverHud.player2.score++;
        }
        player1Alive.currentHealth = player1Alive.startHealth;


        if (player2Alive.isDead == true)
        {
            player2Alive.isDead = false;
            player2Alive.gameObject.SetActive(true);
            gameOverHud.player1.score++;
            
        }
        player2Alive.currentHealth = player2Alive.startHealth;


        player1Alive.healthSlider.value = player1Alive.currentHealth;
        player2Alive.healthSlider.value = player2Alive.currentHealth;

        gameOverHud.gameOverCanvas.enabled = false;

        gameOverHud.roundNumber++;

        scoreText.text = gameOverHud.player1.score + " - " + gameOverHud.player2.score;

        gameOverHud.hudCanvas.enabled = true;
       
    }
	
	
}
