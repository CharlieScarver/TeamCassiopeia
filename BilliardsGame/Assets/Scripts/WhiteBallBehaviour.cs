using UnityEngine;

public class WhiteBallBehaviour : MonoBehaviour
{
    public GameObject stick;                // child object - the stick which "hits" the ball

    public int maxForce = 1000;               // the max possible force which might be applied to the ball
	public int forceStepIncrement = 10;      // how fast the force will increment while Space is pressed
    public float sleepUnderSpeed = 0.1f;    // at what speed the ball shoud stop
    public float rotationStep = 10;         // the rotation of the stick when the player uses arrows
    public bool setPositionMode = false;    // if true (when the ball fell in a hole) the user can set the ball at certain position
    public float moveSpeedWhileSettingBall = 10;     // the speed moving the ball with which the user can set the ball (?)
    public Vector3 initialPosition = new Vector3(0, 5.596084f, -60);    // initial position of the ball

    private Rigidbody whiteBallRigidBody;
    private float rotationY = 0;            // direction of the applied force
    private float forceToApply = 0;                 // the force applied to the ball
    private float speed = 0;                        // the speed of the ball
    
    private Vector3 lastPosition = Vector3.zero;    // helps for determining the speed of the ball (?)

    void Start ()
    {
        whiteBallRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        speed = (transform.position - lastPosition).magnitude;
        //Debug.Log("white ball speed = " + speed);
        if (speed != 0f && speed < sleepUnderSpeed)
        {
            whiteBallRigidBody.Sleep();
        }
        lastPosition = transform.position;
    }

	// Update is called once per frame
	void Update ()
    {
        if (!setPositionMode)
        {
            if (stick.activeSelf) // if the stick is active (non of the balls is moving)
            {
                // if Shift is pressed the rotation is slower
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    rotationStep = 1;
                }
                else
                {
                    rotationStep = 10;
                }

                // left arrow rotates the ball counter clockwise; right arrow - clockwise
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    // when the ball rotate an odd movement appears, the next line fixes this oddiness
                    whiteBallRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    rotationY -= rotationStep;
                }
                else
                {
                    whiteBallRigidBody.constraints = RigidbodyConstraints.None;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    whiteBallRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                    rotationY += rotationStep;
                }
                else
                {
                    whiteBallRigidBody.constraints = RigidbodyConstraints.None;
                }

                transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

                // when space is pressed a variable accumulates the amount of force to be applied on the ball
                if (Input.GetKey(KeyCode.Space) && forceToApply < maxForce)
                {
                    forceToApply += forceStepIncrement;
                }

                if (!Input.GetKey(KeyCode.Space) && forceToApply > 0)
                {
                    whiteBallRigidBody.AddRelativeForce(0f, 0f, forceToApply, ForceMode.Impulse);
                    Debug.Log("Force: " + forceToApply);
                    forceToApply = 0;
                }
            } // end if stick.activeSelf

        } // end if not setPositionMode
        else  // the white ball felt in a hole and now the user set the white ball 
        {
            float horizontalAxis = Input.GetAxis("Horizontal"); 
            float verticalAxis = Input.GetAxis("Vertical");
            if (verticalAxis > 0f)
            {
                transform.Translate(moveSpeedWhileSettingBall * Time.deltaTime, 0f, 0f);
            }
            else if (verticalAxis < 0f)
            {
                transform.Translate(-moveSpeedWhileSettingBall * Time.deltaTime, 0f, 0f);
            }
            if (horizontalAxis < 0f)
            {
                transform.Translate(0f, 0f, moveSpeedWhileSettingBall * Time.deltaTime);
            }
            else if (horizontalAxis > 0f)
            {
                transform.Translate(0f, 0f, -moveSpeedWhileSettingBall * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                setPositionMode = false;
            }
        }
    } // end Update

}
