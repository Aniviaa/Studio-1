using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {


    public Transform player;
    public float maxAngle;
    public float maxRadius;
    public float seenDistance;

    private bool isInLineOfSight = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        //rotate horizontally
        Vector3 lineOfSight1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 lineOfSight2= Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, lineOfSight1);
        Gizmos.DrawRay(transform.position, lineOfSight2);

        

        if (!isInLineOfSight)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }

    public  bool InLineOfSight(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {

        float distance = Vector3.Distance(target.position, checkingObject.position);
        //Debug.Log(distance);
        Vector3 directionBetween = (target.position - checkingObject.position).normalized;

        float angle = Vector3.Angle(checkingObject.forward, directionBetween);
        
        if (angle <= maxAngle && distance <= seenDistance)
        {
            print(target.position - checkingObject.position);
            Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxRadius))
            {
                if (hit.transform == target)
                    return true;
            }
        }
        
        return false;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        isInLineOfSight = InLineOfSight(transform, player, maxAngle, maxRadius);
	}
}
