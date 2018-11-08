using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator playerAnimator;

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    Vector3 whatever;
    float rotSpeed;
    float speed;
    bool moving;
	// Use this for initialization
	void Start () {

        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        rotSpeed = 5;
        speed = 10;
        moving = false;
        whatever = new Vector3(0,0.5f ,0);
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButton(1))
        {
            SetTargetPosition();
        }
        if (moving)
        {
            Move();
            Debug.Log(targetPosition);
            Debug.Log(transform.position);
        }
  	}

    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition =  hit.point;
            targetPosition.y = this.transform.position.y;
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y , targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            moving = true;
            playerAnimator.SetBool("moving", true);
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            moving = false;
            playerAnimator.SetBool("moving", false);
        }
    }
}


