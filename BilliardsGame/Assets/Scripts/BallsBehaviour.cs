﻿using UnityEngine;
using System.Collections;

public class BallsBehaviour : MonoBehaviour 
{
	public float sleepUnderSpeed = 0.2f;    // at what ballSpeed the ball shoud stop
	public float ballSpeed = 0;                        // the ballSpeed of the ball
    private Vector3 lastPosition = Vector3.zero;    // helps for determining the ballSpeed of the ball
	public bool ballIsInHole = false;		// if set to true (i.e. when the ball is in the position of a hole detecor) then dont set ballSpeed to 0 at speeds under sleepUnderSpeed values. The value is set to true in the HoleDetectors script
	
	private Rigidbody ballRigidBody;
    private float dragStep = 0.05f;
	
	public float maxBallSpeed = 14.21f; // the speed is taken from the max speed which the white ball acquire when applying of maxForce on it. the field is needed for acheiving of nicer sound effect when two balls coliding
	public WhiteBallBehaviour whiteBallScript;

    // Use this for initialization
    void Start()
    {
		ballRigidBody = gameObject.GetComponent<Rigidbody>();
        ballIsInHole = false;
    }
	
	void FixedUpdate ()
    {
        ballSpeed = (transform.position - lastPosition).magnitude;
        //Debug.Log(gameObject.name.ToString() + " ballSpeed = " + ballSpeed);
        if (ballSpeed > 0f  && !ballIsInHole)
        {
            ballRigidBody.drag += dragStep;
            ballRigidBody.angularDrag += dragStep;
        }
        lastPosition = transform.position;

        if (ballSpeed == 0f || ballIsInHole)
        {
            ballRigidBody.drag = 0.2f;
            ballRigidBody.angularDrag = 0.2f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    // TODO: Merge Balls And White Ball scripts as much as possible
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "holeDetector")
        {
            ballIsInHole = true;
            /*if (ballSpeed < 0.5f)
            {
                ballRigidBody.drag += dragStep * 50;
                ballRigidBody.angularDrag += dragStep * 50;
            }*/
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "holeDetector")
        {
            ballIsInHole = false;
            ballRigidBody.drag = 0.2f;
            ballRigidBody.angularDrag = 0.2f;
        }
    }
	
	void OnCollisionEnter (Collision collision) 
    {
        if (collision.gameObject.tag == "ball")
        {
			GetComponent<AudioSource>().volume = ballSpeed / maxBallSpeed;
            GetComponent<AudioSource>().Play();
        }
		if(collision.gameObject.tag == "whiteBall")
		{
			// white ball does not "produce sound when colliding with other balls so the volume is calculated upon the both speeds
			float volume = (ballSpeed + whiteBallScript.ballSpeed) / maxBallSpeed;
			if(volume > 1)
			{
				volume = 1;
			}
			GetComponent<AudioSource>().volume = volume; 
			GetComponent<AudioSource>().Play();
		}
    }
}
