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
            transform.Translate(0f, 0f, 0.04f);
            energy -= 0.009f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -0.04f);
            energy -= 0.009f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -1f, 0f);
            energy -= 0.009f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 1f, 0f);
            energy -= 0.009f;
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
            Destroy(this);
        }
        if (is_poisoned) health -= 0.09f;
        if (energy < 10)
        {
            health -= 0.01f;
        }
    }
    void OnEat()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(transform.position, transform.forward ,Color.red);
        if (Physics.Raycast(ray, out hit, 0.5f)){
            GameObject hit_object = hit.collider.gameObject;
            Debug.Log("The agent found " +hit_object.name);
            if (Input.GetKey(KeyCode.E) && ( hit_object.name == "mushroom" || hit_object.name == "apple"))
            {
                if (hit_object.name == "mushroom") is_poisoned = true;
                energy += 5f;
                Destroy(hit_object);
            }
        }

    }
}
