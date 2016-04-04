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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PlayerPrefs.GetInt("gameMode") == 1)
		{
			playerOnTurnText.text = "";
		}
		else
		{
			playerOnTurnText.text = "Player " + PlayerPrefs.GetInt("playerTurn") + "'s turn";
		}
	}
}
