using UnityEngine;

public class StickBehaviour : MonoBehaviour
{
    public GameObject stick;
    public Rigidbody WhiteBallRigidbody;
    private Rigidbody[] ballsRigidbodies;
    private int ballsMovingCount;
	WhiteBallBehaviour whiteBallScript;

    // Use this for initialization
    void Start ()
    {
        ballsRigidbodies = new Rigidbody[15];
	    GameObject[] foundBalls = GameObject.FindGameObjectsWithTag("ball");

	    for (int i = 0; i < foundBalls.Length; i++)
	    {
            ballsRigidbodies[i] = foundBalls[i].GetComponent<Rigidbody>();
	    }
		
		whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ballsMovingCount = 0;

		for (int i = 0; i < ballsRigidbodies.Length; i++)
		{
			if (!ballsRigidbodies[i].IsSleeping())
			{
				ballsMovingCount++;
			}
		}

		if (whiteBallScript.speed > 0f)
		{
			ballsMovingCount++;
		}

        if (ballsMovingCount > 0)
        {
            stick.SetActive(false);
        }
        else
        {
            stick.SetActive(true);
        }
        
	}
}
