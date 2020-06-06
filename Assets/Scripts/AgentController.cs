using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    float health_point = 100;
    float hungry_point = 0;
    float poison = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, -.01f, 0f);
            //Debug.Log("Hello there");)
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, .01f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, -1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, 1f);
        }
    }
}
