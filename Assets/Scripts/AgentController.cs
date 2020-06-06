using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public float health = 100;
    public float energy = 100;
    bool is_poisoned = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
        UpdateStatus();
        OnEat();
    }
    void Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, -.01f, 0f);
            energy -= 0.003f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, .01f, 0f);
            energy -= 0.003f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, -1f);
            energy -= 0.003f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, 1f);
            energy -= 0.003f;
        }
    }
    void UpdateStatus()
    {
        // common rules
        if (health < 100) health += -0.01f;
        energy -= 0.0002f;

        if (health < 0)
        {
            Debug.Log("Die!");
        }
        if (is_poisoned) health -= 0.3f;
        if (energy < 10)
        {
            health -= 0.01f;
        }
    }
    void OnEat()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
            Debug.DrawLine(ray.origin, hit.point);
    }
}
