using UnityEngine;
using System.Collections;

public class StickBehaviour : MonoBehaviour
{

    
    public GameObject stick;
	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        int ballsMovingCount = 0;
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("ball"))
        {
            if (!ball.GetComponent<Rigidbody>().IsSleeping())
            {
                ballsMovingCount++;
                Debug.Log("Object moving : " + ball.name);
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
