using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public int projectilePool = 50;
    public GameObject projectile;
    

    public List<GameObject> arrows;
    
    // Start is called before the first frame update
    void Start()
    {
        arrows = new List<GameObject>();
        for (int i = 0; i < projectilePool; i++)
        {
            GameObject temp = Instantiate(projectile, transform.position, Quaternion.identity);
            temp.SetActive(false);
            arrows.Add(temp);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(GameObject enemy)
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                arrows[i].SetActive(true);
                arrows[i].transform.position = enemy.transform.position;
                arrows[i].transform.rotation = enemy.transform.rotation;
                break;
            }
        }
    }
}
