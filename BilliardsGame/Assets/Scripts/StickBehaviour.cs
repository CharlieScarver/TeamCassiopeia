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
		
		// if until now the stick was was not active but none of the balls is moving
		if(!whiteBallScript.isStickMustBeActiveNow && ballsMovingCount <= 0)
		{
			whiteBallScript.isStickMustBeActiveNow = true;
		}
		
		// if the stick must be active now but it is not active
        if (whiteBallScript.isStickMustBeActiveNow && !stick.activeSelf)
        {
            stick.SetActive(true);
        }
        
		// if the stick must not be active now but it is active
		if(!whiteBallScript.isStickMustBeActiveNow && stick.activeSelf)
        {
            stick.SetActive(false);
        }
        
	}
	
	public void AnimationEvent()
	{
        whiteBallScript.isStickAnimationEnded = true;
	}
}
