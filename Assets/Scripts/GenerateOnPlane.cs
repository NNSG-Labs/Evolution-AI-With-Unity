using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOnPlane : MonoBehaviour
{
    public GameObject selectedPlane;
    public GameObject[] objectsToGenerate;
    public int amount = 20;
    // Start is called before the first frame update
    void Start()
    {
        Transform rectangle = selectedPlane.transform;
        
        for (int i = 0; i < objectsToGenerate.Length; ++i)
        {
            for(int j = 0; j < amount; ++ j)
                Instantiate(objectsToGenerate[i], new Vector3(Random.Range(-15,15),1, Random.Range(-15,15)), Quaternion.Euler(270,0,0) );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
