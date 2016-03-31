using UnityEngine;
using System.Collections;

public class WhiteBallBehaviour : MonoBehaviour
{

    public int maxForce = 15;
	public int forceStepIncrement = 1;
    Rigidbody whiteBallRigidBody;
    private float rotationY = 0;
    public float rotationStep = 10;
    float forceToApply = 0;
    float speed = 0;
    public float sleepUnderSpeed = 0.1f;
    Vector3 lastPosition = Vector3.zero;
    public GameObject stick;
    public bool setPositionMode = false;
    public float moveSpeedWhileSettingBall = 1;
    public Vector3 initialPosition = new Vector3(0, 5.596084f, -60);

    // Use this for initialization
    void Start ()
    {
        whiteBallRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        speed = (transform.position - lastPosition).magnitude;
        //Debug.Log("white ball speed = " + speed);
        if (speed != 0 && speed < sleepUnderSpeed)
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
            if (stick.activeSelf)
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

                // left arrow rotates the ball on counter clockwise direction; right arrow - clockwise
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
                    forceToApply = 0;
                }
            }// end if stick.activeSelf

        } // end if not setPositionMode
        else
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
    }// end Update

}
