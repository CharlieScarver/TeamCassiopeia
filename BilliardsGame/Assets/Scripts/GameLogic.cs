using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour 
{
	GameObject[] balls;
	
	// Use this for initialization
	void Start () 
	{
		balls = GameObject.FindGameObjectsWithTag("ball");
	}
	
	// Update is called once per frame
	void Update () 
	{
		int activeBalls = balls.Length;
		for(int i = 0; i < balls.Length; i++)
		{
			if(!balls[i].activeSelf)
			{
				activeBalls--;
			}
		}
        if (PlayerPrefs.GetInt("gameMode") == 1) // if practice mode is active
        {
            if ((activeBalls > 1 && !balls[7].activeSelf) || (activeBalls == 0))
            {
                Debug.Log("Game Finished");
                // TODO game finished logic
            }
        }
	}
}
