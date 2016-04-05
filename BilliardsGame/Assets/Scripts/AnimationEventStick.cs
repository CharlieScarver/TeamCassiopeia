using UnityEngine;
using System.Collections;

public class AnimationEventStick : MonoBehaviour
{

    private WhiteBallBehaviour whiteBallScript;


    // Use this for initialization
    void Start ()
    {
        whiteBallScript = GameObject.Find("White Ball").GetComponent<WhiteBallBehaviour>();
    }

    public void AnimationEvent ()
    {
        whiteBallScript.isStickAnimationEnded = true;
    }
}
