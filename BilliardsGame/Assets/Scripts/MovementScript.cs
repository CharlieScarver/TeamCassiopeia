using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{

    public int force = 15;
    public Rigidbody body;
    private float moveHorizontal;
    private float moveVertical;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        moveHorizontal = Input.GetAxis("Horizontal");
	    moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * force, 0.0f, moveVertical * force);
        //body.velocity = movement * force;
        body.AddForce(movement);

    }
}
