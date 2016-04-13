using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour 
{
	private GameObject[] balls;
	//public GameObject whiteBall;
	//private WhiteBallBehaviour whiteBallScript;
	private bool isBlackBallActive = true;
    public Text player1ScoreText;
    public Text player2ScoreText;

    // Use this for initialization
    void Start () 
	{
		balls = GameObject.FindGameObjectsWithTag("ball");
		//whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();

        PlayerPrefs.SetInt("gamesPlayed", PlayerPrefs.GetInt("gamesPlayed") + 1);
        PlayerPrefs.SetInt("playerTurn", 0); // 0 because it will increment one extra time in the beginning
        PlayerPrefs.SetInt("player1Score", 0);
        PlayerPrefs.SetInt("player2Score", 0);

        if (PlayerPrefs.GetInt("gameMode") == 1)
        {
            player1ScoreText.text = "";
            player2ScoreText.text = "";
        }
	}

/*    void Update()
    {
        if (PlayerPrefs.GetInt("gameMode") == 4)
        {
            SceneManager.LoadScene("GameFinishedScreen");
        }
    }
*/

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

	    int gameMode = PlayerPrefs.GetInt("gameMode");
        if (gameMode == 1) // if practice mode is active
        {
            if (!isBlackBallActive)
            {
                // Debug.Log("Game Finished");
				PlayerPrefs.SetString("whoWonText", "");
				PlayerPrefs.SetInt("gameMode", 4); // set gameMode to GameOver state
                SceneManager.LoadScene("GameFinishedScreen");
            }
        }
        else if(gameMode == 2) // if two players game mode is active
		{
            if (PlayerPrefs.GetInt("twoPlayerMode") == 1) // the first mode in two players mode which define which player with which balls to play
			{
				if(!isBlackBallActive) // if someone get the blackball in a hole
				{
					string whoWonText = string.Empty;
					if(PlayerPrefs.GetInt("playerTurn") == 1) 
					{
						whoWonText = "PLAYER 2 WON!";
					}
					else if(PlayerPrefs.GetInt("playerTurn") == 2)
					{
						whoWonText = "PLAYER 1 WON";
					}
					PlayerPrefs.SetString("whoWonText", whoWonText);
                    PlayerPrefs.SetInt("gameMode", 4); // set gameMode to GameOver state
                }
				
			}
			else
			{
				// TODO make the mode where the players play with defined balls
			}
		}
        else if (gameMode == 4)
        {
            SceneManager.LoadScene("GameFinishedScreen");
        }
	}
}
