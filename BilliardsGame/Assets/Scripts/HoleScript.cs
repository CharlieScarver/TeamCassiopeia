using UnityEngine;
using UnityEngine.UI;

public class HoleScript : MonoBehaviour
{
    public GameObject whiteBall;
    public PlayerSTurnText playerSTurnTextScript;
    public Text player1ScoreText;
    public Text player2ScoreText;
    private WhiteBallBehaviour whiteBallScript;
    private static bool firstFallenBall;
    
    void Start ()
    {
        whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();
        firstFallenBall = true;
    }

    void OnTriggerExit (Collider collider)
    {
        if (collider.gameObject.tag == "ball")
        {
            Rigidbody ballRigidBody = collider.gameObject.GetComponent<Rigidbody>();
            ballRigidBody.Sleep();
            collider.gameObject.SetActive(false);

            // only if two player mode is active
            if (PlayerPrefs.GetInt("gameMode") == 2)
            { 
                // determine active player
                int activePlayer = PlayerPrefs.GetInt("playerTurn");

                string playerBallsPref = string.Format("player{0}Balls", activePlayer);
                int playerBalls = PlayerPrefs.GetInt(playerBallsPref);
                string ballTag = collider.gameObject.GetComponentsInChildren<SphereCollider>()[1].tag;
            
                if (ballTag == "blackBall")
                {
                    if (PlayerPrefs.GetInt(string.Format("player{0}Score", activePlayer)) == 7)
                    {
                        PlayerPrefs.SetString("whoWonText", string.Format("Player {0} won!", activePlayer));
                        Debug.Log(PlayerPrefs.GetString("whoWonText"));

                        PlayerPrefs.SetInt("gameMode", 4);
                        return;
                    }
                    else
                    {
                        activePlayer++;
                        if (activePlayer > 2)
                        {
                            activePlayer = 1;
                        }
                        PlayerPrefs.SetString("whoWonText", string.Format("Player {0} won!", activePlayer));
                        Debug.Log(PlayerPrefs.GetString("whoWonText"));
                        PlayerPrefs.SetInt("gameMode", 4);
                        return;
                    }
                }

                if (!firstFallenBall)
                {
                    // is the fallen ball one of the player's
                    if ((ballTag == "smallBall" && playerBalls == 0) || (ballTag == "bigBall" && playerBalls == 1))
                    {
                        // increase his score
                        IncreasePlayerScore(activePlayer);
                        // notify that a ball fell
                        whiteBallScript.didABallFallThisTurn = true;
                    }
                    else
                    {
                        activePlayer++;
                        if (activePlayer > 2)
                        {
                            activePlayer = 1;
                        }
                        IncreasePlayerScore(activePlayer);
                    }
                }
                else 
                {
                    // if this is the first fallen ball
                    // increase the player's score
                    IncreasePlayerScore(activePlayer);

                    // and set which balls he's going to play with
                    if (ballTag == "smallBall")
                    {
                        if (activePlayer == 1)
                        {
                            PlayerPrefs.SetInt("player1Balls", 0);
                            PlayerPrefs.SetInt("player2Balls", 1);
                        }
                        else
                        {
                            PlayerPrefs.SetInt("player2Balls", 0);
                            PlayerPrefs.SetInt("player1Balls", 1);
                        }
                        Debug.Log("Player " + activePlayer + " will play with small balls");
                    }
                    else if (ballTag == "bigBall")
                    {
                        if (activePlayer == 1)
                        {
                            PlayerPrefs.SetInt("player1Balls", 1);
                            PlayerPrefs.SetInt("player2Balls", 0);
                        }
                        else
                        {
                            PlayerPrefs.SetInt("player2Balls", 1);
                            PlayerPrefs.SetInt("player1Balls", 0);
                        }
                        Debug.Log("Player " + activePlayer + " will play with big balls");
                    }
                    // notify that a ball fell
                    whiteBallScript.didABallFallThisTurn = true;

                    firstFallenBall = false;
                }
            }
        }

        if (collider.gameObject.tag == "whiteBall")
        {
            whiteBall.transform.position = whiteBallScript.initialPosition;
            whiteBall.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			whiteBallScript.ballIsInHole = false;
            whiteBallScript.setPositionMode = true;
        }
    }

    private void IncreasePlayerScore (int activePlayer)
    {
        // increase the player's score
        string playerScorePref = string.Format("player{0}Score", activePlayer);
        int activePlayerScore = PlayerPrefs.GetInt(playerScorePref);
        activePlayerScore += 1;
        PlayerPrefs.SetInt(playerScorePref, activePlayerScore);

        // print score
        if (activePlayer == 1)
        {
            player1ScoreText.text = string.Format("Player 1:  {0}", activePlayerScore);
        }
        else
        {
            player2ScoreText.text = string.Format("Player 2:  {0}", activePlayerScore);
        }
    }
}
