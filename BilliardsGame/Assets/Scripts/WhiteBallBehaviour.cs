using UnityEngine;
using System.Collections;

public class WhiteBallBehaviour : MonoBehaviour
{

    public int maxForce = 15;
	public int forceStepIncrement = 1;
    public Rigidbody whiteBallRigidBody;
    private float rotationY = 0;
    public float rotationStep = 10;
    public float forceToApply = 0;
    //public GameObject stick;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rotationStep = 1;
        }
        else
        {
            rotationStep = 10;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
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
        
        if (Input.GetKey(KeyCode.Space) && forceToApply < maxForce)
        {
            forceToApply += forceStepIncrement;
        }

        if (!Input.GetKey(KeyCode.Space) && forceToApply > 0)
        {
            //Vector3 movement = new Vector3(0.0f, 0.0f, forceToApply);
            //whiteBallRigidBody.velocity = movement * force;
            //Debug.Log("Applied force : " + forceToApply);
            whiteBallRigidBody.AddRelativeForce(0f, 0f, forceToApply, ForceMode.Impulse);
            forceToApply = 0;
        }

        
    }
}
