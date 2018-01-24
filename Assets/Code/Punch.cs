using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum punchState
{
    forward,backwards, ready
}

public class Punch : MonoBehaviour
{
    public float speed;
    public float distance;
    public BallController player;
    public KeyCode punchKey;
    public punchState stateOfPunch;
    public BallController target;

    Vector3 punchStart;

    private void Start()
    {
        stateOfPunch = punchState.ready;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(punchKey))
        {
            if(stateOfPunch == punchState.ready)
            {
                punchStart = transform.localPosition;
                stateOfPunch = punchState.forward;
            }

        }


        if(stateOfPunch == punchState.forward)
        {
            doPunch();
        }
        if (stateOfPunch == punchState.backwards)
        {
            resetPunch();
        }
	}



    public void doPunch()
    {

        Vector3 destination = transform.position + (transform.right * speed);
        Vector3 dir = (destination - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        
        if (Vector3.Distance(player.transform.position, transform.position) >= distance)
        {
            stateOfPunch = punchState.backwards;
        }
    }
    public void resetPunch()
    {
        transform.localPosition = punchStart;
        stateOfPunch = punchState.ready;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 destination = transform.position + (transform.right * speed);
        Vector3 dir = (destination - transform.position).normalized;
        if (other.tag == "Player")
        {
            target.rb.AddForce(dir * 3, ForceMode.Impulse);
        }
    }
}
