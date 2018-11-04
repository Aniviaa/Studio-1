using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSafe : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("This Shit is doing it");
    }
}
