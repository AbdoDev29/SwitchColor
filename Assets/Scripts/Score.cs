using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // References
 

    TextMeshProUGUI scoreTextWithPanal;
     TextMeshProUGUI scoreText;
     public int scoreCoins;

    TextMeshProUGUI totalScoreText;
    public int totalScore;

    TextMeshProUGUI bestScoreText;
    int bestScore;

    PlayerManager playerManager;
 




 
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        scoreText= GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();

        if(PlayerPrefs.HasKey("totalScore"))
        totalScore = PlayerPrefs.GetInt("totalScore");

    }
       
       


  


    


    void Update()
    {
        // Assign the references
        if (playerManager.gameOver.activeSelf)
        {
            scoreTextWithPanal = GameObject.FindGameObjectWithTag("ScoreWithPanal").GetComponent<TextMeshProUGUI>();
            totalScoreText = GameObject.FindGameObjectWithTag("TotalScore").GetComponent<TextMeshProUGUI>();
            bestScoreText = GameObject.FindGameObjectWithTag("BestScore").GetComponent<TextMeshProUGUI>();

            totalScoreText.text = totalScore.ToString();
            bestScoreText.text = bestScore.ToString();
            scoreTextWithPanal.text = scoreCoins.ToString();
        }
        scoreText.text = scoreCoins.ToString();

  

       // Save the score
        PlayerPrefs.SetInt("totalScore", totalScore);

        // Best Score
        if (bestScore<scoreCoins)
        {
            bestScore = scoreCoins;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        else
        {
            bestScore = PlayerPrefs.GetInt("bestScore");
        }


   
    }

 
}
