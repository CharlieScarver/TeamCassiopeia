using UnityEngine;
using System.Collections;

public class HoleDetectors : MonoBehaviour // Currently not in use - pending deletion
{
    WhiteBallBehaviour whiteBallScript;
    BallsBehaviour[] ballsScript;
	// Use this for initialization
	void Start () 
	{
		whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();
		
		ballsScript = new BallsBehaviour[15];
		GameObject[] foundBalls = GameObject.FindGameObjectsWithTag("ball");
		for (int i = 0; i < foundBalls.Length; i++)
	    {
            ballsScript[i] = foundBalls[i].GetComponent<BallsBehaviour>();
	    }
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider collider)
	{
		//SetBallsInHole(true, collider);
	}
	
	void OnTriggerExit (Collider collider)
	{
		//SetBallsInHole(false, collider);
	}
	
	void SetBallsInHole(bool isInHole, Collider collider)
	{
		if(collider.gameObject.tag == "ball")
		{
			// get index of the ball
			//string indexAsString = string.Empty; 
			//Debug.Log("name[6,7] = " + collider.gameObject.name[6] + "" + collider.gameObject.name[7]);
			int index10 = collider.gameObject.name[6] - '0';
			int index1 = collider.gameObject.name[7] - '0';
			int index = 10 * index10 + index1;
			

			ballsScript[index].ballIsInHole = isInHole;

            Debug.Log("index = " + index + "; Дупка: " + ballsScript[index].ballIsInHole);
        }
		if(collider.gameObject.tag == "whiteBall")
		{
			whiteBallScript.ballIsInHole = isInHole;
		}
	}
}
