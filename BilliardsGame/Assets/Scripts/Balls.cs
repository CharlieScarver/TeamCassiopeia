using UnityEngine;
using System.Collections;

public class Balls : MonoBehaviour 
{
	public float sleepUnderSpeed = 0.05f;    // at what speed the ball shoud stop
	public float speed = 0;                        // the speed of the ball
    private Vector3 lastPosition = Vector3.zero;    // helps for determining the speed of the ball
	public bool ballIsInHole = false;		// if set to true (i.e. when the ball is in the position of a hole detecor) then dont set speed to 0 at speeds under sleepUnderSpeed values. The value is set to true in the HoleDetectors script
	
	private Rigidbody ballRigidBody;
    public float dragUnderSpeedToSleep = 5f;

    // Use this for initialization
    void Start()
    {
		ballRigidBody = gameObject.GetComponent<Rigidbody>();
    }
	
	void FixedUpdate ()
    {
        speed = (transform.position - lastPosition).magnitude;
        //Debug.Log(gameObject.name.ToString() + " speed = " + speed);
        if (speed != 0f && speed < sleepUnderSpeed && !ballIsInHole)
        {
            ballRigidBody.drag = dragUnderSpeedToSleep;
            ballRigidBody.angularDrag = dragUnderSpeedToSleep;
        }
        lastPosition = transform.position;

        if (speed == 0f)
        {
            ballRigidBody.drag = 0.01f;
            ballRigidBody.angularDrag = 0.03f;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
