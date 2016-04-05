using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSTurnText : MonoBehaviour 
{
	public TextMesh playerOnTurnText;
	// Use this for initialization
	void Start () 
	{
		//playerOnTurnText = gameObject.AddComponent<TextMesh>();
		playerOnTurnText.text = "";
	    PrintPlayerTurn();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    public void PrintPlayerTurn()
    {
        if (PlayerPrefs.GetInt("gameMode") == 1)
        {
            playerOnTurnText.text = "";
        }
        else
        {
            int activePlayer = PlayerPrefs.GetInt("playerTurn");
            playerOnTurnText.text = "Player " + activePlayer + "'s turn";
            if (activePlayer == 1)
            {
                playerOnTurnText.color = new Color(242f / 255f, 249f / 255f, 117f / 255f, 1);
                // light yellow
            }
            else
            {
                playerOnTurnText.color = new Color(159f / 255f, 244f / 255f, 90f / 255f, 1);
                // light green
            }
        }
    }

    public void SwitchPlayerTurn()
    {
        int nextPlayerTurn = PlayerPrefs.GetInt("playerTurn") + 1;
        if (nextPlayerTurn > 2)
        {
            nextPlayerTurn = 1;
        }
        PlayerPrefs.SetInt("playerTurn", nextPlayerTurn);
    }
}
