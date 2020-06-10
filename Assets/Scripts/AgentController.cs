using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class AgentController : Agent
{
    public float health = 100;
    public float energy = 100;
    bool is_poisoned = false;
    // Start is called before the first frame update
    
    float WSdir=0.0f;
    float ADdir=0.0f;

    RenderTextureSensorComponent rtc;
    void Start()
    {
        rtc = GetComponent<RenderTextureSensorComponent>();
    }
    
    public override void OnEpisodeBegin()
    {
    }
    
    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(health);
        sensor.AddObservation(energy);

        // Agent velocity
        sensor.AddObservation(rtc);
    }
    
    public override void OnActionReceived(float[] vectorAction)
    {
        if(vectorAction.Length < 2) return;
        print("action received! " + vectorAction[0].ToString() + " " + vectorAction[1].ToString());
        WSdir=vectorAction[0];
        ADdir=vectorAction[1];
          
        //SetReward(1.0f);
        //EndEpisode();
        MyUpdate();
    }

    // Update is called once per frame
    void MyUpdate()
    {
        Controller();
        UpdateStatus();
        OnEat();
    }
    void Controller()
    {
        transform.Translate(0f, 0f, WSdir * 0.04f);
        energy -= Mathf.Abs(WSdir)*0.009f;
        transform.Rotate(0f, ADdir * 1.0f, 0f);
        energy -= Mathf.Abs(ADdir)*0.009f;
    }
    void UpdateStatus()
    {
        // common rules
        if (health < 100) health += -0.01f;
        energy -= 0.0002f;

        if (health < 0)
        {
            Debug.Log("Die!");
            //Destroy(this);
            EndEpisode();
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
            if (/*Input.GetKey(KeyCode.E) &&*/ ( hit_object.name == "mushroom" || hit_object.name == "apple"))
            {
                SetReward(1.0f);
                if (hit_object.name == "mushroom") is_poisoned = true;
                energy += 5f;
                Destroy(hit_object);
            }
        }

    }
}
