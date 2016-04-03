using UnityEngine;

public class StickBehaviour : MonoBehaviour
{
    public GameObject stick;
    public Rigidbody WhiteBallRigidbody;
    public float sleepUnderSpeed = 0.1f;    // at what speed the ball shoud stop

    private Rigidbody[] ballsRigidbodies;
    private int ballsMovingCount;
    private float speed = 0;                // the speed of the ball
    private Vector3 lastPosition = Vector3.zero;    // helps for determining the speed of the ball (?)

    // Use this for initialization
    void Start ()
    {
        ballsRigidbodies = new Rigidbody[15];
	    GameObject[] foundBalls = GameObject.FindGameObjectsWithTag("ball");

	    for (int i = 0; i < foundBalls.Length; i++)
	    {
            ballsRigidbodies[i] = foundBalls[i].GetComponent<Rigidbody>();
	    }
    }
	
	// Update is called once per frame
	void Update ()
    {
        ballsMovingCount = 0;

	    if (!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
	    {
            for (int i = 0; i < ballsRigidbodies.Length; i++)
            {
                if (!ballsRigidbodies[i].IsSleeping())
                {
                    ballsMovingCount++;
                    //Debug.Log("Object moving : " + ballsRigidbodies[i].gameObject.name);

                    // TODO: Stop balls at certain speed
                    //speed = (ballsRigidbodies[i].gameObject.transform.position - lastPosition).magnitude;
                    ////Debug.Log("white ball speed = " + speed);
                    //if (speed != 0f && speed < sleepUnderSpeed)
                    //{
                    //    ballsRigidbodies[i].Sleep();
                    //}
                    //lastPosition = ballsRigidbodies[i].gameObject.transform.position;
                }
            }

            if (!WhiteBallRigidbody.IsSleeping())
            {
                ballsMovingCount++;
            }
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
