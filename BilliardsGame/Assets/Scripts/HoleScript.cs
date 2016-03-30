using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

    void OnTriggerExit (Collider collider)
    {
        collider.gameObject.SetActive(false);
    }
}
