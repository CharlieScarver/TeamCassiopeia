using UnityEngine;

public class StickBehaviour : MonoBehaviour
{
    public GameObject stick;
    public Rigidbody whiteBallRigidbody;

    private Rigidbody[] ballsRigidbodies;
    private int ballsMovingCount;
	private WhiteBallBehaviour whiteBallScript;
    private BallsBehaviour[] ballsScript;


    // Use this for initialization
    void Start ()
    {
        ballsRigidbodies = new Rigidbody[15];
        GameObject[] foundBalls = GameObject.FindGameObjectsWithTag("ball");

        for (int i = 0; i < 15; i++)
        {
            ballsRigidbodies[i] = foundBalls[i].GetComponent<Rigidbody>();
        }

        ballsScript = new BallsBehaviour[15];
        for (int i = 0; i < 15; i++)
        {
            ballsScript[i] = foundBalls[i].GetComponent<BallsBehaviour>();
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

	    if (whiteBallScript.ballSpeed == 0f || whiteBallRigidbody.IsSleeping())
		{
			ballsMovingCount--;
		}

        // if no balls aremoving activate stick
        if (ballsMovingCount > 0)
        {
            stick.SetActive(false);
        }
        else
        {
            stick.SetActive(true);
        }
        
	}
	
	public void AnimationEvent()
	{
        whiteBallScript.isStickAnimationEnded = true;
	}
}
