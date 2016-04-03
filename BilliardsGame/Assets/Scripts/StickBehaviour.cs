using UnityEngine;

public class StickBehaviour : MonoBehaviour
{
    public GameObject stick;
    public Rigidbody whiteBallRigidbody;
    private Rigidbody[] ballsRigidbodies;
    private int ballsMovingCount;
	private WhiteBallBehaviour whiteBallScript;
    private Balls[] ballsScript;
    public float sleepUnedrSpeed = 0.05f;

    // Use this for initialization
    void Start ()
    {
        ballsRigidbodies = new Rigidbody[15];
        GameObject[] foundBalls = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < foundBalls.Length; i++)
        {
            ballsRigidbodies[i] = foundBalls[i].GetComponent<Rigidbody>();
        }

        ballsScript = new Balls[15];
        for (int i = 0; i < foundBalls.Length; i++)
        {
            ballsScript[i] = foundBalls[i].GetComponent<Balls>();
        }

        whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();
        whiteBallRigidbody = GameObject.Find("White Ball").GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ballsMovingCount = ballsScript.Length + 1;

        for (int i = 0; i < ballsRigidbodies.Length; i++)
        {
            if (ballsRigidbodies[i].IsSleeping())
            {
                ballsMovingCount--;
            }
        }

        //for (int i = 0; i < ballsScript.Length; i++)
        //{
        //    if (ballsScript[i].speed == 0 || ballsRigidbodies[i].IsSleeping())
        //    {
        //        ballsMovingCount--;
        //    }
        //}

        if (whiteBallScript.speed == 0 || whiteBallRigidbody.IsSleeping())
		{
			ballsMovingCount--;
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
