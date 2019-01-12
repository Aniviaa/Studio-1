using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabToolScript : MonoBehaviour
{

    public bool created;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoCreateSimplePrefab();
    }

    public void DoCreateSimplePrefab()
    {
        if (!created)
        {
            Transform[] transforms = Selection.transforms;
            foreach (Transform t in transforms)
            {
                Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/Temporary/EmptyPrefabTest.prefab");
            }
            created = true;
        }

    }
}
