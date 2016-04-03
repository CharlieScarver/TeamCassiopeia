using UnityEngine;
using System.Collections;

public class HoleDetectors : MonoBehaviour 
{
    WhiteBallBehaviour whiteBallScript;
	Balls[] ballsScript;
	// Use this for initialization
	void Start () 
	{
		whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();
		
		ballsScript = new Balls[15];
		GameObject[] foundBalls = GameObject.FindGameObjectsWithTag("ball");
		for (int i = 0; i < foundBalls.Length; i++)
	    {
            ballsScript[i] = foundBalls[i].GetComponent<Balls>();
	    }
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider collider)
	{
		SetBallsInHole(true, collider);
	}
	
	void OnTriggerExit (Collider collider)
	{
		SetBallsInHole(false, collider);
	}
	
	void SetBallsInHole(bool isInHole, Collider collider)
	{
		if(collider.gameObject.tag == "ball")
		{
			// get index of the ball
			//string indexAsString = string.Empty; 
			Debug.Log("name[6,7] = " + collider.gameObject.name[6] + "" + collider.gameObject.name[7]);
			int index10 = collider.gameObject.name[6] - '0';
			int index1 = collider.gameObject.name[7] - '0';
			int index = 10 * index10 + index1;
			Debug.Log("index = " + index);
			ballsScript[index].ballIsInHole = isInHole;
		}
		if(collider.gameObject.tag == "whiteBall")
		{
			whiteBallScript.ballIsInHole = isInHole;
		}
	}
}
