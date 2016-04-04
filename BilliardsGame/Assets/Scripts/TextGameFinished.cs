using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextGameFinished : MonoBehaviour 
{
	public Text whoWonText;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Text>();
		whoWonText.text = PlayerPrefs.GetString("whoWonText");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}


