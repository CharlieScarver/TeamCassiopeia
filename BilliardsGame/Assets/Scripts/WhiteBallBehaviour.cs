using UnityEngine;
using UnityEngine.UI;

public class WhiteBallBehaviour : MonoBehaviour
{
    public GameObject stick;                // child object - the stick which "hits" the ball
    public Slider forceSlider;          // determines the applied force
    public int maxForce;               // the max possible force which might be applied to the ball
	public int forceStepIncrement;      // how fast the force will increment while Space is pressed
    public float sleepUnderSpeed;    // at what ballSpeed the ball shoud stop
    public bool setPositionMode = false;    // if true (when the ball fell in a hole) the user can set the ball at certain position
    public float moveSpeedWhileSettingBall = 10;     // the ballSpeed moving the ball with which the user can set the ball (?)
    public Vector3 initialPosition = new Vector3(0, 5.596084f, -60);    // initial position of the ball
    public bool ballIsInHole = false;       // if set to true (i.e. when the ball is in the position of a hole detecor) then dont set ballSpeed to 0 at speeds under sleepUnderSpeed values. The value is set to true in the HoleDetectors script; the vaule is set to false in HoleScript script.
    public float ballSpeed;                        // the ballSpeed of the ball
    public int firstBallTouched;
    public PlayerSTurnText playerSTurnTextScript;   // switches player turns

    public bool didABallFallThisTurn;

    private float stickRotationStep;         // the rotation of the stick when the player uses arrows
    private Rigidbody whiteBallRigidBody;
    private float rotationY;            // direction of the applied force
    private float forceToApply;                 // the force applied to the ball
    private Vector3 lastPosition = Vector3.zero;    // helps for determining the ballSpeed of the ball
    private float dragStep;
    private bool changedTurn;

    
    void Start ()
    {
        whiteBallRigidBody = gameObject.GetComponent<Rigidbody>();
        stickRotationStep = 10;
        ballSpeed = 0;
        dragStep = 0.2f;
        rotationY = 0f;
        forceToApply = 0f;
        firstBallTouched = 0;
        changedTurn = false;
        didABallFallThisTurn = false;
    }

    void FixedUpdate ()
    {
        ballSpeed = (transform.position - lastPosition).magnitude;
        //Debug.Log("white ball ballSpeed = " + ballSpeed);
        if (ballSpeed != 0f && ballSpeed < sleepUnderSpeed && !ballIsInHole)
        {
            whiteBallRigidBody.drag += dragStep;
            whiteBallRigidBody.angularDrag += dragStep;
        }
        lastPosition = transform.position;

        if (ballSpeed == 0f)
        {
            whiteBallRigidBody.drag = 0.2f;
            whiteBallRigidBody.angularDrag = 0.2f;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        // if gameMode is in Practice Mode (1) or gameMode is Two Players (2)
        if (PlayerPrefs.GetInt("gameMode") == 1 || PlayerPrefs.GetInt("gameMode") == 2)
        {
            if (!setPositionMode)
            {                
                if (stick.activeSelf) // if the stick is active (non of the balls is moving)
                {
                    if (!changedTurn && !didABallFallThisTurn)
                    {
                        playerSTurnTextScript.SwitchPlayerTurn();
                        playerSTurnTextScript.PrintPlayerTurn();
                        changedTurn = true;
                    }

                    // if Shift is pressed the rotation is slower
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    {
                        stickRotationStep = 1;
                    }
                    else
                    {
                        stickRotationStep = 5;
                    }

                    // left arrow rotates the ball counter clockwise; right arrow - clockwise
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        // when the ball rotate an odd movement appears, the next line fixes this oddiness
                        whiteBallRigidBody.constraints = RigidbodyConstraints.FreezePositionX |
                                                         RigidbodyConstraints.FreezePositionZ;
                        rotationY -= stickRotationStep;
                    }
                    else
                    {
                        whiteBallRigidBody.constraints = RigidbodyConstraints.None;
                    }
                    if (Input.GetKey(KeyCode.RightArrow))
                    {
                        whiteBallRigidBody.constraints = RigidbodyConstraints.FreezePositionX |
                                                         RigidbodyConstraints.FreezePositionZ;
                        rotationY += stickRotationStep;
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

                    // release space to hit
                    if (!Input.GetKey(KeyCode.Space) && forceToApply > 0)
                    {
                        forceToApply = forceSlider.value; // use the slider value for the force
                        whiteBallRigidBody.AddRelativeForce(0f, 0f, forceToApply, ForceMode.Impulse);
                        //Debug.Log("Force: " + forceToApply);
                        forceToApply = 0;

                        // reset bool
                        didABallFallThisTurn = false;
                    }
                } // end if stick.activeSelf
                else
                {
                    changedTurn = false;
                }

            } // end if not setPositionMode
            else  // the white ball fell in a hole and now the user set the white ball 
            {
                rotationY = 0f;
                float horizontalAxis = Input.GetAxis("Horizontal");
                float verticalAxis = Input.GetAxis("Vertical");
                if (verticalAxis > 0f)
                {
                    transform.Translate(-moveSpeedWhileSettingBall * Time.deltaTime, 0f, 0f);
                }
                else if (verticalAxis < 0f)
                {
                    transform.Translate(moveSpeedWhileSettingBall * Time.deltaTime, 0f, 0f);
                }
                if (horizontalAxis < 0f)
                {
                    transform.Translate(0f, 0f, -moveSpeedWhileSettingBall * Time.deltaTime);
                }
                else if (horizontalAxis > 0f)
                {
                    transform.Translate(0f, 0f, moveSpeedWhileSettingBall * Time.deltaTime);
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    setPositionMode = false;
					firstBallTouched = 0;
                }
            } // end else not setPosition
        } // end if gameMode
    } // end Update

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "holeDetector")
        {
            ballIsInHole = true;
            if (ballSpeed < 0.5f)
            {
                whiteBallRigidBody.drag += dragStep * 50;
                whiteBallRigidBody.angularDrag += dragStep * 50;
            }
        }
		if
			(
				(collider.gameObject.tag == "smallBall" || collider.gameObject.tag == "blackBall" || collider.gameObject.tag == "bigBall")
				&&
				firstBallTouched == 0
			)
		{
			int index10 = collider.gameObject.name[12] - '0';
			int index1 = collider.gameObject.name[13] - '0';
			firstBallTouched =  10 * index10 + index1;
			Debug.Log("firstBallTouched = " + firstBallTouched);
		}
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "holeDetector")
        {
            ballIsInHole = false;
            whiteBallRigidBody.drag = 0.2f;
            whiteBallRigidBody.angularDrag = 0.2f;
        }
    }

}
