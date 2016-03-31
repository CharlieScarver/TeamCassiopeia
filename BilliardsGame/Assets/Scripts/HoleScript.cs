using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour
{

    WhiteBallBehaviour whiteBallScript;
    public GameObject whiteBall;

    void Start ()
    {
        whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();
    }

    void OnTriggerExit (Collider collider)
    {
        if (collider.gameObject.tag == "ball")
        {
            collider.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "whiteBall")
        {
            whiteBall.transform.position = whiteBallScript.initialPosition;
            whiteBall.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            whiteBallScript.setPositionMode = true;
        }
    }
}
