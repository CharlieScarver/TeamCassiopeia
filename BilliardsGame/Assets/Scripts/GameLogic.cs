using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour 
{
	GameObject[] balls;
	private bool isBlackBallActive = true;
	
	// Use this for initialization
	void Start () 
	{
		balls = GameObject.FindGameObjectsWithTag("ball");
	}
	
	// Update is called once per frame
	void Update () 
	{
		int activeBalls = balls.Length;
		int blackBallIndex = 0;
		for(int i = 0; i < balls.Length; i++)
		{
			if(!balls[i].activeSelf)
			{
				activeBalls--;
			}
			if(balls[i].name == "Ball (08)") // get the index of the black ball
			{
				blackBallIndex = i;
			}
		}
		
		if(!balls[blackBallIndex].activeSelf)
		{
			isBlackBallActive = false;
		}
		
        if (PlayerPrefs.GetInt("gameMode") == 1) // if practice mode is active
        {
            if ((activeBalls > 1 && !isBlackBallActive) || (activeBalls == 0))
            {
                Debug.Log("Game Finished");
				PlayerPrefs.SetString("whoWonText", "");
				PlayerPrefs.SetInt("gameMode", 4); // set gameMode to GameOver state
                SceneManager.LoadScene("GameFinishedScreen");
            }
        }
		if(PlayerPrefs.GetInt("gameMode") == 2) // if two players game mode is active
		{
			// TODO: make the logic here
		}
	}
}
