using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriage : MonoBehaviour
{
    public Vector3 startingLocation;
    public Vector3 destination;
    public float speed;
    // Update is called once per frame

    void Update ()
    {
		Vector3 dir = (destination - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}
