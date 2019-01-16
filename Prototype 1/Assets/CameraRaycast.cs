using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public Material fadeMaterial;
    public Material originalMaterial;

    public RaycastHit hit;
    public GameObject objectInWay;
    public GameObject originalObject;

    public float timeNeeded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        timeNeeded += Time.deltaTime;

        if (timeNeeded >= 5 && originalObject)
        {
            originalObject.GetComponent<Renderer>().material = originalMaterial;
            originalObject.GetComponent<Collider>().enabled = true;
            timeNeeded = 0;
            originalObject = objectInWay;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.tag == "Wall")
        {
            objectInWay = hit.transform.gameObject;

            if (originalObject == null)
            {
                originalObject = objectInWay;
            }

            if (originalObject != objectInWay)
            {
                originalObject.GetComponent<Renderer>().material = originalMaterial;
                originalObject.GetComponent<Collider>().enabled = true;
                timeNeeded = 0;
                originalObject = objectInWay;
            }

            if (objectInWay)
            {
                HideObject(objectInWay);
            }
        }
        //if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.transform.gameObject.tag != "Wall"
        //    && originalObject)
        //{
        //    originalObject.GetComponent<Renderer>().material = originalMaterial;
        //    originalObject.GetComponent<Collider>().enabled = true;
        //}
    }

    void HideObject(GameObject obj)
    {
        originalMaterial = obj.GetComponent<Renderer>().material;
        obj.GetComponent<Renderer>().material = fadeMaterial;
        obj.GetComponent<Collider>().enabled = false;
    }
}
