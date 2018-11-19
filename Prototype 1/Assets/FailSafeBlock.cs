using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSafeBlock : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
