using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
	public GameObject scoreText;
    public static float playerScore = 0;
	private string score; 

      void Start(){
            UpdateScore();
      }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
		

      public void AddScore(int points){
            playerScore += points;
            UpdateScore();
      }

      void UpdateScore(){
            Text scoreTextB = scoreText.GetComponent<Text>();
			score = Mathf . FloorToInt ( playerScore ) . ToString ( ) ;
            scoreTextB.text = "distance: " + score;
      }
}
